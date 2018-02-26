<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobstore.aspx.cs" Inherits="WebApplication2.MobileStore.mobstore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile store</title>
    <style type="text/css">
	body{
		font: 14px/150% "Arial", Verdana, sans-serif;
		text-align:center;
		background:aquamarine;
		color:black;
	}
	h1{margin:20px 0;text-align:center;color:black;}
     
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
		background:#fff;
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
		border:2px aquamarine;
	    background-color:chartreuse;
		/*overflow:hidden;*/
	}
	.details{
		width:200px;
		height:300px;
		background:chartreuse;
		color:black;
		text-align:center;
	}

	
	.mob {
	    position:relative;
        float:left;
		margin:20px;
		width:200px;
		height:300px;
		border:2px solid aquamarine;
	}
	.mob img{
		position:absolute;
		top:0;
		left:0;
	    width: 100%;
	    height: 100%;
	    z-index: 6;	
		-webkit-transition: scale(1.5);
		-webkit-transition-timing-function: ease-in;
		-webkit-transition-duration: 250ms;
	}
	.mob:hover img{
		/*margin-left:200px;*/
	    transform: scale(1.3);
        
        opacity: .3;
		-webkit-transition: opacity;
		-webkit-transition-timing-function: ease-out;
		-webkit-transition-duration: 1000ms;
	}
	.mob .details{
		position:absolute;
		top:0;
		left:0;
		z-index:3;
	}
    h2, h3{margin:20px 0;text-align:center;color:blue;background-color: #ffffff;z-index: 20;}
	
	
	</style>
</head>
<body>
<div id="container">
    <h1>Online Web Store</h1>
  	
	<!-- Demo 4 -->
	<div class="mob" >
		<img src="images/Nokia/nokia-lumia-735.jpg"/>
		<div class="details">
			<h3>Nokia Lumia 735</h3>
			<p>Touchscreen phone from nokia with windows operating system</p>			
		</div>
	</div>

    <div class="mob" >
		<img src="images/Nokia/nokia-lumia-930-new.jpg"/>
		<div class="details">
			<h3>Nokia Lumia 930 </h3>
			<p>Touchscreen phone from nokia with windows operating system</p>			
		</div>
	</div>

    <div class="mob" >
		<img src="images/Nokia/nokia-xl.jpg"/>
		<div class="details">
			<h3>Nokia Xl</h3>
			<p>Touchscreen phone from nokia with windows operating system</p>			
		</div>
	</div>

    <div class="mob" >
		<img src="images/Nokia/nokia-x-plus.jpg"/>
		<div class="details">
			<h3>Nokia X Plus</h3>
			<p>Touchscreen phone from nokia with windows operating system</p>			
		</div>
	</div>
    
    
    <div class="mob" >
		<img src="images/Apple/apple-ipad-mini-3-new.jpg"/>
		<div class="details">
			<h3>Apple Ipad Mini 3</h3>
			<p>Touchscreen Tablet from Apple</p>			
		</div>
	</div>
    
    <div class="mob" >
		<img src="images/Apple/apple-iphone-4s-new.jpg"/>
		<div class="details">
			<h3>Apple Iphone 4S</h3>
			<p>Touchscreen phone from apple with IOS</p>			
		</div>
	</div>
    
    <div class="mob" >
		<img src="images/Apple/apple-iphone-5s-ofic.jpg"/>
		<div class="details">
			<h3>Apple Iphone 5S</h3>
			<p>Touchscreen phone from apple with IOS</p>			
		</div>
	</div>
    
    <div class="mob" >
		<img src="images/Apple/apple-iphone-6s1.jpg"/>
		<div class="details">
			<h3>Apple Iphone 6S</h3>
			<p>Touchscreen phone from apple with IOS</p>			
		</div>
	</div>
    
    <div class="mob" >
		<img src="images/Apple/apple-iphone-6s-plus.jpg"/>
		<div class="details">
			<h3>Apple Iphone 6S Plus</h3>
			<p>Touchscreen phone from apple with IOS</p>			
		</div>
	</div>



</div>
</body>
</html>
