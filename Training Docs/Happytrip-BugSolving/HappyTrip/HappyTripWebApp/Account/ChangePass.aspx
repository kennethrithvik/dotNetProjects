<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="HappyTripWebApp.Account.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Styles/main.css" />
    <link rel="stylesheet" href="../Styles/register.css" />
    <link type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <link type="text/css" href="../Styles/nivo-slider.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Styles/themes/default.css" type="text/css" media="screen" />
    
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.nivo.slider.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="legend">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Account/UpdateProfile.aspx" >Profile</asp:HyperLink>
                                    &nbsp;| 
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        >Change Password</asp:HyperLink>
                                        <%if (Roles.IsUserInRole("Administrator"))
                                          { %>
&nbsp;&nbsp;| 
                                    <asp:HyperLink ID="HyperLink2" runat="server" 
                                        NavigateUrl="~/Admin/Home.aspx">Admin Home</asp:HyperLink></h3>
                                        <%} %>
    <center>
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
        onchangedpassword="ChangePassword1_ChangedPassword" 
    ContinueDestinationPageUrl="~/Account/UpdateProfile.aspx" CancelDestinationPageUrl="~/Account/UpdateProfile.aspx">

        <ChangePasswordTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <strong>Change Your Password</strong></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                        AssociatedControlID="CurrentPassword">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                        ControlToValidate="CurrentPassword" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." CssClass="errorLabel" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" 
                                        AssociatedControlID="NewPassword">New Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                        ControlToValidate="NewPassword" ErrorMessage="New Password is required." 
                                        ToolTip="New Password is required." CssClass="errorLabel" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmNewPassword" 
                                        ErrorMessage="Confirm New Password is required." 
                                        ToolTip="Confirm New Password is required." CssClass="errorLabel" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                        ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                        Display="Dynamic" CssClass="errorLabel" 
                                        ErrorMessage="The Confirm New Password must match the New Password entry." 
                                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" class="errorLabel">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                        CommandName="ChangePassword" Text="Change Password" 
                                        ValidationGroup="ChangePassword1" />
                                </td>
                                <td>
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
    </center>
</asp:Content>
