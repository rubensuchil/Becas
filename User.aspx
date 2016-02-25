<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="css/Sistema/fcbkcomplete.css" rel="stylesheet" type="text/css" />
    <script src="js/Sistema/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="js/Sistema/jquery-ui.js" type="text/javascript"></script>
    <script src="js/Sistema/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="js/Sistema/jquery.fcbkcomplete.min.js" type="text/javascript"></script>
    <script src="js/Sistema/jquery.blockUI.js" type="text/javascript"></script>
    <script src="js/Sistema/screenBlock.js" type="text/javascript"></script>
    <script src="js/Sistema/uploadify/jquery.uploadify.js" type="text/javascript"></script>
    <script src="js/user/User.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" Runat="Server">
   
  <div class="header-banner">
  <!-- Top Navigation -->
 <section class="bgi banner5"><h2>User</h2> </section>
					
	<!-- contact -->
	<div class="contact-top">
		<!-- container -->
		<div class="container">
			<div class="mail-grids">
				<div class="col-md-6 mail-grid-left">
                    <img src="img/descarga.jpg" />

                    <h4>Get In Touch</h4>
					<p>Telephone: +1 234 567 9871
						<span>FAX: +1 234 567 9871</span>
						E-mail: <a href="mailto:info@example.com">mail@example.com</a>
					</p>
                </div>

            <div class="col-md-6 contact-form">
					
                          <center><h2><label>Informción de usuario</label></h2></center>
                          
                          <br />
						<input type="text"  id="txtName" placeholder="Nombre" class="holder" title="Text required!">
                        <input type="text"  id="txtIdUser" class="hidden">
						<input type="text" id="txtEmail" placeholder="Usuario"  class="holder" title="Text required!" >
						<input type="password" id="txtPassword" placeholder="Contraseña"  class="holder" title="Campo Obligatorio">
						<input type="text" id="txtCarrera" placeholder="Carrera"  class="holder" title="Campo Obligatorio">
						<input type="text" id="txtIdCarrera" placeholder="Carrera"  class="holder hidden" title="Campo Obligatorio">
						<input type="text" id="txtGrupo" placeholder="Grupo"  class="holder" title="Campo Obligatorio">
						<input type="text" id="txtIdGrupo" placeholder="Grupo"  class="holder hidden" title="Campo Obligatorio">
						<input type="text" id="txtProm" placeholder="promedio"  class="holder" title="Campo Obligatorio">
                        <br />
                        <h4><label>User Role:</label></h4>
                            <div style="width:100%;overflow: hidden;" id="divRol" class="holder" title="Text required!">
                                 <h4 >
                                     <div style="width:30%;float: left;"class="hidden"><input type="radio" id="rdbM" name="rol" class="rdb" ="">ADMINISTRADOR</div>
                                     <div style="width:30%;float: left;"><input type="radio" id="rdbC" name="rol" class="rdb">ALUMNO</div>
                                 </h4>
                            </div>
                           
                        <input type="button" id="btnDelete" value="Delete" class="hide save" style="background-color: red;">
                         <input type="button" id="btnReset" value="Reset"  class="save" style="background-color: gray;">
						<input type="button" id="btnSave" value="Save" style="float: right;" class="save">
					
				</div>

                	<div class="clearfix"> </div>
			</div>
			
            <div id="dialogError" title="Error!!" style="background-color: red;">
              <h4><center><label style="margin-top: 15px;color: aliceblue;" id="lblError"></center></label></h4>
            </div>

            <div id="dialogSucces" title="Succes!!" style="background-color: green;">
              <h4><center><label style="margin-top: 15px;color: aliceblue;" id="lblSucces"></label></center></h4>
            </div>

             <div id="dialogAlet" title="Alert!!" style="background-color: khaki;" >
                <h4><center><label style="margin-top: 15px;color: coral;" id="lblAlert">The user is permanently deleted!</label></center></h4>
                  <div style="margin-left:20%"><a style="margin-right: 5px;" id="hrefCancelar">Cancelar</a><input type="button" id="btnAcept" value="Delete"  class="save" style="background-color: gray;"></div>
            </div>
		</div>
		<!-- //container -->
	</div>
	<!-- //contact -->
</div>
    
</asp:Content>

