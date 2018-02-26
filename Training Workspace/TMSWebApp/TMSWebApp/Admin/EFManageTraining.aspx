<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/tms.Master" AutoEventWireup="true" CodeBehind="EFManageTraining.aspx.cs" Inherits="TMSWebApp.Admin.EFManageTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <h2>
        Manage Training Using Entity Framework
    </h2>
    
    <br/>
    <br/>
    <table align="center" style="width: 74%">  
        <tr>
            <td>
                <div>
                    <asp:Panel ID="Panel3" runat="server">
                        <asp:Label ID="Label2" runat="server" Text="Search With :-"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:CheckBox ID="chkName" runat="server" Text="Name" AutoPostBack="True" OnCheckedChanged="chkName_CheckedChanged" />&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:CheckBox ID="chkDate" runat="server" Text="Date Range" AutoPostBack="True" OnCheckedChanged="chkDate_CheckedChanged" />
                        
                    </asp:Panel>
                    <br/>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                                
                    </asp:Panel>
                    <br/>
                    <asp:Panel ID="Panel2" runat="server" Height="27px" Visible="False">
                        <asp:Label ID="Label1" runat="server" Text="Enter Date Range"></asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="txtSd" runat="server"></asp:TextBox>&nbsp;-->&nbsp;
                        <asp:TextBox ID="txtED" runat="server"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid Date Format" ControlToValidate="txtSd" Operator="DataTypeCheck" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
&nbsp;</asp:Panel>
                    <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Visible="False"/>
                      <br/>  
                    <br/>
             
                    <asp:GridView ID="GridView1" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" 
                        BorderWidth="1px"  
                        AutoGenerateColumns="False" OnLoad="GridView1_Load" OnRowCommand="GridView1_RowCommand" >
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
                            <asp:BoundField HeaderText="Name" DataField="Training"/>
                            <asp:BoundField HeaderText="Start Date" DataField="StartDate" DataFormatString="{0:d}"/>
                            <asp:BoundField HeaderText="End Date" DataField="EndDate" DataFormatString="{0:d}"/>
                            <asp:BoundField HeaderText="Domain" DataField="Domain"/>
                            <asp:BoundField HeaderText="Credits" DataField="Credits"/>
                            
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="edt"  CommandArgument='<%#Eval("TrainingID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button ID="btnDel" runat="server" Text="Delete" CommandName="del"  CommandArgument='<%#Eval("TrainingID") %>' OnClientClick="return confirm('Are you sure you want to delete this user?');"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    
                    
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
