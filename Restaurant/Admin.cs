using Restaurant.Manager;
using Restaurant.Manager.Reciptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            Food food = new Food();
            food.TopLevel = false;
            food.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(food);
            food.Show();
        }

        private void btnreciptions_Click(object sender, EventArgs e)
        {
            Reciptions reciptions = new Reciptions();
            reciptions.TopLevel = false;
            reciptions.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(reciptions);
            reciptions.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            MAdmin admin = new MAdmin();
            admin.TopLevel = false;
            admin.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(admin);
            admin.Show();

        }

        private void btnCashir_Click(object sender, EventArgs e)
        {
            MCashir cashir = new MCashir();
            cashir.TopLevel = false;
            cashir.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(cashir);
            cashir.Show();
        }
    }
}
