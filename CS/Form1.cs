using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using DevExpress.Utils.Paint;

namespace CellBorder
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(460, 264);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(460, 264);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            ThickFocusRectHelper.SetGraphics();
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
		}
	}

    static class ThickFocusRectHelper {
		public static void SetGraphics() {
			FieldInfo fi = typeof(XPaint).GetField("graphics", BindingFlags.Static | BindingFlags.NonPublic);
            XPaint xPaint = null;

            switch(Environment.OSVersion.Platform) {
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    xPaint = new MyXPaint();
                    break;
                default:
                    xPaint = new MyXPaintMixed();
                    break;
            }
            fi.SetValue(null, xPaint);
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
			if(!CanDraw(r)) return;
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r);
		}
	}
    public class MyXPaintMixed : XPaintMixed {
        public override void DrawFocusRectangle(Graphics g, Rectangle r, Color foreColor, Color backColor) {
            if(!CanDraw(r)) return;
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r);
        }
    }

}
