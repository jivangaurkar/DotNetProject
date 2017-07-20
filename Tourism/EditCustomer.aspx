<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="EditCustomer.aspx.cs" Inherits="EditCustomer" Title="Untitled Page" %>
<%-- * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table width="100%">
        <tr>
            <td width="13">
            </td>
            <td>
                <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="MemberId" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowCommand="GridView1_RowCommand" AllowSorting="True" AllowPaging="True"
                    CellSpacing="1" EmptyDataText ="No records found.">
                    <Columns>
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" SortExpression="PhoneNo">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                            <ItemStyle ForeColor="Black" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Img/icon_edit.gif" ToolTip="Delete"
                                    CommandArgument='<%# Eval("MemberId")%>' CommandName="Edited" />
                                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="Img/icon_delete.gif"
                                    ToolTip="Delete" CommandArgument='<%# Eval("MemberId")%>' CommandName="Deleted"
                                    OnClientClick="if(!confirm('Are you sure, you want to delete?')) return false; else return true;" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>"
        SelectCommand="usp_GetMemberListByType" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="Type" QueryStringField="Type" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
