using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace Searcher
{

    public partial class TextViewer : Form
    {
        private readonly SettingsForm _parentProperties;

        #region build content
        public TextViewer(SettingsForm properties)
        {
            _parentProperties = properties;
            InitializeComponent();

            dgvHilights.DataSource = Hilighters;
            dgvFind.DataSource = FindHits;
        }

        public void ShowContexts(string title, List<FileContext> matchFiles, string searchString, bool isRegex)
        {
            Text = title;

            //ftbContent.setContexts(MatchFiles);
            foreach (var fc in matchFiles)
            {
                var fi = new FileInfo(fc.FilePath);
                var tp = new TabPage(fi.Name);
                var fctb = new FastColoredTextBox { 
                    Dock = DockStyle.Fill,
                    ShowLineNumbers = false
                };

                var sb = new StringBuilder();
                foreach (var chunk in fc.Chunks)
                {
                    sb.AppendLine("Match context starting on line: " + chunk.Lines[0].LineNumber);
                    sb.AppendLine("{");
                    foreach (var line in chunk.Lines)
                    {
                        sb.AppendLine(line.Line);
                    }
                    sb.AppendLine("}");
                    sb.AppendLine("");
                }

                fctb.Text = sb.ToString();

                tp.Controls.Add(fctb);
                tabFiles.TabPages.Add(tp);
            }

            Show();
            AddHilighter(searchString, Color.Red, SystemColors.Control);
            dgvHilights.ClearSelection();
            txtNewHilight.Focus();
        }

        public void ShowFiles(string title, List<string> filePaths, string searchString)
        {
            Text = title;

            foreach (var filePath in filePaths)
            {
                var fi = new FileInfo(filePath);
                if (!fi.Exists) continue;

                var tp = new TabPage(fi.Name);
                var fctb = new FastColoredTextBox
                {
                    Dock = DockStyle.Fill,
                    ShowLineNumbers = true,
                    Text = File.ReadAllText(filePath)
                };

                tp.Controls.Add(fctb);
                tabFiles.TabPages.Add(tp);
            }

            Show();
            AddHilighter(searchString, Color.Red, SystemColors.Control);
            dgvHilights.ClearSelection();
            txtNewHilight.Focus();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _parentProperties.Show();
        }
        #endregion

        #region hilights
        private void LblSample_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    colorDialog.Color = lblSample.ForeColor;
                    break;
                case MouseButtons.Right:
                    colorDialog.Color = lblSample.BackColor;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    return;
            }

            var dr = colorDialog.ShowDialog();
	        if (dr != DialogResult.OK) return;

	        switch (e.Button)
	        {
		        case MouseButtons.Left:
			        lblSample.ForeColor = colorDialog.Color;
			        break;
		        case MouseButtons.Right:
			        lblSample.BackColor = colorDialog.Color;
			        break;
		        case MouseButtons.None:
			        break;
		        case MouseButtons.Middle:
			        break;
		        case MouseButtons.XButton1:
			        break;
		        case MouseButtons.XButton2:
			        break;
		        default:
			        throw new ArgumentOutOfRangeException();
	        }
        }

        private void BtnAddHilight_Click(object sender, EventArgs e)
        {
            AddHilighter(txtNewHilight.Text, lblSample.ForeColor, lblSample.BackColor);
        }

        public void AddHilighter(string searchString, Color foreColor, Color backColor)
        {
            if(Hilighters.Rows.Count == 5) { MessageBox.Show(@"Can only have 5 hilighers active at a time."); return; }
            if (string.IsNullOrEmpty(searchString)) { return; }
            var newRow = Hilighters.NewRow();

            newRow[HilightSearch.Attributes.Search.ToString()] = searchString;
            newRow[HilightSearch.Attributes.ForeColor.ToString()] = foreColor;
            newRow[HilightSearch.Attributes.BackColor.ToString()] = backColor;
            newRow[HilightSearch.Attributes.Sample.ToString()] = searchString;

            Hilighters.Rows.Add(newRow);

            var lastRow = dgvHilights.Rows[dgvHilights.Rows.GetLastRow(DataGridViewElementStates.Visible)];

            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.ForeColor = foreColor;
            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.BackColor = backColor;

            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.SelectionForeColor = foreColor;
            lastRow.Cells[HilightSearch.Attributes.Sample.ToString()].Style.SelectionBackColor = backColor;

            lblCounter.Text = Hilighters.Rows.Count + @"/5";
            txtNewHilight.Text = null;

            HilightTab();
        }

        private void HilightTab()
        {
            if (tabFiles.TabPages.Count == 0) { return; }

            var fctb = (FastColoredTextBox)tabFiles.SelectedTab.Controls[0];
            fctb.ClearStyle(StyleIndex.All);
            
            foreach (DataRow row in Hilighters.Rows)
            {
                var search = row[HilightSearch.Attributes.Search.ToString()].ToString();
                var foreColor = (Color)row[HilightSearch.Attributes.ForeColor.ToString()];
                var backColor = (Color)row[HilightSearch.Attributes.BackColor.ToString()];

                var a = new TextStyle(new SolidBrush(foreColor), new SolidBrush(backColor), FontStyle.Regular);
                fctb.Range.SetStyle(a, search, RegexOptions.IgnoreCase);
                fctb.Range.SetFoldingMarkers("{", "}");
            }
        }

        private void TxtNewHilight_TextChanged(object sender, EventArgs e)
        {
            lblSample.Text = txtNewHilight.Text;
        }

        private void TabFiles_TabIndexChanged(object sender, EventArgs e)
        {
            HilightTab();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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
            lblCounter.Text = Hilighters.Rows.Count + @"/5";

            HilightTab();
        }
        #endregion

        #region find/replace
        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindHits.Rows.Clear();

            FindInTab(tabFiles.SelectedIndex);
        }

        private void BtnFindAllTabs_Click(object sender, EventArgs e)
        {
            FindHits.Rows.Clear();

            for (var i = 0; i < tabFiles.TabCount; i++)
            {
                FindInTab(i);
            }
        }

        private void DgvFind_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) { return; }

            //find tab
            var file = dgvFind.Rows[e.RowIndex].Cells["File"].Value.ToString();
            var tabIndex = int.Parse(file.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0]);

			//find location in text.
            var line = int.Parse(dgvFind.Rows[e.RowIndex].Cells["LineNum"].Value.ToString());
            var col = int.Parse(dgvFind.Rows[e.RowIndex].Cells["Char"].Value.ToString());
            GoTo(tabIndex, line, col);
        }

        private void FindInTab(int tabIndex)
        {
            var fctb = (FastColoredTextBox)tabFiles.TabPages[tabIndex].Controls[0];

            var ranges = fctb.GetRanges(txtFind.Text);
            foreach(var r in ranges)
            {
                var dataRow = FindHits.NewRow();

                dataRow[colFile] = tabIndex + ":" + tabFiles.TabPages[tabIndex].Text;
                dataRow[colLineNum] = r.Start.iLine + 1;
                dataRow[colContent] = fctb.Lines[r.FromLine];
                dataRow[colChar] = r.Start.iChar;

                FindHits.Rows.Add(dataRow);
            }
        }

        private void GoTo(int tabIndex, int line, int Char)
        {
            line -= 1;
            if(tabIndex < 0 || line < 0 || Char < 0) { return; }

            tabFiles.SelectedIndex = tabIndex;
            var fctb = (FastColoredTextBox)tabFiles.SelectedTab.Controls[0];
            fctb.Focus();
            fctb.Navigate(line);

            var index = GetIndex(fctb.Lines, line, Char);
            var context = fctb.Lines[line].Substring(Char);
            var regex = new Regex(txtFind.Text);
            var matchLength = regex.Matches(context)[0].Length;

            fctb.SelectionStart = index;
            fctb.SelectionLength = matchLength;
        }

        private static int GetIndex(IList<string> lines, int line, int Char)
        {
            var output = Char;
            var lineCount = 0;
            while(lineCount < line)
            {
                output += lines[lineCount++].Length + 2;
            }

            return output;
        }
        #endregion

        private void TabFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is TabControl tc)) return;
            if (e.Button != MouseButtons.Middle) return;

            for (var i = 0; i < tc.TabCount; i++)
            {
                var rect = tc.GetTabRect(i);
                if (!rect.Contains(e.Location)) continue;
                CloseTab(i);
                FixSearchResults(i);
                break;
            }
        }

        private void CloseTab(int index)
        {
            if (_parentProperties.ConfirmCloseTab
                || MessageBox.Show(@"Would you like to Close this Tab?", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabFiles.TabPages.RemoveAt(index);
            }
        }

        private void FixSearchResults(int index)
        {
            //This whole thing is bothersome and should be refactored to avoid this kind of nonsense.
            for (var i = 0; i < FindHits.Rows.Count; i++)
            {
                var name = FindHits.Rows[i]["File"].ToString();
                var parts = name.Split(":".ToCharArray());
                var temp = int.Parse(parts[0]);

                if (index < temp)
                {
                    parts[0] = (temp - 1).ToString();
                    FindHits.Rows[i]["File"] = string.Join(":", parts);
                }
                else if (index == temp)
                {
                    FindHits.Rows.RemoveAt(i--);
                }
                else if (index > temp)
                {
                    //this is fine.
                }


                Console.Write(name);

            }
        }

        private void dgvHilights_DoubleClick(object sender, EventArgs e)
        {
            var rows = (sender as DataGridView)?.SelectedRows;
            if (rows?.Count == 1)
            {
                txtFind.Text = rows[0].Cells[0].Value.ToString();
                FindHits.Rows.Clear();

                for (var i = 0; i < tabFiles.TabCount; i++)
                {
                    FindInTab(i);
                }
            }
        }
    }
}
