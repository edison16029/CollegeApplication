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
    public partial class adminLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0A88PDVH\SQLEXPRESS;Database=college;Integrated Security = True");
        string password;
        public adminLogin()
        {
            InitializeComponent();
        }

        private void adminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select pwd from admin where name='" + textBox1.Text + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                password =(string) dr.GetValue(0);
                if (password == textBox2.Text)
                {
                    admin a = new admin();
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
                MessageBox.Show("Invalid Admin Name");
            }
            con.Close();
        }
    }
}
