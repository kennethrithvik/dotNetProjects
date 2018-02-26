<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HappyTripWebApp.Admin.Home" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<center>
    <uc:MenuC ID="AdminMenu1" runat="server" />
    
    <br />

  

    <asp:Label ID="lblHi" runat="server" Text="Hi Admin," Font-Bold="True" Font-Italic="True" 
            Font-Names="Verdana" Font-Overline="False" Font-Size="X-Large" ForeColor="Red"
            ></asp:Label>

    <br />
    <asp:Label ID="lblWelcome" runat="server" Text="Welcome Home !!!" Font-Bold="True" Font-Italic="True" 
            Font-Names="Verdana" Font-Overline="False" Font-Size="X-Large" ForeColor="Red"></asp:Label>

</center>


</asp:Content>
