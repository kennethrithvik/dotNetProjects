<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RouteUI.aspx.cs" Inherits="HappyTripWebApp.Admin.RouteUI" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">

        .PopUpStyle{
	position:absolute;
	  background: #737373;
	  padding : 10px; 	
	  border : 2px solid #ddd;
	  float: left;
	  font-size: 1.2em;
	  position: fixed;
	  top: 165px; left: 334px;
	  width:300px;
	  z-index: 99999;
	  box-shadow: 0px 0px 20px #999; /* CSS3 */
      -moz-box-shadow: 0px 0px 20px #999; /* Firefox */
      -webkit-box-shadow: 0px 0px 20px #999; /* Safari, Chrome */
	  border-radius:3px 3px 3px 3px;
      -moz-border-radius: 3px; /* Firefox */
      -webkit-border-radius: 3px; /* Safari, Chrome */
}
img.btn_close { 
	float: right; 
	margin: 1px -1px 0 0;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Routes"></asp:Label>
    <br />
    <p>
        &nbsp;<center>
        <asp:GridView ID="GridView1" runat="server" Width="791px" 
            AutoGenerateColumns="False" 
            Height="217px" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">  
            
            <Columns>
                <asp:BoundField DataField="RouteId" HeaderText="ID" readonly="true" />
                <asp:BoundField DataField="FromCityName" HeaderText="From City" ReadOnly="true" />
                <asp:BoundField DataField="ToCityName" HeaderText="To City"  ReadOnly="true" />
                <asp:BoundField DataField="DistanceInKms" HeaderText="Distance Kms" />
                <asp:CheckBoxField DataField="Status" HeaderText="Active" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
            <asp:Label ID="lblError" runat="server" 
                Text="All mandatory fields must be filled " 
                style="color: #FF0000; font-weight: 700"></asp:Label>
        </center>
    </p>
    
</asp:Content>
