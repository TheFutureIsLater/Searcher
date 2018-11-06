using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

//BUGS

//UI
//TODO: option to stop at nth hit
//TODO: add search history tab: show search parameters and save results list (just the file paths).

//backing
//TODO: clean up Utility.cs
//TODO: threadify context search
//TODO: threadify grid filter
//TODO: clean up TextViewer FindHits nonsense

namespace Searcher
{
    public partial class MainWindow : Form
    {
        private enum LogType
        {
            Info,
            Warning,
            Error
        }

        //Options area:
	    private readonly DataTable _dataSource = new DataTable();
        private readonly Dictionary<FileInfo, string> _matchFiles = new Dictionary<FileInfo, string>();
	    private readonly SettingsForm _properties = new SettingsForm();

	    private DateTime _startTime;
		private bool _stop;
	    private CancellationTokenSource _cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();

            SetDataColumns();
            grdResults.DataSource = _dataSource;

            folderBrowser.SelectedPath = @"C:\";

            chkContents.Checked = true;
            btnSearch.PerformClick();

            rtbLog.AppendText("Opened: " + DateTime.Now);
        }

        #region Events
        private void BtnBuildMultiSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var sce = new Regexr();
                if (sce.ShowDialog() == DialogResult.OK)
                {
                    txtSearchString.Text = sce.Output;
                    chkSearchRegex.Checked = true;
                }

                sce.Dispose();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnContext_Click(object sender, EventArgs e)
        {
            try
            {
                ViewSelectedContext();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            try { 
            SelectedToClipboard();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                PrepFilter();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnFindInFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FindFilesInFolder();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = new List<int>();
                foreach (DataGridViewRow row in grdResults.SelectedRows)
                {
                    selected.Add(row.Index);
                }

                grdResults.CurrentCell = null;
                foreach (var item in selected)
                {
                    grdResults.Rows[item].Visible = false;
                }

                grdResults.ClearSelection();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdResults.Rows)
                {
                    row.Visible = true;
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnRootFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRootFolder.Text) ? @"C:\" : txtRootFolder.Text;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtRootFolder.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PrepSearch();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _stop = true;
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewSelectedItems();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void ChkFilterInclude_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkFilterInclude.Text = chkFilterInclude.Checked ? "Exclude" : "Include";
                if (!string.IsNullOrEmpty(txtFilter.Text)) PrepFilter();
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }
        private void TxtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PrepSearch();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        private void TxtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PrepFilter();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }
        }
        #endregion
        #region private
        private void PrepSearch()
        {
            txtSearchString.BackColor = Color.White;
	        if ( string.IsNullOrEmpty( txtRootFolder.Text ) || string.IsNullOrEmpty( txtSearchString.Text ) )
		        return;
            if (chkSearchRegex.Checked)
            {
                try
                {
                    Utility.TestRegexPattern(txtSearchString.Text);
                }
                catch(Exception x)
                {
                    AddError("Invalid Regex: " + x.Message);
                    txtSearchString.BackColor = Color.Red;
                    return;
                }
            }

	        _startTime = DateTime.Now;
	        lblStart.Text = $@"Start Search: {_startTime:HH:mm:ss}";
            AddInfo(lblStart.Text);
	        lblStopped.Text = string.Empty;
	        lblDuration.Text = string.Empty;


            SetDataColumns();
	        grdResults.ClearSelection();
	        grdResults.DataSource = null;

            _stop = false;
            _matchFiles.Clear();
	        _cancellationTokenSource = new CancellationTokenSource();
	        var ct = _cancellationTokenSource.Token;

            var skipExt = new string[0];
            if (chkSkipExtensions.Checked)
            {
                skipExt = new string[_properties.SkipExtensions.Count];
                _properties.SkipExtensions.CopyTo(skipExt, 0);
            }
            skipExt = skipExt.Concat(txtSkipExtention.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToArray();

            var skipFolder = new string[0];
            if (chkSkipFolders.Checked)
            {
                skipFolder = new string[_properties.SkipFolders.Count];
                _properties.SkipFolders.CopyTo(skipFolder, 0);
            }
            skipFolder = skipFolder.Concat(txtSkipFolder.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToArray();

            var searchExt = txtSearchExtension.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var sp = new SearchParameters(ct)
            {
                CheckContents = chkContents.Checked,
                IsRecursive = chkRecursive.Checked,
                IsRegex = chkSearchRegex.Checked,
                RootFolder = txtRootFolder.Text,
                SearchString = txtSearchString.Text,
                SearchExtension = searchExt,
                SkipExtension = skipExt,
                SkipFolder = skipFolder
            };

	        txtFilter.Text = null;
	        tabControl.Visible = false;
	        lblCount.Text = @"Found Files:0";

	        foreach (Control c in Controls)
	        {
		        if (c is Button || c is CheckBox || c is TextBox)
		        {
			        c.Enabled = false;
		        }
	        }

	        btnStop.Enabled = true;
	        btnStop.BackColor = Color.Red;
	        btnStop.Focus();

	        Task.Run(() => DoSearch(sp), ct);
        }
        private void DoSearch(object o)
        {
            var failedFiles = new Dictionary<string, Exception>();

            if (!(o is SearchParameters)){ return; }
            var sp = (SearchParameters) o;
            Utility.SearchFolder(sp, failedFiles, _matchFiles, lblStatus, lblCount);

			PostSearchUiCleanup( failedFiles );
        }
	    private void PostSearchUiCleanup( Dictionary<string, Exception> failedFiles )
	    {
	        foreach (var key in failedFiles.Keys)
	        {
                AddWarning($"Skipped {key}: {failedFiles[key]}");
	        }
	        PopulateRows();

            MultiThread.SetProperty( btnSearch, "Enabled", true );
		    MultiThread.UpdateToolStripStatus( lblStatus, _stop ? $"Stopped: {_dataSource.Rows.Count} hits"   : $"Done: {_dataSource.Rows.Count} hits" );
		    var endTime = DateTime.Now;
		    var duration = endTime - _startTime;
		    MultiThread.UpdateToolStripStatus( lblStopped, $@"Stop Search: {endTime:HH:mm:ss}" );
            AddInfo($@"Stop Search: {endTime:HH:mm:ss}");
		    MultiThread.UpdateToolStripStatus( lblDuration, $@"Duration: {duration.TotalSeconds}s" );


			foreach ( Control c in Controls )
		    {
			    if ( c is Button || c is CheckBox || c is TextBox )
			    {
				    MultiThread.SetProperty( c, "Enabled", true );
			    }
		    }

		    MultiThread.SetProperty( btnStop, "BackColor", SystemColors.Control );
		    MultiThread.SetProperty( btnStop, "Enabled", false );

			MultiThread.InvokeMethod( txtSearchString, "Focus", null );
		    MultiThread.SetProperty( grdResults, "DataSource", _dataSource );

		    MultiThread.SetProperty( tabControl, "Visible", true );
	    }

        private void PrepFilter()
        {
            grdResults.ClearSelection();

            foreach (Control c in Controls) { c.Enabled = false; }
            btnStop.Enabled = true;
            btnStop.BackColor = Color.Red;
            btnStop.Focus();

            _cancellationTokenSource = new CancellationTokenSource();
            var ct = _cancellationTokenSource.Token;

            var sp = new SearchParameters(ct)
            {
                CheckContents = chkFilterCheckContents.Checked,
                IsRecursive = false,
                IsRegex = chkFilterRegex.Checked,
                RootFolder = "GRID",
                SearchString = txtFilter.Text,
                SearchExtension = null,
                SkipExtension = null,
                SkipFolder = null

            };
            AddInfo($@"Start Filter: {_startTime:HH:mm:ss}");

            DoFilter(sp);

            PostFilterUiCleanup();
        }
        private void DoFilter(SearchParameters sp)
        {
            foreach (DataGridViewRow row in grdResults.Rows)
            {
	            var rowText = new StringBuilder();
                foreach (DataGridViewCell cell in row.Cells) { rowText.Append(cell.Value); }
                var itemText = rowText.ToString();

                //Check row text
                var match = Regex.IsMatch(itemText, sp.SearchString);

                //Check FileContents
                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (!match && chkFilterCheckContents.Checked && File.Exists(filePath))
                {
                    match = Utility.SearchContents(sp, filePath, out var _);
                }

                if (match != chkFilterInclude.Checked)
                {
                    row.Selected = true;
                }
            }
            btnSearch.Enabled = true;
        }
        private void PostFilterUiCleanup()
        {
            foreach (Control c in Controls) { c.Enabled = true; }
            btnStop.Enabled = false;
            btnStop.BackColor = SystemColors.Control;
            AddInfo($@"End Filter: {_startTime:HH:mm:ss}");
        }

        private void ViewSelectedItems()
        {
	        var files = new List<string>();
	        foreach (DataGridViewRow row in grdResults.SelectedRows)
	        {
	            if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
                if (File.Exists(filePath))
                {
                    files.Add(filePath);
                }
            }


            if (_properties.ExternalEditor)
            {
                foreach (var filePath in files)
                {
                    System.Diagnostics.Process.Start(_properties.TextEditor, filePath);
                }
            }
            else if(files.Count > 0)
            {
                var tv = new TextViewer(_properties);
                tv.ShowFiles("Selected Files", files, txtSearchString.Text);
            }

        }
        private void ViewSelectedContext()
        {
            var matchFiles = new List<FileContext>();
            const string title = "Context";
            var searchString = txtSearchString.Text;
            var c = 0;
            var mc = 0;

            foreach (DataGridViewRow row in grdResults.Rows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            var matchLines = chkSearchRegex.Checked ? GetFileContextsRegex(filePath) : GetFileContexts(filePath);
                matchFiles.Add(GetContexts(matchLines, filePath, _properties.ContextSize));

                mc += matchLines.Length;
	            // ReSharper disable once LocalizableElement
                lblStatus.Text = $"{++c} files searched; {mc} total matches";
            }

            var tv = new TextViewer(_properties);
            tv.ShowContexts(title, matchFiles, searchString, chkSearchRegex.Checked);
        }
        private int[] GetFileContexts(string filePath)
        {
            var matchLines = new List<int>();
            var tempSearch = txtSearchString.Text;
            var lineNum = 0;

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
	                lineNum++;
	                if ( string.IsNullOrEmpty(line)) continue;

                    if (line.Contains(tempSearch))
                    {
                        matchLines.Add(lineNum);
                    }
                }
            }

            return matchLines.ToArray();
        }
        private int[] GetFileContextsRegex(string filePath)
        {
            var matchLines = new List<int>();
            var searchString = txtSearchString.Text;
            var lineNum = 0;

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    lineNum++;
	                if (string.IsNullOrEmpty(line)) continue;

                    if (Regex.IsMatch(line, searchString))
                    {
                        matchLines.Add(lineNum);
                    }
                }
            }

            return matchLines.ToArray();
        }
        private static FileContext GetContexts(IList<int> matchLines, string filePath, int contextLines)
        {
            var output = new FileContext(filePath);
            var halfContext = contextLines / 2;
            for (var i = 0; i < matchLines.Count; i++) { matchLines[i] = Math.Max(0, matchLines[i] - halfContext); }

            var lineNum = 0;
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    lineNum++;
                    var line = sr.ReadLine();
                    if (matchLines.Contains(lineNum)) { output.Chunks.Add(new ContextGroup()); }

                    foreach (var chunk in output.Chunks)
                    {
                        if (chunk.Lines.Count < contextLines)
                        {
                            chunk.Lines.Add(new ContextLine(lineNum, line));
                        }
                    }
                }
            }
            return output;
        }

        private void FindFilesInFolder()
        {
            var c = 0;
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            if (!File.Exists(filePath)) continue;

	            // combine the arguments together
	            var argument = "/select, \"" + filePath + "\"";
	            System.Diagnostics.Process.Start("explorer.exe", argument);
	            c++;
            }
	        // ReSharper disable once LocalizableElement
            lblStatus.Text = c + " File Locations Opened.";
        }
        private void SelectedToClipboard()
        {
            var filePaths = new System.Collections.Specialized.StringCollection();
            foreach (DataGridViewRow row in grdResults.SelectedRows)
            {
                if (!row.Visible) { continue; }

                var filePath = Path.Combine(row.Cells["Directory"].Value.ToString(), row.Cells["Name"].Value.ToString());
	            if (!File.Exists(filePath)) continue;

	            // combine the arguments together
	            filePaths.Add(filePath);
            }

            Clipboard.SetFileDropList(filePaths);
	        // ReSharper disable once LocalizableElement
            lblStatus.Text = filePaths.Count + " Files copied to clipboard";
        }

        private void SetDataColumns()
        {
            var hiddenRows = (from DataGridViewRow row in grdResults.Rows where !row.Visible select row.Index).ToList();
            _dataSource.Columns.Clear();
            foreach (var column in _properties.ColumnOrder.OfType<string>().Distinct())
            {
                _dataSource.Columns.Add(column, column == "FileSize" ? typeof(int) : typeof(string));
            }
            PopulateRows();
            grdResults.CurrentCell = null;
            foreach (var i in hiddenRows)
            {
                grdResults.Rows[i].Visible = false;
            }
        }

        private void PopulateRows()
        {
            _dataSource.Rows.Clear();
            foreach (var fi in _matchFiles.Keys)
            {
                Utility.AddRow(_dataSource, fi, _matchFiles[fi]);
            }
        }

        private void ShowSettings()
        {
            try
            {
                if (_properties.ShowDialog() == DialogResult.OK)
                {
                    SetDataColumns();
                }
            }
            catch (Exception x)
            {
                AddError(x.Message);
            }

        }
        #endregion

        #region logging
        private void AddLog(string message, LogType logType)
        {
            Color lineColor;

            switch (logType)
            {
                case LogType.Info:
                    if (!_properties.LogInfo) return;
                    lineColor = Color.Black;
                    break;
                case LogType.Warning:
                    if (!_properties.LogWarning) return;
                    lineColor = Color.BlueViolet;
                    break;
                case LogType.Error:
                    if (!_properties.LogError) return;
                    lineColor = Color.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }


            var preLength = int.Parse(MultiThread.GetProperty(rtbLog, "TextLength").ToString());

            MultiThread.InvokeMethod(rtbLog, "AppendText", new object[] { $"\r\n {DateTime.Now} - " });
            MultiThread.InvokeMethod(rtbLog, "AppendText", new object[] { message });

            var postLength = int.Parse(MultiThread.GetProperty(rtbLog, "TextLength").ToString());
            MultiThread.InvokeMethod(rtbLog, "Select", new object[] { preLength, postLength });

            MultiThread.SetProperty(rtbLog, "SelectionColor", lineColor);

            switch (logType)
            {
                case LogType.Info:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.Black);
                    break;
                case LogType.Warning:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.BlueViolet);
                    break;
                case LogType.Error:
                    MultiThread.SetProperty(rtbLog, "SelectionColor", Color.Red);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }

            MultiThread.InvokeMethod(rtbLog, "Select", new object[] { 0 ,0 });
        }

        private void AddInfo(string message)
        {
            AddLog(message, LogType.Info);
        }

        private void AddWarning(string message)
        {
            AddLog(message, LogType.Warning);
        }

        private void AddError(string message)
        {
            AddLog(message, LogType.Error);
        }

        #endregion


    }
}
