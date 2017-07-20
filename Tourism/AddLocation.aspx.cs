/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.IO;
using Tourism.BusinessInfo;
using Tourism.DataAccess;

public partial class AddLocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*If the session has location's information then fill that data to controls.*/
            if (SessionManager.LocationInfo != null)
            {
                FillFields(SessionManager.LocationInfo);
            }
        }

    }

    /// <summary>
    /// Fill members data to controls
    /// </summary>
    /// <param name="locationInfo"></param>
    private void FillFields(LocationInfo locationInfo)
    {
        txtLocatioName.Text = locationInfo.LocationName;
        txtDescription.Text = locationInfo.Description;
        imgLocation.ImageUrl = locationInfo.LocationUrl;
        trImage.Visible = true;
        ImgUpload.Visible = false;
        RequiredFieldValidator3.Enabled = false;
    }
    protected void btnLocation_Click(object sender, EventArgs e)
    {
        try
        {
            /*Create location object and assign values from controls, we will use this object to pass values from one layer to other.*/
            LocationInfo locationInfo = new LocationInfo();
            locationInfo.LocationName = txtLocatioName.Text.Trim();
            locationInfo.Description = txtDescription.Text.Trim();

            /*Creating dataaccess object to insert/update the assigned data.*/
            Location location = new Location();

            if (SessionManager.LocationInfo == null) /* this operation is to save new location*/
            {
               
                FileInfo file = new FileInfo(ImgUpload.FileName);
                string ext = file.Extension.ToLower();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".tif" && ext != ".bmp" && ext != ".png") /*Checking file extension*/
                {
                    lblMessage.Text = "Uploaded file is not a valid image. supported formats (jpg, jpeg, gif, tif, bmp, png)";
                    return;
                }
                else if (ImgUpload.FileContent.Length > 2.5 * 1024 * 1024)/*Checking uploaded file size.*/
                {
                    lblMessage.Text = "File size should not exceed 2.5 MB.";
                    return;
                }
                else
                {
                    /*Saving file to server physical path.*/
                    string imgLoc = "~/LocationImages/" + Guid.NewGuid().ToString() + ImgUpload.FileName;
                    locationInfo.LocationUrl = imgLoc;
                    ImgUpload.SaveAs(MapPath(imgLoc));
                    location.InsertLocation(locationInfo);

                }
            }
            else/*this operation is to update existing location*/
            {
                /*Before updating the data, assigning the LocationId and LocationUrl to newly created locationInfo Object*/
                locationInfo.LocationId = SessionManager.LocationInfo.LocationId;
                locationInfo.LocationUrl = SessionManager.LocationInfo.LocationUrl;
                location.UpdateLocation(locationInfo);

                /*Making session null*/
                SessionManager.LocationInfo = null;

                trImage.Visible = false;
                RequiredFieldValidator3.Enabled = true;
                ImgUpload.Visible = true;
            }
            ClearControls();
            lblMessage.Text = "Location saved successfully.";
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Unable to save Location.";
        }

    }

    /// <summary>
    /// Clearing all controls.
    /// </summary>
    private void ClearControls()
    {
        txtDescription.Text = string.Empty;
        txtLocatioName.Text = string.Empty;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
        lblMessage.Text = string.Empty;
    }
}
