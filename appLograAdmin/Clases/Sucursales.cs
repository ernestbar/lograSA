using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Sucursales
    {
        //Base de datos
        private static OracleConnection Conexion = new OracleConnection("User Id=compusoft;Password=LoGa.001;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_CODIGO_SUCURSAL = "";
        private string _PV_CODIGO_CLIENTE = "";
        private string _PV_NOMBRE_SUCURSAL = "";
        private string _PV_DIRECCION = "";
        private string _PB_ID_PAIS = "";
        private string _PB_ID_CIUDAD = "";
        private string _PV_LATITUD = "";
        private string _PV_LONGITUD = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_CODIGO_SUCURSAL { get { return _PV_CODIGO_SUCURSAL; } set { _PV_CODIGO_SUCURSAL = value; } }
        public string PV_CODIGO_CLIENTE { get { return _PV_CODIGO_CLIENTE; } set { _PV_CODIGO_CLIENTE = value; } }
        public string PV_NOMBRE_SUCURSAL { get { return _PV_NOMBRE_SUCURSAL; } set { _PV_NOMBRE_SUCURSAL = value; } }
        public string PV_DIRECCION { get { return _PV_DIRECCION; } set { _PV_DIRECCION = value; } }
        public string PB_ID_PAIS { get { return _PB_ID_PAIS; } set { _PB_ID_PAIS = value; } }
        public string PB_ID_CIUDAD { get { return _PB_ID_CIUDAD; } set { _PB_ID_CIUDAD = value; } }
        public string PV_LATITUD { get { return _PV_LATITUD; } set { _PV_LATITUD = value; } }
        public string PV_LOGITUD { get { return _PV_LONGITUD; } set { _PV_LONGITUD = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Sucursales(string pV_CODIGO_SUCURSAL)
        {
            _PV_CODIGO_SUCURSAL = pV_CODIGO_SUCURSAL;
            PR_PAR_GET_SUCURSALES_IND();
        }
        public Sucursales(string pV_CODIGO_SUCURSAL,string pV_CODIGO_CLIENTE, string pV_NOMBRE_SUCURSAL,
            string pV_DIRECCION,string pB_ID_PAIS,string pB_ID_CIUDAD ,string pV_LATITUD, string pV_LONGITUD, string pV_USUARIO)
        {
            _PB_ID_PAIS = pB_ID_PAIS;
            _PB_ID_CIUDAD = pB_ID_CIUDAD;
            _PV_CODIGO_SUCURSAL = pV_CODIGO_SUCURSAL;
            _PV_CODIGO_CLIENTE = pV_CODIGO_CLIENTE;
            _PV_NOMBRE_SUCURSAL = pV_NOMBRE_SUCURSAL;
            _PV_DIRECCION = pV_DIRECCION;
            _PV_LATITUD = pV_LATITUD;
            _PV_LONGITUD = pV_LONGITUD;
            _PV_USUARIO = pV_USUARIO;
        }

        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_PAR_GET_SUCURSALES(string pV_COD_CLIENTE)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_SUCURSALES.PR_PAR_GET_SUCURSALES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_COD_CLIENTE;
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
        private void PR_PAR_GET_SUCURSALES_IND()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_LOG_DOMINIO.PR_PAR_GET_SUCURSALES_IND", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_SUCURSAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO_SUCURSAL;
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
                        _PV_NOMBRE_SUCURSAL = (string)dr["PV_NOMBRE_SUCURSAL"];
                        _PB_ID_PAIS = (string)dr["PB_ID_PAIS"];
                        _PB_ID_CIUDAD = (string)dr["PB_ID_CIUDAD"];

                        if (string.IsNullOrEmpty(dr["PV_DIRECCION"].ToString()))
                        { _PV_DIRECCION = ""; }
                        else
                        { _PV_DIRECCION = (string)dr["PV_DIRECCION"]; }

                        if (string.IsNullOrEmpty(dr["PV_LATITUD"].ToString()))
                        { _PV_LATITUD = ""; }
                        else
                        { _PV_LATITUD = (string)(dr["PV_LATITUD"].ToString()); }

                        if (string.IsNullOrEmpty(dr["PV_LONGITUD"].ToString()))
                        { _PV_LONGITUD = ""; }
                        else
                        { _PV_LONGITUD = (string)(dr["PV_LONGITUD"].ToString()); }

                        

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
                OracleCommand cmd = new OracleCommand("PAQ_LOG_DOMINIO.PR_I_DOMINIO", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO_CLIENTE;
                cmd.Parameters.Add("PV_NOMBRE_SUCURSAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NOMBRE_SUCURSAL;
                cmd.Parameters.Add("PV_DIRECCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DIRECCION;
                cmd.Parameters.Add("PB_ID_PAIS", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PB_ID_PAIS;
                cmd.Parameters.Add("PB_ID_CIUDAD", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PB_ID_CIUDAD;
                cmd.Parameters.Add("PV_LATITUD", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_LATITUD;
                cmd.Parameters.Add("PV_LONGITUD", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_LONGITUD;
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
                OracleCommand cmd = new OracleCommand("PAQ_LOG_DOMINIO.PR_U_DOMINIO", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DOMINIO;
                cmd.Parameters.Add("PV_CODIGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CODIGO;
                cmd.Parameters.Add("PV_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCION;
                cmd.Parameters.Add("PV_VALOR_CARACTER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                cmd.Parameters.Add("PV_VALOR_NUMERICO", OracleDbType.Int32, ParameterDirection.Input).Value = null;
                cmd.Parameters.Add("PV_VALOR_DATE", OracleDbType.Date, ParameterDirection.Input).Value = null;
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
                OracleCommand cmd = new OracleCommand("PAQ_LOG_DOMINIO.PR_D_DOMINIO", Conexion);
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