<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminControl.ascx.cs" Inherits="HappyTripWebApp.Admin.WebUserControl1" %>
-<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-base.css" />
<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-topbar.css" />
<link rel="stylesheet" type="text/css" href="ddlevelsfiles/ddlevelsmenu-sidebar.css" />

<script type="text/javascript" src="ddlevelsfiles/ddlevelsmenu.js"></script>
<div id="ddtopmenubar" class="mattblackmenu">
<ul>
<li><a href="#" rel="schedulesubmenu">Schedule</a></li>
<li><a href="#" rel="flightsubmenu">Flight</a></li>
<li><a href="#" rel="citysubmenu">City</a></li>
<li><a href="#" rel="airlinesubmenu">Airlines</a></li>
<li><a href="#" rel="routessubmenu">Routes</a></li>
</ul>
</div>

<script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>


<ul id="schedulesubmenu" class="ddsubmenustyle">
<li><a href="Add_Schedule.aspx">Add Schedule</a></li>
<li><a href="Schedule_Flight.aspx">Edit Schedule</a></li>
<li><a href="Schedule_Flight.aspx">View Schedule</a></li>
</ul>


<ul id="flightsubmenu" class="ddsubmenustyle">
<li><a href="AddFlight.aspx">Add Flight</a></li>
<li><a href="ManageFlights.aspx">Edit Flight</a></li>
<li><a href="ManageFlights.aspx">View Flight</a></li>
</ul>


<ul id="citysubmenu" class="ddsubmenustyle">
<li><a href="AddCity.aspx">Add City</a></li>
<li><a href="ManageCity.aspx">View City</a></li>
</ul>


<ul id="airlinesubmenu" class="ddsubmenustyle">
<li><a href="AddAirline.aspx">Add Airline</a></li>
<li><a href="ManageAirLines.aspx">View Airline</a></li>
</ul>


<ul id="routessubmenu" class="ddsubmenustyle">
<li><a href="AddRoute.aspx">Add Route</a></li>
<li><a href="RouteUI.aspx">View Route</a></li>
</ul>

