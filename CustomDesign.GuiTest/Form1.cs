using CustomDesign;
using CustomDesign.Core;
using System;

using System.Reflection;
using System.Windows.Forms;

namespace CustomDesign.GuiTest
{
    public partial class Form1 : Form
    {
        readonly CustomDesign.Core.CustomDesign design = new CustomDesign.Core.CustomDesign();

        public void Write(object sender, EventArgs e)
        {
            Console.WriteLine("Test!!");
        }

        public Form1()
        {
            InitializeComponent();
            design.Observe.Add(this, Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            design.LoadJson(textBox5.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
