<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_Schedule.aspx.cs" Inherits="HappyTripWebApp.Admin.Add_Schedule" %>
    <%@ Import Namespace="HappyTrip.Model.Entities.AirTravel"   %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 137px;
        }
        .style6
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc:MenuC id="MenuControl" runat="server" />
    <br />
    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Add Schedule"></asp:Label>
    <br />
<br />
    <center><table style="width: 30%; height: 396px;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="From City:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpFromCity" runat="server" Height="24px" Width="152px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="To City:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpToCity" runat="server" Height="24px" Width="148px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Departure Time:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="HH"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="MM"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Arrival Time:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="HH"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList4" runat="server" Height="24px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="MM"></asp:Label>
&nbsp;
                <asp:DropDownList ID="DropDownList5" runat="server" Height="23px" Width="50px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Duration:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:TextBox ID="txtDuration" runat="server" Height="24px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label15" runat="server" Text="Class"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <table style="width:51%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="Repeater1" runat="server">
                                       <ItemTemplate>
                                <tr class="ClassRow">
                                    <td class="ClassItem">
                                         <asp:Label ID="ClassName" Text='<%# ((TravelClass)Container.DataItem).ToString() %>' runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                    <td class="ClassNoOfSeats">
                                        <asp:TextBox ID="txtCostPerTicket" Text="0" Width="50px" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="Airline Name:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpAirlineName" runat="server" 
                    onselectedindexchanged="dpAirlineName_SelectedIndexChanged" 
                    AutoPostBack="True" Height="22px" Width="135px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label7" runat="server" Text="Flight Name:"></asp:Label>
            &nbsp;<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpFlightName" runat="server" Height="22px" Width="131px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label8" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2" align="center"">
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                    Text="Clear" />
            </td>
        </tr>
    </table>
        <br />
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " ForeColor="Red"></asp:Label>
    </center>
</asp:Content>
