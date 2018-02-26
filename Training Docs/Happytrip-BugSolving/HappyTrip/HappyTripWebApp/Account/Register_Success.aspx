<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register_Success.aspx.cs" Inherits="HappyTripWebApp.Account.Register_Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Begin : Link to css files -->
    <link rel="stylesheet" href="../Styles/main.css" />
    <link rel="stylesheet" href="../Styles/register.css" />
    <link rel="stylesheet" href="../Styles/themes/default.css" type="text/css" media="screen" />
    <!-- End : Link to css files -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Begin : Main Body -->
    <div id="Wrapper">
        <div class="Container" style="height: 40px;">
            <div id="ContentFrame" class="clearfix">
                <div class="Left">
                    <div class="col" id="stepContainer">
                        <div id="Step1" class="step" 
                            style="display: block; height: 196px; width: 469px; top: 0px; left: 0px;">

                            <!-- Begin : Registration Header Text-->
                            <div id="ProgressStatus">
                                <ul class="clearfix">
                                    <li class="step1"><span></span>Personal info</li>
                                </ul>
                            </div>
                            <h1>
                                &nbsp;&nbsp;&nbsp;
                                Thank You for creating an account with Happy Trip
                            </h1>
                            <h5 style="height: 35px; width: 467px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Please <a href="Login.aspx">click here</a> to log in </h5>
                            <!-- End : Registration Header Text-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End : Main Body -->
</asp:Content>
