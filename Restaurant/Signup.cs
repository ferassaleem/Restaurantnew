using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Restaurant
{
    public partial class Signup : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";
        public Signup()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Close();
            Login login = new Login();
            login.Show();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (rdbadmin.Checked == true)
            {
                SqlConnection conn = new SqlConnection(data);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Admin values(@username, @password, @name, @address, @phone, @email  )", conn);
                cmd.Parameters.AddWithValue("@username", txtname.Text);
                cmd.Parameters.AddWithValue("@password", txtusername.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Add Admin is successfully");
            }
            else
            {
                SqlConnection conn = new SqlConnection(data);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Cashir values(@username, @password, @name, @address, @phone, @email)", conn);
                cmd.Parameters.AddWithValue("@username", txtname.Text);
                cmd.Parameters.AddWithValue("@password", txtusername.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Add Cashir is successfully");
            }
        }
    }
}
