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
    public partial class performancecheck : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
        int i;
        public performancecheck()
        {
            i = 0;
            InitializeComponent();
        }

        public performancecheck(int x) : this()
        {
            i = x ;
        }
        private void performancecheck_Load(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select c.userid,u.uname,category,sum(score) total from users u, category c where u.userid = c.userid group by c.userid, uname, category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
          //  button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            staffs b = new staffs();
            if (i == 0)
            {
                a.Show();
                this.Hide();
            }
            else
            {
                b.Show();
                this.Hide();
            }
        }
    }
}
