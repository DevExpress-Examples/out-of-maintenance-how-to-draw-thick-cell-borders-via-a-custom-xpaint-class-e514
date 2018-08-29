using CellBorder.FocusRectHelper;
using System;
using System.Windows.Forms;

namespace CellBorder {
    public static class Program {     
        [STAThread]
        static void Main() {
            ThickFocusRectHelper.SetupCustomPainter();
            Application.Run(new Form1());
        }
    }
}
