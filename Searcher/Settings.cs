﻿using ROOSFAFS.Properties;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Searcher
{
    public partial class SettingsForm : Form
    {
        private const string _defaultRoot = "C:\\";
        private const string _defaultTextEditor = "notepad++.exe";
        private const bool _defaultExternalEditor = false;
        private const int _defaultContextSize = 5;
        private const bool _defaultConfirmCloseTab = true;
        private const bool _defaultLogInfo = true;
        private const bool _defaultLogWarning = true;
        private const bool _defaultLogError = true;
        private readonly string[] _defaultSkipExtensions = {"svn", "git", "vs", "dll", "exe"};
        private readonly string[] _defaultSkipFolders = {"RECYCLE"};
        private readonly string[] _defaultResultsColumns = {"CreationTime", "LastWriteTime", "LastAccessTime", "Length"};
        private readonly string[] _defaultColumnOrder = { "CreationTime", "LastWriteTime", "LastAccessTime", "Length"};
        private readonly string[] _requiredResultsColumns = {"Name", "Directory"};

        private static string _root
        {
            get => (string)Settings.Default["root"];
            set => Settings.Default["root"] = value;
        }
        private static string _textEditor
        {
            get => (string) Settings.Default["textEditor"];
            set => Settings.Default["textEditor"] = value;
        }
        private static int _contextSize
        {
            get => (int) Settings.Default["contextSize"];
            set => Settings.Default["contextSize"] = value;
        }
        private static bool _externalEditor
        {
            get => (bool) Settings.Default["useExternalFileViewer"];
            set => Settings.Default["useExternalFileViewer"] = value;
        }
        private static bool _confirmCloseTab
        {
            get => (bool)Settings.Default["confirmCloseTab"];
            set => Settings.Default["confirmCloseTab"] = value;
        }
        private static bool _logInfo
        {
            get => (bool)Settings.Default["logInfo"];
            set => Settings.Default["logInfo"] = value;
        }
        private static bool _logWarning
        {
            get => (bool)Settings.Default["logWarning"];
            set => Settings.Default["logWarning"] = value;
        }
        private static bool _logError
        {
            get => (bool)Settings.Default["logError"];
            set => Settings.Default["logError"] = value;
        }
        private static StringCollection _skipFolders => (StringCollection)Settings.Default["commonSkipFolders"];
        private static StringCollection _skipExtensions => (StringCollection)Settings.Default["commonSkipExtensions"];
        private static StringCollection _resultsColumns => (StringCollection)Settings.Default["resultsColumns"];
        private static StringCollection _columnOrder => (StringCollection)Settings.Default["columnOrder"];

        public string Root => _root;
        public string TextEditor => _textEditor;
        public int ContextSize => _contextSize;
        public bool ExternalEditor => _externalEditor;
        public bool ConfirmCloseTab => _confirmCloseTab;
        public bool LogInfo => _logInfo;
        public bool LogWarning => _logWarning;
        public bool LogError => _logError;
        public StringCollection SkipFolders => _skipFolders;
        public StringCollection SkipExtensions => _skipExtensions;

        public StringCollection ColumnOrder
        {
            get
            {
                var temp = new string[_columnOrder.Count];
                _columnOrder.CopyTo(temp, 0);
                var sc = new StringCollection();
                sc.AddRange(_requiredResultsColumns);
                sc.AddRange(temp);

                return sc;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            foreach (var prop in typeof(FileInfo).GetProperties())
            {
                if (_requiredResultsColumns.Contains(prop.Name)) { continue; }
                clbResults.Items.Add(prop.Name);
            }
            PopulateInputs();
        }

        private void PopulateInputs()
        {
            txtRoot.Text = _root;
            txtSkipExtensions.Text = string.Join(",", SkipExtensions.Cast<string>().ToArray());
            txtSkipFolders.Text = string.Join(",", SkipFolders.Cast<string>().ToArray());
            txtTextEditor.Text = _textEditor;
            chkExternalFileViewer.Checked = ExternalEditor;
            chkLogInfo.Checked = LogInfo;
            chkLogWarning.Checked = LogWarning;
            chkLogError.Checked = LogError;
            numContextSize.Value = ContextSize;
            SetAllChecks(clbResults, _resultsColumns);
            SetListItems(lstColOrder, _columnOrder);

            txtTextEditor.Visible = chkExternalFileViewer.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtRoot.Text))
            {
                _root = txtRoot.Text;
            }

            if (!string.IsNullOrEmpty(txtTextEditor.Text))
            {
                _textEditor = txtTextEditor.Text;
            }

            _contextSize = (int) numContextSize.Value;
            _externalEditor = chkExternalFileViewer.Checked;
            _logInfo = chkLogInfo.Checked;
            _logWarning = chkLogWarning.Checked;
            _logError = chkLogError.Checked;
            _skipFolders.Clear();
            _skipExtensions.Clear();
            _resultsColumns.Clear();
            _columnOrder.Clear();
            _skipFolders.AddRange(txtSkipFolders.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            _skipExtensions.AddRange(txtSkipExtensions.Text.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            _resultsColumns.AddRange(clbResults.CheckedItems.OfType<object>().Select(x => x.ToString()).ToArray());
            _columnOrder.AddRange(lstColOrder.Items.OfType<object>().Select(x => x.ToString()).ToArray());

            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            txtRoot.Text = _root;
            txtTextEditor.Text = _textEditor;
            numContextSize.Value = _contextSize;
            chkExternalFileViewer.Checked = _externalEditor;
            chkLogInfo.Checked = _logInfo;
            chkLogWarning.Checked = _logWarning;
            chkLogError.Checked = _logError;
            txtSkipFolders.Text = string.Join(",", _skipFolders);
            txtSkipExtensions.Text = string.Join(",", _skipExtensions);
            SetAllChecks(clbResults, _resultsColumns);
            SetListItems(lstColOrder, _columnOrder);

            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private static void SetAllChecks(CheckedListBox chklistbox, IEnumerable itemList)
        {
            if (itemList == null) return;

            foreach (var item in itemList)
            {
                var index = chklistbox.Items.IndexOf(item);
                if (index < 0) continue;
                chklistbox.SetItemChecked(index, true);
            }
        }

        private static void SetListItems(ListBox lst, IEnumerable itemList)
        {
            if (itemList == null) return;
            lst.Items.Clear();

            foreach (var item in itemList)
            {
                if (!lst.Items.Contains(item)) lst.Items.Add(item);
            }
        }

        private void BarOpacity_Scroll(object sender, EventArgs e)
        {
            Opacity = barOpacity.Value / 100f;
        }

        private void ChkExternalFileViewer_CheckedChanged(object sender, EventArgs e)
        {
            txtTextEditor.Visible = chkExternalFileViewer.Checked;
        }

        private void BtnRestoreDefault_Click(object sender, EventArgs e)
        {
            _root = _defaultRoot;
            _textEditor = _defaultTextEditor;
            _contextSize = _defaultContextSize;
            _externalEditor = _defaultExternalEditor;
            _confirmCloseTab = _defaultConfirmCloseTab;
            _skipFolders.Clear();
            _skipExtensions.Clear();
            _resultsColumns.Clear();
            _columnOrder.Clear();
            _skipFolders.AddRange(_defaultSkipFolders);
            _skipExtensions.AddRange(_defaultSkipExtensions);
            _resultsColumns.AddRange(_defaultResultsColumns);
            _columnOrder.AddRange(_defaultColumnOrder);
            _logInfo = _defaultLogInfo;
            _logWarning = _defaultLogWarning;
            _logError = _defaultLogError;

            PopulateInputs();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            MoveItem(lstColOrder, -1);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            MoveItem(lstColOrder, 1);
        }


        public void MoveItem(ListBox listBox, int direction)
        {
            var newIndex = listBox.SelectedIndex + direction;

            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0
                || newIndex < 0 || newIndex >= listBox.Items.Count)
                return;

            var selected = listBox.SelectedItem;

            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SetSelected(newIndex, true);
        }

        ////has to be a better way to do this part:
        private void ClbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbResults.CheckedItems.Contains(clbResults.SelectedItem))
            {
                //add
                lstColOrder.Items.Add(clbResults.SelectedItem);
            }
            else
            {
                //remove
                lstColOrder.Items.Remove(clbResults.SelectedItem);
            }
        }
        private void ClbResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (clbResults.CheckedItems.Contains(clbResults.SelectedItem))
            {
                //add
                lstColOrder.Items.Add(clbResults.SelectedItem);
            }
            else
            {
                //remove
                lstColOrder.Items.Remove(clbResults.SelectedItem);
            }
        }

        private void btnRootFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowser.SelectedPath = string.IsNullOrEmpty(txtRoot.Text) ? @"C:\" : txtRoot.Text;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtRoot.Text = folderBrowser.SelectedPath;
                }
            }
            catch {}
        }
    }
}
