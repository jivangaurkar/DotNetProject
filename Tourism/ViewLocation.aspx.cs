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

public partial class ViewLocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {  /*Creating data access object to get data members details.*/
            Location location = new Location();
            if (e.CommandName == "Edited")
            {
                /*get the data and assign it to object.*/
                LocationInfo locationInfo = location.GetLocationById(Convert.ToInt32(e.CommandArgument));

                /*Store the location information in session to use it in next screen.*/
                SessionManager.LocationInfo = locationInfo;

                /*Redirecting to AddLocation page to display retrieved values in the page.*/
                Response.Redirect("AddLocation.aspx");
            }
            else if (e.CommandName == "Deleted")
            {
                /*Deleting the location details using ID*/
                location.Deletelocation(Convert.ToInt32(e.CommandArgument));

                /*Re-Bind the grid to update the records.*/
                grdLocation.DataBind();

            }
        }
        catch (Exception ex)
        {
            /*Log the exception to log file.*/
        }
    }
    protected void grdLocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*This page is used for public and private purpose, based query string we are hiding the edit and delete actions, this
         method is not recommended because anybody can change query sting and recommended way is to post the value from link click or maintain session.*/
        if (Request.QueryString["Type"] != null && e.Row.RowType != DataControlRowType.Pager && e.Row.RowType != DataControlRowType.EmptyDataRow)
        {
            e.Row.Cells[3].Visible = false;
        }
    }
}
