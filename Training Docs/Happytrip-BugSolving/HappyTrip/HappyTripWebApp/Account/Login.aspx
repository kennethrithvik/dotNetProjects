<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="HappyTripWebApp.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="../Styles/account.css" type="text/css"/>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="Signin">
        <div id="Wrapper">
            <div class="Container">
                <div id="ContentFrame" class="clearfix">
                    <div class="Left">
                        <div class="col">
                            <h1>
                                Sign in to Happytrip
                            </h1>
                            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
                                RenderOuterTable="false" 
                                FailureText="Your Login attempt was not Successful. Please try again.">
                                <LayoutTemplate>
                                    <span class="failureNotification errorLabel">
                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </span>
                                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="hint errorLabel"
                                        ValidationGroup="LoginUserValidationGroup" EnableViewState="true" 
                                        />
                                    <div class="accountInfo">
                                        <dl class="vertical">
                                            <fieldset class="login">
                                                <dt>
                                                    <asp:Label ID="UserNameLabel" runat="server" CssClass="required" AssociatedControlID="UserName">Username</asp:Label>
                                                </dt>
                                                <dd>
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                                </dd>
                                                <dd class="hint">
                                                    This is the email address you registered with</dd>
                                                <dt>
                                                    <asp:Label ID="PasswordLabel" CssClass="required" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                                </dt>
                                                <dd>
                                                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                                </dd>
                                                <dd>
                                                <div>
                                                <div style="float:left">
                                                <asp:CheckBox ID="RememberMe" runat="server" />
                                                </div>
                                                <div  style="float:left;padding-left: 10px;">
                                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Remember me on this computer</asp:Label>
                                                </div>
                                                </div>
                                                </dd>
                                            </fieldset>
                                            <p class="submitButton">
                                                <asp:Button ID="LoginButton" CssClass="primary" runat="server" CommandName="Login" Text="Sign In" ValidationGroup="LoginUserValidationGroup" />
                                            </p>
                                        </dl>
                                    </div>
                                </LayoutTemplate>
                            </asp:Login>
                            <div id="GetAnAccount">
                                <div>
                                    <h2>
                                        Don't have a Happytrip Account?</h2>
                                    <p id="SocialConnect">
                                        <asp:HyperLink ID="RegisterHyperLink" CssClass="light" runat="server" EnableViewState="false">Sign up for one</asp:HyperLink>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="Right">
                        <div class="col clearfix">
                            <asp:Image ID="Image1" ImageUrl="~/Images/suitcase.png" Style="margin-left: 40px;"
                                runat="server" Width="500" Height="500" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
