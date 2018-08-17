using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class student : Form
    {
        int sid;
        string sname;
        public student()
        {
            InitializeComponent();
        }


        public student(int i,string n) : this()
        {
            sid = i;
            sname = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exam a = new exam(sid,sname);
            a.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prog a = new prog(sid,sname);
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void student_Load(object sender, EventArgs e)
        {

        }
    }
}
