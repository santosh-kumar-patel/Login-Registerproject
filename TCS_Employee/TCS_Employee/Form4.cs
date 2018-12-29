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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        Form1 m;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter the email address");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("enter the user ID");
                textBox2.Focus();
            }
            else
            {
                try
                {
                    cmd.CommandText = "select * from register where email='" + textBox1.Text + "' and id='" + textBox2.Text + "'";
                    con.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Hello  " + dr[1].ToString() + "\n\nYour password is " + dr[5].ToString() , "TBS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m = new Form1();
                        m.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("invalid email address or User ID");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=NETDEVELOPER-PC;Initial Catalog=TBS;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
    }
}
