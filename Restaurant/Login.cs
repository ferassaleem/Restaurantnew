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

namespace Restaurant
{
    public partial class Login : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(data);
            SqlDataAdapter sqldt = new SqlDataAdapter("select * from Admin where username= '" + txtusername.Text + "' and password='" + txtpassword.Text + "'", conn);
            DataTable datat = new DataTable();
            sqldt.Fill(datat);
            if (datat.Rows.Count > 0)
            {
                Admin ahomePage = new Admin();
                ahomePage.Show();
            }
            else
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Cashir where username= '" + txtusername.Text + "' and Password='" + txtpassword.Text + "'", conn);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Cashir chomePage = new Cashir();
                    chomePage.Show();
                }
                else
                {
                    MessageBox.Show("username or password is worng");
                }
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            Signup sign_Up = new Signup();
            sign_Up.Show();
        }
    }
}
