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
   
    public partial class BindFrm : Form
    {
        class TestCls : INotifyPropertyChanged
        {
            private int? valueInt;
            private double valueFloat;
            private bool valueBool;
            private string valueStr;
            private DateTime valueTime;

            public event PropertyChangedEventHandler PropertyChanged;

            private void notifyView(string filedName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler.Invoke(this, new PropertyChangedEventArgs(filedName));
                }
            }

            public int? ValueInt
            {
                get
                {
                    return valueInt;
                }

                set
                {
                    valueInt = value;
                    notifyView("ValueInt");
                }
            }

            public double ValueFloat
            {
                get
                {
                    return valueFloat;
                }

                set
                {
                    valueFloat = value;
                    notifyView("ValueFloat");
                }
            }

            public bool ValueBool
            {
                get
                {
                    return valueBool;
                }

                set
                {
                    valueBool = value;
                    notifyView("ValueBool");
                }
            }

            public string ValueStr
            {
                get
                {
                    return valueStr;
                }

                set
                {
                    valueStr = value;
                    notifyView("ValueStr");
                }
            }

            public DateTime ValueTime
            {
                get
                {
                    return valueTime;
                }

                set
                {
                    valueTime = value;
                    notifyView("ValueTime");
                }
            }
        }

        private TestCls data = null;
        public BindFrm()
        {
            InitializeComponent();
            test();
        }

        private void test()
        {
            data = new TestCls() { ValueInt = 1 };
            Binding bind = new Binding("Text", data, "ValueInt", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox1.DataBindings.Add(bind);

            Binding bind2 = new Binding("checked", data, "ValueInt", true, DataSourceUpdateMode.OnPropertyChanged);
            bind2.Format += new ConvertEventHandler(dataToView);
            bind2.Parse += new ConvertEventHandler(viewToData);

            Binding bind3 = new Binding("checked", data, "ValueInt", true, DataSourceUpdateMode.OnPropertyChanged);
            bind3.Format += new ConvertEventHandler(dataToView);
            bind3.Parse += new ConvertEventHandler(viewToData);

            radioButton1.DataBindings.Add(bind2);
            radioButton2.DataBindings.Add(bind3);
        }
        void dataToView(object sender, ConvertEventArgs e)
        {
            Binding t = sender as Binding;
            RadioButton cmt = t.BindableComponent as RadioButton;
            if(cmt == radioButton1)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = true;
                }
                if (e.Value.ToString() == "2")
                {
                    e.Value = false;
                }
            }
            if (cmt == radioButton2)
            {
                if (e.Value.ToString() == "2")
                {
                    e.Value = true;
                }
                if (e.Value.ToString() == "1")
                {
                    e.Value = false;
                }
            }

        }
        void viewToData(object sender, ConvertEventArgs e)
        {
            Binding t = sender as Binding;
            RadioButton cmt = t.BindableComponent as RadioButton;
            e.Value = e.Value.ToString().Trim();
            if (cmt == radioButton1)
            {
                if (e.Value.ToString() == "False")
                {
                    e.Value = 2;
                }
                if (e.Value.ToString() == "True")
                {
                    e.Value = 1;
                }
            }
            if (cmt == radioButton2)
            {
                if (e.Value.ToString() == "False")
                {
                    e.Value = 1;
                }
                if (e.Value.ToString() == "True")
                {
                    e.Value = 2;
                }
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(data.ValueInt);
        }
    }
}
