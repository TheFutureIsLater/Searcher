namespace Searcher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextEditor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numContextSize = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.barOpacity = new System.Windows.Forms.TrackBar();
            this.chkExternalFileViewer = new System.Windows.Forms.CheckBox();
            this.txtSkipFolders = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRestoreDefault = new System.Windows.Forms.Button();
            this.chkConfirmTabClose = new System.Windows.Forms.CheckBox();
            this.txtSkipExtensions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clbResults = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstColOrder = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.chkLogInfo = new System.Windows.Forms.CheckBox();
            this.chkLogWarning = new System.Windows.Forms.CheckBox();
            this.chkLogError = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numContextSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Editor";
            // 
            // txtTextEditor
            // 
            this.txtTextEditor.Enabled = false;
            this.txtTextEditor.Location = new System.Drawing.Point(100, 447);
            this.txtTextEditor.Name = "txtTextEditor";
            this.txtTextEditor.Size = new System.Drawing.Size(240, 20);
            this.txtTextEditor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Context Size";
            // 
            // numContextSize
            // 
            this.numContextSize.Location = new System.Drawing.Point(100, 473);
            this.numContextSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numContextSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numContextSize.Name = "numContextSize";
            this.numContextSize.Size = new System.Drawing.Size(61, 20);
            this.numContextSize.TabIndex = 3;
            this.numContextSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(574, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(507, 529);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Dock = System.Windows.Forms.DockStyle.Right;
            this.barOpacity.LargeChange = 10;
            this.barOpacity.Location = new System.Drawing.Point(639, 0);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 20;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.barOpacity.Size = new System.Drawing.Size(26, 564);
            this.barOpacity.SmallChange = 5;
            this.barOpacity.TabIndex = 6;
            this.barOpacity.TabStop = false;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barOpacity.Value = 100;
            this.barOpacity.Scroll += new System.EventHandler(this.BarOpacity_Scroll);
            // 
            // chkExternalFileViewer
            // 
            this.chkExternalFileViewer.AutoSize = true;
            this.chkExternalFileViewer.Location = new System.Drawing.Point(350, 449);
            this.chkExternalFileViewer.Name = "chkExternalFileViewer";
            this.chkExternalFileViewer.Size = new System.Drawing.Size(140, 17);
            this.chkExternalFileViewer.TabIndex = 7;
            this.chkExternalFileViewer.Text = "Use External File Viewer";
            this.chkExternalFileViewer.UseVisualStyleBackColor = true;
            this.chkExternalFileViewer.CheckedChanged += new System.EventHandler(this.ChkExternalFileViewer_CheckedChanged);
            // 
            // txtSkipFolders
            // 
            this.txtSkipFolders.Location = new System.Drawing.Point(137, 35);
            this.txtSkipFolders.Multiline = true;
            this.txtSkipFolders.Name = "txtSkipFolders";
            this.txtSkipFolders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSkipFolders.Size = new System.Drawing.Size(227, 42);
            this.txtSkipFolders.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Common Skip Folders";
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestoreDefault.Location = new System.Drawing.Point(12, 529);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.btnRestoreDefault.Size = new System.Drawing.Size(115, 23);
            this.btnRestoreDefault.TabIndex = 10;
            this.btnRestoreDefault.Text = "Restore Defaults";
            this.btnRestoreDefault.UseVisualStyleBackColor = true;
            this.btnRestoreDefault.Click += new System.EventHandler(this.BtnRestoreDefault_Click);
            // 
            // chkConfirmTabClose
            // 
            this.chkConfirmTabClose.AutoSize = true;
            this.chkConfirmTabClose.Location = new System.Drawing.Point(113, 449);
            this.chkConfirmTabClose.Name = "chkConfirmTabClose";
            this.chkConfirmTabClose.Size = new System.Drawing.Size(112, 17);
            this.chkConfirmTabClose.TabIndex = 11;
            this.chkConfirmTabClose.Text = "Confirm Close Tab";
            this.chkConfirmTabClose.UseVisualStyleBackColor = true;
            // 
            // txtSkipExtensions
            // 
            this.txtSkipExtensions.Location = new System.Drawing.Point(151, 83);
            this.txtSkipExtensions.Multiline = true;
            this.txtSkipExtensions.Name = "txtSkipExtensions";
            this.txtSkipExtensions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSkipExtensions.Size = new System.Drawing.Size(213, 42);
            this.txtSkipExtensions.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Common Skip Extensions";
            // 
            // clbResults
            // 
            this.clbResults.CheckOnClick = true;
            this.clbResults.FormattingEnabled = true;
            this.clbResults.Items.AddRange(new object[] {
            "First Match"});
            this.clbResults.Location = new System.Drawing.Point(49, 147);
            this.clbResults.Name = "clbResults";
            this.clbResults.Size = new System.Drawing.Size(176, 244);
            this.clbResults.Sorted = true;
            this.clbResults.TabIndex = 14;
            this.clbResults.SelectedIndexChanged += new System.EventHandler(this.ClbResults_SelectedIndexChanged);
            this.clbResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clbResults_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Results Columns";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Column Order";
            // 
            // lstColOrder
            // 
            this.lstColOrder.FormattingEnabled = true;
            this.lstColOrder.Location = new System.Drawing.Point(296, 173);
            this.lstColOrder.Name = "lstColOrder";
            this.lstColOrder.Size = new System.Drawing.Size(186, 225);
            this.lstColOrder.TabIndex = 17;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(488, 197);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(22, 23);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(488, 226);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(22, 23);
            this.btnDown.TabIndex = 19;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // chkLogInfo
            // 
            this.chkLogInfo.AutoSize = true;
            this.chkLogInfo.Location = new System.Drawing.Point(542, 32);
            this.chkLogInfo.Name = "chkLogInfo";
            this.chkLogInfo.Size = new System.Drawing.Size(65, 17);
            this.chkLogInfo.TabIndex = 20;
            this.chkLogInfo.Text = "Log Info";
            this.chkLogInfo.UseVisualStyleBackColor = true;
            // 
            // chkLogWarning
            // 
            this.chkLogWarning.AutoSize = true;
            this.chkLogWarning.Location = new System.Drawing.Point(542, 55);
            this.chkLogWarning.Name = "chkLogWarning";
            this.chkLogWarning.Size = new System.Drawing.Size(87, 17);
            this.chkLogWarning.TabIndex = 21;
            this.chkLogWarning.Text = "Log Warning";
            this.chkLogWarning.UseVisualStyleBackColor = true;
            // 
            // chkLogError
            // 
            this.chkLogError.AutoSize = true;
            this.chkLogError.Location = new System.Drawing.Point(542, 78);
            this.chkLogError.Name = "chkLogError";
            this.chkLogError.Size = new System.Drawing.Size(69, 17);
            this.chkLogError.TabIndex = 22;
            this.chkLogError.Text = "Log Error";
            this.chkLogError.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(522, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Logging";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Viewing Files";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Searching";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Directory";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 564);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkLogError);
            this.Controls.Add(this.chkLogWarning);
            this.Controls.Add(this.chkLogInfo);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lstColOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clbResults);
            this.Controls.Add(this.txtSkipExtensions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkConfirmTabClose);
            this.Controls.Add(this.btnRestoreDefault);
            this.Controls.Add(this.txtSkipFolders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkExternalFileViewer);
            this.Controls.Add(this.barOpacity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numContextSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTextEditor);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numContextSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numContextSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TrackBar barOpacity;
        private System.Windows.Forms.CheckBox chkExternalFileViewer;
        private System.Windows.Forms.TextBox txtSkipFolders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRestoreDefault;
        private System.Windows.Forms.CheckBox chkConfirmTabClose;
        private System.Windows.Forms.TextBox txtSkipExtensions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstColOrder;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.CheckBox chkLogInfo;
        private System.Windows.Forms.CheckBox chkLogWarning;
        private System.Windows.Forms.CheckBox chkLogError;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}