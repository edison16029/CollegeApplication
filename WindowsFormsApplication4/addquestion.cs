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
    public partial class addquestion : Form
    {
        int maxqno = new int();
        public addquestion()
        {
            InitializeComponent();
            maxqno = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void addquestion_Load(object sender, EventArgs e)
        {
            SqlConnection con7 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con7.Open();
            SqlCommand cmd = new SqlCommand("select max(qno) from questions", con7);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                maxqno = (int)dr.GetValue(0);

            }
            con7.Close();
            maxqno++;
            textBox1.Text = maxqno.ToString();
            textBox1.Enabled = false;
            con7.Open();
            SqlCommand cmd1 = new SqlCommand("select * from list", con7);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            //comboBox1.SelectedItem = null;

            con7.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con7 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con7.Open();
            SqlCommand cmd = new SqlCommand("insert into questions values('" + maxqno + "','"+comboBox1.Text+"','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", con7);
            cmd.ExecuteNonQuery();
            con7.Close();
            MessageBox.Show("Question Added");
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffs a = new staffs();
            a.Show();
            this.Hide();
        }
    }
}
