<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="HappyTripWebApp.Account.Register" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server" ID="headContent">
    <!-- Begin : Link to css files -->
    <link rel="stylesheet" href="../Styles/main.css" />
    <link rel="stylesheet" href="../Styles/register.css" />
    <link rel="stylesheet" href="../Styles/themes/default.css" type="text/css" media="screen" />
    <!-- End : Link to css files -->
    <!-- Begin : Javascript Content -->
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_date").datepicker({
                showOn: "button",
                changeMonth: true,
                changeYear: true,
                maxDate: 0,
                yearRange: '-100:+0',
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                buttonImageOnly: true
            });

            $('#<% =bt_Submit.ClientID %>').click(function () {
                var flag = true;
                if ($('#<%=EMailId.ClientID %>').val() == '') {
                    flag = false
                    $('#MainContent_email_error').html('E-mail Id not entered')
                }
                else if (!validateEmail($('#<%=EMailId.ClientID %>').val())) {
                    flag = false
                    $('#MainContent_email_error').html('E-mail Id invailded')
                }
                else
                    $('#MainContent_email_error').html('')

                if ($('#<%=password.ClientID %>').val() == '') {
                    flag = false
                    $('#MainContent_lb_password_error').html('Password not entered')
                }
                else
                    $('#MainContent_lb_password_error').html('')

                if ($('#<%=password_confirmation.ClientID %>').val() != ($('#<%=password.ClientID %>').val())) {
                    flag = false
                    $('#MainContent_lb_error_conformpassword').html('Password mismatch')
                }
                else
                    $('#MainContent_lb_error_conformpassword').html('')

                if ($('#<%=last_name.ClientID %>').val() == '') {
                    flag = false
                    $('#MainContent_lb_error_username').html('User name not entered')
                }
                else
                    $('#MainContent_lb_error_username').html('')

                if ($('#<%=date.ClientID %>').val() == '') {
                    flag = false
                    $('#MainContent_lb_error_DOB').html('DOB not entered')
                }
                else
                    $('#MainContent_lb_error_DOB').html('')

                return flag
            })
        });


        //E mail validation
        function validateEmail($email) {
            var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
            if (!emailReg.test($email)) {
                return false;
            } else {
                return true;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body -->
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div class="Left" style="padding-left:190px">
                    <div class="col" id="stepContainer">
                        <div id="Step1" class="step" 
                            style="display: block; top: 54px; left: 0px; width: 504px; height: 527px;">
                            <!-- Begin : Registration Header Text-->
                            <div id="ProgressStatus">
                                <ul class="clearfix">
                                    <li class="step1"><span></span>Personal info</li>
                                </ul>
                            </div>
                            <h1>
                                Welcome to your Happytrip Account
                            </h1>
                            <!-- End : Registration Header Text-->
                            <!-- Begin : Area to display errors during registration -->
                            <div id="step1_errors" class="errors clearfix">
                                <span>Oops, you’ll need to fix these issues before we can confirm your account</span>
                                <asp:Label ID="gendral_error" class="required" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <!-- Begin : Form For Registration-->
                            <%--<form id="signin_details" runat="server">--%>
                            <!-- Begin : Form Fields For Registration-->
                            <fieldset class="primary">
                                <h3 class="legend">
                                    Set a password to get started</h3>
                                <dl class="vertical">
                                    <dt>
                                        <label for="username">
                                            Your email address</label></dt>
                                    <dd>
                                    <div style="display:none">
                                        <asp:ScriptManager ID="aspButtonLink" runat="server">
                                        </asp:ScriptManager></div>
                                        <asp:UpdatePanel ID="emailNameCheck" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox name="email" ID="EMailId" size="32" runat="server" class="textvalidation" />
                                                &nbsp;<asp:Button ID="hlCheckAvailaibilty" runat="server" Text="Check Availaibility"
                                                    ToolTip="Click to Check User Avaibility" BorderColor="White" ClientIDMode="Static"
                                                    CssClass="bubble" Width="131px" OnClick="hlCheckAvailaibilty_Click"></asp:Button>
                                                <asp:Label ID="email_error" runat="server" ForeColor="Red" class="error_class"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </dd>
                                    <dd>
                                        <span class="hint">This will be the username for your Happytrip Account</span>
                                    </dd>
                                    <dt>
                                        <label class="required" for="password">
                                            Your password</label></dt>
                                    <dd>
                                        <asp:TextBox class="required" name="user[password]" type="password" runat="server"
                                            ID="password" size="24" title="Your account password" TextMode="Password" />
                                        <asp:Label ID="lb_password_error" runat="server" ForeColor="Red" class="error_class"></asp:Label>
                                    </dd>
                                    <dt>Re-type your password </dt>
                                    <dd>
                                        <asp:TextBox class="required" name="retype_password" type="password" ID="password_confirmation"
                                            runat="server" size="24" title="Password verification" TextMode="Password" />
                                        <asp:Label ID="lb_error_conformpassword" runat="server" ForeColor="Red" class="error_class"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label for="title">
                                            Your name</label></dt>
                                    <dd>
                                        <asp:TextBox name="personal_data[last_name]" ID="last_name" selflabel="Full name"
                                            runat="server" class="required selflabel" title="Your full name / surname" />
                                        <asp:Label ID="lb_error_username" runat="server" ForeColor="Red" class="error_class"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label class="required" for="gender">
                                            Gender</label></dt>
                                    <dd>
                                        <asp:DropDownList ID="dl_gender" runat="server">
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </dd>
                                    <dt>
                                        <label class="required" for="address1">
                                            Date Of Birth</label></dt>
                                    <dd>
                                        <input type="text" id="date" runat="server" class="datePicker required" title="Your full name / surname"
                                            readonly="readonly" />
                                        <asp:Label ID="lb_error_DOB" runat="server" ForeColor="Red" class="error_class"></asp:Label>
                            <fieldset class="stepControls">
                                <asp:Button ID="bt_Submit" runat="server" class="next blue" Text="Submit →" OnClick="bt_Submit_Click" />
                            </fieldset></dd>
                                </dl>
                            </fieldset>
                            <!-- End : Form Fields For Registration-->
                            <!-- Begin : Submit Button For Registration-->
                            &nbsp;<!-- End : Submit Button For Registration--><%--</form>--%><!-- End : Form For Registration--></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End : Main Body -->
</asp:Content>
