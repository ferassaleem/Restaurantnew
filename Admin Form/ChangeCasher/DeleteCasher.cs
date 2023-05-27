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

namespace project.Admin_Form
{
    public partial class DeleteCasher : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public DeleteCasher()
        {
            InitializeComponent();
            GetAllData();
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string delete = "Delete From Casher Where ID=@ID";
            SqlConnection con = new SqlConnection(Data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
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
    }
}
