﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example5.aspx.cs" Inherits="CSS3Demos.Animation.Example5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
	body{
		font: 14px/150% "Arial", Verdana, sans-serif;
		text-align:center;
		background:#111;
		color:#fff;
	}
	h1, h2, h3{margin:20px 0;text-align:center;color:#fff;}
	a{
		text-decoration:none;
		color:#0080ea;
	}
	#container{
		margin:0 auto;
		text-align:left;
		width:760px;
	}
	h2{
		background:#aaa;
		padding:10px;
		text-shadow:1px 1px 1px #555;
		color:#fff;
	}
	p.aligncenter{text-align:center;}
	br{clear:both;height:1px;display:block;line-height:1px;}
	.demobox{
		float:left;
		margin:20px;
		width:200px;
		height:300px;
		border:2px solid #555;
		overflow:hidden;
	}
	.details{
		width:200px;
		height:300px;
		background:#000;
		color:#fff;
		text-align:center;
	}
	#demo-1 img {
		-webkit-transform: scale(1);
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms;
	}
	#demo-1 img:hover{
		-webkit-transform: scale(.5);
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms; 
	}
	
	#demo-2 img {
		opacity: 1;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms;
	}
	#demo-2 img:hover{
		opacity: .5;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms; 
	}
	
	#demo-3{position:relative;}
	#demo-3 img{
	    opacity: 1;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms;
	}
	#demo-3 .details{
		position:absolute;
		top:0;
		left:0;
		opacity: 0;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms;
	}
	
	#demo-3 .details:hover{
		opacity: .9;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 500ms;
	}
	
	#demo-4{position:relative;}
	#demo-4 img{
		position:absolute;
		top:0;
		left:0;		
		-webkit-transition: margin-left;
		-webkit-transition-timing-function: ease-in;
		-webkit-transition-duration: 250ms;
	}
	#demo-4:hover img{
		margin-left:200px;
	}
	#demo-4 .details{
		position:absolute;
		top:0;
		left:0;
		z-index:-1;
	}
	
	#demo-5{position:relative;}
	#demo-5 .details{
		opacity: .9;
		position:absolute;
		top:0;
		left:0;
		margin-left:-200px;		
		-webkit-transition: margin-left;
		-webkit-transition-timing-function: ease-in;
		-webkit-transition-duration: 250ms;
	}
	#demo-5:hover .details{
		margin-left:0;
	}
	#demo-6{
		position:relative;
	}
	#demo-6 img{
		position:absolute;
		top:0;
		left:0;
		z-index:0;
	}
	#demo-6 .details{
		opacity: .9;
		position:absolute;
		top:100px;
		left:150px;
		z-index:999;
		-webkit-transform: scale(0);
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 250ms;
	}
	#demo-6:hover .details{
		-webkit-transform: scale(1);
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 250ms; 
	}
	</style>
</head>
<body>
<div id="container">
  	<!-- Demo 1 -->
	<div id="demo-1" class="demobox">
		<img src="images/gallery/image1.jpg"/>
	</div>
	<!-- Demo 2 -->
	    <div id="demo-2" class="demobox">
		    <img src="images/gallery/image2.jpg"/>
	    </div>
	<!-- Demo 3 -->
	<div id="demo-3" class="demobox">
		<img src="images/gallery/image3.jpg"/>
		<div class="details">
			<h3>Nature</h3>
			<p>More than meets the eye</p>			
		</div>
	</div>
	<!-- Demo 4 -->
	<div id="demo-4" class="demobox">
		<img src="images/gallery/image4.jpg"/>
		<div class="details">
			<h3>Nature</h3>
			<p>More than meets the eye</p>			
		</div>
	</div>
	<!-- Demo 5 -->
	<div id="demo-5" class="demobox">
		<img src="images/gallery/image5.jpg"/>
		<div class="details">
			<h3>Nature</h3>
			<p>More than meets the eye</p>			
		</div>
	</div>
	<!-- Demo 6 -->
	<div id="demo-6" class="demobox">
		<img src="images/gallery/image1.jpg"/>
		<div class="details">
			<h3>Nature</h3>
			<p>More than meets the eye</p>			
		</div>
	</div>
</div>
</body>
</html>
