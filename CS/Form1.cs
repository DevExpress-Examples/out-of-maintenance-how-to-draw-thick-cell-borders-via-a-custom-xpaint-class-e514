using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellBorder {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
        }
    }
}
