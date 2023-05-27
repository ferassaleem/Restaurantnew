using project.Casher_Form;
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

namespace project.Admin_Form
{
    public partial class AHomePage : Form
    {
        private string admin;
        public AHomePage(string _admin)
        {
            InitializeComponent();
            admin = _admin;
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            ManageFood manageFood = new ManageFood();
            manageFood.TopLevel = false;
            manageFood.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(manageFood);
            manageFood.Show();
        }

        private void AHomePage_Load(object sender, EventArgs e)
        {
            
            lblWelcome.Text = "Welcome " + admin;
            label1.Text = DateTime.Now.ToString();
        }

        private void btnCasher_Click(object sender, EventArgs e)
        {
            ManageCasher manageCasher = new ManageCasher();
            manageCasher.TopLevel = false;
            manageCasher.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(manageCasher);
            manageCasher.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ManageAdmin manageAdmin = new ManageAdmin();
            manageAdmin.TopLevel = false;
            manageAdmin.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(manageAdmin);
            manageAdmin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageSales manageSales = new ManageSales();
            manageSales.TopLevel = false;
            manageSales.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(manageSales);
            manageSales.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
    

