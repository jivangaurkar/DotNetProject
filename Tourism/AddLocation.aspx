<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="AddLocation.aspx.cs" Inherits="AddLocation" Title="Untitled Page" %>
<%-- * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table width="100%">
        <tr id="trImage" runat="server" visible="false">
            <td>
            </td>
            <td>
                <asp:Image ID="imgLocation" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Location Name:
            </td>
            <td>
                <asp:TextBox ID="txtLocatioName" runat="server" Columns="38"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Location Description:
            </td>
            <td>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="60" runat="server"
                    Columns="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Upload Image:
            </td>
            <td>
                <asp:FileUpload ID="ImgUpload" runat="server" Width="346" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnLocation" runat="server" Text="Save Location" CssClass="button1"
                    OnClick="btnLocation_Click" ValidationGroup="A" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button1" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="fontblack"></asp:Label>
                <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Please enter location name." ControlToValidate="txtLocatioName"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Please enter description." ControlToValidate="txtDescription" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ValidationGroup="A" ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Please upload image of location." ControlToValidate="ImgUpload"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="A" runat="server"
                    ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
