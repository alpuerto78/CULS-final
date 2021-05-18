using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CULS_SERVER
{
    public partial class form_Preload : Form
    {
      
        public form_Preload()
        {
            InitializeComponent();
        
        }

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
        int dir = 1;
        private void stretch_Tick(object sender, EventArgs e)
        {

            if (progbar_pre_load.Value == 90)
            {
                
                dir--;
                //  progbar_pre_load.animationIterval = 4;
            //    SwitchColor();

            }
            else if (progbar_pre_load.Value==10) 
            {
               
                dir ++;
                // progbar_pre_load.animationIterval = 2;
              //  SwitchColor();

            }

            progbar_pre_load.Value += dir;
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void form_Preload_Load(object sender, EventArgs e)
        {
            timer.Interval = 3500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
