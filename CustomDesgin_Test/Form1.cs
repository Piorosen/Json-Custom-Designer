using CustomDesign;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CustomDesgin_Test
{
    public partial class Form1 : Form
    {
        Observe observer = new Observe();
        public Form1()
        {
            InitializeComponent();

            observer.Add(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = observer.GetField(observer[0], textBox3.Text, BindingFlags.Instance | BindingFlags.NonPublic);
            var t = observer.GetProperty(p.Item2, "Text");
            t.Item1.SetValue(p.Item2.Value, textBox4.Text);
        }
    }
}
