<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicDefault.aspx.cs" Inherits="CarWalla.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carwalla - Pre owned car</title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="../script/jquery-1.7.2.js"></script>
    <script src="script/Model.js"></script>
    <script src="script/View.js"></script>
    <script src="script/Controller.js"></script>
</head>
<body>
<div id="main">
		<header>
		<div id="logo"></div>
		<div id="navigation">
			<nav>
			<ul>
				<li>About Us</li>
				<li>Sale Report</li>
			</ul>
			</nav>
		</div>
		</header>
		
		<section>
			<div id="leftpan">
				<fieldset>
					<legend>Features</legend>									
					<div id="lftcont">
						<div class="filtersection">
							<div align="center" class="filter">Brand</div>
							<div id="brands">                                
							</div>
						</div>
						<br>
						<div class="filtersection">
							<div align="center" class="filter">Price</div>
							<div align="center">
								<input type="text" id="amount" 
									style="border: 0; color: #f6931f; font-weight: bold;"></div><br/><br/>
								<input type="range" name="points" min="1" max="10">
						</div>
						<br>
						<div class="filtersection">
							<div align="center" class="filter">Fuel Type</div>
							<div id="fuels">
                                <%--Petrol<input type="radio" checked="checked" /><br />
                                Diesel<input type="radio" />--%>
							</div>
						</div>
						<br>
						<!-- <div class="filtersection">
							<div align="center" class="filter">Vehicle Type</div>
							<div id="vehicles"></div>
						</div> -->
					</div>
				</fieldset>
			</div>
		</section>
		
		<section>
			<div id="content">
				<fieldset>
					<legend>Cars</legend>
					<div id="cars">
						 <%--<div id="car">
							<div>
								<div id="carimg">
									<img src="images/small/1.jpg">
								</div>
								<div id="cardetails">
									<div class="carname">Mazda - Rx 8</div>
									<div class="carinfo">Model : 2003</div>
									<div class="price">12,24,500 /-</div><br>
									<div class="owner">Have used for 3 years</div>
								</div>
							</div>
							<div class="clear"></div>
						</div> 	--%>										
					</div>
				</fieldset>
			</div>
		</section>

		<aside>
			<div id="ads">
				<fieldset>
					<legend>Ads</legend>
				</fieldset>
			</div>
		</aside>

		<div class="clear"></div>
		
		<footer> 
			All rights reserved to carwalla.com
		</footer>
	</div>
</body>
</html>
