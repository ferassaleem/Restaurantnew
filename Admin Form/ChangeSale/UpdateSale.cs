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
    public partial class UpdateSale : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public UpdateSale()
        {
            InitializeComponent();
            GetAllData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            ManageSales manageSales = new ManageSales();
            AHomePage aHomePage = new AHomePage("");
            manageSales.TopLevel = false;
            manageSales.Dock = DockStyle.Fill;
            aHomePage.panel3.Controls.Add(manageSales);
            manageSales.Show();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Data);
            con.Open();
            string update = "Update Sales Set  FoodName=@FoodName, Price=@Price, DateSale=@DateSale" + " where ID=@ID ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@FoodName", txtName.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@DateSale", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
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
    }
}
