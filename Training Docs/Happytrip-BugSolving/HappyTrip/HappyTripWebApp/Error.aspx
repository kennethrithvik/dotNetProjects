<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HappyTripWebApp.Error" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="mainContent">
    Sorry, we couldn't complete your request
    <input type="button" value="Search for flights" title="search" class="booking" onclick="javascript:window.location.href='index.aspx'"/>
</asp:Content>

