using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.Security;
using System.Text;

namespace TTSH.ServiceLayer
{
    /// <summary>
    /// Author: TTSH Dev Team
    /// Created Date: 09/06/2015
    /// Description: To handle Client Schema Code.
    /// </summary>
    internal class TTSHClient
    {
        //#region Private Member Functions

        //private List<string> _GetSchemaName(string appURL)
        //{

        ////    List<string> clientInfo = new List<string>();
        ////    TTSH.DataAccess.DataHelper _helper = new DataAccess.DataHelper();
        ////    _helper.InitializedHelper();

        ////    List<System.Data.Common.DbParameter> parameter = new List<System.Data.Common.DbParameter>();

        ////    parameter.Add(_helper.CreateDbParameter());
        ////    parameter[parameter.Count - 1].ParameterName = "@ClientAppURL";
        ////    if (!string.IsNullOrEmpty(appURL))
        ////    {
        ////       appURL = HttpUtility.UrlDecode(appURL);
                
        ////        parameter[parameter.Count - 1].Value = appURL; }
        ////    else
        ////    { parameter[parameter.Count - 1].Value = DBNull.Value; }
             

        ////    parameter.Add(_helper.CreateDbParameter());
        ////    parameter[parameter.Count - 1].ParameterName = "@Ret_Parameter";
        ////    parameter[parameter.Count - 1].Direction = ParameterDirection.Output;
        ////    parameter[parameter.Count - 1].Size = 500;

        ////    DataTable dt = _helper.GetData("UAT.spGetSchemaByClientAppURL", parameter);

        ////    if (dt != null && dt.Rows.Count > 0)
        ////    {
        ////        clientInfo.Add(dt.Rows[0]["schemaName"].ToString());//Schema Name
        ////        clientInfo.Add(dt.Rows[0]["clientName"].ToString());//Client Name
        ////        clientInfo.Add(dt.Rows[0]["clientLogo"].ToString());//Client Logo Path
        ////        return clientInfo;
        ////        //return dt.Rows[0][0].ToString();
        ////    }
        ////    else
        ////        // return string.Empty;
        ////        return null;
        ////}

        ////private string _GetAppURL(string requestURL)
        ////{
        ////    string appURL = string.Empty;

        ////    //requestURL = (requestURL).ToLower().Replace("//", "/").Replace("https:/", "https://").Replace("http:/", "http://");
        ////    //requestURL = (requestURL).ToLower("https:/", "https://").Replace("http:/", "http://");

        ////    string[] url = requestURL.Split('/');
        ////    foreach (string s in url)
        ////    {
        ////        if (s.ToLower().Contains(".aspx"))
        ////            break;

        ////        if (s.ToLower() == "sitepages")
        ////            break;

        ////        appURL += s.ToLower() + "/";
        ////    }

        ////    return appURL.Substring(0, appURL.Length - 1);
        //}

        //#endregion

        //#region Internal Member Functions

        //internal string GetClientSchema()
        //{
        //    List<string> listClientInfo = new List<string>();

        //    string schemaName = string.Empty;

        //    try
        //    {
        //        if (WebOperationContext.Current != null)
        //        {
        //            listClientInfo = _GetSchemaName(_GetAppURL(WebOperationContext.Current.IncomingRequest.Headers[HttpRequestHeader.Referer]));

        //            schemaName = listClientInfo[0];

        //            string clientInfo = listClientInfo[1] + "|" + listClientInfo[2]+"~";

        //            WebOperationContext.Current.OutgoingResponse.Headers.Add("ClientInfo", clientInfo);
                    

        //        }

        //        if (string.IsNullOrEmpty(schemaName))
        //            ExceptionHelper.TraceServiceLevelException("Client is not configured to use UAT Tool!!!");
        //    }
        //    catch (Exception) { }

        //    return schemaName;
        //}

        //internal string GetClientInfo()
        //{
        //    List<string> listClientInfo = new List<string>();

        //    string clientInfo = string.Empty;

        //    try
        //    {
                
        //            listClientInfo = _GetSchemaName(_GetAppURL(WebOperationContext.Current.IncomingRequest.Headers[HttpRequestHeader.Referer]));

        //            clientInfo = listClientInfo[1] + "|" + listClientInfo[2];

        //    }
        //    catch (Exception) { }

        //    return clientInfo;
        //}

        //internal string GetLoggedInUserSPUserId()
        //{
        //    string spUserId = string.Empty;

        //    try
        //    {
        //        if (WebOperationContext.Current != null)
        //        {
        //            string customHeader = WebOperationContext.Current.IncomingRequest.Headers["LoggedInUserSPUserId"];

        //            if (!string.IsNullOrEmpty(customHeader))
        //                spUserId = customHeader;
        //        }

        //        if (string.IsNullOrEmpty(spUserId))
        //            ExceptionHelper.TraceServiceLevelException("Invalid Client Session!!!");
        //    }
        //    catch (Exception) { }

        //    return spUserId;
        //}

        //#endregion
    }
}