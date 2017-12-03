using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace Searcher
{
    //TODO: sync scrolling with line numbers
    //TODO: get hilights to hilight.

    public class FancyTextBox : UserControl
    {
        const int EM_LINESCROLL = 0x00B6;
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);

        private List<HilightSearch> Hilighters = new List<HilightSearch>();

        private string _text;
        public override string Text { get { return _text; } set { _text = value; } }

        private RichTextBox Contents = new RichTextBox();
        private RichTextBox LineNumbers = new RichTextBox();
        private FastColoredTextBox fcText = new FastColoredTextBox();

        public FancyTextBox() {
            Init();
        }

        public void setContexts(List<FileContext> Input)
        {
            System.Text.StringBuilder SB1 = new System.Text.StringBuilder();
            System.Text.StringBuilder SB2 = new System.Text.StringBuilder();
            foreach (FileContext FC in Input)
            {
                SB1.AppendLine(FC.FilePath);
                SB2.AppendLine("File:");
                int MC = 0;
                foreach (ContextGroup CG in FC.Chunks)
                {
                    SB1.AppendLine("");
                    SB2.AppendLine("Match:" + ++MC);
                    foreach (ContextLine CL in CG.Lines)
                    {
                        SB1.AppendLine(CL.Line);
                        SB2.AppendLine(CL.LineNumber.ToString());
                    }
                    SB1.AppendLine();
                    SB2.AppendLine();
                }
                SB1.AppendLine();
                SB2.AppendLine();
            }

            Contents.Text = SB1.ToString();
            LineNumbers.Text = SB2.ToString();

            Contents.Text += SB1.ToString();
            LineNumbers.Text += SB2.ToString();

            fcText.Text = SB1.ToString();
        }

        private void Init()
        {
            LineNumbers = new RichTextBox()
            {
                Multiline=true,
                Dock = DockStyle.Left,
                Width = 50,
                ReadOnly = true,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.None,
                BackColor = Color.LightGray
            };

            Contents = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                BackColor = Color.White
            };

            fcText = new FastColoredTextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                BackColor = Color.White,
                ShowLineNumbers = true
            };

            //Contents.VScroll += Contents_VScroll;
            //LineNumbers.VScroll += LineNumbers_VScroll;
            //Contents.LinkClicked += Contents_LinkClicked;

            //this.Controls.Add(LineNumbers);
            this.Controls.Add(fcText);

            Contents.BringToFront();
        }

        /** /
        private void Init1()
        {
            Contents = new RichTextBox()
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Both,
                BorderStyle= System.Windows.Forms.BorderStyle.None,
                BackColor = Color.White
            };

            LineNumbers = new TextBox()
            {
                Multiline = true,
                Dock = DockStyle.Left,
                ScrollBars = ScrollBars.None,
                Width = 50,
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                BackColor = Color.LightGray
            };

            Contents.VScroll += Contents_VScroll;
            Contents.LinkClicked += Contents_LinkClicked;

            this.Controls.Add(LineNumbers);
            this.Controls.Add(Contents);

            Contents.BringToFront();
        }
        /**/

        void Contents_VScroll(object sender, EventArgs e)
        {
            int scrollPOSa = GetScrollPos(Contents.Handle, 1);

            Control P = this.Parent;
            while (P != null)
            {
                P.Text = string.Format("{0}", scrollPOSa);
                P = P.Parent;
            }

            //SendMessage(LineNumbers.Handle, EM_LINESCROLL, 0, scrollPOSa);
            int charCount = 0;
            int row = 0;
            while(row < LineNumbers.Lines.Length && row < scrollPOSa / 13){
                charCount += LineNumbers.Lines[row].Length;
            }
        }

        void LineNumbers_VScroll(object sender, EventArgs e)
        {
            int scrollPOSa = GetScrollPos(Contents.Handle, 1);
            int scrollPOSb = GetScrollPos(LineNumbers.Handle, 1);

            Control P = this.Parent;
            while (P != null)
            {
                P.Text = string.Format("{0}:{1}", scrollPOSb, scrollPOSa);
                P = P.Parent;
            }
        }


        void Contents_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string FilePath = e.LinkText;
            if (File.Exists(FilePath))
            {
                if (File.Exists(FilePath))
                {
                    System.Diagnostics.Process.Start("Notepad++.exe", FilePath);
                }
            }
        }

        public void Clear()
        {
            Contents.Clear();
            LineNumbers.Clear();
        }

        public void AddHilighter(string SearchString, bool isRegex, Color ForeColor, Color BackColor)
        {
            if (string.IsNullOrEmpty(SearchString)) { return; }
            Hilighters.Add(new HilightSearch(SearchString, isRegex, ForeColor, BackColor));
        }

        public void ClearHilighters()
        {
            Hilighters.Clear();
        }

        public DataTable HilightersAsTable()
        {
            DataTable output = new DataTable();
            output.Columns.Add(HilightSearch.Attributes.Search.ToString(), typeof(string));
            output.Columns.Add(HilightSearch.Attributes.isRegex.ToString(), typeof(bool));
            output.Columns.Add(HilightSearch.Attributes.foreColor.ToString(), typeof(Color));
            output.Columns.Add(HilightSearch.Attributes.backColor.ToString(), typeof(Color));
            output.Columns.Add(HilightSearch.Attributes.Sample.ToString(), typeof(string));

            foreach (HilightSearch HS in Hilighters)
            {
                DataRow newRow = output.NewRow();

                newRow[HilightSearch.Attributes.Search.ToString()] = HS.SearchString;
                newRow[HilightSearch.Attributes.isRegex.ToString()] = HS.isRegex;
                newRow[HilightSearch.Attributes.foreColor.ToString()] = HS.backColor;
                newRow[HilightSearch.Attributes.backColor.ToString()] = HS.foreColor;
                newRow[HilightSearch.Attributes.Sample.ToString()] = HS.SearchString;

                output.Rows.Add(newRow);
            }

            return output;
        }

        public void UpdateHiligters(DataTable Input)
        {
            if (!Input.Columns.Contains(HilightSearch.Attributes.Search.ToString())
                || !Input.Columns.Contains(HilightSearch.Attributes.isRegex.ToString())
                || !Input.Columns.Contains(HilightSearch.Attributes.foreColor.ToString())
                || !Input.Columns.Contains(HilightSearch.Attributes.backColor.ToString())
                || !Input.Columns.Contains(HilightSearch.Attributes.Sample.ToString()))
            {
                throw new Exception("Invalid input table.");
            }

            Hilighters.Clear();

            foreach (DataRow row in Input.Rows)
            {
                HilightSearch HS = new HilightSearch()
                {
                    SearchString = (string)row[HilightSearch.Attributes.Search.ToString()],
                    backColor = (Color)row[HilightSearch.Attributes.backColor.ToString()],
                    foreColor = (Color)row[HilightSearch.Attributes.foreColor.ToString()],
                    isRegex = (bool)row[HilightSearch.Attributes.isRegex.ToString()]
                };
                Hilighters.Add(HS);
            }
        }
    }

    #region unused - delete if you get the scrolling working without this
    public class SyncTextBox : TextBox
    {
        public SyncTextBox()
        {
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
        }
        public Control Buddy { get; set; }

        private static bool scrolling;   // In case buddy tries to scroll us
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Trap WM_VSCROLL message and pass to buddy
            if ((m.Msg == 0x115 || m.Msg == 0x20a) && !scrolling && Buddy != null && Buddy.IsHandleCreated)
            //if (m.Msg == 0x115 && !scrolling && Buddy != null && Buddy.IsHandleCreated)
            {
                scrolling = true;
                SendMessage(Buddy.Handle, m.Msg, m.WParam, m.LParam);
                scrolling = false;
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    }

    public class SyncRichTextBox : RichTextBox
    {
        public SyncRichTextBox()
        {
            this.Multiline = true;
            this.ScrollBars = RichTextBoxScrollBars.Vertical;
        }
        #region API Stuff
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        #endregion
        public int HorizontalPosition
        {
            get { return GetScrollPos((IntPtr)this.Handle, SB_HORZ); }
            set { SetScrollPos((IntPtr)this.Handle, SB_HORZ, value, true); }
        }

        public int VerticalPosition
        {
            get { return GetScrollPos((IntPtr)this.Handle, SB_VERT); }
            set { SetScrollPos((IntPtr)this.Handle, SB_VERT, value, true); }
        }

    }
    #endregion

    public class HilightSearch
    {
        public enum Attributes { Search, isRegex, foreColor, backColor, Sample };

        public string SearchString;
        public bool isRegex;

        public Color foreColor;
        public Color backColor;

        public HilightSearch(){}

        public HilightSearch(string SearchString, bool isRegex, Color ForeColor, Color BackColor)
        {
            this.SearchString = SearchString;
            this.isRegex = isRegex;
            this.foreColor = ForeColor;
            this.backColor = BackColor;
        }

    }

}
