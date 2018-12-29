using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TCS_Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 form2;
        Form3 form3;
        Form4 form4;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string t;
        private void button3_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
           // this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=NETDEVELOPER-PC;Initial Catalog=TBS;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
          
        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter the admin name");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("enter the password name");
                textBox2.Focus();
            }
            else 
            {
                cmd.CommandText = "select name, password from register where name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                con.Open();
                dr= cmd.ExecuteReader();

                if (dr.Read())
                {
                   MessageBox.Show("login successfully");
                  //  if (a == 1)
                    //{
                  t = textBox1.Text;
                        form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    
                    //}
                }
                else
                {
                    MessageBox.Show("invalid admin or password");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                con.Close();
                
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.Show();
        }
        
        
    }
}
