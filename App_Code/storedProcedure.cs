using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// Descripción breve de storedProcedure
/// </summary>
public class storedProcedure
{
    private string Conexion;
    private SqlConnection conexion;
    SqlCommand comando = null;
    SqlDataReader resultados = null;
    private string conn;

    private SqlDataAdapter objAdapter;


    #region storedProcedure
    public storedProcedure(string conn)
    {
        this.conn = conn;
    }
    #endregion

    #region establecerConexion
    public void establecerConexion()
    {
        conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
    }
    #endregion 

    #region InsertaCampos
    public int InsertaCampos(string campo)
    {
        establecerConexion();
        comando = new SqlCommand(campo, conexion);
        try
        {
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return 1;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return 0;
        }
    }
    #endregion

    #region ejecutaSQL
    public bool ejecutaSQL(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;

        try
        {
            conexion.Open();
            comando.ExecuteReader();
            conexion.Close();

            return true;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return false;
        }

    }
    #endregion

    #region RecuperarRegistros
    public List<string> recuperaRegistros(string query)
    {
        List<string> resultado = new List<string>();
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();

            if (resultados.HasRows)
            {
                while (resultados.Read())
                {
                    for (int i = 0; i < resultados.FieldCount; i++)
                    {
                        resultado.Add(resultados.GetValue(i).ToString());
                    }
                }

            }
            conexion.Close();
            return resultado;

        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return null;
 
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion

    #region RecuperaResultados
    public string recuperaValor(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        string resultado = "";
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();
            if (resultados.HasRows)
            {
                while (resultados.Read())
                {
                    resultado = resultados.GetValue(0).ToString();
                }
            }
            conexion.Close();

            return resultado;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return "-1";
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion

    #region RecuperaValores
    public int recuperaValornum(string query)
    {
        establecerConexion();
        comando = new SqlCommand(query, conexion);
        comando.CommandType = CommandType.Text;
        int resultado;
        try
        {
            conexion.Open();
            object resultados = comando.ExecuteScalar();
            resultado = Convert.ToInt32(resultados);

            return resultado;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            return 0;
        }
        finally
        {
            conexion.Dispose();
            conexion.Close();
        }

    }
    #endregion

    #region user

    public string saveUser(string name, string email, string pass, int idRol, int idCarrera, int idGrupo, float prom)
    {
        string result = "";
        establecerConexion();
        comando = new SqlCommand("sp_guardarUsuario", conexion);

        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandTimeout = 12100;
        comando.Parameters.Add("@name ", SqlDbType.VarChar).Value = name;
        comando.Parameters.Add("@email ", SqlDbType.VarChar).Value = email;
        comando.Parameters.Add("@password ", SqlDbType.Int).Value = pass;
        comando.Parameters.Add("@idCarrera ", SqlDbType.Int).Value = idCarrera;
        comando.Parameters.Add("@idGrupo ", SqlDbType.VarChar).Value = idGrupo;
        comando.Parameters.Add("@promedio ", SqlDbType.Float).Value = prom;
        comando.Parameters.Add("@idRole ", SqlDbType.Int).Value = idRol;

        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();
            while (resultados.Read())
            {
                result = resultados.GetValue(0).ToString();
            }
            conexion.Close();
            return result;
        }
        catch (SqlException ex)
        {
            Console.Write(ex);
            result = "-1";
            return result;
        }
    }
    #endregion

    #region saveFolio
    public string saveFolio(string folio, string source, string posting, string idusuarios)
    {
        establecerConexion();
        comando = new SqlCommand("sp_saveFolio", conexion);
        comando.CommandType = CommandType.StoredProcedure;

        comando.Parameters.Add("@folio", SqlDbType.VarChar).Value = folio;
        comando.Parameters.Add("@source", SqlDbType.VarChar).Value = source;
        comando.Parameters.Add("@posting", SqlDbType.VarChar).Value = posting;
        comando.Parameters.Add("@idusuarios", SqlDbType.VarChar).Value = idusuarios;
        string result = "";
        try
        {
            conexion.Open();
            resultados = comando.ExecuteReader();
            while (resultados.Read())
            {
                result = resultados.GetValue(0).ToString();
            }
            conexion.Close();

            return result;
        }
        catch (SqlException e)
        {
            return e.Message.ToString();
        }
    }
    #endregion
}


    