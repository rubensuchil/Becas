using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Configuracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string obtenerTabla(int origen)
    {
        string tabla = "<table id='tablam'><thead><tr><th style='padding: 10px;'>Descripcion</th><th style='padding: 10px;'>Editar</th><th style='padding: 10px;'>Eliminar</th></tr></thead><tbod>";
        string query = "";
        storedProcedure sp = new storedProcedure("ConnectionString");

        if(origen == 1){
            query = "select nombreBeca,modificar,eliminar from view_beca";
        }else  if(origen == 2){
            query = "select * from view_grupo";
        }
        else if (origen == 3)
        {
            query = "select * from view_carrera";            
        }else if(origen ==4){
            query = "select * from view_tiposb";
        }

        List<string> ls = sp.recuperaRegistros(query);

        for (int i = 0; i < ls.Count;i = i +3 )
        {
            tabla += "<tr><td>" + ls[i + 0] + "</td><td>" + ls[i + 1] + "</td><td>" + ls[i + 2] + "</td></tr>";
        }
        tabla += "</tbody></table>";

        return tabla;
    }

    [WebMethod]
    public static string eliminar(int origen,int id) {
        storedProcedure sp = new storedProcedure("ConnectionString");
        try {

            if (origen == 1)
            {

                sp.ejecutaSQL("delete alumno where idbeca = " + id + "");
                sp.ejecutaSQL("delete beca where idbeca = " + id + "");
            }
            else if (origen == 2)
            {
                var re = "delete alumno where idgrupo = " + id + "";
                var ri = "delete grupo where idrupo = " + id + "";
                sp.ejecutaSQL("delete alumno where idgrupo = " + id + "");
                sp.ejecutaSQL("delete grupo where idgrupo = " + id + "");
            }
            else if (origen == 3)
            {
                var re = "delete alumno where idCarrera = " + id + "";
                var ri = "delete carrera where idCarrera = " + id + "";

                sp.ejecutaSQL("delete alumno where idCarrera = " + id + "");
                sp.ejecutaSQL("delete carrera where idCarrera = " + id + "");
            }
            else if (origen == 4)
            {
                var re = "delete alumno where idCarrera = " + id + "";
                var ri = "delete carrera where idCarrera = " + id + "";

                sp.ejecutaSQL("delete tipoBeca where idTipoBeca = " + id + "");
            }

            return "0";
        
        }catch(Exception ex){
            return "-1";
        }
      
    }

    [WebMethod]
    public static string guardar(string beca, int tipob, float prom, int ido,string desc)
    {
        storedProcedure sp = new storedProcedure("ConnectionString");
        if (ido == 1)
        {
            string q = "insert into beca values(" + beca + "," + prom + "," + tipob + "";
             sp.ejecutaSQL("insert into beca values('"+beca+"',"+prom+","+tipob+")");
        }
        else if (ido == 2)
        {
            sp.ejecutaSQL("insert into grupo values ('"+beca+"','"+desc+"')");
        }
        else if (ido == 3)
        {
            sp.ejecutaSQL("insert into carrera values ('" + beca + "','"+desc+"')");
        }
        else if (ido == 4)
        {
            sp.ejecutaSQL("insert into tipoBeca values ('" + beca + "','" + desc + "')");
        }
       
        return "0";
    }

    [WebMethod]
    public static string modificar(int id, string beca, int tipob, float prom, int ido, string desc)
    {
        storedProcedure sp = new storedProcedure("ConnectionString");
        if (ido == 1)
        {
            sp.ejecutaSQL("update beca set nombreBeca ='" + beca + "' , promedio=" + prom + " ,idTipoBeca = "+tipob+" where idBeca ="+id+" ");
        }
        else if (ido == 2)
        {
            sp.ejecutaSQL("update grupo set grupo = '"+beca+"', descripcion = '"+desc+"' where idgrupo = "+id+" ");
        }
        else if (ido == 3)
        {
            sp.ejecutaSQL("update carrera set carrera ='"+beca+"' , descripcion = '"+desc+"' where idCarrera = "+id+" ");
        }
        else if (ido == 4)
        {
            sp.ejecutaSQL("update tipoBeca set tipoBeca ='" + beca + "' , descripcion=  '" + desc + "' where idTipoBeca =  " + id + " ");
        }

        return "0";
    }

    [WebMethod]
    public static string cargarCombo() {
        string combo = "<select id='ss'>";
        storedProcedure sp = new storedProcedure("ConnectionString");

        string querycombo = "select distinct idTipoBeca, tipoBeca from tipoBeca";
        List<string> lsbeca = sp.recuperaRegistros(querycombo);
        for (int i = 0; i < lsbeca.Count;i = i=i+2 )
        {
            combo += "<option value='" + lsbeca[i + 0] + "'>"+lsbeca[i+1]+"</option>";
        }
        combo += "</select>";

        return combo;
    }
    
}