<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/tms.Master" AutoEventWireup="true" CodeBehind="EditTraining.aspx.cs" Inherits="TMSWebApp.Admin.EditTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
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
    <h2>Edit Training</h2>
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
            <th>&nbsp;</th>
            <td class="auto-style3">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th>Start Date</th>
            <td class="auto-style3">
                <asp:TextBox ID="txtSD" runat="server"></asp:TextBox>
&nbsp;(MM/DD/YYY)</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSD" ErrorMessage="DOB should not be empty" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSD" ErrorMessage="Invalid Date Format" Operator="DataTypeCheck" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <th>&nbsp;</th>
            <td class="auto-style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">End Date</th>
            <td class="auto-style4">
                <asp:TextBox ID="txtED" runat="server"></asp:TextBox>
                (MM/DD/YYY)</td>
            <td class="auto-style2">
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtED" ErrorMessage="Invalid Date Format" Operator="DataTypeCheck" SetFocusOnError="True" Type="Date">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtED" ErrorMessage="DOB should not be empty" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <th>&nbsp;</th>
            <td class="auto-style3">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th>Domain</th>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlDomain" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">&nbsp;</th>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">Credits</th>
            <td class="auto-style4">
                <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCredits" ErrorMessage="Credits not given">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th class="auto-style2">&nbsp;</th>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <th class="auto-style2">&nbsp;</th>
            <td class="auto-style4">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Correct all below errors and continue" />

</asp:Content>
