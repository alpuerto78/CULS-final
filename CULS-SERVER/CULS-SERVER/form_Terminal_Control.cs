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
    public partial class form_Terminal_Control : Form
    {
        //Shadow in form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public form_Terminal_Control()
        {
            InitializeComponent();
          
        }

        private void form_Terminal_Login_Load(object sender, EventArgs e)
        {
            GetControlImages();          
        }
        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetControlImages()
        {
            //Get the Image from the resource
            btn_terminal_control_add_time.Image = Properties.Resources.icon_terminal_control_add_time;
            btn_terminal_control_logout.Image = Properties.Resources.icon_terminal_control_logout_user;
            btn_terminal_control_restart.Image = Properties.Resources.icon_terminal_control_restart;
            btn_terminal_control_shutdown.Image = Properties.Resources.icon_terminal_control_shutdown;
        }
        private void btn_terminal_control_add_time_Click(object sender, EventArgs e)
        {
            form_add_time f1 = new form_add_time();
            f1.Show();
            this.Hide();
        }

        private void btn_terminal_control_logout_Click(object sender, EventArgs e)
        {

        }

        private void btn_terminal_control_restart_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_terminal_name_Click(object sender, EventArgs e)
        {

        }

        private void btn_terminal_control_shutdown_Click(object sender, EventArgs e)
        {

        }
    }
}
