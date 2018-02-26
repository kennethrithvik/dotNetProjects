<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddAirline.aspx.cs" Inherits="HappyTripWebApp.Admin.EditAirline" %>
    <%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ErrorMsg
        {
            color: Red;
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <uc:MenuC id="MenuControl" runat="server" />
<br />
<center>
    <asp:Panel runat="server" CssClass="PopUpStyle" ID="pnlCreateAirline">
        <a href="#" class="close" id="btnClose">
            <img src="../Images/close_pop.gif" onclick="return CloseWindow();" class="btn_close"
                title="Close Window" alt="Close" /></a>
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
            Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
            Font-Underline="True" Text="Add Airline"></asp:Label>
        <br /><br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>Airline Name:<span class="ErrorMsg">*</span>
        
                </td>
                <td><asp:TextBox runat="server" ID="txtcrAirlineName"></asp:TextBox></td>
            </tr>
            <tr>
            <td>Airline Code:<span class="ErrorMsg">*</span></td>
            <td><asp:TextBox runat="server" ID="txtcrAirlineCode"></asp:TextBox></td>
            </tr>
            <tr>
            <td>Airline Logo Path:<span class="ErrorMsg">*</span></td>
            <td><asp:TextBox runat="server" ID="txtcrAirlineLogoPath"></asp:TextBox></td>
            </tr>
        </table>
        
        <br /><br />
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " 
            style="color: #FF0000; font-weight: 700"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnSave" Text="Save" runat="server" 
            OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnClear" Text="Clear"   
             onclick="btnClear_Click" />
        <br />
        <br />
        <asp:SqlDataSource ID="sdsAirline" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HappyTripConnectionString %>" 
            DeleteCommand="DELETE FROM [Airlines] WHERE [AirlineId] = @AirlineId" 
            InsertCommand="INSERT INTO [Airlines] ([AirlineName], [AirlineCode], [AirlineLogo]) VALUES (@AirlineName, @AirlineCode, @AirlineLogo)" 
            SelectCommand="SELECT * FROM [Airlines]" 
            UpdateCommand="UPDATE [Airlines] SET [AirlineName] = @AirlineName, [AirlineCode] = @AirlineCode, [AirlineLogo] = @AirlineLogo WHERE [AirlineId] = @AirlineId">
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
        <br />
    </asp:Panel>    
    </center>
</asp:Content>
