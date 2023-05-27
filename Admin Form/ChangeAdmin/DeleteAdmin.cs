using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Admin_Form.ChangeAdmin
{
    public partial class DeleteAdmin : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public DeleteAdmin()
        {
            InitializeComponent();
            GetAllData();
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string delete = "Delete From Admin Where ID=@ID";
            SqlConnection con = new SqlConnection(Data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
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
    }
}
