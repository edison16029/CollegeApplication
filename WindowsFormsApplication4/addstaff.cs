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
            SqlCommand cmd = new SqlCommand("insert into staff values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "' ,'" + textBox3.Text + "', '" + textBox4.Text + "','"+ textBox5.Text+"')", con6);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Staff Added Successfully");
            con6.Close();
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void addstaff_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
