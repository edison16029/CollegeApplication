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
    public partial class prog : Form
    {
        int sid;
        string sname;
        public prog()
        {
            InitializeComponent();
        }

        public prog(int i,string s) : this()
        {
            sid = i;
            sname = s;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            student a = new student(sid,sname);
            a.Show();
            this.Hide();
        }

        private void prog_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(sid + " " + sname);
            SqlConnection con4 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con4.Open();
            SqlCommand cmd = new SqlCommand("select * from category where userid = '"+sid+"'", con4);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con4.Close();

        }
    }
}
