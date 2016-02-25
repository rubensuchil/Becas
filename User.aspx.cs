using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [WebMethod]
    public static List<AutoComplete> carrera(string term)
    {
        List<AutoComplete> resultado = new List<AutoComplete>();
        List<string> obtener = new List<string>();
        AutoComplete ac;
        string query = "";
        term = term.ToLower();
        storedProcedure sp = new storedProcedure("ConnectionString");
        query = "select idCarrera, carrera from carrera where carrera like '%" + term + "%'";
        obtener = sp.recuperaRegistros(query);

        if (obtener != null && obtener.Count > 0)
        {
            for (int i = 0; i < obtener.Count; i += 6)
            {
                ac = new AutoComplete();
                ac.ID = obtener[i];
                ac.nombre = obtener[i + 1];
                resultado.Add(ac);
            }
        }
        else
        {
            resultado.Add(new AutoComplete { ID = "", nombre = "No se encontraron resultados" });
        }
        return resultado;
    }

    

         [WebMethod]
    public static List<AutoComplete> user(string term)
    {
        List<AutoComplete> resultado = new List<AutoComplete>();
        List<string> obtener = new List<string>();
        AutoComplete ac;
        string query = "";
        term = term.ToLower();
        storedProcedure sp = new storedProcedure("ConnectionString");
        query = "select idAlumno,nombreCompleto from alumno where nombreCompleto like '%" + term + "%'";
        obtener = sp.recuperaRegistros(query);

        if (obtener != null && obtener.Count > 0)
        {
            for (int i = 0; i < obtener.Count; i += 6)
            {
                ac = new AutoComplete();
                ac.ID = obtener[i];
                ac.nombre = obtener[i + 1];
                resultado.Add(ac);
            }
        }
        else
        {
            resultado.Add(new AutoComplete { ID = "", nombre = "No se encontraron resultados" });
        }
        return resultado;
    }
    [WebMethod]
    public static List<AutoComplete> grupo(string term)
    {
        List<AutoComplete> resultado = new List<AutoComplete>();
        List<string> obtener = new List<string>();
        AutoComplete ac;
        string query = "";
        term = term.ToLower();
        storedProcedure sp = new storedProcedure("ConnectionString");
        query = "select idgrupo,grupo from grupo where grupo like '%" + term + "%'";
        obtener = sp.recuperaRegistros(query);

        if (obtener != null && obtener.Count > 0)
        {
            for (int i = 0; i < obtener.Count; i += 6)
            {
                ac = new AutoComplete();
                ac.ID = obtener[i];
                ac.nombre = obtener[i + 1];
                resultado.Add(ac);
            }
        }
        else
        {
            resultado.Add(new AutoComplete { ID = "", nombre = "No se encontraron resultados" });
        }
        return resultado;
    }

    [WebMethod]
    public static string saveUser(string name, string email, string pass, int idRol, int idCarrera, int idGrupo, float prom)
    {
        string result = "";
        storedProcedure sp = new storedProcedure("ConnectionString");
        result = sp.saveUser(name, email, pass, idRol,idCarrera,idGrupo,prom);
        return result;
    }

    [WebMethod]
    public static List<string> selectUser(int idUser)
    {
        string result = "";
        storedProcedure sp = new storedProcedure("ConnectionString");
        string query = "select a.usuario,a.contrasena,r.idrol,c.idCarrera,c.carrera,g.idgrupo,g.grupo,a.promedio from alumno as a inner join " +
                        " carrera as c on c.idCarrera = a.iCarrera inner join "+
                        " grupo as g on g.idgrupo = a.idGrupo inner join usuarioRol as ur"+
                        " on ur.idUsuario = a.idAlumno inner join rol as r on r.idRol = ur.idRol"+
                        " where idAlumno = "+idUser+"";
        List<string> listaUser = sp.recuperaRegistros(query);
        return listaUser;
    }

    [WebMethod]
    public static bool deleteUser(int idUser)
    {
        bool result = true;
        storedProcedure sp = new storedProcedure("ConnectionString");
            result = sp.ejecutaSQL("delete usuarioRol where idUsuario =" + idUser + "");
            result = sp.ejecutaSQL("delete becasAlumnos where idAlumno = " + idUser + "");
            result = sp.ejecutaSQL("delete alumno where idAlumno = " + idUser + "");
        return result;
    }

}