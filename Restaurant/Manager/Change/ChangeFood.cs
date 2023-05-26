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
    public partial class ChangeFood : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public ChangeFood()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            string add = "INSERT INTO Food VALUES(@Name, @Price)";
            SqlCommand cmd = new SqlCommand(add, conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Add is successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            string update = "UPDATE Food SET  Name=@Name, Price=@Price" + " WHERE Id=@Id ";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update is successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM Food WHERE Id=@Id";
            SqlConnection con = new SqlConnection(data);
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtID.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete is successfully");
        }
    }
}
