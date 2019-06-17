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
    public partial class MainForm : Form
    {
        ChildForm1 childFrm1;
        public MainForm()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            panel1.Controls.Clear();
            childFrm1 = new ChildForm1();
            childFrm1.TopLevel = false;
           // childFrm1.Dock = DockStyle.Top;
           childFrm1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(childFrm1);
            childFrm1.Show();
            //panel1.AutoSizeMode = AutoSizeMode.GrowOnly;
            panel1.AutoScroll = true;
            panel1.AutoSize = false;

        }
    }
}
