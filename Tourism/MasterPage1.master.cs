/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddCust_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomer.aspx?Type=CUST");
    }
    protected void btnAddLoc_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddLocation.aspx");
    }
    protected void btnAddGuide_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomer.aspx?Type=GUIDE");
    }
    protected void btnVEditCust_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditCustomer.aspx?Type=CUST");
    }
    protected void btnVEditLoc_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewLocation.aspx");
    }
    protected void btnVEditGuide_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditCustomer.aspx?Type=GUIDE");
    }
}
