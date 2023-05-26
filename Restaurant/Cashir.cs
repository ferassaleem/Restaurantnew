using Restaurant.Manager.Reciptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Cashir : Form
    {
        public Cashir()
        {
            InitializeComponent();
        }

        private void btnaddreciptions_Click(object sender, EventArgs e)
        {
            ChageReciptions reciptions = new ChageReciptions();
            reciptions.Show();
        }
    }
}
