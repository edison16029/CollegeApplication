using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class studentLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
        int password;
        public studentLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select userid from users where uname='" + textBox1.Text + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                password = (int)dr.GetValue(0);
                if (password == int.Parse(textBox2.Text) )
                {
                    //student a = new student();
                   student a = new student(password,textBox1.Text);
                    a.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password Does Not Match");
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid Student Name");
            }
            con.Close();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            reg a = new reg();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void studentLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
