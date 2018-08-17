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
    public partial class staffLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
        string password;
        public staffLogin()
        {
            InitializeComponent();
        }

        private void staffLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select pwd from staff where sname='" + textBox1.Text + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                password = (string)dr.GetValue(0);
                if (password == textBox2.Text)
                {
                    staffs a = new staffs();
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
                MessageBox.Show("Invalid Staff Name");
            }
            con.Close();
        }
    }
}
