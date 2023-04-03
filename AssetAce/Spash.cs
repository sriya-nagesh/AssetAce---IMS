using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetAce
{
    public partial class Spash : Form
    {
        private bool isLoaded = false;

        public Spash()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
          
            if (!isLoaded)
            {
                this.Hide();
                Login log = new Login();
                log.Show();
                isLoaded = true;
            }
        }
    }
}
