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
using System.Windows.Forms.DataVisualization.Charting;

namespace project.Admin_Form.ChangeSale
{
    public partial class Graph : Form
    {
        string Data = "Data Source=DESKTOP-SV7JT22;Initial Catalog=Project-db;Integrated Security=True";

        public Graph()
        {
            InitializeComponent();
        }
        void fillChart()
        {
            SqlConnection sqlConnection = new SqlConnection(Data);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Price,DateSale FROM Sales", sqlConnection);
            sqlDataAdapter.Fill(dt);
            chart1.DataSource = dt;
            sqlConnection.Close();

            // Add the series to the SeriesCollection
            chart1.Series.Add("Price");

            // Set the properties of the series
            chart1.Series["Price"].ChartType = SeriesChartType.Line;
            chart1.Series["Price"].XValueMember = "DateSale";
            chart1.Series["Price"].YValueMembers = "Price";

            chart1.Titles.Add("Sales");
        }
        private void Graph_Load(object sender, EventArgs e)
        {
            fillChart();
        }

        private void btnFillter_Click(object sender, EventArgs e)
        {
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            SqlConnection sqlConnection = new SqlConnection(Data);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            string query = $"SELECT Price, DateSale FROM Sales WHERE DateSale BETWEEN '{startDate}' AND '{endDate}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlDataAdapter.Fill(dt);
            chart1.DataSource = dt;
            sqlConnection.Close();

            Series priceSeries = chart1.Series["Price"];

            priceSeries.ChartType = SeriesChartType.Line;
            priceSeries.XValueMember = "DateSale";
            priceSeries.YValueMembers = "Price";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
