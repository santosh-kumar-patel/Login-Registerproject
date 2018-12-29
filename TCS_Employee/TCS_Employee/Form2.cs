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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            writeonimage();
        }

        private void writeonimage()
        {
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Lucida Sans Unicode",20,FontStyle.Bold,GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString("Register the page , if you register this page,you \nwill find a ID.\nThis ID is very helpful for you to find the\nforgotten password .\nAnd after that you will be able to find\nthis service.", font, Brushes.White, new Point(30, 200));
            this.pictureBox1.Image = image;
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        Form1 m;
        string id;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter the name");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("enter the address name");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("enter the phone no");
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("enter the email");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("create the password");
                textBox5.Focus();
            }
           
            else if (textBox5.Text == textBox6.Text)
            {
                try
                {
                    cmd.CommandText = "insert into register (name,address,phone_no,email,password) values('" + textBox1.Text + "','" + textBox2.Text + "'," + long.Parse(textBox3.Text) + ",'" + textBox4.Text + "','" + textBox5.Text + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int a = (int)MessageBox.Show("Data has been inserted successfully", "TBS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (a == 1)
                    {

                        for (int k = 1; k > 0; k++)
                        {
                            Random rand = new Random();
                            int num = rand.Next(22201 + k, 100000 + k);
                            id = "TBS-" + num;
                            cmd.CommandText = "select * from register where id='" + id + "'";
                            con.Open();
                            dr = cmd.ExecuteReader();
                            if (!dr.Read())
                            {
                                con.Close();
                                break;
                            }
                            con.Close();
                        }
                        cmd.CommandText = "update register set id='" + id + "' where name='"+textBox1.Text+"' and password='"+textBox6.Text+"'" ;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Hello  " + textBox1.Text + "\n\nYour ID is " + id, "TBS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        m = new Form1();
                        m.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("confirm password is incorrect");
                textBox6.Clear();
                textBox6.Focus();
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            
            m = new Form1();
            m.Show();
            this.Close(); 
                       
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=NETDEVELOPER-PC;Initial Catalog=TBS;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 14))
    {
        e.Graphics.DrawString("Hello .NET Guide!", myFont, Brushes.Green, new Point(2, 2));
    }
        }
    }
}     
