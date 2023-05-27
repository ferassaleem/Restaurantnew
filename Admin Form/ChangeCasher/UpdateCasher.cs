﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Admin_Form
{
    public partial class UpdateCasher : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public UpdateCasher()
        {
            InitializeComponent();
            GetAllData();
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
            ManageCasher manageCasher = new ManageCasher();
            AHomePage aHomePage = new AHomePage("");
            manageCasher.TopLevel = false;
            manageCasher.Dock = DockStyle.Fill;
            aHomePage.panel3.Controls.Add(manageCasher);
            manageCasher.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Data);
            con.Open();
            string update = "Update Casher Set  Name=@Name, UserName=@UserName, Password=@Password, Phone=@Phone, Address=@Address"
                + " where ID=@ID ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", Convert.ToInt64(txtPhone.Text));
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
        }
        void GetAllData()
        {
            SqlConnection con = new SqlConnection(Data);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Casher", con);
            con.Open();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
