<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRoute.aspx.cs" Inherits="HappyTripWebApp.Admin.AddRoute" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc:MenuC id="MenuControl" runat="server" />
<br />
<center>
<asp:Panel ID="Panel1" runat="server" CssClass="PopUpStyle">
            <a href="#" class="close" id="btnClose">
            <img src="../Images/close_pop.gif" onclick="return CloseWindow();" class="btn_close"
                title="Close Window" alt="Close" /></a>
        <div class="pnlHeader">
            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
                Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
                Font-Underline="True" Text="Add Route"></asp:Label>
        </div>
        <br /><br /><br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>From City:<span class="style6">*</span>
        
                </td>
                <td>
                    <asp:DropDownList ID="dpFromCity" runat="server" Height="24px" Width="140px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td>To City:<span class="style6">*</span></td>
            <td>
                <asp:DropDownList ID="dpToCity" runat="server" Height="24px" Width="139px">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td>Distance in Kms:<span class="style6">*</span></td>
            <td><asp:TextBox runat="server" ID="txtDistance"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Active:</td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            
            </tr>
        </table>
        
        <br />
            <asp:Label ID="lblError" runat="server" 
                Text="All mandatory fields must be filled " 
                style="color: #FF0000; font-weight: 700"></asp:Label>
            <br />
        <br />
        <asp:Button ID="btnSave" Text="Save" runat="server" 
            OnClick="btnSave_Click" />
        <asp:Button ID="Button2" Text="Clear" runat="server" onclick="Button2_Click" 
             />
        <br />
        <br />
        <br />

    </asp:Panel>
    </center>
</asp:Content>
