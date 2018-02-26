<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageFlights.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageFlights" %>
    <%@ Import Namespace="HappyTrip.Model.Entities.AirTravel"   %>
    <%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/repeater_style.css" rel="stylesheet" type="text/css" /> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Flight Details"></asp:Label>
    <br />
        <center>
            <table border="1" cellpadding="20" cellspacing="0" class="mGrid">
                <!--End : List of Columns for the display -->
                <!--Begin : Header for Columns for the display -->
                <thead>
                    <tr>
                        <th>
                            ID
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            AirLine
                        </th>
                        <th>
                            Select
                        </th>
                        <th align="right">
                            Cost &nbsp &nbsp &nbsp &nbsp Seats
                        </th>
                        <th>
                            Edit
                        </th>
                    </tr>
                </thead>
                                <tbody>
                    <asp:Repeater ID="dlFlight" runat="server" 
                        OnItemDataBound="dlFlight_ItemDataBound" onitemcommand="dlFlight_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                   <asp:Label ID='lblflightid' runat="server" Text='<%# ((Flight)Container.DataItem).ID %>' /> 
                                </td>
                                <td>
                                    <%# ((Flight)Container.DataItem).Name %>
                                </td>
                                <td>
                                    <%# ((Flight)Container.DataItem).AirlineForFlight.Name %>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </td>
                                <td align="center">
                                    <table>
                                        <asp:Repeater  ID="dlFlightClass" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# ((FlightClass)Container.DataItem).ClassInfo.ToString() %>
                                                    </td>
                                                    <td>
                                                        <%# ((FlightClass)Container.DataItem).NoOfSeats %>
                                                    </td>
                                                </tr>
                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                                <td>
                                    <asp:Button Text="Edit" ID="btnEdit" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </center>
            </div>
    <br /><center>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                        <asp:LinkButton Text="Prev" ID="commandPrevious" runat="server" 
                            onclick="commandPrevious_Click" />
                    </td>
                    <td>
                        
                        <asp:Label Text="" ID="lblCurrentPage" runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton Text="Next" ID="commandNext" runat="server" 
                            onclick="commandNext_Click" />
                    
                    </td>
                </tr>
            </table>
            </center>
<br />
</asp:Content>
