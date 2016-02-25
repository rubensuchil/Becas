<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Plantillas_Footer" %>

<!---- Footer ---->
<div id="footer-layer">

	<!--footer-starts-->
	<div class="footer">
		<div class="container">
			<div class="footer-main">
				<div class="col-md-3 footet-left">
					<h3>INFORMATION</h3>
					<ul>
						<li><a href="#">Home</a></li>
						<li><a href="#">User</a></li>
						<li><a href="Follow.aspx">Follow</a></li>
					</ul>
				</div>
				<div class="col-md-3 footet-left">
					<h3>CATEGORIES</h3>
					<ul>
						<li><a href="#">Pickup </a></li>
						<li><a href="#">Check In</a></li>
						<li><a href="#">On Fly</a></li>
						<li><a href="#">Custom Clearance</a></li>
						<li><a href="#">Delivered</a></li>
					</ul>
				</div>
				<div class="col-md-3 footet-left">
					<h3>MY ACCOUNT</h3>
					<ul>
						<li><a href="#">Team</a></li>
						<li><a href="#"></a></li>
					</ul>
				</div>
				<div class="col-md-3 footet-left">
					<h3>NEWSLETTER</h3>
					<div class="sub-text">
						<input type="text" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Enter Your Email';}"/>
						<input type="submit" value="" >
					</div>
				</div>
				<div class="clearfix"> </div>
			</div>
			<div class="copy-rights">
				<p>&copy; 2015. All Rights Reserved |<a href=""></a> </p>
			</div>
		</div>
    <!---->
    </div>
    <a href="#to-top" id="toTop" onclick="javascript:Mover();" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
<!----> 
</div>
