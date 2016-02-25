<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Plantillas_WebUserControl" %>
<!--header-->
<!---- Inicio Header ---->
 <script type="text/javascript">
     $(document).ready(function () {
         $("div.nav-container > ul#nav > li:first").addClass("first");
         $("div.nav-container > ul#nav > li:last").addClass("last");
     });
    </script>
<div id="header-layer">
<asp:TextBox ID="txtIdUsuario"  runat="server" CssClass="hide"></asp:TextBox>
	<div class="head">
        <div class="header" id="home">
			<nav class="navbar navbar-default">
				<div class="container">
					<!-- Brand and toggle get grouped for better mobile display -->
					<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="#"><h1>Becas UTNG</h1><br /><span>B - B</span></a>
					</div>
					<!-- Collect the nav links, forms, and other content for toggling -->
						<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
							<ul class="nav navbar-nav navbar-right margin-top cl-effect-2">
                                <li><a href="Home.aspx"><span data-hover="Home">Home</span></a></li>
								<li><a href="User.aspx"><span data-hover="Users">Users</span></a></li>
								<li><a href="Configuracion.aspx"><span data-hover="Configuracion">Configuracion</span></a></li>
								<li><a href="SingOut.aspx"><span data-hover="Sing Out">Sing Out</span></a></li>
							</ul>
							<div class="clearfix"></div>
						</div><!-- /.navbar-collapse -->
						<div class="clearfix"></div>
				</div><!-- /.container-fluid -->
			</nav>
       </div>
	</div>
</div>
<!---- Termina Header ---->
