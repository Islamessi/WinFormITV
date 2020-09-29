using System;
using System.Windows.Forms;

namespace TestWinForm
{
    [Serializable]
    public class FormsData
    {
        public int Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Widht { get; set; }

        public FormWindowState WindowState { get; set; }
    }
}
