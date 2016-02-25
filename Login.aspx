<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,800italic,800,700italic,700,600,600italic' rel='stylesheet' type='text/css'>

 
    <script src="js/jquery.min.js"> </script>
    <script src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript" src="js/sistema.js"></script>
    <script src="js/Sistema/jquery-1.11.1.min.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery-ui.js" type="text/javascript"></script> 
    <script src="js/Sistema/screenBlock.js" type="text/javascript"></script>
    <script src="js/Sistema/jquery.blockUI.js" type="text/javascript"></script>  
    <script src="js/login/Login.js" type="text/javascript"></script>
    <title>Login Becas</title>
</head>
<body>
  <div class="header" id="home">
			
			<div class="header-banner">
					<!-- Top Navigation -->
					<div class="container page-seperator">
					<section class="color bgi">
						<div class="container"> 
						<div class="banneer-text">
						<h3><img src="img\icoSet1\apple.png" width"140px" height="40px" /></h3>
						<h4>Becas!</h4>
						</div>
						<div class="banner-forms">
							<form>
								<input class="mail2 holder" id="txtEmail" type="text" placeholder="User" title="Campo Obligatorio"/>
								<input class="nuber holder" id="txtPassword" type="password" placeholder="Password" title="Campo Obligatorio"/ >
								<button type="button" id="btnLogin" class="btn btn-info mrgn-can" >Login</button>
							</form>
						</div>
						<div class="clearfix"> </div>
					</section>

                    <div id="dialogError" title="Error!!" style="background-color: red;">
                         <h4><center><label style="margin-top: 15px;color: aliceblue;" id="lblError"></center></label></h4>
                     </div>
					<section class="col-3 ss-style-doublediagonal our-features">
							<div class="container"> 
							<h2>Our Company</h2>
							<p>© 2015. All Rights Reserved |</p>
							<div class="col-md-4 column our-feat">
									
								</div>
										<div class="col-md-4 column our-feat">
									
								</div>
										<div class="col-md-4 column our-feat">
									
								</div>
							</div>
							<div class="clearfix"> </div>
					</section>


                    
					</div>
					</div>
				</div>
</body>
</html>
