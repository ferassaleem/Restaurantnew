using project.Admin_Form.ChangeSale;
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


namespace project.Admin_Form
{
    public partial class ManageSales : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public ManageSales()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            int x = 30;
            int y = 30;
            int counter = 0;

            SqlConnection conn = new SqlConnection(Data);
            conn.Open();
            string query = "SELECT FoodName, Price, DateSale FROM Sales";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string column1Value = reader.GetString(0);
                int column2Value = reader.GetInt32(1);
                DateTime column3Value = reader.GetDateTime(2);


                Panel paneln = new Panel();
                paneln.Size = new Size(240, 120);
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
                paneltitle.Size = new Size(240, 40);
                paneltitle.BackColor = Color.Green;
                paneltitle.Dock = DockStyle.Top;
                Label title = new Label();
                title.Location = new Point(87, 18);
                title.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                title.Text = "Receipt";
                

                //label Name
                Label labelname = new Label();
                labelname.Location = new Point(19, 60);
                labelname.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelname.Text = "FoodName: " + column1Value;

                //label price
                Label labelprice = new Label();
                labelprice.Location = new Point(19, 80);
                labelprice.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                labelprice.Text = "Price: " + Convert.ToString(column2Value);

                //label date
                Label labeldate = new Label();
                DateTimePicker date = new DateTimePicker();
                labeldate.Location = new Point(19, 100);
                labeldate.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSale addSale = new AddSale();
            addSale.TopLevel = false;
            addSale.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(addSale);
            addSale.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSale updateSale = new UpdateSale();
            updateSale.TopLevel = false;
            updateSale.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(updateSale);
            updateSale.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSale deleteSale = new DeleteSale();
            deleteSale.TopLevel = false;
            deleteSale.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(deleteSale);
            deleteSale.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            SqlConnection con = new SqlConnection(Data);
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM Sales WHERE CONVERT(DATE, DateSale, 23) BETWEEN '" + startDate + "' AND '" + endDate + "'", con);
            DataTable dt = new DataTable();
            data.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                int x = 30;
                int y = 30;
                int counter = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string column1Value = row["FoodName"].ToString();
                    int column2Value = Convert.ToInt32(row["Price"]);
                    DateTime column3Value = Convert.ToDateTime(row["DateSale"]);

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
                    paneltitle.Dock = DockStyle.Top;
                    paneltitle.BackColor = Color.Green;
                    Label title = new Label();
                    title.Location = new Point(87, 18);
                    title.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                    title.Text = "Receipt";
                    paneltitle.Controls.Add(title);
                    paneln.Controls.Add(paneltitle);

                    //label Name
                    Label labelname = new Label();
                    labelname.Location = new Point(19, 20);
                    labelname.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                    labelname.Text = "FoodName: " + column1Value;
                    paneln.Controls.Add(labelname);

                    //label price
                    Label labelprice = new Label();
                    labelprice.Location = new Point(19, 45);
                    labelprice.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                    labelprice.Text = "Price: " + Convert.ToString(column2Value);
                    paneln.Controls.Add(labelprice);

                    //label date
                    Label labeldate = new Label();
                    DateTimePicker date = new DateTimePicker();
                    labeldate.Location = new Point(19, 70);
                    labeldate.Font = new System.Drawing.Font("Berlin Sans FB", 7F, System.Drawing.FontStyle.Bold);
                    date.Value = column3Value;
                    labeldate.Text = "Date: " + column3Value;
                    paneln.Controls.Add(labeldate);

                    /////////////////////////////////////////////////////////
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

        private void ManageSales_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}