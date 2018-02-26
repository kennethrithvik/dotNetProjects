<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="HappyTripWebApp.Admin.WebForm1" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" >



        function Validation() {

            var a = document.getElementById('<%=txtCrCity.ClientID %>').value;

            var regex1 = /^[a-zA-Z]*$/;  //this is the pattern of regular expression

            if (regex1.test(a) == false) {
                
                return false;
            }

        }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc:MenuC id="MenuControl" runat="server" />
<br />
<center>
<asp:Panel ID="pnlCreate" runat="server" CssClass="PopUpStyle">
        
        <a href="#" class="close" id="btnClose">
            <img src="../Images/close_pop.gif" onclick="return CloseWindow();" class="btn_close"
                title="Close Window" alt="Close" /></a>
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
            Font-Names="Verdana" Font-Overline="False" Font-Size="Larger" 
            Font-Underline="True" Text="Add City"></asp:Label>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    City Name:<span class="style6">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtCrCity" runat="server" Width="134px" />
                </td>
            </tr>
            <tr>
                <td>
                    State:<span class="style6">*</span>
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="dpStateCity" runat="server" Height="27px" Width="169px">
                    </asp:DropDownList>
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
            OnClick="btnSave_Click" OnClientClick="javascript:return Validation();" />
        <asp:Button runat="server" ID="btnClear" Text="Clear"   
             onclick="btnClear_Click" />
        <br />
        <br />
        <br />
    </asp:Panel>
</center>
</asp:Content>
