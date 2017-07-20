<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ViewLocation.aspx.cs" Inherits="ViewLocation" Title="Untitled Page" %>
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
                <asp:GridView Width="100%" ID="grdLocation" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="LocationId" DataSourceID="SqlDataSource1" CellSpacing="1" PageSize="4"
                    OnRowCommand="grdLocation_RowCommand" OnRowDataBound="grdLocation_RowDataBound" EmptyDataText ="No records found.">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderColor="Black" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="LocationName" HeaderText="Location Name" SortExpression="LocationName">
                            <ItemStyle ForeColor="Black" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                            <ItemStyle ForeColor="Black" Width="52%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%#Eval("LocationUrl") %>' Width="100" Height="100" ID="imgLocation"
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Img/icon_edit.gif" ToolTip="Edit"
                                    CommandArgument='<%# Eval("LocationId")%>' CommandName="Edited" />
                                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="Img/icon_delete.gif"
                                    ToolTip="Delete" CommandArgument='<%# Eval("LocationId")%>' CommandName="Deleted"
                                    OnClientClick="if(!confirm('Are you sure, you want to delete the location?')) return false; else return true;" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>"
        SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
</asp:Content>
