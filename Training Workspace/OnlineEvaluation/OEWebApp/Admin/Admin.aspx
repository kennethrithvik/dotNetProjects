<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/OEMP.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="OEWebApp.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Admin page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightDiv" runat="server">
    <h2>
        Manage Users
    </h2>
    
    <br/>
    <br/>
    <table width="50%" align="center">  
        <tr>
            <td>
                <div>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        
                    </asp:Panel>
                    <br/>
                    <br/>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" 
                        BorderWidth="1px"  
                        AutoGenerateColumns="false" OnLoad="GridView1_Load" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="name"/>
                            <asp:BoundField HeaderText="Login Name" DataField="login" />
                            <asp:BoundField HeaderText="Score" DataField="score"/>
                            
                        </Columns>
                    </asp:GridView>

                    
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
