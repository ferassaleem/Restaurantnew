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

namespace project.Admin_Form
{
    public partial class Update : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";
        public Update()
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
            SqlConnection con = new SqlConnection(Data);
            con.Open();
            string update = "Update Food Set  Name=@Name, Price=@Price" + " where ID=@ID ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
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
