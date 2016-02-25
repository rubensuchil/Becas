using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Plantillas_Home1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Boolean)Session["logged"])
        {
            //Response.Redirect("Login.aspx");
        }
        else { 
        
        }
    }

    [WebMethod]
    public static string selectBecaUser(int idUser)
    {
        string result = "";
        storedProcedure sp = new storedProcedure("ConnectionString");
        string queryprom = "select promedio from alumno where idAlumno = "+idUser+"";
        
       List<string> lsp = sp.recuperaRegistros(queryprom);
        
       float prom = float.Parse(lsp[0]);
       string querybeca = "select b.idBeca,b.nombreBeca from beca as b where b.promedio <= " + prom + " and b.idBeca not in (select distinct ba.idBeca from becasAlumnos as ba where ba.idAlumno = " + idUser + " and ba.idBeca = b.idBeca )";

       List<string> lsb = sp.recuperaRegistros(querybeca);
        if(lsb.Count> 0){
         for(int i =0;i<lsb.Count;i = i + 2){
             result += "<h3><label>Beca:" + lsb[i + 1] + " </label><img src='images/images.jpg' heit='40px' width='40px'  style='margin-left: 90px;' onclick='JavaScript:solicitar(" + lsb[i + 0] + ");'/>Solicitar</h3>"; 
        }
        }
        else{
        
            result ="<h2>No hay becas disponibles en este momento</h2>";
        }

        return result;
    }


    [WebMethod]
    public static List<string> obtenerDatosUser(int iduser) { 

         storedProcedure sp = new storedProcedure("ConnectionString");
         string query = "select nombreCompleto,promedio,carrera,grupo from alumno as a inner join carrera as c" +
                        " on c.idCarrera = a.iCarrera inner join grupo as g on g.idgrupo = a.idGrupo" +
                        " where a.idAlumno = " + iduser + "";

         List<string> lsalumno = sp.recuperaRegistros(query);
         return lsalumno;
    }


    [WebMethod]
    public static string solicitarB(int iduser, int idBeca)
    {
        storedProcedure sp = new storedProcedure("ConnectionString");
        sp.ejecutaSQL("insert into becasAlumnos values("+iduser+","+idBeca+")");
    
        return "0";
    }

    [WebMethod]
    public static string consulBeca(int iduser) { 
          storedProcedure sp = new storedProcedure("ConnectionString");
          string tabla = "<table id='tablam'><thead><tr><th style='padding: 10px;'>Beca Solicitada</th><th style='padding: 10px;'>Eliminar</th></tr></thead><tbod>";


          string querybe = "select ba.idBecasAlumnos,b.idBeca,b.nombreBeca from beca as b" +
                           " inner join becasAlumnos as ba " +
                           " on ba.idBeca = b.idBeca and ba.idAlumno = " + iduser + "";
          List<string> lsbe = sp.recuperaRegistros(querybe);

          for (int i = 0; i < lsbe.Count; i = i + 3)
          {
              tabla += "<tr><td style='padding: 10px;'>" + lsbe[i + 2] + "</td><td style='padding: 10px;'><label onclick='JavaScript:eliminarS(" + lsbe[i + 0] + ")'>X</label></td></tr>";
          }
          tabla += "</tbody></table>";

          return tabla;
    }

    [WebMethod]
    public static string eliminarS(int idB)
    {
        storedProcedure sp = new storedProcedure("ConnectionString");
        sp.ejecutaSQL("delete becasAlumnos where  idBecasAlumnos = "+idB+" ");

        return "0";
    }

}