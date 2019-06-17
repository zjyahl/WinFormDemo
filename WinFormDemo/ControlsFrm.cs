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
    public partial class ControlsFrm : Form
    {
        public ControlsFrm()
        {
            InitializeComponent();
            textBox1.Multiline = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;
            //label1.Dock = DockStyle.Fill;
            //textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom ;
            //textBox1.Dock =  DockStyle.Fill;
            createComponent(2);

        }
        private void createComponent(int num)
        {
            int parentWidth = 150;
            int parentHeight = 170;
            int scanSize = 18;
            for (int i =1; i<=num; i++)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Name = "groupCollect"+i;
                groupBox.Width = parentWidth;
                groupBox.Height = parentHeight;
                groupBox.Text = "ddd";
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Name = "panelCollect" + i;
                panel.FlowDirection = FlowDirection.TopDown;
                panel.Width = parentWidth - scanSize;
                panel.Height = parentHeight - scanSize;
                panel.Padding = new Padding(0, 0, 0, 0);
                Button btn = new Button();
                btn.Name = "fetchBtn" + i;
                btn.Text = "Fetch";
                DataGridView dgView = new DataGridView();
                btn.Margin = new Padding(40, 10, 0, 0);
                dgView.Height = panel.Width;
                panel.Controls.Add(dgView);
                panel.Controls.Add(btn);
                panel.Dock = DockStyle.Bottom;
                groupBox.Margin = new Padding(0,0,50,0);

                groupBox.Controls.Add(panel);
                flowLayoutPanel1.Controls.Add(groupBox);
        
            }
        }
    }
}
