using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCS_Employee
{    public partial class Form3 : Form
    {
    Form1 fm = new Form1();
        public Form3()
        {
            InitializeComponent();
        }


        int next=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Left += 2;
            if (label2.Left >this.Width)
            {
                label2.Left = 0 - label2.Width;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to "+Form1.t;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Close();
        }

           }
}
