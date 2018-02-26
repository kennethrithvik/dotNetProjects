<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="TMSWebApp.NewEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/tms.css" rel="stylesheet" />
    
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 335px;
        }
        .auto-style4 {
            height: 23px;
            width: 335px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 class="MainHeading">New Employee Registration</h2>
    
    </div>
    <table align="center" class="auto-style1" id="tblEmp">
        <tr>
            <th>Name</th>
            <td class="auto-style3">
                <asp:TextBox ID="txtName" runat="server" MaxLength="40"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Name cannot be empty" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>DOB</th>
            <td class="auto-style3">
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
&nbsp;(MM/DD/YYY)</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDOB" ErrorMessage="DOB should not be empty" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDOB" ErrorMessage="Invalid Date Format" Operator="DataTypeCheck" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDOB" ErrorMessage="DOB out of range" MinimumValue="01/01/1980" OnLoad="RangeValidator1_Load" SetFocusOnError="True" Type="Date">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <th class="auto-style2">Department ID</th>
            <td class="auto-style4">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <th>Role</th>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th>Manager</th>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th>Login Name</th>
            <td class="auto-style3">
                <asp:TextBox ID="txtLName" runat="server" MaxLength="40"></asp:TextBox>
                (Email)</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLName" ErrorMessage="Invalid Email" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th>Password</th>
            <td class="auto-style3">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">Confirm Password</th>
            <td class="auto-style4">
                <asp:TextBox ID="txtConPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConPass" ErrorMessage="Passwords not matching" SetFocusOnError="True">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <th class="auto-style2">Gender</th>
            <td class="auto-style4">
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="gender" Text="Male" />
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gender" Text="Female" />
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">&nbsp;</th>
            <td class="auto-style4">
                <asp:Button ID="btnOK" runat="server" Text="OK" />
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Correct all below errors and continue" />
    </form>
    </body>
</html>
