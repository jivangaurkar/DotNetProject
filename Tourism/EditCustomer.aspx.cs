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
using Tourism.BusinessInfo;
using Tourism.DataAccess;

public partial class EditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            /*Creating dataaccess object to get data members details.*/
            Member member = new Member();
            if (e.CommandName == "Edited")
            {
                /*get the data and assign it to object.*/
                MemberInfo memberInfo = member.GetMemberById(Convert.ToInt32(e.CommandArgument));

                /*Store the member information in session to use it in next screen.*/
                SessionManager.MemberInfo = memberInfo;

                /*Redirecting to AddCustomer page to display retrieved values in the page.*/
                Response.Redirect("AddCustomer.aspx");
            }
            else if (e.CommandName == "Deleted")
            {
                /*Deleting the member details using ID*/
                member.DeleteMember(Convert.ToInt32(e.CommandArgument));

                /*Re-Bind the grid to update the records.*/
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            /*Need to log this exception*/
        }
    }
}
