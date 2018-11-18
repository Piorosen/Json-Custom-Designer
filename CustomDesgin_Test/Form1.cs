using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomDesgin_Test
{
    public partial class Form1 : Form
    {
        CustomDesign.Observe observer = new CustomDesign.Observe();
        public Form1()
        {
            InitializeComponent();

            observer.Add(textBox1);
            observer.Add(textBox2);

            var t = textBox1.GetType().GetProperty("Text");
            observer.Change();
        }
    }
}
