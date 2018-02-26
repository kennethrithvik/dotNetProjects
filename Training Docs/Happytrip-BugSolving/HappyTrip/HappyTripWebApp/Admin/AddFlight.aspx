<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddFlight.aspx.cs" Inherits="HappyTripWebApp.Admin.AddFlight" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ErrorMsg
        {
            color: Red;
            display: inline;
        }
    </style>
    <script type="text/javascript">
        /// <reference path="../Scripts/jquery-1.4.1.js"/>
   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Add Flight"></asp:Label>
    <br />
<br />
    <center>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    Name:<span class="ErrorMsg">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Airline:<span class="ErrorMsg">*</span>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAirLine" runat="server" Height="24px" Width="155px">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td align="right">
                    Class/Seats<span class="ErrorMsg">*</span>
                </td>
                <td>
                    <table>
                        <tr>
                            <th>
                                Class
                            </th>
                            <th>
                                Seats
                            </th>
                        </tr>
                        <asp:Repeater ID="dlClass" runat="server">
                            <ItemTemplate>
                                <tr class="ClassRow">
                                    <td class="ClassItem">
                                        <asp:Label ID="lblClass" Text='<%# ((TravelClass)Container.DataItem).ToString() %>' runat="server" />    
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="ClassNoOfSeats" ID="txtNoOfSeats" Text="0" Width="50px" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Add" ID="btnAdd"  
                        runat="server" onclick="btnAdd_Click"  />
                </td>
                <td>
                    <asp:Button Text="Clear" ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                         />
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
