<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/tms.Master" AutoEventWireup="true" CodeBehind="EFManageEmployee.aspx.cs" Inherits="TMSWebApp.Admin.EFManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <h2>
        Manage Employee Using Entity Framework
    </h2>
    
    <br/>
    <br/>
    <table width="50%" align="center">  
        <tr>
            <td>
                <div>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        
                    </asp:Panel>
                    <br/>
                    <br/>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" 
                        BorderWidth="1px"  
                        AutoGenerateColumns="False" OnLoad="GridView1_Load" >
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
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <a href='/Admin/EmployeeTrainingList.aspx?eid=<%#Eval("EmployeeID") %>'>  <%#Eval("Name") %>  </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Birth Date" DataField="DOB" DataFormatString="{0:d}"/>
                            <asp:BoundField HeaderText="Department" DataField="Department"/>
                            <asp:BoundField HeaderText="Role" DataField="Role"/>
                            
                        </Columns>
                    </asp:GridView>
                    
                    
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
