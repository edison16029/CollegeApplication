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
    public partial class exam : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
        int qno = new int();
        int correct = new int();
        bool chosen = new bool();
        int maxqno = new int();
        int sid;
        string sname;
        public exam()
        {
            InitializeComponent();
            qno = 1;
            correct = 0;
            chosen = true;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from list", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.SelectedItem = null;
            
            con.Close();
        }

        public exam(int i,string s) : this()
        {
            sid = i;
            sname = s;
        }
    

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(qno) from questions", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                maxqno = (int) dr.GetValue(0);
                
            }
            con.Close();

            textBox1.Text = sid.ToString();
            textBox2.Text = sname;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where userid='" + textBox1.Text + "' and uname='"+textBox2.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                MessageBox.Show("Invalid User");
                goback();
            }
            con.Close();

           while ( chooseques() == false || qno > maxqno )
            {
               // MessageBox.Show("Inside While Loop");
                qno++;
            }

            panel1.Visible = true;

        }

        public void goback()
        {
            student a = new student(sid,sname);
            a.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkanswer();
            qno++;
            while ( chooseques()==false && qno <= maxqno)
            {
                qno++;
            }

            if (qno > maxqno)
            {
                MessageBox.Show("Exam Over!"+" Your Score : "+correct.ToString());
                SqlConnection con3 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
                con3.Open();
                SqlCommand cmd = new SqlCommand("insert into category values('" + textBox1.Text + "','" + comboBox1.Text + "','" + correct + "')", con3);
                cmd.ExecuteNonQuery();
                con3.Close();
                goback();
            }
        

        }

        public bool chooseques()
        {
            SqlConnection con5 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con5.Open();
            SqlCommand cmd1 = new SqlCommand("select * from questions where qno='" + qno + "' ", con5);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                if (comboBox1.Text == dr.GetString(1))
                {
                    // MessageBox.Show("inside if");
                    label4.Text = dr.GetValue(0).ToString();
                    label5.Text = dr.GetString(2).ToString();

                    radioButton1.Text = dr.GetString(3).ToString();
                    radioButton2.Text = dr.GetString(4).ToString();
                    radioButton3.Text = dr.GetString(5).ToString();
                    radioButton4.Text = dr.GetString(6).ToString();
                    con5.Close();
                    return true;
                }
                else
                {
                    //MessageBox.Show("inside else");
                    con5.Close();
                    return false;
                }
            }
            con5.Close();
            return true;
        }


        
        public void checkanswer()
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con2.Open();
            SqlCommand cmd1 = new SqlCommand("select * from questions where qno='" + qno + "'", con2);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                if (radioButton1.Checked && dr.GetString(3) == dr.GetString(7))
                    correct++;
                if (radioButton2.Checked && dr.GetString(4) == dr.GetString(7))
                    correct++;
                if (radioButton3.Checked && dr.GetString(5) == dr.GetString(7))
                    correct++;
                if (radioButton4.Checked && dr.GetString(6) == dr.GetString(7))
                    correct++;
            }
            
            con2.Close();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            //MessageBox.Show("correct is : " + correct.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            student a = new student(sid,sname);
            a.Show();
            this.Hide();
        }
    }
}
