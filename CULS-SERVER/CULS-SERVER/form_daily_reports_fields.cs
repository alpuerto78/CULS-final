using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace CULS_SERVER
{
    public partial class form_daily_reports_fields : Form
    {
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_daily_reports_fields()
        {
            InitializeComponent();
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_course_save_Click(object sender, EventArgs e)
        {

            if ((report_daily_txt_area_field.Text == String.Empty) || (report_daily_txt_date_field.Text == String.Empty) || (report_daily_txt_prepared_field.Text == String.Empty) || (report_daily_txt_noted_field.Text == String.Empty)){
                MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Daily_Report_Fields handler = new Daily_Report_Fields();
                handler.Daily_report_field_date = report_daily_txt_date_field.Text;
                handler.Daily_report_field_area = report_daily_txt_area_field.Text;
                handler.Daily_report_field_prepared = report_daily_txt_prepared_field.Text;
                handler.Daily_report_field_noted = report_daily_txt_noted_field.Text;

                form_daily_logs_view f1 = new form_daily_logs_view();
                f1.ShowDialog();

            }
        }

        private void form_daily_reports_fields_Load(object sender, EventArgs e)
        {
            //get the date range of the report of daily 
            Daily_Report_Fields handler = new Daily_Report_Fields();
            report_daily_txt_date_field.Text = handler.Daily_report_field_date;
        }
    }
}
