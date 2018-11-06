using System;
using System.Windows.Forms;

/*
* ignore case: (?i)regex(?-i)
* word: /w
* not word: /W
* digit: /d
* not digit: /D
* whitespace: /s
* not whitespace: /S
* start of string: ^
* end of string: $
* any of: [regex]
* none of: [^regex]
* between(inclusive): [a-m]
* 0+: *
* 1+: +
* 0|1: ?
* match as few as possible: regex+? || regex{2,}?
* capture group: (regex)
* non capturing group: (?:regex)
* positive lookahead: (?=regex)
* negative lookahead: (?!regex)
*/

namespace Searcher
{
    public partial class Regexr : Form
    {
        public string Output = string.Empty;

        public Regexr()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Output = txtInput.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Output = null;

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void treeCheatSheet_DoubleClick(object sender, EventArgs e)
        {
            txtInput.Text += treeCheatSheet.SelectedNode.ToolTipText;
        }
    }
}
