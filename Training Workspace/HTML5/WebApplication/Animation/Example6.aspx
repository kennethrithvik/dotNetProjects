﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example6.aspx.cs" Inherits="CSS3Demos.Animation.Example6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
            .badgestronaut
            {
                position: absolute;
                left: 10px;
                top: 10px;
                width: 225px;
                z-index: 2;
            }

            .badgestronaut p
            {
                margin: 0 0 10px 0;
                padding: 0;
                width: 225px;
                height: 50px;
            }

            .badgestronaut a
            {
                display: block;
                width: 100%;
                height: 100%;
                text-indent: -999em;
                background: url(http://www.zachstronaut.com/images/zachstronaut-badge.gif) top left no-repeat;
                opacity: 0.8;
            }

            .badgestronaut a:hover
            {
                opacity: 1.0;
                border-bottom: 2px solid #0f0;
            }
            body {
                background: #090;
                text-align: center;
                font-family: sans-serif;
            }

            a {
                color: #6f6;
            }

            a:hover {
                text-decoration: none;
            }

            #backdrop {
                width: 600px;
                color: #0f0;
                font-family: monospace;
                font-size: 24px;
                margin: 0 auto;
                -webkit-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -ms-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -moz-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -o-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
            }

            .cube {
                position: absolute;
                top: 90px;
                left: 360px;
            }

            .face {
                position: absolute;
                width: 200px;
                height: 200px;
                overflow: hidden;
                font-family: monospace;
                font-size: 24px;
            }


            .top {
                top: 0;
                left: 86px;
                background: #fff;
                color: #999;
                /*    -webkit-transform: matrix(0.8965754721680534, -0.5176380902050416, 0.8965754721680536, 0.5176380902050415, 0, 0);*/
                -webkit-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -ms-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -moz-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -o-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
            }

            .left {
                top: 165px;
                left: 0;
                background: #999;
                color: #333;
                /*    -webkit-transform: matrix(0.8965754721680536, 0.5176380902050415, 0, 1.035276180410083, 0, 0);*/
                -webkit-transform: rotate(30deg) skewX(30deg) skewY(0deg);
                -ms-transform: rotate(30deg) skewX(30deg) skewY(0deg);
                -moz-transform: rotate(30deg) skewX(30deg) skewY(0deg);
                -o-transform: rotate(30deg) skewX(30deg) skewY(0deg);
                transform: rotate(30deg) skewX(30deg) skewY(0deg);
            }

            .right {
                top: 165px;
                left: 172px;
                background: #ccc;
                color: #666;
                /*    -webkit-transform: matrix(0.8965754721680536, -0.5176380902050415, 0, 1.035276180410083, 0, 0);*/
                -webkit-transform: rotate(-30deg) skewX(-30deg) skewY(0deg);
                -ms-transform: rotate(-30deg) skewX(-30deg) skewY(0deg);
                -moz-transform: rotate(-30deg) skewX(-30deg) skewY(0deg);
                -o-transform: rotate(-30deg) skewX(-30deg) skewY(0deg);
                transform: rotate(-30deg) skewX(-30deg) skewY(0deg);
            }


            .shadow {
                top: 330px;
                left: -86px;
                background: black;
                opacity: 0.5;
                -webkit-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -ms-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -moz-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                -o-transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
                transform: rotate(-30deg) skewX(30deg) skewY(0deg) scaleY(0.87);
            }

            video {
                width: 100%;
                height: 100%;
            }

            #two {
                -webkit-transform: scale(0.5) translate(700px, 600px);
                -moz-transform: scale(0.5) translate(700px, 600px);
                -o-transform: scale(0.5) translate(700px, 600px);
                -ms-transform: scale(0.5) translate(700px, 600px);
                transform: scale(0.5) translate(700px, 600px);
            }
        </style>
</head>
<body>
<p>Discover the power of CSS5</p>

<div id="backdrop">
    
<a href="http://www.google.com/">Google</a>... Shasikanth Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi   Shashi  
</div>

<div class="cube">
    <div class="face top">
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    </div>
    <div class="face left">
    <!--
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    -->
    <video autoplay>
        <source src="D:/Tesco batch5/HTML5/WebApplication2/Animation/images/gallery/Wildlife.wmv" type="video/wmv"/>
        <source src="D:/Tesco batch5/HTML5/WebApplication2/Animation/images/gallery/Wildlife.wmv"/>
      Your browser does not support the <code>video</code> element.  
    </video>
    </div>
    <div class="face right">
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    </div>
    <div class="face shadow"></div>
</div>

<div id="two" class="cube">
    <div class="face top">
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    </div>
    <div class="face left">
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    </div>
    <div class="face right">
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    iso<input type="button" name="button" value="HTML Button" />cube
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    Shashi  Shashi  
    </div>
    <div class="face shadow"></div>
</div>
</body>
</html>
