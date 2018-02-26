<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment_Success.aspx.cs" Inherits="HappyTripWebApp.Booking.Payment_Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/flight_seats.css" />
    <style type="text/css">
        tr.FlighSearchResult td
        {
            border: 1px solid black;
        }
        
        
        tr.FlighSearchResultHeader td
        {
         border: 1px solid black;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        var intlSearchToBookDays = 1;
    </script>
    <div class="Results">
        <div id="Wrapper">
            <div class="Container">
                <div id="ContentFrame" class="clearfix">
                    <div id="ModifySearchWrapper">
                        <div id="SearchParams">
                            <div id="SPRow">
                                <div id="mod_link_wrapper">
                                    <a href="<%= ResolveClientUrl("~/Index.aspx")%>" title="Click here to make a new search" id="mod_link"
                                        class="toggle_closed">Modify your search</a>
                                </div>
                                <ul class="inline">
                                    <li class="no_border"><asp:Label ID="lblHeaderFromCity" runat="server"></asp:Label> &ndash; <asp:Label ID="lblHeaderToCity" runat="server"></asp:Label></li>
                                    <li>
                                        <asp:Label ID="lblHeaderDepart" runat="server"></asp:Label>
                                        <asp:Label ID="lblHeaderDateSeparator" runat="server" Visible="true"> - </asp:Label>
                                        <asp:Label ID="lblHeaderReturn" runat="server"></asp:Label>,
                                        <asp:Label runat="server" ID="lblAdults"></asp:Label>
                                        Seat</li>
                                </ul>
                                <div id="SalesUpsell">
                                    <div class="clearfix" id="SUWrapper">
                                        Prefer booking over the phone? <span class="channel phone">Call 080123456789 <span
                                            class="weak">local call from any phone</span> </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--  end of search params div -->
                    <div class="Left">
                        <div class="col">
                        </div>
                        <!--  end of col div -->
                    </div>
                    <!--  end of left div -->
                    <!--  Begin : Right Div With Results Information -->
                    <div class="Right clearfix">
                        <!--  Begin : Col clearfix div -->
                        <div class="col clearfix">
                            <!-- Begin : Form to display all elements regarding flight search results -->
                            <!-- Begin : Flight and Price Info for Selected Flights by User -->
                            <div id="SelectionInfo" class="clearfix">
                                <!-- Begin : Display Total Price -->
                                <div id="divOnward" style="width: 45%; float: left;" class="dynamic_price">
                                    <span id="Span1" style="clear: left; float: left; font-size: 30px; font-weight: bold;
                                        padding-bottom: 5px; background-image: none; background-color: rgb(255, 255, 255);">
                                        Onward</span>
                                    <br style="line-height: 0px; clear: both;">
                                    <table cellspacing="1" cellpadding="5">
                                        <asp:Repeater ID="rptrOnwardFlightInfo" runat="server">
                                            <HeaderTemplate>
                                                <tr class="FlighSearchResultHeader">
                                                    <td>
                                                        <div class="airline_logos AI">
                                                        </div>
                                                    </td>
                                                    <td align="center">
                                                        <b>Flight No</b>
                                                    </td>
                                                    <td align="center">
                                                        <b>Route</b>
                                                    </td>
                                                    <td align="center">
                                                        <b>Date</b>
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="FlighSearchResult">
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %>
                                                    </td>
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %>
                                                        -
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                    </td>
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                        to
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                    </td>
                                                    <td>
                                                        <span class="departs">
                                                            <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span>
                                                        – <span class="arrives">
                                                            <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                <div id="divReturn" runat="server" visible="false" style="width: 45%; float: left;"
                                    class="dynamic_price">
                                    <span id="Span2" style="clear: left; float: left; font-size: 30px; font-weight: bold;
                                        padding-bottom: 5px; background-image: none; background-color: rgb(255, 255, 255);">
                                        Return</span>
                                    <br style="line-height: 0px; clear: both;">
                                    <table cellspacing="1" cellpadding="5">
                                        <asp:Repeater ID="rptrReturnFlightInfo" runat="server">
                                            <HeaderTemplate>
                                                <tr class="FlighSearchResultHeader">
                                                    <td>
                                                        <div class="airline_logos AI">
                                                        </div>
                                                    </td>
                                                    <td align="center">
                                                        <b>Flight No</b>
                                                    </td>
                                                    <td align="center">
                                                        <b>Route</b>
                                                    </td>
                                                    <td align="center">
                                                        <b>Date</b>
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="FlighSearchResult">
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %>
                                                    </td>
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %>
                                                        -
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                    </td>
                                                    <td>
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                        to
                                                        <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                    </td>
                                                    <td>
                                                        <span class="departs">
                                                            <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span>
                                                        – <span class="arrives">
                                                            <%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                            <div id="SearchParams"
									style="margin-left: 2px; margin-right: 300px;">

									<div id="Div2">
										<div>
											<ul class="inline">
												<li class="no_border"></li>
                                                <asp:Panel ID="pnlOnwardTicketno" runat="server">
                                                    Onward Ticket No : <asp:Label ID="lblOnwardTicketNo" runat="server"></asp:Label>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlReturnTicketNo" runat="server" Visible="false">
                                                    Return Ticket No : <asp:Label ID="lblReturnTicketNo" runat="server"></asp:Label>
                                                </asp:Panel>
											</ul>
										</div>
									</div>
								</div>
                            <%--<b>Total Price</b>: INR
                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                            &nbsp;<span style="background-image: none; background-color: rgb(255, 255, 255);"> &nbsp;&nbsp;--%><h3>
                                Passenger Details</h3>
                            </span>
                            <!-- Single Traveller block -->
                            <div id="intADDAD1" style="display: block;">
                                <table border="0" cellpadding="10" cellspacing="0" width="400px">
                                    <asp:Repeater ID="rptrPassengerInfo" runat="server">
                                        <HeaderTemplate>
                                            <tr>
                                                <td>
                                                    <h4>
                                                        Name</h4>
                                                </td>
                                                <td>
                                                    <h4>
                                                        Gender</h4>
                                                </td>
                                                <td>
                                                    <h4>
                                                        Date of Birth</h4>
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%#((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).Name.Trim()%>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).Gender%>
                                                </td>
                                                <td>
                                                    <%#((HappyTrip.Model.Entities.Transaction.Passenger)Container.DataItem).DateOfBirth.ToString("dd-MM-yyyy").Trim()%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            &nbsp;<span id="total_price" style="background-image: none; background-color: rgb(255, 255, 255);">
                                &nbsp;&nbsp;<h3>
                                    Contact Information:
                                </h3>
                            </span>
                            <table>
                                <tr>
                                    <td>
                                        <h4>
                                            Name:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>
                                            Address:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAddressline1" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <h4>
                                            City:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <h4>
                                            State:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>
                                            Phone Number:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPhno" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <h4>
                                            Mobile No:</h4>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMobno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email Id:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- end of universal div -->
            </div>
        </div>
    </div>
</asp:Content>

