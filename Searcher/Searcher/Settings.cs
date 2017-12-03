using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searcher
{
    public partial class Settings : Form
    {
        private bool _externalEditor = false;
        private string _textEditor = "notepad++.exe";
        private int _contextSize = 5;

        public string TextEditor { get { return _textEditor; } }
        public int ContextSize { get { return _contextSize; } }
        public bool ExternalEditor { get { return _externalEditor; } }

        public Settings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTextEditor.Text))
            {
                _textEditor = txtTextEditor.Text;
            }
            _contextSize = (int)numContextSize.Value;
            _externalEditor = chkExternalFileViewer.Checked;

            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtTextEditor.Text = _textEditor;
            numContextSize.Value = _contextSize;
            chkExternalFileViewer.Checked = _externalEditor;
            this.Hide();
        }

        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            this.Opacity = barOpacity.Value/100f;
        }

        private void chkExternalFileViewer_CheckedChanged(object sender, EventArgs e)
        {
            txtTextEditor.Enabled = chkExternalFileViewer.Checked;
        }
    }
}
