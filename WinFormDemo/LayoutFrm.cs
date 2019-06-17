using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class LayoutFrm : Form
    {
        
        public LayoutFrm()
        {
            InitializeComponent();
           // panel1.BorderStyle = BorderStyle.FixedSingle;
           // flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
           // tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            initComponen();
            resizeComponen();

        }

        private void initComponen()
        {
            this.Width = 900;
            this.Height = 600;
            flowLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            flowLayoutPanel2.AutoSize = true;

            flowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            flowLayoutPanel1.AutoSize = true;

        }

        private void resizeComponen()
        {
            panel1.Location = new Point((this.Width - panel1.Width) / 2, 10);
         
        }

        private void LayoutFrm_Resize(object sender, EventArgs e)
        {
            resizeComponen();
        }
    }
}
