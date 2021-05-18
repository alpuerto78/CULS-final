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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value +=1;
            if (bunifuCircleProgressbar1.Value==100)
            {
                timer_progress.Enabled = false;
           
                Login f1 = new Login();
              
                f1.ShowDialog();
                this.Close();
            }
         
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer_progress.Start();

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void transition_form_in_Tick(object sender, EventArgs e)
        {
            if (Opacity==1)
            {
                transition_form_in.Enabled = false;

            }
            Opacity += 0.1;
        }
    }
}
