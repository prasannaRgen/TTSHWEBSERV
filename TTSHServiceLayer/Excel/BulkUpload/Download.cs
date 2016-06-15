using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTSH.ServiceLayer.Excel.BulkUpload
{
    internal class Download
    {
        internal void DownloadTemplate(string projectId)
        {
            OpenXML.Util util = new OpenXML.Util();

            //string SourceTemplatePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "SampleTemplate\\TestersParticipation.xlsx";

            util.fileName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + Configuration.TemplateFileName ;
        }
    }
}