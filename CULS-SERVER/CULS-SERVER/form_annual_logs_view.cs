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
    public partial class form_annual_logs_view : Form
    {
        public form_annual_logs_view()
        {
            InitializeComponent();
            onloadReport();
        }
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        private void form_annual_logs_view_Load(object sender, EventArgs e)
        {
          
        }
        private void onloadReport()
        {
            try
            {
                Annual_Report_Fields handler = new Annual_Report_Fields();
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(Application.StartupPath + @"\Reports\reports_annual_logs.rpt");
                //----------------------------------------------------//
                //current year
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = handler.Annual_report_field_year;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["@yyyy"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                //----------------------------------------------------//
                //area
                ParameterFieldDefinitions crParameterFieldDefinitions2;
                ParameterFieldDefinition crParameterFieldDefinition2;
                ParameterValues crParameterValues2 = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
                crParameterDiscreteValue2.Value = handler.Annual_report_field_area.ToUpper();
                crParameterFieldDefinitions2 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition2 = crParameterFieldDefinitions2["area_annual"];
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

                crParameterDiscreteValue3.Value = handler.Annual_report_field_prepared.ToUpper();
                crParameterFieldDefinitions3 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition3 = crParameterFieldDefinitions3["Librarian_annual"];
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

                crParameterDiscreteValue4.Value = handler.Annual_report_field_noted.ToUpper();
                crParameterFieldDefinitions4 = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition4 = crParameterFieldDefinitions4["Univ_librarian_annual"];
                crParameterValues4 = crParameterFieldDefinition4.CurrentValues;

                crParameterValues4.Clear();
                crParameterValues4.Add(crParameterDiscreteValue4);
                crParameterFieldDefinition4.ApplyCurrentValues(crParameterValues4);

                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
