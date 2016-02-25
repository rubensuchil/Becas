<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" MasterPageFile="~/MasterPage.master"
 Inherits="Plantillas_Home1" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <link href="css/Sistema/fcbkcomplete.css" rel="stylesheet" type="text/css" />
    <script src="js/Sistema/jquery-1.11.1.min.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery-ui.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery.dataTables.min.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery.fcbkcomplete.min.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery.blockUI.js" type="text/javascript"></script> 
    <script src="js/Sistema/screenBlock.js" type="text/javascript"></script>  
    <script src="js/Sistema/uploadify/jquery.uploadify.js" type="text/javascript"></script> 
    <script src="js/home/home.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina"   runat="Server">
    
  <div class="header-banner">
  <!-- Top Navigation -->
 <section class="bgi banner5"><h2>Home</h2> </section>
					
	<!-- contact -->
	<div class="contact-top">
		<!-- container -->
		<div class="container">
			
            <input type="button" id="btnBuscarB" value="Buscar Becas" class="save" style="background-color: green;">

            <div class="left" style="border: solid;border-color: black;height:auto">
            <center><h2>Becas a Solicitar:</h2></center>
                <br />
                nombre:<label id="txtNombre" style="padding: 10px;"></label> promedio:<label id="txtPromedio" style="padding: 10px;"></label>Carrera:<label id="txtCarrera" style="padding: 10px;"></label>Grupo:<label id="txtGrupo" style="padding: 10px;"></label>
               <div id="divBecasS" style="padding: 75px;">
                
                </div>
                <div id="divBecas" style="padding: 75px;">
                
                </div>
            
            </div>
			
		</div>
		<!-- //container -->
	</div>
	<!-- //contact -->
</div>
    
    
</asp:Content>
