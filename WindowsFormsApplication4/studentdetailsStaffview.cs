﻿using System;
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
    public partial class studentdetailsStaffview : Form
    {
        public studentdetailsStaffview()
        {
            InitializeComponent();
        }

        private void studentdetailsStaffview_Load(object sender, EventArgs e)
        {
            SqlConnection con4 = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
            con4.Open();
            SqlCommand cmd = new SqlCommand("select * from users", con4);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con4.Close();
            //  button1_Click(sender, e);
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            staffs a = new staffs();
            a.Show();
            this.Hide();
        }
    }
}
