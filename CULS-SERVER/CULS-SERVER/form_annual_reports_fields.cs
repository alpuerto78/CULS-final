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
    public partial class form_annual_reports_fields : Form
    {
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_annual_reports_fields()
        {
            InitializeComponent();
        }

        private void form_annual_reports_fields_Load(object sender, EventArgs e)
        {
            Annual_Report_Fields handler = new Annual_Report_Fields();
            report_annual_txt_year_field.Text = handler.Annual_report_field_year;
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_annual_report_field_view_Click(object sender, EventArgs e)
        {

            if ((report_annual_txt_area_field.Text == String.Empty) || (report_annual_txt_year_field.Text == String.Empty) || (report_annual_txt_prepared_field.Text == String.Empty) || (report_annual_txt_noted_field.Text == String.Empty))
            {
                MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Annual_Report_Fields handler = new Annual_Report_Fields();
                handler.Annual_report_field_year = report_annual_txt_year_field.Text;
                handler.Annual_report_field_area = report_annual_txt_area_field.Text;
                handler.Annual_report_field_prepared = report_annual_txt_prepared_field.Text;
                handler.Annual_report_field_noted = report_annual_txt_noted_field.Text;
                MessageBox.Show(handler.Annual_report_field_noted);
                form_annual_logs_view f1 = new form_annual_logs_view();
                f1.ShowDialog();

            }
        }
    }
}
