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

namespace project.Admin_Form.ChangeSale
{
    public partial class DeleteSale : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public DeleteSale()
        {
            InitializeComponent();
            GetAllData();
        }

        void GetAllData()
        {
            SqlConnection con = new SqlConnection(Data);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Sales", con);
            con.Open();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string delete = "Delete Sales Where ID=@ID";
            SqlConnection con = new SqlConnection(Data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
            ManageSales manageSales = new ManageSales();
            AHomePage aHomePage = new AHomePage("");
            manageSales.TopLevel = false;
            manageSales.Dock = DockStyle.Fill;
            aHomePage.panel3.Controls.Add(manageSales);
            manageSales.Show();
        }
    }
}
