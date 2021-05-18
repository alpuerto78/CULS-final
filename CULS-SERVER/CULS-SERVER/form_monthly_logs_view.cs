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
namespace CULS_SERVER
{
    public partial class form_monthly_logs_view : Form
    {
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_monthly_logs_view()
        {
            InitializeComponent();
        }

        private void form_monthly_logs_view_Load(object sender, EventArgs e)
        {
            Monthly_Report_Fields handler = new Monthly_Report_Fields();
            int _mm = int.Parse(handler.Monthly_report_field_month);
            try
            {
               
                //ParameterFields param = new ParameterFields();
                //ParameterField param2 = new ParameterField();
                //ParameterDiscreteValue paramdisc = new ParameterDiscreteValue();
                //param2.Name = "area_daily";
                //paramdisc.Value = handler.Daily_report_field_date;
                //param2.CurrentValues.Add(paramdisc);
                //param.Add(param2);
                //form_daily_logs_view f2 = new form_daily_logs_view();
                //reports_daily_logs.ParameterFieldInfo = paramdisc;

                ReportDocument cryRpt = new ReportDocument();
                //cryRpt.Load(@"C:\Users\Alpuerto\Documents\GitHub\Computer-Usage-Limiter-System\CULS-SERVER\CULS-SERVER\reports_monthly_logs.rpt");
                cryRpt.Load(Application.StartupPath + @"\Reports\reports_monthly_logs.rpt");
                // ----------------------------------------------------//
                // current month
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = _mm;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@mm"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
          
                //----------------------------------------------------//
                //current month
                ParameterFieldDefinitions crParameterFieldDefinitions5;
                ParameterFieldDefinition crParameterFieldDefinition5;
                ParameterValues crParameterValues5 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue5 = new ParameterDiscreteValue();

                crParameterDiscreteValue5.Value = handler.Monthly_report_field_year;
                crParameterFieldDefinitions5 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition5 = crParameterFieldDefinitions5["@yyyy"];
                crParameterValues5 = crParameterFieldDefinition5.CurrentValues;

                crParameterValues5.Clear();
                crParameterValues5.Add(crParameterDiscreteValue5);
                crParameterFieldDefinition5.ApplyCurrentValues(crParameterValues5);

                //----------------------------------------------------//
                //current date
                ParameterFieldDefinitions crParameterFieldDefinitions6;
                ParameterFieldDefinition crParameterFieldDefinition6;
                ParameterValues crParameterValues6 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue6 = new ParameterDiscreteValue();

                crParameterDiscreteValue6.Value = handler.Monthly_report_field_concat_date.ToUpper();
                crParameterFieldDefinitions6 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition6 = crParameterFieldDefinitions6["date_monthly"];
                crParameterValues6 = crParameterFieldDefinition6.CurrentValues;

                crParameterValues6.Clear();
                crParameterValues6.Add(crParameterDiscreteValue6);
                crParameterFieldDefinition6.ApplyCurrentValues(crParameterValues6);

                //----------------------------------------------------//
                //area
                ParameterFieldDefinitions crParameterFieldDefinitions2;
                ParameterFieldDefinition crParameterFieldDefinition2;
                ParameterValues crParameterValues2 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();

                crParameterDiscreteValue2.Value = handler.Monthly_report_field_area.ToUpper();
                crParameterFieldDefinitions2 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition2 = crParameterFieldDefinitions2["area_monthly"];
                crParameterValues2 = crParameterFieldDefinition2.CurrentValues;

                crParameterValues2.Clear();
                crParameterValues2.Add(crParameterDiscreteValue2);
                crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2);
             
                //----------------------------------------------------//
                //prepared by
                ParameterFieldDefinitions crParameterFieldDefinitions3;
                ParameterFieldDefinition crParameterFieldDefinition3;
                ParameterValues crParameterValues3 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue3 = new ParameterDiscreteValue();

                crParameterDiscreteValue3.Value = handler.Monthly_report_field_prepared.ToUpper();
                crParameterFieldDefinitions3 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition3 = crParameterFieldDefinitions3["Librarian_monthly"];
                crParameterValues3 = crParameterFieldDefinition3.CurrentValues;

                crParameterValues3.Clear();
                crParameterValues3.Add(crParameterDiscreteValue3);
                crParameterFieldDefinition3.ApplyCurrentValues(crParameterValues3);
               
                //----------------------------------------------------//
                //noted by
                ParameterFieldDefinitions crParameterFieldDefinitions4;
                ParameterFieldDefinition crParameterFieldDefinition4;
                ParameterValues crParameterValues4 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue4 = new ParameterDiscreteValue();

                crParameterDiscreteValue4.Value = handler.Monthly_report_field_noted.ToUpper();
                crParameterFieldDefinitions4 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition4 = crParameterFieldDefinitions4["Univ_Librarian_monthly"];
                crParameterValues4 = crParameterFieldDefinition4.CurrentValues;

                crParameterValues4.Clear();
                crParameterValues4.Add(crParameterDiscreteValue4);
                crParameterFieldDefinition4.ApplyCurrentValues(crParameterValues4);
                
                crystalReportViewer1.ReportSource = cryRpt;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
