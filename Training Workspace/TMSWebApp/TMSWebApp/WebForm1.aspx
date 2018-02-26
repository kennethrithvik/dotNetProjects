<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TMSWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body style="height: 216px">
    <form id="form1" runat="server">
    <div>
        <h1 align="center">My First ASP.net Page for <% =company %></h1>
        
        
        <br/>
        <br/>
    
    </div>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblName" runat="server" BackColor="#66FF66" Font-Names="Arial" Font-Size="Larger" ForeColor="#000066" Text="Enter your Name" OnInit="lblName_Init"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtName" runat="server" OnInit="txtName_Init" OnLoad="txtName_Load" OnPreRender="txtName_PreRender" OnTextChanged="txtName_TextChanged">Enter here</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnLoad="DropDownList1_Load" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="1">Monday</asp:ListItem>
                        <asp:ListItem Value="2">Tuesday</asp:ListItem>
                        <asp:ListItem Value="3">Wednesday</asp:ListItem>
                        <asp:ListItem Value="4">Thursday</asp:ListItem>
                        <asp:ListItem Value="5">Friday</asp:ListItem>
                        <asp:ListItem Value="6">Saturday</asp:ListItem>
                        <asp:ListItem Value="7">Sunday</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="lblMessage" runat="server" Text="Label" EnableViewState="False"></asp:Label>
        </p>
    </form>
</body>
</html>
