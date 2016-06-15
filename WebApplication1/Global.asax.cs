using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication1;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
        //void Application_AuthenticateRequest(object sender, EventArgs e)
        //{
        //    String cookieName = FormsAuthentication.FormsCookieName;
        //    HttpCookie authCookie = Context.Request.Cookies[cookieName];

        //    if (null == authCookie)
        //    {//There is no authentication cookie.
        //        return;
        //    }

        //    FormsAuthenticationTicket authTicket = null;

        //    try
        //    {
        //        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Write the exception to the Event Log.
        //        return;
        //    }

        //    if (null == authTicket)
        //    {//Cookie failed to decrypt.
        //        return;
        //    }

        //    //When the ticket was created, the UserData property was assigned a
        //    //pipe-delimited string of group names.
        //    String[] groups = authTicket.UserData.Split(new char[] { '|' });

        //    //Create an Identity.
        //    GenericIdentity id = new GenericIdentity(authTicket.Name, "LdapAuthentication");

        //    //This principal flows throughout the request.
        //    GenericPrincipal principal = new GenericPrincipal(id, groups);

        //    Context.User = principal;
        //}
    }
}
