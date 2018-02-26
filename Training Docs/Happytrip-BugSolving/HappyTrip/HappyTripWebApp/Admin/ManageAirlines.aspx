<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageAirlines.aspx.cs" Inherits="HappyTripWebApp.Admin.ManageAirlines" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/GridviewStyle.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
        Font-Underline="True" Text="Airlines"></asp:Label>
    <br />
<br />
    &nbsp;<center> <asp:GridView ID="grdAirline" runat="server" 
            CssClass="AirlineGrid mGrid" AllowPaging="True"
        DataSourceID="sdsAirline" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
        PagerStyle-CssClass="pgr" DataKeyNames="AirlineId" PageSize="5" 
        Width="70%" Height="184px">
        <Columns>
            <asp:BoundField DataField="AirlineId" HeaderText="AirlineId" InsertVisible="False"
                ReadOnly="True" SortExpression="AirlineId" />
            <asp:BoundField DataField="AirlineName" HeaderText="AirlineName" SortExpression="AirlineName" />
            <asp:BoundField DataField="AirlineCode" HeaderText="AirlineCode" SortExpression="AirlineCode" />
            <asp:BoundField DataField="AirlineLogo" HeaderText="AirlineLogo" SortExpression="AirlineLogo" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
        <br />
    </center>
    <asp:SqlDataSource ID="sdsAirline" runat="server" ConnectionString="<%$ ConnectionStrings:HappyTripConnectionString %>"
        DeleteCommand="DELETE FROM [Airlines] WHERE [AirlineId] = @AirlineId" InsertCommand="INSERT INTO [Airlines] ([AirlineName], [AirlineCode], [AirlineLogo]) VALUES (@AirlineName, @AirlineCode, @AirlineLogo)"
        SelectCommand="SELECT * FROM [Airlines]" UpdateCommand="UPDATE [Airlines] SET [AirlineName] = @AirlineName, [AirlineCode] = @AirlineCode, [AirlineLogo] = @AirlineLogo WHERE [AirlineId] = @AirlineId">
        <DeleteParameters>
            <asp:Parameter Name="AirlineId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AirlineName" Type="String" />
            <asp:Parameter Name="AirlineCode" Type="String" />
            <asp:Parameter Name="AirlineLogo" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="AirlineName" Type="String" />
            <asp:Parameter Name="AirlineCode" Type="String" />
            <asp:Parameter Name="AirlineLogo" Type="String" />
            <asp:Parameter Name="AirlineId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
