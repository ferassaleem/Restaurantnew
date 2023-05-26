using Restaurant.Manager.Change;
using Restaurant.Manager.Reciptions;
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

namespace Restaurant.Manager
{
    public partial class Food : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public Food()
        {
            InitializeComponent();
            LoadData();

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeFood changeFood = new ChangeFood();
            changeFood.TopLevel = false;
            changeFood.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(changeFood);
            changeFood.Show();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            string query = "SELECT Name,Price FROM Food";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                SqlMoney column2Value = reader.GetSqlMoney(1);

                Panel paneln = new Panel();
                paneln.Size = new Size(240, 100);
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

                Panel paneltitle = new Panel();
                paneltitle.Size = new Size(240, 35);
                paneltitle.BackColor = Color.DarkMagenta;
                paneltitle.Dock = DockStyle.Top;
                Label title = new Label();
                title.Location = new Point(87, 12);
                title.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold);
                title.Text = "Food";
                paneltitle.Controls.Add(title);
                paneln.Controls.Add(paneltitle);
                Label labeln = new Label();
                labeln.Location = new Point(19, 50);
                labeln.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                labeln.Text = "Name: " + column1Value;
                paneln.Controls.Add(labeln);
                Label labelp = new Label();
                labelp.Location = new Point(19, 70);
                labelp.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                labelp.Text = "Price: " + column2Value;
                paneln.Controls.Add(labelp);
                panel2.Controls.Add(paneln);
            }
            reader.Close();
            conn.Close();
        }
        
        private void Food_Load(object sender, EventArgs e)
        {
        }
    }
}