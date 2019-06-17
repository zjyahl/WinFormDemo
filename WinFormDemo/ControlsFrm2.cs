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
    public partial class ControlsFrm2 : Form
    {
        public ControlsFrm2()
        {
            InitializeComponent();

           
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            Panel t = new Panel();
            t.Width = 100;
            t.Height = 75;
            t.Controls.Add(button6);
            //   button6.Dock = DockStyle.Left;
            t.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(t);

           // button2.Width = 200;
           button1.Anchor = AnchorStyles.Right;//DockStyle.Right
            button3.Anchor = AnchorStyles.Left | AnchorStyles.Right; //DockStyle.Fill
            textBox1.Multiline = true;
            textBox1.Dock = DockStyle.Fill;

            button4.Dock = DockStyle.Left;
           // button4.Dock = DockStyle.Top;

        }
    }
}
