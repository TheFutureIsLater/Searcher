namespace Searcher {
    partial class TextViewer {
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
            this.mnuTV = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spltTextViewer = new System.Windows.Forms.SplitContainer();
            this.tabFiles = new System.Windows.Forms.TabControl();
            this.splitFind = new System.Windows.Forms.SplitContainer();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnFindAllTabs = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvHilights = new System.Windows.Forms.DataGridView();
            this.pnlNewHighlight = new System.Windows.Forms.Panel();
            this.lblCounter = new System.Windows.Forms.Label();
            this.txtNewHilight = new System.Windows.Forms.TextBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.btnAddHilight = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.dataSet = new System.Data.DataSet();
            this.Hilighters = new System.Data.DataTable();
            this.colSearch = new System.Data.DataColumn();
            this.colIsRegex = new System.Data.DataColumn();
            this.colForeColor = new System.Data.DataColumn();
            this.colBackColor = new System.Data.DataColumn();
            this.colSample = new System.Data.DataColumn();
            this.FindHits = new System.Data.DataTable();
            this.colFile = new System.Data.DataColumn();
            this.colLineNum = new System.Data.DataColumn();
            this.colContent = new System.Data.DataColumn();
            this.colChar = new System.Data.DataColumn();
            this.mnuTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).BeginInit();
            this.spltTextViewer.Panel1.SuspendLayout();
            this.spltTextViewer.Panel2.SuspendLayout();
            this.spltTextViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFind)).BeginInit();
            this.splitFind.Panel1.SuspendLayout();
            this.splitFind.Panel2.SuspendLayout();
            this.splitFind.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilights)).BeginInit();
            this.pnlNewHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hilighters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindHits)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuTV
            // 
            this.mnuTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mnuTV.Location = new System.Drawing.Point(0, 0);
            this.mnuTV.Name = "mnuTV";
            this.mnuTV.Size = new System.Drawing.Size(1174, 24);
            this.mnuTV.TabIndex = 5;
            this.mnuTV.Text = "menuStrip1";
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
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // spltTextViewer
            // 
            this.spltTextViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spltTextViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltTextViewer.Location = new System.Drawing.Point(0, 24);
            this.spltTextViewer.Name = "spltTextViewer";
            // 
            // spltTextViewer.Panel1
            // 
            this.spltTextViewer.Panel1.Controls.Add(this.tabFiles);
            // 
            // spltTextViewer.Panel2
            // 
            this.spltTextViewer.Panel2.Controls.Add(this.splitFind);
            this.spltTextViewer.Panel2.Controls.Add(this.btnDelete);
            this.spltTextViewer.Panel2.Controls.Add(this.dgvHilights);
            this.spltTextViewer.Panel2.Controls.Add(this.pnlNewHighlight);
            this.spltTextViewer.Size = new System.Drawing.Size(1174, 598);
            this.spltTextViewer.SplitterDistance = 862;
            this.spltTextViewer.TabIndex = 6;
            // 
            // tabFiles
            // 
            this.tabFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFiles.Location = new System.Drawing.Point(0, 0);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(862, 598);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.SelectedIndexChanged += new System.EventHandler(this.TabFiles_TabIndexChanged);
            this.tabFiles.TabIndexChanged += new System.EventHandler(this.TabFiles_TabIndexChanged);
            this.tabFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabFiles_MouseDown);
            // 
            // splitFind
            // 
            this.splitFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFind.Location = new System.Drawing.Point(0, 236);
            this.splitFind.Name = "splitFind";
            this.splitFind.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFind.Panel1
            // 
            this.splitFind.Panel1.Controls.Add(this.pnlSearch);
            // 
            // splitFind.Panel2
            // 
            this.splitFind.Panel2.Controls.Add(this.dgvFind);
            this.splitFind.Size = new System.Drawing.Size(308, 362);
            this.splitFind.SplitterDistance = 68;
            this.splitFind.TabIndex = 9;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSearch.Controls.Add(this.btnFindAllTabs);
            this.pnlSearch.Controls.Add(this.btnFind);
            this.pnlSearch.Controls.Add(this.txtFind);
            this.pnlSearch.Controls.Add(this.lblFind);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(308, 68);
            this.pnlSearch.TabIndex = 7;
            // 
            // btnFindAllTabs
            // 
            this.btnFindAllTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindAllTabs.Location = new System.Drawing.Point(170, 35);
            this.btnFindAllTabs.Name = "btnFindAllTabs";
            this.btnFindAllTabs.Size = new System.Drawing.Size(135, 23);
            this.btnFindAllTabs.TabIndex = 8;
            this.btnFindAllTabs.Text = "Find in All Tabs";
            this.btnFindAllTabs.UseVisualStyleBackColor = true;
            this.btnFindAllTabs.Click += new System.EventHandler(this.BtnFindAllTabs_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(230, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(58, 9);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(166, 20);
            this.txtFind.TabIndex = 2;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(22, 12);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(30, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Find:";
            // 
            // dgvFind
            // 
            this.dgvFind.AllowUserToAddRows = false;
            this.dgvFind.AllowUserToOrderColumns = true;
            this.dgvFind.AllowUserToResizeRows = false;
            this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFind.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFind.Location = new System.Drawing.Point(0, 0);
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.RowHeadersVisible = false;
            this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFind.Size = new System.Drawing.Size(308, 290);
            this.dgvFind.TabIndex = 0;
            this.dgvFind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFind_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Location = new System.Drawing.Point(0, 213);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(308, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // dgvHilights
            // 
            this.dgvHilights.AllowUserToAddRows = false;
            this.dgvHilights.AllowUserToResizeRows = false;
            this.dgvHilights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHilights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHilights.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHilights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHilights.Location = new System.Drawing.Point(0, 65);
            this.dgvHilights.Name = "dgvHilights";
            this.dgvHilights.RowHeadersVisible = false;
            this.dgvHilights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHilights.Size = new System.Drawing.Size(308, 148);
            this.dgvHilights.TabIndex = 5;
            this.dgvHilights.DoubleClick += new System.EventHandler(this.dgvHilights_DoubleClick);
            // 
            // pnlNewHighlight
            // 
            this.pnlNewHighlight.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNewHighlight.Controls.Add(this.lblCounter);
            this.pnlNewHighlight.Controls.Add(this.txtNewHilight);
            this.pnlNewHighlight.Controls.Add(this.lblSample);
            this.pnlNewHighlight.Controls.Add(this.btnAddHilight);
            this.pnlNewHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNewHighlight.Location = new System.Drawing.Point(0, 0);
            this.pnlNewHighlight.Name = "pnlNewHighlight";
            this.pnlNewHighlight.Size = new System.Drawing.Size(308, 65);
            this.pnlNewHighlight.TabIndex = 6;
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(281, 27);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(24, 13);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "1/5";
            // 
            // txtNewHilight
            // 
            this.txtNewHilight.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewHilight.Location = new System.Drawing.Point(0, 0);
            this.txtNewHilight.Name = "txtNewHilight";
            this.txtNewHilight.Size = new System.Drawing.Size(308, 20);
            this.txtNewHilight.TabIndex = 0;
            this.txtNewHilight.TextChanged += new System.EventHandler(this.TxtNewHilight_TextChanged);
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(3, 26);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(42, 13);
            this.lblSample.TabIndex = 3;
            this.lblSample.Text = "Sample";
            this.lblSample.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblSample_MouseClick);
            // 
            // btnAddHilight
            // 
            this.btnAddHilight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddHilight.Location = new System.Drawing.Point(0, 42);
            this.btnAddHilight.Name = "btnAddHilight";
            this.btnAddHilight.Size = new System.Drawing.Size(308, 23);
            this.btnAddHilight.TabIndex = 2;
            this.btnAddHilight.Text = "Add Hilight";
            this.btnAddHilight.UseVisualStyleBackColor = true;
            this.btnAddHilight.Click += new System.EventHandler(this.BtnAddHilight_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.Hilighters,
            this.FindHits});
            // 
            // Hilighters
            // 
            this.Hilighters.Columns.AddRange(new System.Data.DataColumn[] {
            this.colSearch,
            this.colIsRegex,
            this.colForeColor,
            this.colBackColor,
            this.colSample});
            this.Hilighters.TableName = "Hilighters";
            // 
            // colSearch
            // 
            this.colSearch.ColumnName = "Search";
            // 
            // colIsRegex
            // 
            this.colIsRegex.ColumnName = "IsRegex";
            this.colIsRegex.DataType = typeof(bool);
            // 
            // colForeColor
            // 
            this.colForeColor.ColumnName = "ForeColor";
            this.colForeColor.DataType = typeof(object);
            // 
            // colBackColor
            // 
            this.colBackColor.ColumnName = "BackColor";
            this.colBackColor.DataType = typeof(object);
            // 
            // colSample
            // 
            this.colSample.ColumnName = "Sample";
            // 
            // FindHits
            // 
            this.FindHits.Columns.AddRange(new System.Data.DataColumn[] {
            this.colFile,
            this.colLineNum,
            this.colContent,
            this.colChar});
            this.FindHits.TableName = "FindHits";
            // 
            // colFile
            // 
            this.colFile.ColumnName = "File";
            // 
            // colLineNum
            // 
            this.colLineNum.ColumnName = "LineNum";
            // 
            // colContent
            // 
            this.colContent.ColumnName = "Content";
            // 
            // colChar
            // 
            this.colChar.Caption = "Char";
            this.colChar.ColumnName = "Char";
            this.colChar.DataType = typeof(int);
            // 
            // TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 622);
            this.Controls.Add(this.spltTextViewer);
            this.Controls.Add(this.mnuTV);
            this.MainMenuStrip = this.mnuTV;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextViewer";
            this.Text = "TextViewer";
            this.mnuTV.ResumeLayout(false);
            this.mnuTV.PerformLayout();
            this.spltTextViewer.Panel1.ResumeLayout(false);
            this.spltTextViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).EndInit();
            this.spltTextViewer.ResumeLayout(false);
            this.splitFind.Panel1.ResumeLayout(false);
            this.splitFind.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitFind)).EndInit();
            this.splitFind.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilights)).EndInit();
            this.pnlNewHighlight.ResumeLayout(false);
            this.pnlNewHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hilighters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindHits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTV;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer spltTextViewer;
        private System.Windows.Forms.TextBox txtNewHilight;
        private System.Windows.Forms.Button btnAddHilight;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvHilights;
        private System.Windows.Forms.TabControl tabFiles;
        private System.Windows.Forms.Panel pnlNewHighlight;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFindAllTabs;
        private System.Windows.Forms.SplitContainer splitFind;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable Hilighters;
        private System.Data.DataColumn colSearch;
        private System.Data.DataColumn colIsRegex;
        private System.Data.DataColumn colForeColor;
        private System.Data.DataColumn colBackColor;
        private System.Data.DataColumn colSample;
        private System.Data.DataTable FindHits;
        private System.Data.DataColumn colFile;
        private System.Data.DataColumn colLineNum;
        private System.Data.DataColumn colContent;
        private System.Data.DataColumn colChar;
    }
}