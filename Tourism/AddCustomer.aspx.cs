/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */

using System;
using System.Web.UI;
using Tourism.BusinessInfo;
using Tourism.DataAccess;

public partial class AddCustomer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.DefaultButton = btnSubmit.UniqueID;
        if (!IsPostBack)
        {
            /*If the session has Member's information then fill that data to controls.*/
            if (SessionManager.MemberInfo != null)
            {
                FillMember(SessionManager.MemberInfo);
            }
        }
    }

    /// <summary>
    /// Fills member data to controls.
    /// </summary>
    /// <param name="memberInfo"></param>
    private void FillMember(MemberInfo memberInfo)
    {
        txtLastName.Text = memberInfo.LastName;
        txtFirstName.Text = memberInfo.FirstName;
        txtMiddleName.Text = memberInfo.MiddleName;
        txtPhoneNo.Text = memberInfo.PhoneNo;
        txtMobileNo.Text = memberInfo.MobileNo;
        txtEmail.Text = memberInfo.Email;
        txtAddress1.Text = memberInfo.AddressInfo.Address1;
        txtAddress2.Text = memberInfo.AddressInfo.Address2;
        txtCity.Text = memberInfo.AddressInfo.City;
        txtState.Text = memberInfo.AddressInfo.State;
        txtZip.Text = memberInfo.AddressInfo.Zip;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            /*Create member object and assign values from controls.*/
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.LastName = txtLastName.Text.Trim();
            memberInfo.FirstName = txtFirstName.Text.Trim();
            memberInfo.MiddleName = txtMiddleName.Text.Trim();
            memberInfo.PhoneNo = txtPhoneNo.Text.Trim();
            memberInfo.MobileNo = txtMobileNo.Text.Trim();
            memberInfo.Email = txtEmail.Text.Trim();
            memberInfo.AddressInfo.Address1 = txtAddress1.Text.Trim();
            memberInfo.AddressInfo.Address2 = txtAddress2.Text.Trim();
            memberInfo.AddressInfo.City = txtCity.Text.Trim();
            memberInfo.AddressInfo.State = txtState.Text.Trim();
            memberInfo.AddressInfo.Zip = txtZip.Text.Trim();

            /*Creating dataaccess object to insert/update the assigned data.*/
            Member member = new Member();
            if (Request.QueryString["Type"] != null)
            {
                /*This query sting values helps us to determine the member type.*/
                string memberType = Request.QueryString["Type"].ToString();
                memberInfo.MemberType = memberType;
            }

            /*If the session is null, which means this data is not for editing and insert a new record into the database.*/
            if (SessionManager.MemberInfo == null)
            {
                member.InsertMember(memberInfo);
            }
            else /*If session has data, which means this data is for editing and need update the existing data in the database.*/
            {
                /*Before updating the data, assigning the MemberID and MemberType and AddressID to newly created MemberInfo Object*/
                memberInfo.MemberId = SessionManager.MemberInfo.MemberId;
                memberInfo.MemberType = SessionManager.MemberInfo.MemberType;
                memberInfo.AddressInfo.AddressId = SessionManager.MemberInfo.AddressInfo.AddressId;
                member.UpdateMember(memberInfo);
            }
            lblMessage.Text = "Details saved successfully.";
            ClearControls();
        }
        catch (Exception ex)
        {
            ClearControls();
            lblMessage.Text = "Unable to save data, error:" + ex.Message;
        }
    }

    /// <summary>
    /// Clearing all controls.
    /// </summary>
    private void ClearControls()
    {
        txtLastName.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtMiddleName.Text = string.Empty;
        txtPhoneNo.Text = string.Empty;
        txtMobileNo.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress1.Text = string.Empty;
        txtAddress2.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtState.Text = string.Empty;
        txtZip.Text = string.Empty;
        /*Making session null*/
        SessionManager.MemberInfo = null;

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
        lblMessage.Text = string.Empty;
    }
}
