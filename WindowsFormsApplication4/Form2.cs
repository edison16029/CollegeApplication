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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 testform = new Form3();
            testform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prog progress = new prog();
            progress.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg a = new reg();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}
