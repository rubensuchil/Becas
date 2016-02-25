using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["cve"] = "";
        Session["nombre"] = "";
        Session["logged"] = false;
    }


    [WebMethod]
    public static bool validarUsuario(string email, string password){

        storedProcedure sp = new storedProcedure("ConnectionString");
        bool resultado = true;
        string query = "select idAlumno,nombreCompleto from alumno as al inner join"+
                       " usuarioRol as ur on ur.idUsuario = al.idAlumno"+
                       " where al.usuario = '"+email+"'and contrasena = '"+password+"'";

        List<string> listaUser = sp.recuperaRegistros(query);

        if (listaUser.Count > 0)
        {
            int idUser = int.Parse(listaUser[0]);
            string emailq = listaUser[1];

            HttpContext.Current.Session["cve"] = idUser;
            HttpContext.Current.Session["nombre"] = emailq;
            HttpContext.Current.Session["logged"] = true;

            resultado = true;
        }
        else {
            resultado = false;
        }

        return resultado;
    }

    
}