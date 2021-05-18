using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CULS_SERVER
{
    public partial class Module_Close : Form
    {
        public Module_Close()
        {
            InitializeComponent();
        }

        private void button_okay_Click(object sender, EventArgs e)
        {
            this.Dispose();
            

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Opacity = 1.00;
            this.Hide();
            
        }
    }
}
