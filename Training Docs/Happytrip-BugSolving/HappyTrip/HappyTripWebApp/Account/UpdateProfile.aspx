<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="HappyTripWebApp.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../Styles/main.css" />
    <link rel="stylesheet" href="../Styles/register.css" />
    <link type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <link type="text/css" href="../Styles/nivo-slider.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Styles/themes/default.css" type="text/css" media="screen" />
    
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.nivo.slider.js"></script>
    
    <script type="text/javascript">
        $(function () {
            $("#MainContent_date").datepicker({
                showOn: "button",
                buttonImage: "../Styles/ui-lightness/images/calendar.gif",
                changeMonth: true,
                changeYear: true,
                maxDate: 0,
                yearRange: '-100:+0',
                buttonImageOnly: true
            });

                        $('#MainContent_LinkButton1').click(function () {
                            $('#Edit_Div').show()
                            $('#Display_Div').hide()
                            return false
                        })

        });

//        function display() {
//            document.getElementById('Edit_Div').style.display = 'block'
//            document.getElementById('Display_Div').style.display = 'none'
//            return false;
//        }
        

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body Content -->
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <!-- Begin : Update Profile Section-->
                <div class="Left">
                    <div class="col">
                        <div id="Step1" class="step" 
                            style="display: block; height: 566px; width: 435px; top: 0px; left: 0px;">
                            <h1>
                                Welcome to your Happytrip Account
                            </h1>
                            <!-- Begin : Area to display errors during profile update -->
                            <div id="step1_errors" class="errors clearfix">
                                <span>Oops, you’ll need to fix these issues before we can confirm your account</span>
                            </div>
                            <!-- End : Area to display errors during profile update -->
                            
                            <!-- Begin : Form to display and update profile information-->
     
                            <fieldset class="primary">
                                <h3 class="legend">
                                    <asp:LinkButton ID="LinkButton1" runat="server"  >Update</asp:LinkButton>
                                    &nbsp;| 
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        NavigateUrl="~/Account/ChangePass.aspx">Change Password</asp:HyperLink>
                                        <%if (Roles.IsUserInRole("Administrator"))
                                          { %>
&nbsp;&nbsp;| 
                                    <asp:HyperLink ID="HyperLink2" runat="server" 
                                        NavigateUrl="~/Admin/Home.aspx">Admin Home</asp:HyperLink></h3>
                                        <%} %>
                <div id="Display_Div">
                                <dl class="vertical">
                                    <dt>
                                        <asp:Label ID="lbl_error" runat="server" CssClass="Error" ForeColor="Red"></asp:Label>
                                    </dt>
                                    <dt>
                                        <label for="title">
                                            <strong>Your name</strong></label></dt>
                                    <dd>
                                        <asp:Label ID="lbname" runat="server"></asp:Label>
&nbsp;</dd>
                                    <dt>
                                        <label class="required" for="gender">
                                            Gender</label></dt>
                                    <dd>
                                        <asp:Label ID="lbgender" runat="server"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label class="required" for="address1">

                                            Date Of Birth</label></dt>
                                    <dd>
                                        <asp:Label ID="lbDOB" runat="server"></asp:Label>

                                        </dd>
                                    <dt>
                                        <label class="required" for="address1">
                                            Address line </label>
                                    </dt>
                                    <dd>
                                        <asp:Label ID="lbAddress" runat="server"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label class="required" for="city">
                                            City</label></dt>
                                    <dd>
                                        <asp:Label ID="lbCity" runat="server"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label class="required" for="state">
                                            State</label></dt>
                                    <dd>
                                        <asp:Label ID="lbState" runat="server"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label class="required" for="pin">
                                            Pin Code</label></dt>
                                    <dd>
                                        <asp:Label ID="lbPib" runat="server"></asp:Label>
                                    </dd>
                                    <dt>
                                        <label for="mobile_number">
                                            <strong>Mobile number</strong></label></dt>
                                    <dd>
                                        <asp:Label ID="lbMobile" runat="server"></asp:Label>
&nbsp;</dd>
                                </dl>
            </div>

                            <div id="Edit_Div" style="display:none">
                                <dl class="vertical">
                                <dt>
                                        <label for="title" id="update">
                                            <asp:Label ID="UpdateLabel" runat="server"></asp:Label>
                                            </label></dt>
                                    <dt>
                                        <label for="title">
                                            Your name</label></dt>
                                    <dd>
                                        <asp:TextBox ID="Name" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valNameRequired" runat="server" ControlToValidate="Name" ErrorMessage="Name is required" CssClass="errorLabel"></asp:RequiredFieldValidator>
                                    </dd>
                                    <dt>
                                        <label class="required" for="gender">
                                            Gender</label></dt>
                                    <dd>
                                        <asp:DropDownList ID="Gender" runat="server">
                                            <asp:ListItem Selected="True">None</asp:ListItem>
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </dd>
                                    <dt>
                                        <label class="required" for="address1">

                                            Date Of Birth</label></dt>
                                    <dd>
                                        <asp:TextBox class="datePicker required" type="text" name="dateOfBirth" title="Date Of Birth"
                                            runat="server" ID="date" size="10" />
                                        <asp:RequiredFieldValidator ID="valDateRequired" runat="server" ControlToValidate="date" ErrorMessage="Date of Birth is required" CssClass="errorLabel"></asp:RequiredFieldValidator>
                                    </dd>
                                    <dt>
                                        <label class="required" for="address1">
                                            Address line </label>
                                    </dt>
                                    <dd>
                                        <asp:TextBox ID="Address1" runat="server" Width="334px"></asp:TextBox>
                                    </dd>
                                    <dt>
                                        <label class="required" for="city">
                                            City</label></dt>
                                    <dd>
                                        <asp:TextBox ID="City" runat="server" Width="154px"></asp:TextBox>
                                    </dd>
                                    <dt>
                                        <label class="required" for="state">
                                            State</label></dt>
                                    <dd>
                                        <asp:TextBox ID="State" runat="server"></asp:TextBox>
                                    </dd>
                                    <dt>
                                        <label class="required" for="pin">
                                            Pin Code</label></dt>
                                    <dd>
                                        <asp:TextBox ID="Pincode" runat="server"></asp:TextBox>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                            runat="server" ControlToValidate="Pincode" 
                                            ErrorMessage="Pincode Should be 6 Digits" CssClass="errorLabel" 
                                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                    </dd>
                                    <dt>
                                        <label for="mobile_number">
                                            Mobile number</label></dt>
                                    <dd>
                                        <asp:TextBox ID="MobileNo" runat="server"></asp:TextBox>
&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="MobileNo" 
                                            ErrorMessage="Mobile Number should be 10 digits only" CssClass="errorLabel" 
                                            ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                    </dd>
                                </dl>

                                <fieldset class="stepControls">
                                    <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="Submit" />
                                </fieldset>
                        </div>
                            </fieldset>
                            
                            
     
                            <!-- End : Form to display and update profile information -->
                            <br />
                        </div>
                    </div>
                </div>
                <!-- End : Update Profile Section-->

                      <!-- Begin : Right side slider with images-->
                <div class="Right">
                    <div class="col">
                        <div id="aside">
                            <div class="slider-wrapper theme-default">
                                <%--<div id="slider" class="nivoSlider">
                                    <img src="../images/pic1.jpg" data-thumb="images/pic1.jpg" alt="" />
                                    <a href="#">
                                        <img src="../images/pic2.jpg" data-thumb="images/pic2.jpg" alt="" 
                                        title="Welcome to happy trip" /></a>
                                    <img src="../images/pic3.jpg" data-thumb="images/pic3.jpg" alt="" 
                                        data-transition="slideInLeft" />
                                    <img src="../images/pic4.jpg" data-thumb="images/pic4.jpg" alt="" 
                                        title="#htmlcaption" />
                                </div>
                                <div id="htmlcaption" class="nivo-html-caption">
                                    <strong>Fly</strong> to <em>Paris with</em><a href="#">Happy Trip</a>.
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End : Right side slider with images -->

            </div>
        </div>
    </div>
    <!-- End : Main Body Content -->

</asp:Content>
