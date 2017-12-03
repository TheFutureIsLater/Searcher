using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


//TODO: add hit counter on fancy search hilight grid
//TODO: add 'Find Next'/'Find Prev' buttons on search hilight grid


//TODO: threadify context search
//TODO: threadify grid filter



namespace Searcher
{
    public partial class MainWindow : Form
    {
        //Options area:
        List<Exception> Errors = new List<Exception>();
        DataTable DataSource = new DataTable();
        Settings properties = new Settings();

        bool Stop = false;

        public MainWindow()
        {
            InitializeComponent();

            DataSource.Columns.Add("Name");
            DataSource.Columns.Add("Path");
            DataSource.Columns.Add("Created");
            DataSource.Columns.Add("Updated");
            DataSource.Columns.Add("Accessed");
            DataSource.Columns.Add("FileSize", typeof(int));
            DataSource.Columns.Add("First Match");
            grdResults.DataSource = DataSource;

            folderBrowser.SelectedPath = @"C:\";

            chkContents.Checked = true;
            btnSearch.PerformClick();

        }

        #region Events
        private void btnBuildMultiSearch_Click(object sender, EventArgs e)
        {
            StringCollectionEditor sce = new StringCollectionEditor();
            if (sce.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSearchString.Text = "(" + string.Join(")|(", sce.Output) + ")";
                chkSearchRegex.Checked = true;
            }
            sce.Dispose();
        }
        private void btnContext_Click(object sender, EventArgs e)
        {
            ViewSelectedContext();
        }
        private void btnCopyFiles_Click(object sender, EventArgs e)
        {
            SelectedToClipboard();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            StartFilter();
        }
        private void btnFindInFolder_Click(object sender, EventArgs e)
        {
            FindFilesInFolder();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<int> Selected = new List<int>();
            foreach (DataGridViewRow Row in grdResults.SelectedRows)
            {
                Selected.Add(Row.Index);
            }
            grdResults.CurrentCell = null;
            foreach (int Item in Selected)
            {
                grdResults.Rows[Item].Visible = false;
            }
            grdResults.ClearSelection();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in grdResults.Rows)
            {
                Row.Visible = true;
            }
        }
        private void btnRootFolder_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRootFolder.Text) ? @"C:\" : txtRootFolder.Text;
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRootFolder.Text = folderBrowser.SelectedPath;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblStart.Text = "Start: " + DateTime.Now.ToString("HH:mm:ss");
            lblStopped.Text = string.Empty;
            StartSearch();
        }
        private void btnSkipFolder_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRootFolder.Text) ? @"C:\" : txtRootFolder.Text;
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string temp = folderBrowser.SelectedPath;
                temp = temp.Substring(temp.LastIndexOf("\\") + 1);
                txtSkipFolder.Text += temp + " ";
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewSelectedItems();
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            (sender as CheckBox).Text = (sender as CheckBox).Checked ? "Exclude" : "Include";
            switch ((sender as CheckBox).Name)
            {
                case "chkFilter":
                    SearchGrid();
                    break;
                default:
                    break;
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            properties.Show();
        }
        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartSearch();
            }
        }
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartFilter();
            }
        }
        #endregion
        #region private
        private void StartSearch()
        {
            Errors = new List<Exception>();
            Stop = false;

            SearchParameters SP = new SearchParameters()
            {
                CheckContents = chkContents.Checked,
                isRecursive = chkRecursive.Checked,
                isRegex = chkSearchRegex.Checked,
                MatchCase = chkMatchCase.Checked,
                RootFolder = txtRootFolder.Text,
                SearchExtension = txtSearchExtension.Text,
                SearchString = txtSearchString.Text,
                SkipExtension = txtSkipExtention.Text,
                SkipFolder = txtSkipFolder.Text + (chkRecycle.Checked ? " RECYCLE, .svn" : string.Empty)
            };

            if (!string.IsNullOrEmpty(txtRootFolder.Text) && !string.IsNullOrEmpty(txtSearchString.Text))
            {
                txtFilter.Text = null;
                DataSource.Rows.Clear();
                grdResults.Visible = false;
                lblCount.Text = "Found Files:0";
                grdResults.ClearSelection();

                foreach (Control C in this.Controls)
                {
                    if (C is Button || C is CheckBox || C is TextBox)
                    {
                        C.Enabled = false;
                    }
                }

                btnStop.Enabled = true;
                btnStop.BackColor = Color.Red;
                btnStop.Focus();

                System.Threading.ThreadPool.QueueUserWorkItem(ThreadedSearch, SP);
                foreach (DataGridViewRow Row in grdResults.Rows) { Row.Selected = true; }
            }
        }
        private void ThreadedSearch(object o)
        {
            if(!(o is SearchParameters)){ return; }
            SearchParameters SP = o as SearchParameters;
            SearchFolder(SP, SP.RootFolder);

            MultiThread.MultiThread.ControlAction(btnSearch, "Enabled=true", null, null);
            if (Stop) { MultiThread.MultiThread.UpdateToolStripStatus(lblStatus, "Stopped"); }
            else { MultiThread.MultiThread.UpdateToolStripStatus(lblStatus, "Done"); }
            MultiThread.MultiThread.UpdateToolStripStatus(lblStopped, "Stop:" + DateTime.Now.ToString("HH:mm:ss"));


            foreach (Control C in this.Controls)
            {
                if (C is Button || C is CheckBox || C is TextBox)
                {
                    MultiThread.MultiThread.ControlAction(C, "Enabled=true", null, null);
                }
            }
            MultiThread.MultiThread.ControlAction(btnStop, "BackColor=", null, new object[] { SystemColors.Control });
            MultiThread.MultiThread.ControlAction(btnStop, "Enabled=false", null, null);

            if (Stop)
            {
                if (grdResults.Rows.Count > 0)
                {
                    MultiThread.MultiThread.ControlAction(txtFilter, "Focus()", null, null);
                }
                else
                {
                    MultiThread.MultiThread.ControlAction(txtSearchString, "Focus()", null, null);
                }
            }
            MultiThread.MultiThread.ControlAction(grdResults, "Visible=true", null, null);
        }
        private void SearchFolder(SearchParameters SP, string SearchPath)
        {
            if (Stop) { return; }
            bool MatchCase = chkMatchCase.Checked;
            if (Directory.Exists(SearchPath))
            {
                MultiThread.MultiThread.UpdateToolStripStatus(lblStatus, SearchPath);

                foreach (string Skip in SP.SkipFolders())
                {
                    if (SearchPath.ToUpper().Contains(Skip.ToUpper()) || Skip.ToUpper().Contains(SearchPath.ToUpper()))
                    {
                        return;
                    }
                }

                string[] Files = new string[0];
                try
                {
                    Files = Directory.GetFiles(SearchPath);
                }
                catch (Exception x)
                {
                    if (!x.Message.StartsWith("Access")) { Errors.Add(x); }
                    return;
                }
                foreach (string File in Files)
                {
                    SearchFile(SP, File);
                }


                if (chkRecursive.Checked)
                {
                    string[] Dirs = Directory.GetDirectories(SearchPath);
                    foreach (string Dir in Dirs)
                    {
                        SearchFolder(SP, Dir);
                    }
                }
            }
        }
        private void SearchFile(SearchParameters SP, string FilePath)
        {
            if (Stop) { return; }
            FileInfo FI = new FileInfo(FilePath);
            bool Match = false;
            string MatchLine = string.Empty;

            string FileName = SP.MatchCase ? FilePath : FilePath.ToUpper();

            //if skip extensions ever contains FI.Extension ski; 
            //Or if search extensions has values and doesn't match file, then skip
            string[] skip = SP.SkipExtensions();
            string[] search = SP.SearchExtensions();

            if (skip.Contains(FI.Extension)
                || (search.Length > 0 && !search.Contains(FI.Extension)))
            {
                return;
            }

            if (SP.isRegex)
            {
                if (chkMatchCase.Checked)
                {
                    System.Text.RegularExpressions.Regex R = new System.Text.RegularExpressions.Regex(SP.SearchString);
                    System.Text.RegularExpressions.Match M = R.Match(FileName);
                    if (M.Success) { Match = true; }
                }
                else
                {
                    System.Text.RegularExpressions.Regex R = new System.Text.RegularExpressions.Regex(SP.SearchString.ToLower());
                    System.Text.RegularExpressions.Match M = R.Match(FileName.ToLower());
                    if (M.Success) { Match = true; }
                }
            }
            else
            {
                if (FileName.Contains(SP.SearchString)) { Match = true; }
            }

            if (!Match && chkContents.Checked)
            {
                Match = SearchContents(SP, FilePath, out MatchLine);
            }
            #region Add matches
            if (Match)
            {
                var dataSource = grdResults.DataSource;
                var tempRow = (dataSource as DataTable).NewRow();
                tempRow["Name"] = FI.Name;
                tempRow["Path"] = FI.DirectoryName;
                tempRow["Created"] = FI.CreationTime;
                tempRow["Updated"] = FI.LastWriteTime;
                tempRow["Accessed"] = FI.LastAccessTime;
                tempRow["FileSize"] = FI.Length;
                tempRow["First Match"] = MatchLine.Trim();
                (dataSource as DataTable).Rows.Add(tempRow);

                MultiThread.MultiThread.ControlAction(lblCount, "Text=Found Files:" + (dataSource as DataTable).Rows.Count, null, null);
            }
            #endregion
        }
        private bool SearchContents(SearchParameters SP, string FilePath, out string FirstMatch)
        {
            FirstMatch = null;
            try
            {
                using (StreamReader Reader = new StreamReader(FilePath))
                {
                    while (!Reader.EndOfStream)
                    {
                        string Line = Reader.ReadLine();
                        if (SP.isRegex)
                        {
                            System.Text.RegularExpressions.Regex R = new System.Text.RegularExpressions.Regex(SP.SearchString);
                            System.Text.RegularExpressions.Match M = R.Match(Line);
                            if (M.Success)
                            {
                                FirstMatch = Line;
                                return true;
                            }
                        }
                        else
                        {
                            string tempLine = SP.MatchCase ? Line : Line.ToUpper();
                            if (tempLine.Contains(SP.SearchString))
                            {
                                FirstMatch = Line;
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                Errors.Add(x);
            }
            return false;
        }

        private void StartFilter()
        {
            grdResults.ClearSelection();

            foreach (Control C in this.Controls) { C.Enabled = false; }
            btnStop.Enabled = true;
            btnStop.BackColor = Color.Red;
            btnStop.Focus();

            SearchGrid();

            foreach (Control C in this.Controls) { C.Enabled = true; }
            btnStop.Enabled = false;
            btnStop.BackColor = SystemColors.Control;
        }
        private void SearchGrid()
        {
            bool MatchCase = chkFilterMatchCase.Checked;
            string FilterString = MatchCase ? txtFilter.Text : txtFilter.Text.ToUpper();

            foreach (DataGridViewRow Row in grdResults.Rows)
            {
                bool Match = false;

                StringBuilder rowText = new StringBuilder();
                foreach (DataGridViewCell Cell in Row.Cells) { rowText.Append(MatchCase ? Cell.Value.ToString() : Cell.Value.ToString().ToUpper()); }
                string itemText = rowText.ToString();

                //Check row text
                Match = itemText.Contains(FilterString);

                //Check FileContents
                string FilePath = Path.Combine(Row.Cells["Path"].Value.ToString(), Row.Cells["Name"].Value.ToString());
                if (!Match && chkFilterCheckContents.Checked && File.Exists(FilePath))
                {
                    Match = SearchGridContents(FilePath, FilterString, MatchCase);
                }

                if (Match != chkFilterInclude.Checked)
                {
                    Row.Selected = true;
                }
            }
            btnSearch.Enabled = true;
        }
        private bool SearchGridContents(string FilePath, string FilterString, bool MatchCase)
        {
            try
            {
                using (StreamReader Reader = new StreamReader(FilePath))
                {
                    while (!Reader.EndOfStream)
                    {
                        string Line = Reader.ReadLine();
                        string tempLine = MatchCase ? Line : Line.ToUpper();
                        if (tempLine.Contains(FilterString))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception x)
            {
                Errors.Add(x);
            }

            return false;
        }

        private void ViewSelectedItems()
        {
            List<string> Files = new List<string>();
            foreach (DataGridViewRow Row in grdResults.SelectedRows)
            {
                string FilePath = Path.Combine(Row.Cells["Path"].Value.ToString(), Row.Cells["Name"].Value.ToString());
                if (File.Exists(FilePath))
                {
                    Files.Add(FilePath);
                }
            }


            if (properties.ExternalEditor)
            {
                foreach (string FilePath in Files)
                {
                    string tempSearch = chkFilterMatchCase.Checked ? txtSearchString.Text : txtSearchString.Text.ToUpper();
                    System.Diagnostics.Process.Start(properties.TextEditor, FilePath);
                }
            }
            else if(Files.Count > 0)
            {
                TextViewer tv = new TextViewer(properties);
                tv.ShowFiles("Selected Files", Files, txtSearchString.Text, chkSearchRegex.Checked);
            }

        }
        private void ViewSelectedContext()
        {
            List<FileContext> MatchFiles = new List<FileContext>();
            string Title = "Context";
            string SearchString = txtSearchString.Text;
            string tempSearch = chkFilterMatchCase.Checked ? SearchString : SearchString.ToUpper();
            int C = 0;
            int MC = 0;

            foreach (DataGridViewRow Row in grdResults.Rows)
            {
                string FilePath = Path.Combine(Row.Cells["Path"].Value.ToString(), Row.Cells["Name"].Value.ToString());
                int[] MatchLines = new int[0];
                if (chkSearchRegex.Checked)
                {
                    MatchLines = GetFileContextsRegex(FilePath);
                }
                else
                {
                    MatchLines = GetFileContexts(FilePath);
                }
                MatchFiles.Add(GetContexts(MatchLines, FilePath, properties.ContextSize));

                MC += MatchLines.Length;
                lblStatus.Text = string.Format("{0} files searched; {1} total matches", ++C, MC);
            }

            TextViewer TV = new TextViewer(properties);
            TV.ShowContexts(Title, MatchFiles, tempSearch, chkSearchRegex.Checked);
        }
        private int[] GetFileContexts(string FilePath)
        {
            List<int> MatchLines = new List<int>();
            string tempSearch = chkFilterMatchCase.Checked ? txtSearchString.Text : txtSearchString.Text.ToUpper();
            int LineNum = 0;

            using (StreamReader SR = new StreamReader(FilePath))
            {
                while (!SR.EndOfStream)
                {
                    string Line = SR.ReadLine();
                    LineNum++;
                    string tempLine = chkFilterMatchCase.Checked ? Line : Line.ToUpper();

                    if (tempLine.Contains(tempSearch))
                    {
                        MatchLines.Add(LineNum);
                    }
                }
            }

            return MatchLines.ToArray();
        }
        private int[] GetFileContextsRegex(string FilePath)
        {
            List<int> MatchLines = new List<int>();
            string SearchString = txtSearchString.Text;
            int LineNum = 0;

            using (StreamReader SR = new StreamReader(FilePath))
            {
                while (!SR.EndOfStream)
                {
                    string Line = SR.ReadLine();
                    LineNum++;
                    string tempLine = chkFilterMatchCase.Checked ? Line : Line.ToUpper();

                    System.Text.RegularExpressions.Regex R = new System.Text.RegularExpressions.Regex(SearchString);
                    System.Text.RegularExpressions.Match M = R.Match(Line);
                    if (M.Success)
                    {
                        MatchLines.Add(LineNum);
                    }
                }
            }

            return MatchLines.ToArray();
        }
        private FileContext GetContexts(int[] MatchLines, string FilePath, int ContextLines)
        {
            FileContext Output = new FileContext(FilePath);
            int halfContext = ContextLines / 2;
            for (var i = 0; i < MatchLines.Length; i++) { MatchLines[i] = Math.Max(0, MatchLines[i] - halfContext); }

            int LineNum = 0;
            using (StreamReader SR = new StreamReader(FilePath))
            {
                while (!SR.EndOfStream)
                {
                    LineNum++;
                    string Line = SR.ReadLine();
                    if (MatchLines.Contains(LineNum)) { Output.Chunks.Add(new ContextGroup()); }

                    foreach (ContextGroup Chunk in Output.Chunks)
                    {
                        if (Chunk.Lines.Count < ContextLines)
                        {
                            Chunk.Lines.Add(new ContextLine(LineNum, Line));
                        }
                    }
                }
            }
            return Output;
        }

        private void FindFilesInFolder()
        {
            int C = 0;
            foreach (DataGridViewRow Row in grdResults.SelectedRows)
            {
                string FilePath = Path.Combine(Row.Cells["Path"].Value.ToString(), Row.Cells["Name"].Value.ToString());
                if (File.Exists(FilePath))
                {
                    if (!File.Exists(FilePath)) { return; }

                    // combine the arguments together
                    string argument = "/select, \"" + FilePath + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                    C++;
                }
            }
            lblStatus.Text = C + " File Locations Opened.";
        }
        private void SelectedToClipboard()
        {
            System.Collections.Specialized.StringCollection FilePaths = new System.Collections.Specialized.StringCollection();
            foreach (DataGridViewRow Row in grdResults.SelectedRows)
            {
                string FilePath = Path.Combine(Row.Cells["Path"].Value.ToString(), Row.Cells["Name"].Value.ToString());
                if (File.Exists(FilePath))
                {
                    if (!File.Exists(FilePath)) { return; }

                    // combine the arguments together
                    FilePaths.Add(FilePath);
                }
            }

            Clipboard.SetFileDropList(FilePaths);
            lblStatus.Text = FilePaths.Count + " Files copied to clipboard";
        }
        #endregion
    }
}
