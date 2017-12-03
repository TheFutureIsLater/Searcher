using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using FastColoredTextBoxNS;

namespace Searcher
{

    public partial class TextViewer : Form
    {
        private string SearchString;
        private bool isRegex;
        private Settings _parentProperties;

        //private List<HilightSearch> Hilighters = new List<HilightSearch>();
        private DataTable Hilighters = new DataTable();

        public TextViewer(Settings Properties)
        {
            Hilighters.Columns.Add(HilightSearch.Attributes.Search.ToString(), typeof(string));
            Hilighters.Columns.Add(HilightSearch.Attributes.isRegex.ToString(), typeof(bool));
            Hilighters.Columns.Add(HilightSearch.Attributes.foreColor.ToString(), typeof(Color));
            Hilighters.Columns.Add(HilightSearch.Attributes.backColor.ToString(), typeof(Color));
            Hilighters.Columns.Add(HilightSearch.Attributes.Sample.ToString(), typeof(string));

            _parentProperties = Properties;
            InitializeComponent();

            dgvHilights.DataSource = Hilighters;
        }

        public void ShowContexts(string Title, List<FileContext> MatchFiles, string SearchString, bool isRegex)
        {
            Text = Title;
            this.SearchString = SearchString;
            this.isRegex = isRegex;

            //ftbContent.setContexts(MatchFiles);
            foreach (FileContext fc in MatchFiles)
            {
                FileInfo fi = new FileInfo(fc.FilePath);
                TabPage tp = new TabPage(fi.Name);
                FastColoredTextBox fctb = new FastColoredTextBox() { 
                    Dock = DockStyle.Fill,
                    ShowLineNumbers = false
                };

                StringBuilder sb = new StringBuilder();
                foreach (ContextGroup chunk in fc.Chunks)
                {
                    sb.AppendLine("Match context starting on line: " + chunk.Lines[0].LineNumber);
                    sb.AppendLine("{");
                    foreach (ContextLine Line in chunk.Lines)
                    {
                        sb.AppendLine(Line.Line);
                    }
                    sb.AppendLine("}");
                    sb.AppendLine("");
                }

                fctb.Text = sb.ToString();

                tp.Controls.Add(fctb);
                tabFiles.TabPages.Add(tp);
            }

            this.Show();
            AddHilighter(SearchString, isRegex, Color.Red, SystemColors.Control);
            dgvHilights.ClearSelection();
            txtNewHilight.Focus();
        }

        public void ShowFiles(string Title, List<string> FilePaths, string SearchString, bool isRegex)
        {
            Text = Title;
            this.SearchString = SearchString;
            this.isRegex = isRegex;

            foreach (string FilePath in FilePaths)
            {
                FileInfo fi = new FileInfo(FilePath);
                if (!fi.Exists) { continue; }

                TabPage tp = new TabPage(fi.Name);
                FastColoredTextBox fctb = new FastColoredTextBox()
                {
                    Dock = DockStyle.Fill,
                    ShowLineNumbers = true,
                    Text = File.ReadAllText(FilePath)
                };

                tp.Controls.Add(fctb);
                tabFiles.TabPages.Add(tp);
            }

            this.Show();
            AddHilighter(SearchString, isRegex, Color.Red, SystemColors.Control);
            dgvHilights.ClearSelection();
            txtNewHilight.Focus();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _parentProperties.Show();
        }

        private void lblSample_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                colorDialog.Color = lblSample.ForeColor;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                colorDialog.Color = lblSample.BackColor;
            }

            DialogResult DR = colorDialog.ShowDialog();
            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    lblSample.ForeColor = colorDialog.Color;
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    lblSample.BackColor = colorDialog.Color;
                }
            }
        }

        private void btnAddHilight_Click(object sender, EventArgs e)
        {
            AddHilighter(txtNewHilight.Text, chkIsRegex.Checked, lblSample.ForeColor, lblSample.BackColor);
        }

        public void AddHilighter(string SearchString, bool isRegex, Color ForeColor, Color BackColor)
        {
            if (string.IsNullOrEmpty(SearchString)) { return; }
            DataRow newRow = Hilighters.NewRow();

            newRow[HilightSearch.Attributes.Search.ToString()] = SearchString;
            newRow[HilightSearch.Attributes.isRegex.ToString()] = isRegex;
            newRow[HilightSearch.Attributes.foreColor.ToString()] = ForeColor;
            newRow[HilightSearch.Attributes.backColor.ToString()] = BackColor;
            newRow[HilightSearch.Attributes.Sample.ToString()] = SearchString;

            Hilighters.Rows.Add(newRow);

            DataGridViewRow lastRow = dgvHilights.Rows[dgvHilights.Rows.GetLastRow(DataGridViewElementStates.Visible)];

            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.ForeColor = ForeColor;
            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.BackColor = BackColor;

            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.SelectionForeColor = ForeColor;
            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.SelectionBackColor = BackColor;

            HilightTab();
        }

        private void HilightTab()
        {
            if (tabFiles.TabPages.Count == 0) { return; }

            FastColoredTextBox fctb = (FastColoredTextBox)tabFiles.SelectedTab.Controls[0];
            fctb.ClearStyle(StyleIndex.All);
            
            foreach (DataRow row in Hilighters.Rows)
            {
                string Search = row[HilightSearch.Attributes.Search.ToString()].ToString();
                bool isRegex = (bool)row[HilightSearch.Attributes.isRegex.ToString()];
                Color foreColor = (Color)row[HilightSearch.Attributes.foreColor.ToString()];
                Color backColor = (Color)row[HilightSearch.Attributes.backColor.ToString()];

                TextStyle a = new TextStyle(new SolidBrush(foreColor), new SolidBrush(backColor), FontStyle.Regular);
                fctb.Range.SetStyle(a, Search);
                fctb.Range.SetFoldingMarkers("{", "}");
            }
        }

        private void txtNewHilight_TextChanged(object sender, EventArgs e)
        {
            lblSample.Text = txtNewHilight.Text;
        }

        private void tabFiles_TabIndexChanged(object sender, EventArgs e)
        {
            HilightTab();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void RemoveSelected()
        {
            foreach (DataGridViewRow row in dgvHilights.SelectedRows)
            {
                Hilighters.Rows.RemoveAt(row.Index);
            }

            dgvHilights.ClearSelection();
            HilightTab();
        }
    }
}
