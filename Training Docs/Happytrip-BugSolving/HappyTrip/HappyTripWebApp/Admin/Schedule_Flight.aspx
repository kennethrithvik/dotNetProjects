<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule_Flight.aspx.cs" Inherits="HappyTripWebApp.Admin.Schedule_Flight" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel"   %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/repeater_style.css" rel="stylesheet" type="text/css" /> 
     <style type="text/css">
        .AirlineGrid
        {
            clear: both;
        }
        .btnCreate
        {
            float: left;
        }
    </style>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Schedule Flight"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <center>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound1" 
            onitemcommand="Repeater1_ItemCommand">
        <HeaderTemplate>
        <table border"2" cellpadding="10" cellpadding="10" bordercolor="black" rules=all class="mGrid" width="90%">
            <tr>
                <th>ID</th>
                <th>From City</th>
                <th>To City</th>
                <th>Distance In Kms</th>
                <th>Departure Time</th>
                <th>Arrival Time</th>
                <th>Duration in Time</th>
        <th align="right">
                            Cost &nbsp &nbsp &nbsp &nbsp Seats
                        </th>
                        
                <th>Airline Name</th>
                <th>Flight Name</th>
                <th>Status</th>
                <th>Edit</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td>
            <asp:Label ID='lblscheduleid' runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' />
        </td>
        
        <td>
            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.FromCity.Name")%>
        </td>
        <td>
            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.ToCity.Name")%>
        </td>
        <td>
            <%#DataBinder.Eval(Container.DataItem, "RouteInfo.DistanceInKms")%>
        </td>
        <td>
        <%#DataBinder.Eval(Container.DataItem, "DepartureTime")%>
        </td>
        <td>
        <%#DataBinder.Eval(Container.DataItem, "ArrivalTime")%>
        </td>
        <td>
        <%#DataBinder.Eval(Container.DataItem, "DurationInMins")%>
        </td>
        <td>
         <table>
                                        <asp:Repeater  ID="dlFlightCost" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# ((FlightCost)Container.DataItem).Class.ToString()%>
                                                    </td>
                                                    
                                                    <td>
                                                        <%# ((FlightCost)Container.DataItem).CostPerTicket %>
                                                    </td>
                                                </tr>
                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
        </td>
        <td>
        <%#DataBinder.Eval(Container.DataItem, "FlightInfo.AirlineForFlight.Name")%>
        </td>
        <td>
        <%#DataBinder.Eval(Container.DataItem, "FlightInfo.Name")%>
        </td>
        <td>
                      <asp:CheckBox ID="CheckBox1" Checked='<%#DataBinder.Eval(Container.DataItem, "IsActive")%>' runat="server" Enabled="false"/>
        
        </td>
        <td>
                      <asp:LinkButton runat="server"  Text="Edit" />
        </td>        
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
        
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

    </p>
</asp:Content>
