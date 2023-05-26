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

namespace Restaurant.Manager.Reciptions
{
    public partial class ChangeCashir : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public ChangeCashir()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            string update = "UPDATE Cashir SET  username=@username, password=@password, phone=@phone, address=@address, email=@email"
                + " where name=@name ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(txtphone.Text));
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM Cashir WHERE name=@name";
            SqlConnection con = new SqlConnection(data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
        }
        public void load()
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            string query = "SELECT name FROM Cashir";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["name"].ToString());
            }
            con.Close();
        }

        private void ChangeCashir_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
