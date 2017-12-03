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
    public partial class StringCollectionEditor : Form
    {
        public string[] Output = null;

        public StringCollectionEditor()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Output = txtInput.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Output = null;

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


    }
}
