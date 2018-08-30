using DevExpress.Utils.Paint;
using System;
using System.Drawing;
using System.Reflection;

namespace CellBorder.FocusRectHelper {
    static class ThickFocusRectHelper {
        public static void SetupCustomPainter() {
            XPaint.CreateCustomPainter(new MyXPaint());
        }

        public static void DrawThickFocusRectangle(Graphics g, Rectangle r) {
            Brush hb = Brushes.Black;
            g.FillRectangle(hb, new Rectangle(r.X, r.Y, 2, r.Height - 2)); // left
            g.FillRectangle(hb, new Rectangle(r.X, r.Y, r.Width - 2, 2));  // top
            g.FillRectangle(hb, new Rectangle(r.Right - 2, r.Y, 2, r.Height - 2)); // right
            g.FillRectangle(hb, new Rectangle(r.X, r.Bottom - 2, r.Width, 2)); // bottom
        }
    }
    public class MyXPaint : XPaint {
        public override void DrawFocusRectangle(Graphics g, Rectangle r, Color foreColor, Color backColor) {
            if (!CanDraw(r)) return;
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r);
        }
    }
    public class MyXPaintMixed : XPaintMixed {
        public override void DrawFocusRectangle(Graphics g, Rectangle r, Color foreColor, Color backColor) {
            if (!CanDraw(r)) return;
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r);
        }
    }
}
