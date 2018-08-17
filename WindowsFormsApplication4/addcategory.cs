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
    public partial class addcategory : Form
    {
        public addcategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con6 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con6.Open();
            SqlCommand cmd = new SqlCommand("insert into list values('" + textBox1.Text + "')", con6);
            cmd.ExecuteNonQuery();
            con6.Close();
            MessageBox.Show("Category Added Successfully");
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void addcategory_Load(object sender, EventArgs e)
        {

        }
    }
}
