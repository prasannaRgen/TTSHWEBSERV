using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.TTSHWCFService;
using WebApplication2.TTSHWCFService;

namespace WebApplication2
{
    public partial class Frm_DMS : System.Web.UI.Page
    {
        static TTSHWCFServiceClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            TTSHWCFServiceClient client = new TTSHWCFServiceClient();
            DocumentManagementSystem docmapsys = client.GetDocumentWithProject(6);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetText(string Prefix, int count, string ContextKey)
        {
            TTSHWCFServiceClient sc = new TTSHWCFServiceClient();
            List<string> lst = new List<string>();
            
            lst.AddRange(sc.GetText(Prefix, count, ContextKey));
            return lst.ToArray();
        }

        [WebMethod()]
        [ScriptMethod()]
        public static WebApplication2.TTSHWCFService.DocumentManagementSystem GetProjectDetails(int projectid)
        {
            string Result = "";
            TTSHWCFServiceClient client = new TTSHWCFServiceClient();
           // List<WebApplication2.TTSHWCFService.Project_Master> project;
            //TTSHWCFReference.Project_Master project = new Project_Master();
            try
            {
                //project = new List<WebApplication2.TTSHWCFService.Project_Master>();
                //project.Add(client.GetProject_MasterDetailsByID(project_id));
                //return project;
                return client.GetDocumentWithProject(projectid);

            }
            catch (Exception)
            {

                return null;
            }

        }
        
    }
}