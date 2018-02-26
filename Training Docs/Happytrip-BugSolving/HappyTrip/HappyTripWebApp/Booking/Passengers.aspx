<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Passengers.aspx.cs"
    Inherits="HappyTripWebApp.Passengers" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="Styles/flight_seats.css" />
    <script type="text/javascript">
        $(function () {
            $(".datePicker").datepicker({ showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                changeMonth: true,
                changeYear: true,
                buttonImageOnly: true,
                yearRange: '-90:+0',
                maxDate: 0
            });
        });
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
<div class="Results">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div id="ModifySearchWrapper">
                    <div id="SearchParams">
                        <div id="SPRow">
                            <div id="mod_link_wrapper">
                                <a class="toggle_closed" id="mod_link" title="Click here to make a new search" href="<%= ResolveClientUrl("~/Index.aspx")%>">Modify your search</a>
                            </div>
                            <ul class="inline">
                                <li class="no_border"><asp:Label ID="lblHeaderFromCity" runat="server"></asp:Label> &ndash; <asp:Label ID="lblHeaderToCity" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblHeaderDepart" runat="server"></asp:Label> <asp:Label ID="lblHeaderDateSeparator" runat="server" Visible="true"> - </asp:Label> <asp:Label ID="lblHeaderReturn" runat="server"></asp:Label>, <asp:Label runat="server" ID="lblAdults"></asp:Label> </li>
                            </ul>
                            <div id="SalesUpsell">
                                <div id="SUWrapper" class="clearfix">
                                    Prefer booking over the phone? <span class="channel phone">Call 080123456789 <span class="weak">local call from any phone</span> </span>
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
                            <div id="divOnward" style="width: 45%;float: left;" class="dynamic_price">
                                <span id="Span1" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px;background-image: none; background-color: rgb(255, 255, 255);">
                                    Onward</span>
                                <br style="line-height: 0px; clear: both;">
                                <table cellspacing="1" cellpadding="5">
                                    <asp:Repeater ID="rptrOnwardFlightInfo" runat="server">
                                        <HeaderTemplate>
                                            <tr>
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
                                            <tr>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %> 
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %> -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    
                                                    <span class="departs"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span> – 
                                                    <span class="arrives"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div id="divReturn" runat="server" visible="false" style="width: 45%;float: left;" class="dynamic_price">
                                <span id="Span2" style="clear: left; float: left; font-size: 30px; font-weight: bold; padding-bottom: 5px;background-image: none; background-color: rgb(255, 255, 255);">
                                    Return</span>
                                <br style="line-height: 0px; clear: both;">
                                <table cellspacing="1" cellpadding="5">
                                <asp:Repeater ID="rptrReturnFlightInfo" runat="server">
                                        <HeaderTemplate>
                                            <tr>
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
                                            <tr>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.Name %> 
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Name %> -
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).FlightInfo.AirlineForFlight.Code %>
                                                </td>
                                                <td>
                                                    <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.FromCity.Name %>
                                                    to <%# ((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).RouteInfo.ToCity.Name %>
                                                </td>
                                                <td>
                                                    
                                                    <span class="departs"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).DepartureTime.Ticks).ToString("HH:mm")) %></span> – 
                                                    <span class="arrives"><%# (new DateTime(((HappyTrip.Model.Entities.AirTravel.Schedule)Container.DataItem).ArrivalTime.Ticks).ToString("HH:mm")) %></span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                        <b>Total Price</b>: INR <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                        &nbsp;<span style="background-image: none; background-color: rgb(255, 255, 255);">
                            &nbsp;&nbsp;<h3>
                                Passenger Details</h3>
                        </span>
                        <!-- Single Traveller block -->
                        <asp:Repeater ID="rptrPassengerInfo" runat="server">
                            <ItemTemplate>
                                <div id="intADDAD1" style="display: block;" class="blockOptInBG clearFix active">
                                    <dl class="horizontal travellers row">
                                        <dt style="text-align: right;">
                                            <label class="" id="AdultOne" style="margin: 0; padding: 0; border: 0; font-weight: bold;
                                                font-style: normal; font-size: 120%; line-height: 1; font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif;">
                                                <%# Container.ItemIndex + 1 %>
                                            </label>
                                        </dt>
                                        <dd id="addAD1">
                                            Name:
                                            <asp:TextBox runat="server" ID="AdultFname" MaxLength="18" CssClass="required travellerFName name span four placeholder"
                                                minchars="1" title="Adult 1's first name" placeholder="First / Given Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ForeColor="Red" ID="rfvAdultFname" ValidationGroup="passenger" SetFocusOnError="true" Text="*" ControlToValidate="AdultFname" Display="Dynamic" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                            Gender:
                                            <asp:DropDownList ID="ddlGender" runat="server">
                                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                            </asp:DropDownList>
                                            Date of Birth:
                                            <asp:TextBox runat="server" ID="txtDOB" size="10" CssClass="datePicker required"
                                                placeholder="Date of Birth"></asp:TextBox>
                                                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvtxtDOB" ValidationGroup="passenger" SetFocusOnError="true" Text="*" ControlToValidate="txtDOB" Display="Dynamic" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                        </dd>
                                    </dl>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        &nbsp;<span id="total_price" style="background-image: none; background-color: rgb(255, 255, 255);">
                            &nbsp;&nbsp;<h3>
                                Contact Information:
                            </h3>
                        </span>
                        <table>
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" maxlength="18" minchars="1"
                                        title="Adult 1's first name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvName" ControlToValidate="txtName" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress" Rows="3" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvAddress" ControlToValidate="txtAddress" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    City:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvCity" ControlToValidate="txtCity" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    State:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvState" ControlToValidate="txtState" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Mobile No:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvMobile" ControlToValidate="txtMobile" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email Id:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="passenger" ForeColor="Red" ID="rfvEmailId" ControlToValidate="txtEmailId" Display="Dynamic" SetFocusOnError="true" runat="server" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <div id="button">
                            <asp:Button ID="btnBook" ValidationGroup="passenger" OnClick="btnBook_Click" Text="Proceed to Confirm" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- end of universal div -->
        </div>
    </div>
</div>
</asp:Content>
