namespace Searcher
{
    partial class Settings
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
            ((System.ComponentModel.ISupportInitialize)(this.numContextSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Editor";
            // 
            // txtTextEditor
            // 
            this.txtTextEditor.Enabled = false;
            this.txtTextEditor.Location = new System.Drawing.Point(76, 6);
            this.txtTextEditor.Name = "txtTextEditor";
            this.txtTextEditor.Size = new System.Drawing.Size(212, 20);
            this.txtTextEditor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Context Size";
            // 
            // numContextSize
            // 
            this.numContextSize.Location = new System.Drawing.Point(76, 32);
            this.numContextSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numContextSize.Name = "numContextSize";
            this.numContextSize.Size = new System.Drawing.Size(61, 20);
            this.numContextSize.TabIndex = 3;
            this.numContextSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(401, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(334, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Dock = System.Windows.Forms.DockStyle.Right;
            this.barOpacity.LargeChange = 10;
            this.barOpacity.Location = new System.Drawing.Point(466, 0);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 20;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.barOpacity.Size = new System.Drawing.Size(26, 296);
            this.barOpacity.SmallChange = 5;
            this.barOpacity.TabIndex = 6;
            this.barOpacity.TabStop = false;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barOpacity.Value = 100;
            this.barOpacity.Scroll += new System.EventHandler(this.barOpacity_Scroll);
            // 
            // chkExternalFileViewer
            // 
            this.chkExternalFileViewer.AutoSize = true;
            this.chkExternalFileViewer.Location = new System.Drawing.Point(294, 8);
            this.chkExternalFileViewer.Name = "chkExternalFileViewer";
            this.chkExternalFileViewer.Size = new System.Drawing.Size(140, 17);
            this.chkExternalFileViewer.TabIndex = 7;
            this.chkExternalFileViewer.Text = "Use External File Viewer";
            this.chkExternalFileViewer.UseVisualStyleBackColor = true;
            this.chkExternalFileViewer.CheckedChanged += new System.EventHandler(this.chkExternalFileViewer_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 296);
            this.Controls.Add(this.chkExternalFileViewer);
            this.Controls.Add(this.barOpacity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numContextSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTextEditor);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
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
    }
}