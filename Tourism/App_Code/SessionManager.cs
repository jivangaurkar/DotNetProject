/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tourism.BusinessInfo;

/// <summary>
/// Summary description for SessionManager
/// </summary>
public class SessionManager
{


    public static MemberInfo MemberInfo
    {
        get
        {
            if (HttpContext.Current.Session["Member"] == null)
                return null;
            else
                return (MemberInfo)HttpContext.Current.Session["Member"];

        }
        set { HttpContext.Current.Session["Member"] = value; }
    }
    public static LocationInfo LocationInfo
    {
        get
        {
            if (HttpContext.Current.Session["Location"] == null)
                return null;
            else
                return (LocationInfo)HttpContext.Current.Session["Location"];

        }
        set { HttpContext.Current.Session["Location"] = value; }
    }
    public SessionManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
