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
    public partial class UpdateAdmin : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public UpdateAdmin()
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
            SqlConnection con = new SqlConnection(Data);
            con.Open();
            string update = "Update Admin Set  Name=@Name, UserName=@UserName, Password=@Password, Phone=@Phone, Address=@Address"
                + " where ID=@ID ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", int.Parse(txtPhone.Text));
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Admin", con);
            con.Open();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
