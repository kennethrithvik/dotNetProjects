<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSchedule.aspx.cs" Inherits="HappyTripWebApp.Admin.EditSchedule" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel"   %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Edit Schedule Flight"></asp:Label>
    <br />
<br/>
    <center><table style="width: 30%; height: 425px;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="From City:" 
                    style="text-align: left"></asp:Label>
            </td>
            <td class="style18">
                <asp:DropDownList ID="dpFromCity" runat="server" Height="28px" Width="152px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="Label2" runat="server" Text="To City:"></asp:Label>
            </td>
            <td class="style17">
                <asp:DropDownList ID="dpToCity" runat="server" Height="35px" Width="148px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style14">
                <asp:Label ID="Label3" runat="server" Text="Departure Time:"></asp:Label>
            </td>
            <td class="style15">
                <asp:Label ID="Label9" runat="server" Text="HH"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="MM"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label4" runat="server" Text="Arrival Time:"></asp:Label>
            </td>
            <td class="style13">
                <asp:Label ID="Label12" runat="server" Text="HH"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList4" runat="server" Height="26px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="MM"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList5" runat="server" Height="25px" Width="50px" 
                    >
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label5" runat="server" Text="Duration:"></asp:Label>
            </td>
            <td class="style5" valign=middle align=center>
                
                <asp:TextBox ID="txtDuration" runat="server" Height="24px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label15" runat="server" Text="Class"></asp:Label>
            </td>
            <td class="style11">
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                                    onrowediting="GridView1_RowEditing" 
                                onrowupdating="GridView1_RowUpdating" Width="207px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Class">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClass" Text='<%#Eval("Class") %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            
                                            <asp:TextBox ID="txtClass" Text='<%# ((FlightCost)Container.DataItem).Class.ToString()%>'
                                                    runat="server" ReadOnly="true" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cost">
                                            <ItemTemplate>
                                            <asp:Label ID="lblCost" Text='<%#Eval("CostPerTicket") %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            
                                            <asp:TextBox ID="txtCost" Text='<%# ((FlightCost)Container.DataItem).CostPerTicket %>'
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                                    </Columns>
                                </asp:GridView>
                                </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label6" runat="server" Text="Airline Name:"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="dpAirlineName" runat="server" 
                     
                    AutoPostBack="True" Height="24px" Width="135px" 
                    onselectedindexchanged="dpAirlineName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label7" runat="server" Text="Floight Name:"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="dpFlightName" runat="server" Height="27px" Width="131px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label8" runat="server" Text="Active"></asp:Label>
            </td>
            <td class="style5">
                <asp:CheckBox ID="chkStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    onclick="btnUpdate_Click" />
            </td>
            <td class="style3">
                <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click1" 
                    Text="Cancel" />
            </td>
        </tr>
        
    </table>
    <asp:Label ID="lblError" runat="server" 
             ForeColor="Red"></asp:Label>
    </center>

</asp:Content>
