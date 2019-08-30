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
    public partial class crudFrm : Form
    {
        DataTable dt = new DataTable();
        public crudFrm()
        {
            InitializeComponent();
            init();


        }

        private void init()
        {

            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AllowUserToResizeRows = true;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewCheckBoxColumn columncb = new DataGridViewCheckBoxColumn();
            columncb.HeaderText = "选择";
            columncb.Name = "cb_check";
            columncb.TrueValue = true;
            columncb.FalseValue = false;
            columncb.DataPropertyName = "IsChecked";
            dataGridView1.Columns.Insert(0, columncb);

            DataGridViewComboBoxColumn cellComboBox = new DataGridViewComboBoxColumn();
            cellComboBox.HeaderText = "combobox";
            cellComboBox.Name = "combobox";
            bindDataGridCombox(cellComboBox, new Dictionary<int, string>() { { 1, "ddd" }, { 2, "55" } });
            dataGridView1.Columns.Insert(1, cellComboBox);

            

            DataColumn dc = new DataColumn();
            dt.Columns.Add("column0", typeof(String));
            dt.Columns.Add("column1", typeof(DateTime));
            dt.Rows.Add("张三ddddddddddddddddddddddddddddddddddd", DateTime.Now);
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;

        }
       private void setDataGridViewWidth(DataGridView dgv)
        {
            int width = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                width += dgv.Columns[i].Width;
            }
            if (width > dgv.Size.Width)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void setDataGridViewWidthWeight(DataGridView dgv, Dictionary<int, int> colWidthWeight)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].FillWeight = colWidthWeight[i];
            }
        }

        public void bindDataGridCombox(DataGridViewComboBoxColumn column, Dictionary<int, string> mapData)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("value", typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(new DataColumn("id", typeof(int)));
            DataRow dr;
            foreach(var item in mapData)
            {
                dr = dt.NewRow();
                dr["value"] = item.Value;
                dr["id"] = item.Key;
                dt.Rows.Add(dr);
            }
            column.DataSource = dt; 
            column.DisplayMember = "value";
            column.ValueMember = "id";

        }

        private void test()
        {
            //创建一个DataTable
            DataTable dtDemo = GetDataTable();
            DataRow myDr;

            //Detached row:该行已经被创建，但不属于任何DataRowCollection
            myDr = dtDemo.NewRow();
            Console.WriteLine("New Row状态:" + myDr.RowState);
            //将新创建的行添加到DataTable中
            dtDemo.Rows.Add(myDr);
            Console.WriteLine("Add Row状态:" + myDr.RowState);

            #region Add之后直接使用Delete，RowState变为Detached,  行数-1
            //myDr.Delete();
            //Console.WriteLine("myDr的状态：" + myDr.RowState);
            //Console.WriteLine("dtDemo的行数:" + dtDemo.Rows.Count.ToString()); 
            #endregion

            dtDemo.AcceptChanges();
           Console.WriteLine("AcceptChanges状态:" + myDr.RowState);
            //修改
            myDr["Name"] = "Tom";
            Console.WriteLine("Modified状态:" + myDr.RowState);
            Console.WriteLine("删除前的行数:" + dtDemo.Rows.Count.ToString());

            #region 非Added状态下使用Delete，RowState变为Deleted,  行数不变
            myDr.Delete();
            Console.WriteLine("Deleted状态:" + myDr.RowState);
            Console.WriteLine("删除后的行数:" + dtDemo.Rows.Count.ToString());
            #endregion

            //这时myDr的状态变为Detached
            Console.WriteLine("myDr的状态：" + myDr.RowState);
            //重新加入myDr，这时状态变为Added
            myDr.AcceptChanges();
            dtDemo.Rows.Add(myDr);
            Console.WriteLine("myDr的状态：" + myDr.RowState);
            //取消删除行
            //dtDemo.RejectChanges();
            Console.ReadKey();
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable("MyTable");
            DataColumn dc = new DataColumn("Name", typeof(string));
            dt.Columns.Add(dc);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr.RowState);
                
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            }
            else
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == "combobox")
            {
                ((ComboBox)e.Control).SelectedIndexChanged +=
                                    new EventHandler(ComboBox_SelectedIndexChanged);
            }
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == "column0")
            {
                TextBox t = e.Control as TextBox;
                t.Multiline = true;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == "combobox")
            {

                string str = ((ComboBox)sender).Text.ToString();
                //绑定第二个COMBOX  
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("id"));
                dt.Columns.Add(new DataColumn("text"));

                for (int i = 0; i < 20; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = str + i;
                    dr[1] = str + i;
                    dt.Rows.Add(dr);
                }
                ((DataGridViewComboBoxCell)this.dataGridView1.CurrentRow.Cells[4]).DataSource = dt;
                ((DataGridViewComboBoxCell)this.dataGridView1.CurrentRow.Cells[4]).DisplayMember = "text";
                ((DataGridViewComboBoxCell)this.dataGridView1.CurrentRow.Cells[4]).ValueMember = "id";
                ((ComboBox)sender).SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);

            }
        }
    }
}
