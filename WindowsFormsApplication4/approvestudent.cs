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
    public partial class approvestudent : Form
    {
        int f = 0;
        public approvestudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con5 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con5.Open();
            SqlCommand cmd = new SqlCommand("select * from users where userid='" + textBox1.Text + "' and uname = '"+textBox2.Text+"' ", con5);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                f = 1;
            }
            else
            {
                MessageBox.Show("Invalid Student Details");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            dr.Close();
            if (f == 1)
            {
                SqlCommand cmd1 = new SqlCommand("update users set status='Approved' where userid='" + textBox1.Text + "' and uname='" + textBox2.Text + "' ", con5);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Student Approved");
                button2_Click(sender, e);
            }
            con5.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffs a = new staffs();
            a.Show();
            this.Hide();
        }

        private void approvestudent_Load(object sender, EventArgs e)
        {

        }
    }
}
