using Restaurant.Manager.Reciptions;
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

namespace Restaurant.Manager
{
    public partial class MCashir : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public MCashir()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeCashir changeCashir = new ChangeCashir();
            changeCashir.TopLevel = false;
            changeCashir.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(changeCashir);
            changeCashir.Show();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            //Data Base
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            string query = "SELECT name,username,password,phone,address,email FROM Cashir";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                string column2Value = reader.GetString(1);
                string column3Value = reader.GetString(2);
                int column4Value = reader.GetInt32(3);
                string column5Value = reader.GetString(4);
                string column6Value = reader.GetString(5);
                Panel paneln = new Panel();
                paneln.Size = new Size(270, 190);
                paneln.BackColor = Color.LightSkyBlue;
                panel2.Controls.Add(paneln);

                counter++;
                paneln.Location = new Point(x, y);
                x += paneln.Width + 5;

                if (counter == 5)
                {
                    y += paneln.Height + 10;
                    x = 30;
                    counter = 0;
                }

                //Title
                Panel paneltitle = new Panel();
                paneltitle.Size = new Size(240, 48);
                paneltitle.BackColor = Color.DarkMagenta;
                paneltitle.Dock = DockStyle.Top;
                Label title = new Label();
                title.Location = new Point(87, 18);
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
                title.Text = "Cashir";
                paneltitle.Controls.Add(title);
                paneln.Controls.Add(paneltitle);

                //label Name
                Label labelName = new Label();
                labelName.Location = new Point(19, 50);
                labelName.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                labelName.Text = "Name: " + column1Value;
                paneln.Controls.Add(labelName);

                //label Username
                Label labeln = new Label();
                labeln.Location = new Point(19, 70);
                labeln.Font = new System.Drawing.Font("Comic Sans MS", 6F, System.Drawing.FontStyle.Bold);
                labeln.Text = "UserName: " + column2Value;
                paneln.Controls.Add(labeln);

                //label Password
                Label labelp = new Label();
                labelp.Location = new Point(19, 90);
                labelp.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                labelp.Text = "Password: " + column3Value;
                paneln.Controls.Add(labelp);

                //label Phone
                Label labelPhone = new Label();
                labelPhone.Location = new Point(19, 110);
                labelPhone.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                labelPhone.Text = "Phone: " + Convert.ToString(column4Value);
                paneln.Controls.Add(labelPhone);

                //label Address
                Label labelAddress = new Label();
                labelAddress.Location = new Point(19, 130);
                labelAddress.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                labelAddress.Text = "Address: " + column5Value;
                paneln.Controls.Add(labelAddress);

                //label Email
                Label labelEmail = new Label();
                labelEmail.Location = new Point(19, 150);
                labelEmail.Font = new System.Drawing.Font("Comic Sans MS", 6F, System.Drawing.FontStyle.Bold);
                labelEmail.Text = "Email: " + column6Value;
                paneln.Controls.Add(labelEmail);

                ////////////////////////////////////////////////////////////
                panel2.Controls.Add(paneln);
            }
        }
        private void MCashir_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
