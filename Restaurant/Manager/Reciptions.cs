using Restaurant.Manager.Change;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant.Manager.Reciptions
{
    public partial class Reciptions : Form
    {
        string data = "Data Source=DESKTOP-CDSJAGG;Initial Catalog=Restaurant-DataBase;Integrated Security=True";

        public Reciptions()
        {
            InitializeComponent();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            ChageReciptions chageReciptions = new ChageReciptions();
            chageReciptions.TopLevel = false;
            chageReciptions.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(chageReciptions);
            chageReciptions.Show();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            string query = "SELECT Name, Price, Date FROM Reciptions";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                SqlMoney column2Value = reader.GetSqlMoney(1);
                DateTime column3Value = reader.GetDateTime(2);


                Panel paneln = new Panel();
                paneln.Size = new Size(240, 150);
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
                paneltitle.Size = new Size(240, 40);
                paneltitle.BackColor = Color.DarkMagenta;
                paneltitle.Dock = DockStyle.Top;
                Label title = new Label();
                title.Location = new Point(87, 18);
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
                title.Text = "Reciption";


                //Name
                Label labelname = new Label();
                labelname.Location = new Point(19, 60);
                labelname.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                labelname.Text = "Name: " + column1Value;

                //price
                Label labelprice = new Label();
                labelprice.Location = new Point(19, 80);
                labelprice.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                labelprice.Text = "Price: " + Convert.ToString(column2Value);

                //date
                Label labeldate = new Label();
                DateTimePicker date = new DateTimePicker();
                labeldate.Location = new Point(19, 100);
                labeldate.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                date.Value = column3Value;
                labeldate.Text = "Date: " + column3Value;


                /////////////////////////////////////////////////////////
                ///
                paneltitle.Controls.Add(title);
                paneln.Controls.Add(paneltitle);
                paneln.Controls.Add(labelname);
                paneln.Controls.Add(labelprice);
                paneln.Controls.Add(labeldate);
                panel2.Controls.Add(paneln);
            }

            reader.Close();
            conn.Close();
        }

        private void Reciptions_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            SqlConnection con = new SqlConnection(data);
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            SqlDataAdapter dataAdpter = new SqlDataAdapter("SELECT * FROM Reciptions WHERE CONVERT(DATE, Date, 23) BETWEEN '" + startDate + "' AND '" + endDate + "'", con);
            DataTable dt = new DataTable();
            dataAdpter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                int x = 30;
                int y = 30;
                int counter = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string column1Value = row["Name"].ToString();
                    SqlMoney column2Value = Convert.ToInt32(row["Price"]);
                    DateTime column3Value = Convert.ToDateTime(row["Date"]);

                    Panel paneln = new Panel();
                    paneln.Size = new Size(240, 150);
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
                    paneltitle.Size = new Size(240, 40);
                    paneltitle.BackColor = Color.DarkMagenta;
                    paneltitle.Dock = DockStyle.Top;
                    Label title = new Label();
                    title.Location = new Point(87, 18);
                    title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
                    title.Text = "Reciption";


                    //Name
                    Label labelname = new Label();
                    labelname.Location = new Point(19, 60);
                    labelname.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                    labelname.Text = "Name: " + column1Value;

                    //price
                    Label labelprice = new Label();
                    labelprice.Location = new Point(19, 80);
                    labelprice.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
                    labelprice.Text = "Price: " + Convert.ToString(column2Value);

                    //date
                    Label labeldate = new Label();
                    DateTimePicker date = new DateTimePicker();
                    labeldate.Location = new Point(19, 100);
                    labeldate.Font = new System.Drawing.Font("Comic Sans MS", 7F, System.Drawing.FontStyle.Bold);
                    date.Value = column3Value;
                    labeldate.Text = "Date: " + column3Value;


                    /////////////////////////////////////////////////////////
                    ///
                    paneltitle.Controls.Add(title);
                    paneln.Controls.Add(paneltitle);
                    paneln.Controls.Add(labelname);
                    paneln.Controls.Add(labelprice);
                    paneln.Controls.Add(labeldate);
                    panel2.Controls.Add(paneln);
                }
            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.TopLevel = false;
            graph.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(graph);
            graph.Show();
        }
    }
}
