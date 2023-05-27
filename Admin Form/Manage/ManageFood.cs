using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Admin_Form
{
    public partial class ManageFood : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public ManageFood()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.TopLevel = false;
            add.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(add);
            add.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.TopLevel = false;
            update.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(update);
            update.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.TopLevel = false;
            delete.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(delete);
            delete.Show();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            string query = "SELECT Name,Price FROM Food";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                int column2Value = reader.GetInt32(1);

                Panel paneln = new Panel();
                paneln.Size = new Size(240, 100);
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
                title.Text = "Food";
                paneltitle.Controls.Add(title);
                paneln.Controls.Add(paneltitle);

                //label Name
                Label labeln = new Label();
                labeln.Location = new Point(19, 50);
                labeln.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labeln.Text = "Name: " + Convert.ToString(column1Value);
                paneln.Controls.Add(labeln);

                //label Price
                Label labelp = new Label();
                labelp.Location = new Point(19, 70);
                labelp.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelp.Text = "Price: " + Convert.ToString(column2Value);
                paneln.Controls.Add(labelp);

                //////////////////////////////////////////////////////////////////
                panel2.Controls.Add(paneln);
            }

            reader.Close();
            conn.Close();
        }

        private void ManageFood_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}