using System.Drawing;

namespace Searcher
{
    public class HilightSearch
    {
        public enum Attributes { Search, IsRegex, ForeColor, BackColor, Sample }

        public string SearchString;
        public bool IsRegex;

        public Color ForeColor;
        public Color BackColor;
    }
}
