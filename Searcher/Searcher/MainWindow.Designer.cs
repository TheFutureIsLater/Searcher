﻿namespace Searcher {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.txtSkipFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRootFolder = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkContents = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnContext = new System.Windows.Forms.Button();
            this.chkRecycle = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.chkFilterInclude = new System.Windows.Forms.CheckBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkFilterMatchCase = new System.Windows.Forms.CheckBox();
            this.chkFilterCheckContents = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtSearchExtension = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSkipExtention = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSearchRegex = new System.Windows.Forms.CheckBox();
            this.chkFilterRegex = new System.Windows.Forms.CheckBox();
            this.btnFindInFolder = new System.Windows.Forms.Button();
            this.btnCopyFiles = new System.Windows.Forms.Button();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBuildMultiSearch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStopped = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.mnuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search String: ";
            // 
            // txtSearchString
            // 
            this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchString.Location = new System.Drawing.Point(101, 29);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(607, 20);
            this.txtSearchString.TabIndex = 0;
            this.txtSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchString_KeyDown);
            // 
            // txtSkipFolder
            // 
            this.txtSkipFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipFolder.Location = new System.Drawing.Point(101, 100);
            this.txtSkipFolder.Name = "txtSkipFolder";
            this.txtSkipFolder.Size = new System.Drawing.Size(607, 20);
            this.txtSkipFolder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skip Folder: ";
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootFolder.Location = new System.Drawing.Point(101, 74);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(607, 20);
            this.txtRootFolder.TabIndex = 1;
            this.txtRootFolder.Text = "C:\\Projects\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Root Folder: ";
            // 
            // btnRootFolder
            // 
            this.btnRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRootFolder.Location = new System.Drawing.Point(714, 75);
            this.btnRootFolder.Name = "btnRootFolder";
            this.btnRootFolder.Size = new System.Drawing.Size(118, 23);
            this.btnRootFolder.TabIndex = 8;
            this.btnRootFolder.TabStop = false;
            this.btnRootFolder.Text = "Select Folder";
            this.btnRootFolder.UseVisualStyleBackColor = true;
            this.btnRootFolder.Click += new System.EventHandler(this.btnRootFolder_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(714, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkContents
            // 
            this.chkContents.AutoSize = true;
            this.chkContents.Location = new System.Drawing.Point(101, 55);
            this.chkContents.Name = "chkContents";
            this.chkContents.Size = new System.Drawing.Size(102, 17);
            this.chkContents.TabIndex = 5;
            this.chkContents.TabStop = false;
            this.chkContents.Text = "Check Contents";
            this.chkContents.UseVisualStyleBackColor = true;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(101, 178);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(119, 17);
            this.chkRecursive.TabIndex = 6;
            this.chkRecursive.TabStop = false;
            this.chkRecursive.Text = "Search Sub-Folders";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(714, 119);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(115, 53);
            this.btnStop.TabIndex = 14;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnView.Location = new System.Drawing.Point(714, 261);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(115, 23);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "Open Files";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnContext
            // 
            this.btnContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnContext.Location = new System.Drawing.Point(714, 290);
            this.btnContext.Name = "btnContext";
            this.btnContext.Size = new System.Drawing.Size(115, 23);
            this.btnContext.TabIndex = 9;
            this.btnContext.Text = "Match Contexts";
            this.btnContext.UseVisualStyleBackColor = true;
            this.btnContext.Click += new System.EventHandler(this.btnContext_Click);
            // 
            // chkRecycle
            // 
            this.chkRecycle.AutoSize = true;
            this.chkRecycle.Checked = true;
            this.chkRecycle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecycle.Location = new System.Drawing.Point(229, 178);
            this.chkRecycle.Name = "chkRecycle";
            this.chkRecycle.Size = new System.Drawing.Size(135, 17);
            this.chkRecycle.TabIndex = 19;
            this.chkRecycle.TabStop = false;
            this.chkRecycle.Text = "Skip Recycle Bin, SVN";
            this.chkRecycle.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Location = new System.Drawing.Point(714, 451);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(118, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Checked = true;
            this.chkMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatchCase.Location = new System.Drawing.Point(209, 55);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkMatchCase.TabIndex = 21;
            this.chkMatchCase.TabStop = false;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(80, 511);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(628, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // chkFilterInclude
            // 
            this.chkFilterInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFilterInclude.AutoSize = true;
            this.chkFilterInclude.Location = new System.Drawing.Point(17, 537);
            this.chkFilterInclude.Name = "chkFilterInclude";
            this.chkFilterInclude.Size = new System.Drawing.Size(61, 17);
            this.chkFilterInclude.TabIndex = 23;
            this.chkFilterInclude.TabStop = false;
            this.chkFilterInclude.Text = "Include";
            this.chkFilterInclude.UseVisualStyleBackColor = true;
            this.chkFilterInclude.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestore.Location = new System.Drawing.Point(714, 480);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(118, 23);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 514);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Filter String: ";
            // 
            // chkFilterMatchCase
            // 
            this.chkFilterMatchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFilterMatchCase.AutoSize = true;
            this.chkFilterMatchCase.Checked = true;
            this.chkFilterMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterMatchCase.Location = new System.Drawing.Point(84, 537);
            this.chkFilterMatchCase.Name = "chkFilterMatchCase";
            this.chkFilterMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkFilterMatchCase.TabIndex = 27;
            this.chkFilterMatchCase.TabStop = false;
            this.chkFilterMatchCase.Text = "Match Case";
            this.chkFilterMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkFilterCheckContents
            // 
            this.chkFilterCheckContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFilterCheckContents.AutoSize = true;
            this.chkFilterCheckContents.Location = new System.Drawing.Point(185, 537);
            this.chkFilterCheckContents.Name = "chkFilterCheckContents";
            this.chkFilterCheckContents.Size = new System.Drawing.Size(102, 17);
            this.chkFilterCheckContents.TabIndex = 28;
            this.chkFilterCheckContents.TabStop = false;
            this.chkFilterCheckContents.Text = "Check Contents";
            this.chkFilterCheckContents.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(380, 531);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(74, 23);
            this.btnFilter.TabIndex = 29;
            this.btnFilter.Text = "Filter Table";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdResults.Location = new System.Drawing.Point(12, 203);
            this.grdResults.Name = "grdResults";
            this.grdResults.RowHeadersVisible = false;
            this.grdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResults.Size = new System.Drawing.Size(696, 300);
            this.grdResults.TabIndex = 30;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(18, 253);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(149, 25);
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "Files Found: 0";
            // 
            // txtSearchExtension
            // 
            this.txtSearchExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchExtension.Location = new System.Drawing.Point(101, 126);
            this.txtSearchExtension.Name = "txtSearchExtension";
            this.txtSearchExtension.Size = new System.Drawing.Size(607, 20);
            this.txtSearchExtension.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Search Extension: ";
            // 
            // txtSkipExtention
            // 
            this.txtSkipExtention.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkipExtention.Location = new System.Drawing.Point(101, 152);
            this.txtSkipExtention.Name = "txtSkipExtention";
            this.txtSkipExtention.Size = new System.Drawing.Size(607, 20);
            this.txtSkipExtention.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Skip Extension: ";
            // 
            // chkSearchRegex
            // 
            this.chkSearchRegex.AutoSize = true;
            this.chkSearchRegex.Location = new System.Drawing.Point(298, 55);
            this.chkSearchRegex.Name = "chkSearchRegex";
            this.chkSearchRegex.Size = new System.Drawing.Size(57, 17);
            this.chkSearchRegex.TabIndex = 36;
            this.chkSearchRegex.TabStop = false;
            this.chkSearchRegex.Text = "Regex";
            this.chkSearchRegex.UseVisualStyleBackColor = true;
            // 
            // chkFilterRegex
            // 
            this.chkFilterRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFilterRegex.AutoSize = true;
            this.chkFilterRegex.Location = new System.Drawing.Point(293, 537);
            this.chkFilterRegex.Name = "chkFilterRegex";
            this.chkFilterRegex.Size = new System.Drawing.Size(57, 17);
            this.chkFilterRegex.TabIndex = 37;
            this.chkFilterRegex.TabStop = false;
            this.chkFilterRegex.Text = "Regex";
            this.chkFilterRegex.UseVisualStyleBackColor = true;
            // 
            // btnFindInFolder
            // 
            this.btnFindInFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindInFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFindInFolder.Location = new System.Drawing.Point(714, 203);
            this.btnFindInFolder.Name = "btnFindInFolder";
            this.btnFindInFolder.Size = new System.Drawing.Size(115, 23);
            this.btnFindInFolder.TabIndex = 41;
            this.btnFindInFolder.Text = "Find In Folder";
            this.btnFindInFolder.UseVisualStyleBackColor = true;
            this.btnFindInFolder.Click += new System.EventHandler(this.btnFindInFolder_Click);
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCopyFiles.Location = new System.Drawing.Point(714, 232);
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.Size = new System.Drawing.Size(115, 23);
            this.btnCopyFiles.TabIndex = 42;
            this.btnCopyFiles.Text = "Copy Selected";
            this.btnCopyFiles.UseVisualStyleBackColor = true;
            this.btnCopyFiles.Click += new System.EventHandler(this.btnCopyFiles_Click);
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(834, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // btnBuildMultiSearch
            // 
            this.btnBuildMultiSearch.Location = new System.Drawing.Point(361, 51);
            this.btnBuildMultiSearch.Name = "btnBuildMultiSearch";
            this.btnBuildMultiSearch.Size = new System.Drawing.Size(108, 23);
            this.btnBuildMultiSearch.TabIndex = 43;
            this.btnBuildMultiSearch.TabStop = false;
            this.btnBuildMultiSearch.Text = "Build MultiSearch";
            this.btnBuildMultiSearch.UseVisualStyleBackColor = true;
            this.btnBuildMultiSearch.Click += new System.EventHandler(this.btnBuildMultiSearch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStart,
            this.lblStopped});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 44;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 17);
            this.lblStatus.Text = "\\\\";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStart
            // 
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(47, 17);
            this.lblStart.Text = "Started:";
            // 
            // lblStopped
            // 
            this.lblStopped.Name = "lblStopped";
            this.lblStopped.Size = new System.Drawing.Size(54, 17);
            this.lblStopped.Text = "Stopped:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 579);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBuildMultiSearch);
            this.Controls.Add(this.btnCopyFiles);
            this.Controls.Add(this.btnFindInFolder);
            this.Controls.Add(this.chkFilterRegex);
            this.Controls.Add(this.chkSearchRegex);
            this.Controls.Add(this.txtSkipExtention);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearchExtension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.chkFilterCheckContents);
            this.Controls.Add(this.chkFilterMatchCase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.chkFilterInclude);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.chkRecycle);
            this.Controls.Add(this.btnContext);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.chkContents);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRootFolder);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSkipFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.mnuStrip);
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "MainWindow";
            this.Text = "Searcher";
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.TextBox txtSkipFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnRootFolder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkContents;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnContext;
        private System.Windows.Forms.CheckBox chkRecycle;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox chkFilterInclude;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkFilterMatchCase;
        private System.Windows.Forms.CheckBox chkFilterCheckContents;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView grdResults;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtSearchExtension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSkipExtention;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSearchRegex;
        private System.Windows.Forms.CheckBox chkFilterRegex;
        private System.Windows.Forms.Button btnFindInFolder;
        private System.Windows.Forms.Button btnCopyFiles;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnBuildMultiSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStart;
        private System.Windows.Forms.ToolStripStatusLabel lblStopped;
    }
}

