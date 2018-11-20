﻿using CustomDesign;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CustomDesgin_Test
{
    public partial class Form1 : Form
    {
        CustomDesign.CustomDesign design = new CustomDesign.CustomDesign();

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            design.Observe.Add(this, this.Name);
            design.LoadJson(@"C:\Users\aoika\Desktop\git\Custom-Design-WinForm\CustomDesign_Test\JsonFile.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}