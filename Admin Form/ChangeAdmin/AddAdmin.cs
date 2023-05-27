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

namespace project.Admin_Form.ChangeAdmin
{
    public partial class AddAdmin : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public AddAdmin()
        {
            InitializeComponent();
            GetAllData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            ManageAdmin manageAdmin = new ManageAdmin();
            AHomePage aHomePage = new AHomePage("");
            manageAdmin.TopLevel = false;
            manageAdmin.Dock = DockStyle.Fill;
            aHomePage.panel3.Controls.Add(manageAdmin);
            manageAdmin.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Admin values(@Name, @UserName, @Password, @Phone, @Address)", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
        }
        void GetAllData()
        {
            SqlConnection con = new SqlConnection(Data);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Admin", con);
            con.Open();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
