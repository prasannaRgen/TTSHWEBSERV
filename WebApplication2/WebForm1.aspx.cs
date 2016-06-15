using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlReportServer = "http://srvpps01:7070/Reportserver";
            
            rptViewer.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local
            rptViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
            rptViewer.ServerReport.ReportPath = "/ProjectDeptPI"; //Passing the Report Path  
            CustomReportCredentials obj = new CustomReportCredentials();
           // obj.ImpersonationUser
            //IReportServerCredentials irsc = new CustomReportCredentials("spfarm", "ROOT#123", "srvpps01");
            //rptViewer.ServerReport.ReportServerCredentials = irsc;
            //Creating an ArrayList for combine the Parameters which will be passed into SSRS Report
            //ArrayList reportParam = new ArrayList();
            //reportParam = ReportDefaultPatam();

            //ReportParameter[] param = new ReportParameter[reportParam.Count];
            //for (int k = 0; k < reportParam.Count; k++)
            //{
            //    param[k] = (ReportParameter)reportParam[k];
            //}
            // pass crendentitilas
            //rptViewer.ServerReport.ReportServerCredentials = 
            //  new ReportServerCredentials("uName", "PassWORD", "doMain");

            //pass parmeters to report
            //rptViewer.ServerReport.SetParameters(param); //Set Report Parameters
            rptViewer.ServerReport.Refresh();

        }
    }
}