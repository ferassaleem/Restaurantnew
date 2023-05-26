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

namespace Restaurant.Manager.Reciptions
{
    public partial class ChageReciptions : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public ChageReciptions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Reciptions VALUES(@Name, @Price, @Date)", conn);
            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            string update = "UPDATE Reciptions SET  Name=@Name, Price=@Price, Date=@Date" + " WHERE Id=@Id ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE Reciptions WHERE Id=@Id";
            SqlConnection con = new SqlConnection(data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
        }

        public void load()
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            string query = "SELECT Name FROM Food";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Name"].ToString());
            }
            con.Close();
        }

        private void ChageReciptions_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
