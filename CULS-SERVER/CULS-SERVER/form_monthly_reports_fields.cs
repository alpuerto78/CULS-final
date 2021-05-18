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
    public partial class form_monthly_reports_fields : Form
    {
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_monthly_reports_fields()
        {
            InitializeComponent();
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_monthly_reports_fields_Load(object sender, EventArgs e)
        {
            //get the date range of the report by moths 
            Monthly_Report_Fields handler = new Monthly_Report_Fields();
            report_monthly_txt_month_field.Text = handler.Monthly_report_field_month;
            report_monthly_txt_year_field.Text = handler.Monthly_report_field_year;
            report_monthly_txt_area_field.Focus();

        }
      
        private void button_monthly_report_field_view_Click(object sender, EventArgs e)
        {
            int _mm_value = 0;
            if ((report_monthly_txt_area_field.Text == String.Empty) || (report_monthly_txt_month_field.Text == String.Empty) || (report_monthly_txt_prepared_field.Text == String.Empty) || (report_monthly_txt_noted_field.Text == String.Empty) || (report_monthly_txt_year_field.Text == String.Empty))
            {
                MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Monthly_Report_Fields handler = new Monthly_Report_Fields();
             
                handler.Monthly_report_field_year = report_monthly_txt_year_field.Text;
                handler.Monthly_report_field_area = report_monthly_txt_area_field.Text;
                handler.Monthly_report_field_prepared = report_monthly_txt_prepared_field.Text;
                handler.Monthly_report_field_noted = report_monthly_txt_noted_field.Text;
                handler.Monthly_report_field_concat_date=report_monthly_txt_month_field.Text+" "+ report_monthly_txt_year_field.Text;
                string _mm = handler.Monthly_report_field_month;
                if (_mm == "January")
                {
                    _mm_value = 1;
                }
                else if (_mm == "February")
                {
                    _mm_value = 2;
                }
                else if (_mm == "March")
                {
                    _mm_value = 3;
                }
                else if (_mm == "April")
                {
                    _mm_value = 4;
                }
                else if (_mm == "May")
                {
                    _mm_value = 5;
                }
                else if (_mm == "June")
                {
                    _mm_value = 6;
                }
                else if (_mm == "July")
                {
                    _mm_value = 7;
                }
                else if (_mm == "August")
                {
                    _mm_value = 8;
                }
                else if (_mm == "September")
                {
                    _mm_value = 9;
                }
                else if (_mm == "October")
                {
                    _mm_value = 10;
                }
                else if (_mm == "November")
                {
                    _mm_value = 11;
                }
                else if (_mm == "December")
                {
                    _mm_value = 12;
                }
          handler.Monthly_report_field_month = _mm_value.ToString();

                form_monthly_logs_view f1 = new form_monthly_logs_view();
                f1.ShowDialog();

            }
        }
    }
}
