using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;


namespace appLograAdmin.Clases
{
    public class Dominios
    { 
        //Base de datos
        //private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_DOMINIO = "";
        private string _PV_CODIGO = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_VALOR_CARACTER = "";
        private int _PV_VALOR_NUMERICO = 0;
        private DateTime _PV_VALOR_DATE = DateTime.Now;

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_DOMINIO { get { return _PV_DOMINIO; } set { _PV_DOMINIO = value; } }
        public string PV_CODIGO { get { return _PV_CODIGO; } set { _PV_CODIGO = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_VALOR_CARACTER { get { return _PV_VALOR_CARACTER; } set { _PV_VALOR_CARACTER = value; } }
        public int PV_VALOR_NUMERICO { get { return _PV_VALOR_NUMERICO; } set { _PV_VALOR_NUMERICO = value; } }
        public DateTime PV_VALOR_DATE { get { return _PV_VALOR_DATE; } set { _PV_VALOR_DATE = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Dominios(string pV_DOMINIO, string pV_CODIGO)
        {
            _PV_DOMINIO = pV_DOMINIO;
            _PV_CODIGO = pV_CODIGO;
            RecuperarDatos();
        }
        public Dominios(string pV_DOMINIO, string pV_CODIGO,
         string pV_DESCRIPCION, string pV_VALOR_CARACTER, int pV_VALOR_NUMERICO,
         DateTime pV_VALOR_DATE, string pV_USUARIO)
        {
            _PV_DOMINIO = pV_DOMINIO;
            _PV_CODIGO = pV_CODIGO;
            _PV_DESCRIPCION = pV_DESCRIPCION;
            _PV_VALOR_CARACTER = pV_VALOR_CARACTER;
            _PV_VALOR_DATE = pV_VALOR_DATE;
            _PV_VALOR_NUMERICO = pV_VALOR_NUMERICO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_PAR_GET_DOMINIOS(string pV_DOMINIO)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_PAR_GET_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_DOMINIO;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_PAR_GET_ONLY_DOMINIOS()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                 Conexion.Open(); 
                    
                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_PAR_GET_ONLY_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_GET_DATOS_DOMINIOS(string pV_DOMINIO)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_GET_DATOS_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_DOMINIO;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_GET_DATOS_DOMINIOS_PADRE()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_GET_DATOS_DOMINIOS_PADRE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_GET_LISTA_DOMINIO_DATA(string pV_DOMINIO)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_GET_LISTA_DOMINIO_DATA", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_DOMINIO;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_GET_CIUDAD(string pV_COD_PAIS)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_GET_CIUDAD", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_PAIS", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_COD_PAIS;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_GET_SERVIDORES()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_GET_SERVIDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_PAR_GET_DOMINIOS_IND", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DOMINIO;
                cmd.Parameters.Add("PV_CODIGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);  
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PV_DESCRIPCION = (string)dr["descripcion"];

                        if (string.IsNullOrEmpty(dr["VALOR_CARACTER"].ToString()))
                        { _PV_VALOR_CARACTER = ""; }
                        else
                        { _PV_VALOR_CARACTER = (string)dr["VALOR_CARACTER"]; }

                        if (string.IsNullOrEmpty(dr["VALOR_NUMERICO"].ToString()))
                        { _PV_VALOR_NUMERICO = 0; }
                        else
                        { _PV_VALOR_NUMERICO = int.Parse(dr["VALOR_NUMERICO"].ToString()); }

                        if (string.IsNullOrEmpty(dr["VALOR_DATE"].ToString()))
                        { _PV_VALOR_DATE = DateTime.Parse("01/01/3000"); }
                        else
                        { _PV_VALOR_DATE = DateTime.Parse(dr["VALOR_DATE"].ToString()); }

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }



        public string ABM_I()
        {
            string resultado = "";
            try
            {

                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_I_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DOMINIO;
                cmd.Parameters.Add("PV_CODIGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO;
                cmd.Parameters.Add("PV_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCION;
                cmd.Parameters.Add("PV_VALOR_CARACTER", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_VALOR_CARACTER;
                cmd.Parameters.Add("PV_VALOR_NUMERICO", OracleDbType.Int32, ParameterDirection.Input).Value = _PV_VALOR_NUMERICO;
                if (_PV_VALOR_DATE == DateTime.Parse("01/01/3000"))
                    cmd.Parameters.Add("PV_VALOR_DATE", OracleDbType.Date, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_VALOR_DATE", OracleDbType.Date, ParameterDirection.Input).Value = _PV_VALOR_DATE;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
               
                Conexion.Close();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ESTADOPR"].Value.ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = cmd.Parameters["PV_ESTADOPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ERROR"].Value.ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = cmd.Parameters["PV_ERROR"].Value.ToString();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }

        public string ABM_U()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_U_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DOMINIO;
                cmd.Parameters.Add("PV_CODIGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO;
                cmd.Parameters.Add("PV_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCION;
                cmd.Parameters.Add("PV_VALOR_CARACTER", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_VALOR_CARACTER;
                cmd.Parameters.Add("PV_VALOR_NUMERICO", OracleDbType.Int32, ParameterDirection.Input).Value = _PV_VALOR_NUMERICO;
                if(_PV_VALOR_DATE==DateTime.Parse("01/01/3000"))
                    cmd.Parameters.Add("PV_VALOR_DATE", OracleDbType.Date, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_VALOR_DATE", OracleDbType.Date, ParameterDirection.Input).Value = _PV_VALOR_DATE;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Conexion.Close();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ESTADOPR"].Value.ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = cmd.Parameters["PV_ESTADOPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ERROR"].Value.ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = cmd.Parameters["PV_ERROR"].Value.ToString();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }

        public string ABM_D()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_D_DOMINIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DOMINIO;
                cmd.Parameters.Add("PV_CODIGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Conexion.Close();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ESTADOPR"].Value.ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = cmd.Parameters["PV_ESTADOPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ERROR"].Value.ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = cmd.Parameters["PV_ERROR"].Value.ToString();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }
        #endregion
    }
}