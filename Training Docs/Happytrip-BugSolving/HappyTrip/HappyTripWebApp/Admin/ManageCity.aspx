<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageCity.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageCity" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/GridviewStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .PopUpStyle
        {
            position: absolute;
            background: #737373;
            padding: 10px;
            border: 2px solid #ddd;
            float: left;
            font-size: 1.2em;
            position: fixed;
            top: 165px;
            left: 334px;
            width: 300px;
            z-index: 99999;
            box-shadow: 0px 0px 20px #999; /* CSS3 */
            -moz-box-shadow: 0px 0px 20px #999; /* Firefox */
            -webkit-box-shadow: 0px 0px 20px #999; /* Safari, Chrome */
            border-radius: 3px 3px 3px 3px;
            -moz-border-radius: 3px; /* Firefox */
            -webkit-border-radius: 3px; /* Safari, Chrome */
        }
        img.btn_close
        {
            float: right;
            margin: 1px -1px 0 0;
        }
        .ErrorMsg
        {
            color: Red;
            display: inline;
        }
    </style>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="City"></asp:Label>
    <br />
<br />
    <center>
        <asp:GridView ID="grdCity" runat="server" CssClass="mGrid" AllowPaging="True" 
            AutoGenerateColumns="False" PagerStyle-CssClass="pgr" Height="114px" 
            onrowcancelingedit="grdCity_RowCancelingEdit"  DataKeyNames="CityId"
            onrowediting="grdCity_RowEditing" onrowupdating="grdCity_RowUpdating" 
            onpageindexchanging="grdCity_PageIndexChanging">
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <PagerStyle CssClass="pgr"></PagerStyle>
            <Columns>
             <asp:TemplateField HeaderText="CityId">
             
             <ItemTemplate>
             
                 <asp:Label Text='<%#Eval("CityId") %>' runat="server" />
             </ItemTemplate>
             
             </asp:TemplateField>
             <asp:TemplateField HeaderText="CityName">
             
             <ItemTemplate>
             
                 <asp:Label Text='<%#Eval("Name") %>' runat="server" />
             </ItemTemplate>
             <EditItemTemplate>
             
                 <asp:TextBox ID="txtCityName"  Text='<%#Eval("Name") %>' runat="server" />
             </EditItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="State">
             
             <ItemTemplate>
             
                <%#DataBinder.Eval(Container.DataItem, "StateInfo.Name")%>
             </ItemTemplate>
             <EditItemTemplate>
             
                 <asp:TextBox ID="txtState"  Text='<%#DataBinder.Eval(Container.DataItem, "StateInfo.Name")%>' runat="server" ReadOnly="true" />
             </EditItemTemplate>
             </asp:TemplateField>
            
                <asp:CommandField ShowEditButton="True" />
            
            </Columns>

        </asp:GridView>
        <br />
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " 
            style="color: #FF0000; font-weight: 700"></asp:Label>
    </center>
    <asp:ObjectDataSource ID="odsCity" runat="server" SelectMethod="GetCities" TypeName="HappyTrip.Model.BusinessLayer.AirTravel.CityManager">
    </asp:ObjectDataSource>
    
</asp:Content>
