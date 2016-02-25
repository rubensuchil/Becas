<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Configuracion.aspx.cs" Inherits="Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="js/Sistema/jquery-1.11.1.min.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery-ui.js" type="text/javascript"></script> 
    <script src="js/Sistema/jquery.dataTables.min.js" type="text/javascript"></script> 
    <script src="js/Configuracion/Configuracion.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" Runat="Server">
  <div class="header-banner">
  <!-- Top Navigation -->
 <section class="bgi banner5"><h2>Configracion</h2> </section>
					
	<!-- contact -->
	<div class="contact-top">
		<!-- container -->
		<div class="container">
          <div class="left" style="border: solid;border-color: black;height:auto;overflow:auto;">
            <center><h2>Configuracion:</h2></center>

            <div style="float: left;">
                <img src="img/beca.jpg" alt="" width="150px"  height="100" id="imgB"/>
                <br /><br />
                <img src="img/grupo.jpg"   alt="" width="150px"  height="100" id="imgG"/>
                <br /><br />
                <img src="img/carrera.jpg"  alt=""  width="150px"  height="100" id="imgC"/>
                <br /><br />
                <img src="img/icoSet1/tools.png"  alt=""  width="150px"  height="100" id="imtipob"/>
            </div>
            <div style="float: left;margin-left: 29%;margin-top: 7%;">
                <div id="divBeca" class="">
                    <label>Beca</label>
                    <input type="text" id="TxtBeca"/>
                    <input type="text" id="txtIdBeca" class="hidden"/>
                    <br />
                    <label>promedio</label>
                    <input type="text" id="txtprom"/>
                    <br />
                    <label>Tipo Beca</label>
                    <div id="divcombo">
                    
                    </div>
                   <!-- <select id="ss">
                        <option value="1">Academica</option>
                        <option  value="2">Deportiva</option>
                        <option  value="3">Aprovechamiento</option>
                    </select>-->
                    <br />
                    <input type="button" onclick="JavaScript:guardar(1);" value="Guardar" class="g"/>
                    <input type="button" onclick="JavaScript:modificarbase(1);" value="modificar" class=" m"/>
                    <input type="button" onclick="JavaScript:reset(1);" value="reset" class="r"/>
                </div>
                <div id="divGrupo" class="">
                    <label>Grupo</label>
                    <input type="text" id="txtGrupo"/>
                    <input type="text" id="txtIdGrupo" class="hidden"/>
                    <br />
                    <label>Descripcion</label>
                    <input type="text" id="txtDescripciong" />

                    <br />
                    <input type="button" onclick="JavaScript:guardar(2); " value="Guardar" class="g"/>
                    <input type="button" onclick="JavaScript:modificarbase(2);" value="modificar" class=" m"/>
                    <input type="button" onclick="JavaScript:reset(1);" value="reset" class="r"/>
                </div>
                <div id="divCarrera" class="">
                    <label>Carrera</label>                    
                    <input type="text" id="txtCarrera"/>
                    <input type="text" id="txtIdCarrera" class="hidden"/>
                    <br />
                    <label>Descripcion</label>
                    <input type="text" id="txtDescripcionc"/>
                    <br />
                    <input type="button" onclick="JavaScript:guardar(3);" value="Guardar" class="g"/>
                    <input type="button" onclick="JavaScript:modificarbase(3);" value="modificar" class=" m" />
                    <input type="button" onclick="JavaScript:reset(1);" value="reset" class="r"/>
                </div>
                <div id="divtioBeca" class="">
                    <label>tipo beca</label>                    
                    <input type="text" id="txttBeca"/>
                    <input type="text" id="txtidtBeca" class="hidden"/>
                    <br />
                    <label>Descripcion</label>
                    <input type="text" id="txtdesctb"/>
                    <br />
                    <input type="button" onclick="JavaScript:guardar(4);" value="Guardar" class="g"/>
                    <input type="button" onclick="JavaScript:modificarbase(4);" value="modificar" class=" m" />
                    <input type="button" onclick="JavaScript:reset(1);" value="reset" class="r"/>
                </div>
                
                <div id="tabla" style="margin-top:20px">
            
                </div>
            </div>

            </div>
        </div>
		<!-- //container -->
	</div>
	<!-- //contact -->
</div>
    
</asp:Content>

