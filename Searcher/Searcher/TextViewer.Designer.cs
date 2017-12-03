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
            this.dgvHilights = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSample = new System.Windows.Forms.Label();
            this.btnAddHilight = new System.Windows.Forms.Button();
            this.chkIsRegex = new System.Windows.Forms.CheckBox();
            this.txtNewHilight = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.mnuTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).BeginInit();
            this.spltTextViewer.Panel1.SuspendLayout();
            this.spltTextViewer.Panel2.SuspendLayout();
            this.spltTextViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilights)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuTV
            // 
            this.mnuTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mnuTV.Location = new System.Drawing.Point(0, 0);
            this.mnuTV.Name = "mnuTV";
            this.mnuTV.Size = new System.Drawing.Size(914, 24);
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
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // spltTextViewer
            // 
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
            this.spltTextViewer.Panel2.Controls.Add(this.dgvHilights);
            this.spltTextViewer.Panel2.Controls.Add(this.btnDelete);
            this.spltTextViewer.Panel2.Controls.Add(this.lblSample);
            this.spltTextViewer.Panel2.Controls.Add(this.btnAddHilight);
            this.spltTextViewer.Panel2.Controls.Add(this.chkIsRegex);
            this.spltTextViewer.Panel2.Controls.Add(this.txtNewHilight);
            this.spltTextViewer.Size = new System.Drawing.Size(914, 486);
            this.spltTextViewer.SplitterDistance = 487;
            this.spltTextViewer.TabIndex = 6;
            // 
            // tabFiles
            // 
            this.tabFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFiles.Location = new System.Drawing.Point(0, 0);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(487, 486);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.SelectedIndexChanged += new System.EventHandler(this.tabFiles_TabIndexChanged);
            this.tabFiles.TabIndexChanged += new System.EventHandler(this.tabFiles_TabIndexChanged);
            // 
            // dgvHilights
            // 
            this.dgvHilights.AllowUserToAddRows = false;
            this.dgvHilights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHilights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHilights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHilights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHilights.Location = new System.Drawing.Point(0, 60);
            this.dgvHilights.Name = "dgvHilights";
            this.dgvHilights.RowHeadersVisible = false;
            this.dgvHilights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHilights.Size = new System.Drawing.Size(423, 403);
            this.dgvHilights.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(0, 463);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(423, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(86, 21);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(42, 13);
            this.lblSample.TabIndex = 3;
            this.lblSample.Text = "Sample";
            this.lblSample.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblSample_MouseClick);
            // 
            // btnAddHilight
            // 
            this.btnAddHilight.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddHilight.Location = new System.Drawing.Point(0, 37);
            this.btnAddHilight.Name = "btnAddHilight";
            this.btnAddHilight.Size = new System.Drawing.Size(423, 23);
            this.btnAddHilight.TabIndex = 2;
            this.btnAddHilight.Text = "Add Hilight";
            this.btnAddHilight.UseVisualStyleBackColor = true;
            this.btnAddHilight.Click += new System.EventHandler(this.btnAddHilight_Click);
            // 
            // chkIsRegex
            // 
            this.chkIsRegex.AutoSize = true;
            this.chkIsRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkIsRegex.Location = new System.Drawing.Point(0, 20);
            this.chkIsRegex.Name = "chkIsRegex";
            this.chkIsRegex.Size = new System.Drawing.Size(423, 17);
            this.chkIsRegex.TabIndex = 1;
            this.chkIsRegex.Text = "Is Regex";
            this.chkIsRegex.UseVisualStyleBackColor = true;
            // 
            // txtNewHilight
            // 
            this.txtNewHilight.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewHilight.Location = new System.Drawing.Point(0, 0);
            this.txtNewHilight.Name = "txtNewHilight";
            this.txtNewHilight.Size = new System.Drawing.Size(423, 20);
            this.txtNewHilight.TabIndex = 0;
            this.txtNewHilight.TextChanged += new System.EventHandler(this.txtNewHilight_TextChanged);
            // 
            // TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 510);
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
            this.spltTextViewer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltTextViewer)).EndInit();
            this.spltTextViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilights)).EndInit();
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
        private System.Windows.Forms.CheckBox chkIsRegex;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvHilights;
        private System.Windows.Forms.TabControl tabFiles;
    }
}