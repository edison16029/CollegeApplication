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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con5 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con5.Open();
            SqlCommand cmd = new SqlCommand("insert into users values('" + textBox1.Text + "','" + textBox2.Text + "','Not Approved')", con5);
            cmd.ExecuteNonQuery();
            con5.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}
