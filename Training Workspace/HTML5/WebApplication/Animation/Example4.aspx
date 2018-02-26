﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example4.aspx.cs" Inherits="CSS3Demos.Animation.Example4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
            /** CSS3 Gallery Example by (C) Andrea Giammarchi for Ajaxian */
            html, body, ul.thumb, ul.thumb li {
                padding: 0;
                margin: 0;
            }
            html, body, ul.thumb {
                width: 100%;
                height: 100%;
                overflow: hidden;
            }
            ul.thumb {
                position: relative;
                list-style: none;
                /* a gradient background with wide diffusion is quite hard
                   to handle without Direct2D or better hardware strategies but
                   it could make the box-shadow effect more real at the same time.
                   Setting it as important we can be sure supported browser will use it
                   while other browser will use just the normal background color
                */
                background: -webkit-gradient(radial, 45 45, 50, 50 10, 640, from(#444), to(#333)) !important;
                background: #333;
            }
            ul.thumb li {
                position: absolute;
                top: 50%;
                left: 50%;
                padding: 6px 6px 24px 6px;
                background: #FFF;
                width: 150px;
                height: 130px;
                /* box shadow is heavy as well if we need
                   to rotate it during the animation or if
                   we have not a flat background behind
                   The alpha channel needs to work a lot
                   but it gives 3D feeling    
                */
                -moz-box-shadow:1px 1px 6px #222;
                -webkit-box-shadow:1px 1px 6px #222;
                box-shadow:1px 1px 6px #222;
                /* to activate transiction FXs
                   this is all we need
                   specifying "all" means that 
                   the browser will try to resolve
                   and computate everything
                   z-index included
                */
                -webkit-transition: all 3s ease-in-out;
                /* to create a better 3D feeling
                   z-index will be in a range from 0 to 10
                   this means while another pic is going
                   back to its position another rollovered one
                   will gradually reach higher z-index
                */
                z-index: 0;
            }
            ul.thumb li img {
                width: 100%;
                height: 100%;
            }
            /* each image will have a fake rotation
               to emulate a disordered desk
               It's not clear to me why we like so much
               rotated stuff ... probably because we
               like to put order without effort
               and simply with an hover, or a click?
            */
            ul.thumb li:nth-child(1) {
                margin-top: -130px;
                margin-left: -130px;
                -moz-transform: rotate(30deg);
                -webkit-transform: rotate(30deg);
                transform: rotate(30deg);
                -webkit-filter: blur(5px);
            }
            ul.thumb li:nth-child(2) {
                margin-top: -120px;
                margin-left: -10px;
                -moz-transform: rotate(19deg);
                -webkit-transform: rotate(19deg);
                transform: rotate(19deg);
                -webkit-filter: blur(4px);
            }
            ul.thumb li:nth-child(3) {
                margin-top: -10px;
                margin-left: -180px;
                -moz-transform: rotate(-10deg);
                -webkit-transform: rotate(-10deg);
                transform: rotate(-10deg);
                -webkit-filter: blur(3px);
            }
            ul.thumb li:nth-child(4) {
                margin-top: -50px;
                margin-left: -80px;
                -moz-transform: rotate(12deg);
                -webkit-transform: rotate(12deg);
                transform: rotate(12deg);
                -webkit-filter: blur(2px);
            }
            ul.thumb li:nth-child(5) {
                margin-top: 20px;
                margin-left: 30px;
                -moz-transform: rotate(-20deg);
                -webkit-transform: rotate(-20deg);
                transform: rotate(-20deg);
                -webkit-filter: blur(1px);
            }
            /* here is how the LI element should look
               at the end of the transition which
               will be activated on hover special selector
            */
            ul.thumb li:hover{
                z-index: 10;
                /* original image size */
                width: 480px;
                height: 322px;
                /* put the LI in the center (almost due to bottom padding) */
                margin-top: -151px;
                margin-left: -240px;
                /* the effect is a "zoom" one, the shadow will be bigger */
                -moz-box-shadow:8px 8px 24px #111;
                -webkit-box-shadow:8px 8px 24px #111;
                box-shadow:8px 8px 24px #111;
                /* and finally order via zero degrees rotation */
                -moz-transform: rotate(0deg);
                -webkit-transform: rotate(0deg);
                -webkit-filter: blur(0px);
                transform: rotate(0deg);
            }
            /* just some credit fixed on the bottom of the page ... */
            div.copyright {
                position: fixed;
                width: 100%;
                bottom: 20px;
                color: #666;
                text-align: center;
                font-family: sans-serif;
                font-size: 8pt;
            }
            div.copyright a {
                color: #555;
                text-decoration: none;
                border-bottom: 1px dotted #999;
            }
            div.copyright a:hover {
                color: #888;
                border-bottom: 1px dotted #555;
            }
        </style>
</head>
<body>
 <ul class="thumb">
            <li>
                <img src="images/gallery/image1.jpg" width="480" height="322" />
            </li>
            <li>
                <img src="images/gallery/image2.jpg" width="480" height="322" />
            </li>
            <li>
                <img src="images/gallery/image3.jpg" width="480" height="322" />
            </li>
            <li>
                <img src="images/gallery/image4.jpg" width="480" height="322" />
            </li>
            <li>
                <img src="images/gallery/image5.jpg" width="480" height="322" />
            </li>
        </ul>
</body>
</html>
