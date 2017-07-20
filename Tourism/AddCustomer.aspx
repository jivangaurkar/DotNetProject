<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="AddCustomer.aspx.cs" Inherits="AddCustomer" %>
    
<%-- * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 --%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table width="100%" style="background: img/m20.gif">
        <tr height="20">
            <td colspan="5">
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                Last Name:
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
                First Name:
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                Middle Name:
            </td>
            <td>
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
                Phone Number:
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                Mobile Number:
            </td>
            <td>
                <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
                Email:
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                Address1:
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
                Address2:
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                City:
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
                State:
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20">
            <td width="50">
            </td>
            <td class="td1">
                Zip code:
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
            </td>
            <td class="td1">
            </td>
            <td>
            </td>
        </tr>
        <tr height="50">
            <td align="center" colspan="5">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button1" OnClick="btnSubmit_Click"
                    ValidationGroup="A" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button1" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" align="center">
                <asp:Label ID="lblMessage" runat="server" CssClass="fontgreen"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" align="center">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastname"
                    runat="server" ErrorMessage="Please enter last name." Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter first name."
                    ControlToValidate="txtFirstName" Display="None" EnableTheming="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter middle name."
                    ControlToValidate="txtMiddleName" Display="None" EnableTheming="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Please enter phone number." ControlToValidate="txtPhoneNo" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator9" runat="server"
                    ErrorMessage="Please enter email." ControlToValidate="txtEmail" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="Please enter Address1." ControlToValidate="txtAddress1" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator6" runat="server"
                    ErrorMessage="Please enter city name." ControlToValidate="txtCity" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Please enter state name." ControlToValidate="txtState" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator8" runat="server"
                    ErrorMessage="Please enter zip." ControlToValidate="txtZip" EnableTheming="True"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Please enter valid email address." ControlToValidate="txtEmail"
                    EnableTheming="True" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    EnableTheming="True" ShowSummary="False" ValidationGroup="A" />
            </td>
        </tr>
    </table>
</asp:Content>
