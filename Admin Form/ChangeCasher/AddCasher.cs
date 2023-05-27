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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project.Admin_Form
{
    public partial class AddCasher : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public AddCasher()
        {
            InitializeComponent();
            GetAllData();
        }

        private void btnClose_Click(object sender, EventArgs e)
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
            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Casher values(@Name, @UserName, @Password, @Phone, @Address)", conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", int.Parse(txtPhone.Text));
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
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
