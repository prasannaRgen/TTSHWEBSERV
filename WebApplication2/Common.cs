using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.TTSHWCFService;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Web.Configuration;

namespace WebApplication2
{
    public static class Common
    {
        public static void FillCombo(this System.Web.UI.WebControls.DropDownList ddl, DropDownName dname, string Condition = "")
        {
            TTSHWCFServiceClient cl = new TTSHWCFServiceClient();
            try
            {

                List<WebApplication2.TTSHWCFService.clsDropDown> ddllist = cl.GetDropDownData(dname, Condition, "", "", "", "").ToList();
                ddl.DataSource = ddllist;
                ddl.DataTextField = "DisplayField";
                ddl.DataValueField = "ValueField";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--Select--", System.Convert.ToString(0)));
            }
            catch
            { }
        }
    }
}