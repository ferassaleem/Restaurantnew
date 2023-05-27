using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Admin_Form.ChangeSale
{
    public partial class AddSale : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public AddSale()
        {
            InitializeComponent();
            GetAllData();
            load();
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
            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Sales values( @FoodName, @Price, @DateSale)", conn);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@FoodName", listBox1.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@DateSale", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
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
        void load()
        {
            SqlConnection con = new SqlConnection(Data);
            con.Open();
            string query = "SELECT Name,Price FROM Food";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlConnection conn = new SqlConnection(Data);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Name"].ToString());
            }
            con.Close();
        }
    }
}
