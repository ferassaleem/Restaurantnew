using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Admin_Form
{
    public partial class Add : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public Add()
        {
            InitializeComponent();
            GetAllData();
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
            ManageFood manageFood = new ManageFood();
            AHomePage aHomePage = new AHomePage("");
            manageFood.TopLevel = false;
            manageFood.Dock = DockStyle.Fill;
            aHomePage.panel3.Controls.Add(manageFood);
            manageFood.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Food values(@Name, @Price)", conn);
            //cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
        }
        void GetAllData()
        {
            SqlConnection con = new SqlConnection(Data);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Food", con);
            con.Open();
            adapter.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
