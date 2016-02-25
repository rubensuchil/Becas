using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

    public class Conexion
    {
        protected SqlConnection objCon;
        protected SqlCommand objComand;
        protected SqlDataReader objResult;
        protected SqlDataAdapter objAdapter;
        protected string conexionString;

        public Conexion()
        {
            conexionString = "";
        }

        public void open_conexion(string conexionString)
        {
            objCon = new SqlConnection(ConfigurationManager.ConnectionStrings[conexionString].ConnectionString);
        }

        public string getValue(string query)
        {
            string value = "";
            open_conexion("ConnectionString");
            try
            {
                objComand = new SqlCommand(query, objCon);
                objComand.CommandType = CommandType.Text;
                objComand.CommandTimeout = 30000;

                objCon.Open();
                objResult = objComand.ExecuteReader();
                if (objResult.HasRows)
                {
                    while (objResult.Read())
                    {
                        value = objResult.GetValue(0).ToString();
                    }
                }
                this.objCon.Close();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return value;
        }

        public DataTable getValues(string query)
        {
            DataTable ds = new DataTable();
            open_conexion("ConnectionString");
            try
            {
                objComand = new SqlCommand(query, objCon);
                objComand.CommandType = CommandType.Text;
                objComand.CommandTimeout = 30000;
                objCon.Open();
                objResult = objComand.ExecuteReader();

                if (objResult.HasRows)
                {
                    ds.Load(objResult, LoadOption.OverwriteChanges);
                }
                this.objCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        public DataTable getValuesLogs(string query)
        {
            DataTable ds = new DataTable();
            open_conexion("ConnectionString");
            try
            {
                objComand = new SqlCommand(query, objCon);
                objComand.CommandType = CommandType.Text;
                objComand.CommandTimeout = 30000;
                objCon.Open();
                objResult = objComand.ExecuteReader();

                if (objResult.HasRows)
                {
                    ds.Load(objResult, LoadOption.OverwriteChanges);
                }
                this.objCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        public void execute_query(string query)
        {
            open_conexion("ConnectionString");
            try
            {
                objComand = new SqlCommand(query, objCon);
                objComand.CommandType = CommandType.Text;

                objCon.Open();
                objComand.ExecuteReader();
                objCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public string ejecutar_query(string query)
        {
            string resultado = "";
            open_conexion("ConnectionString");
            try
            {
                objComand = new SqlCommand(query, objCon);
                objComand.CommandType = CommandType.Text;

                objCon.Open();
                objResult = objComand.ExecuteReader();
                while (objResult.Read())
                {
                    resultado += "|" + objResult.GetValue(0).ToString();
                }
                this.objCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }


    }