using project.Admin_Form.ChangeAdmin;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project.Admin_Form
{
    public partial class ManageAdmin : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public ManageAdmin()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAdmin updateAdmin = new UpdateAdmin();
            updateAdmin.TopLevel = false;
            updateAdmin.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(updateAdmin);
            updateAdmin.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAdmin addAdmin = new AddAdmin();
            addAdmin.TopLevel = false;
            addAdmin.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(addAdmin);
            addAdmin.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAdmin deleteAdmin = new DeleteAdmin();
            deleteAdmin.TopLevel = false;
            deleteAdmin.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(deleteAdmin);
            deleteAdmin.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            //Data Base
            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            string query = "SELECT Name,UserName,Password,Phone,Address FROM Admin";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                string column2Value = reader.GetString(1);
                string column3Value = reader.GetString(2);
                int column4Value = reader.GetInt32(3);
                string column5Value = reader.GetString(4);
                Panel paneln = new Panel();
                paneln.Size = new Size(240, 150);
                paneln.BackColor = Color.LightBlue;
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
                paneltitle.BackColor = Color.Green;
                paneltitle.Dock = DockStyle.Top;
                Label title = new Label();
                title.Location = new Point(87, 18);
                title.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                title.Text = "Admin";
                paneltitle.Controls.Add(title);
                paneln.Controls.Add(paneltitle);

                //label Name
                Label labelName = new Label();
                labelName.Location = new Point(19,50);
                labelName.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelName.Text = "Name: " + column1Value;
                paneln.Controls.Add(labelName);

                //label Username
                Label labeln = new Label();
                labeln.Location = new Point(19, 70);
                labeln.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labeln.Text = "UserName: " + column2Value;
                paneln.Controls.Add(labeln);

                //label Password
                Label labelp = new Label();
                labelp.Location = new Point(19, 90);
                labelp.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelp.Text = "Password: " + column3Value;
                paneln.Controls.Add(labelp);

                //label Phone
                Label labelPhone = new Label();
                labelPhone.Location = new Point(19, 110);
                labelPhone.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelPhone.Text = "Phone: " + Convert.ToString(column4Value);
                paneln.Controls.Add(labelPhone);

                //label Address
                Label labelAddress = new Label();
                labelAddress.Location = new Point(19, 130);
                labelAddress.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelAddress.Text = "Address: " + column5Value;
                paneln.Controls.Add(labelAddress);

                ////////////////////////////////////////////////////////////
                panel2.Controls.Add(paneln);
            }

            reader.Close();
            conn.Close();
        }

        private void ManageAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
