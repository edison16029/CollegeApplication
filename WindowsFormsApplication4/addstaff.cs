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
    public partial class addstaff : Form
    {
        public addstaff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con6 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con6.Open();
            SqlCommand cmd = new SqlCommand("insert into staff values('" + textBox1.Text + "','" + textBox2.Text + "')", con6);
            cmd.ExecuteNonQuery();
            con6.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}
