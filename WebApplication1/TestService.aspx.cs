using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.TTSHServiceReference;
using ExportToExcel;
using WebApplication1.Excel;



namespace WebApplication1
{
    public partial class TestService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TTSHWCFServiceClient client = new TTSHWCFServiceClient();

            

            //List<TTSHServiceReference.Project_Master> pmList = new List<TTSHServiceReference.Project_Master>();
            //pmList = client.GetAllProjectDetails().ToList();

           // Project_Master pm = new Project_Master();

           // pm.b_Collaboration_Involved = true;
           // pm.dt_Created_Date = DateTime.Now;
           // pm.i_Dept_ID = 3;
           // pm.i_PI_ID = 1;
           // pm.s_IRB_No = "123456";
           // pm.s_Project_Title = "Project1";
           // pm.s_Short_Title = "ShortTitle";
           // pm.s_User_ID = "1";
           
           //string a =  client.ProjectDetails(pm, Mode.Insert);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TTSHWCFServiceClient client = new TTSHWCFServiceClient();
            //client.GetProjectDetailsByID(1);
            //client.ExportToExcel();

            DataTable dtReportData = new DataTable();
            dtReportData.Columns.Add("FirstName", typeof(string));
            dtReportData.Columns.Add("LastName", typeof(string));
            dtReportData.Columns.Add("Age", typeof(int));
            dtReportData.Columns.Add("Email", typeof(string));
            dtReportData.Columns.Add("Contact", typeof(string));
            dtReportData.Columns.Add("Address", typeof(string));

            dtReportData.Rows.Add("Ejaz", "Waquif", 26, "mohd.ejaz@rgensolutions.com", "8446347114", "Nagpur");
            dtReportData.Rows.Add("Atul", "Sirsode", 25, "atul@rgensolutions.com", "844447114", "Nagpur");

            DataTable dt = dtReportData;

            dt.TableName = "Project";

            //string attachment = "attachment; filename=city.xlsx";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            ////Response.ContentType = "application/vnd.ms-excel";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            //Response.TransmitFile(@"D:\Projects\Source Code\TTSHServiceLayer\WebApplication1\Images\accent.png");
            //Response.End();

            //Response.ContentType = "application/vnd.ms-excel";
            //string fileName = Server.MapPath("~\\DownloadFile\\Test.xls");  //Give path name\file name.

            //Response.AppendHeader("Content-Disposition", "attachment; filename=Test.xls"); 

            // //Specify the file name which needs to be displayed while prompting

            // //Response.TransmitFile(@"D:\Projects\Source Code\TTSHServiceLayer\WebApplication1\DownloadFile\Test.xlsx");
            //Response.TransmitFile(fileName);

            // Response.End();

             Excel.ExportToExcel export = new Excel.ExportToExcel();
             export.Export(dt, Response);

            
            
         
        }
    }
}