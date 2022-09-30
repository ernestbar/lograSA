using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Personal
    {
        //Base de datos
        private static OracleConnection Conexion = new OracleConnection("User Id=seguridad;Password=segu123;Data Source=200.12.254.22:1521/XE");
        #region Propiedades
        //Propiedades privadas
        private string _PV_SUPERVISOR_INMEDIATO = "";
        private string _PV_COD_SUCURSAL = "";
        private string _PV_COD_CLIENTE = "";
        private string _PV_COD_PERSONAL = "";
        private string _PV_NOMBRE_COMPLETO = "";
        private string _PV_TIPO_DOCUMENTO = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_EXPEDIDO = "";
        private string _PV_COD_CARGO = "";
        private int _PN_CELULAR = 0;
        private Int64 _PN_FIJO = 0;
        private Int64 _PN_INTERNO = 0;
        private string _PV_EMAIL = "";
        private string _PV_DESCRIPCION = "";
        private DateTime _PD_FECHA_DESDE = DateTime.Now;
        private DateTime _PD_FECHA_HASTA = DateTime.Now;
        private string _PV_ROL = "";
        private string _PV_USUARIOI = "";
        private string _PV_PASSWORD = "";
        private string _PV_PASSWORD_ANTERIOR = "";

        private string _PV_USUARIO = "";
        private string _PV_EMAILOUT = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        private string _PV_ESTADOPR = "";

        //Propiedades públicas
        public string PV_SUPERVISOR_INMEDIATO { get { return _PV_SUPERVISOR_INMEDIATO; } set { _PV_SUPERVISOR_INMEDIATO = value; } }
        public string PV_COD_SUCURSAL { get { return _PV_COD_SUCURSAL; } set { _PV_COD_SUCURSAL = value; } }
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }
        public string PV_COD_PERSONAL { get { return _PV_COD_PERSONAL; } set { _PV_COD_PERSONAL = value; } }
        public string PV_NOMBRE_COMPLETO { get { return _PV_NOMBRE_COMPLETO; } set { _PV_NOMBRE_COMPLETO = value; } }
        public string PV_TIPO_DOCUMENTO { get { return _PV_TIPO_DOCUMENTO; } set { _PV_TIPO_DOCUMENTO = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_EXPEDIDO { get { return _PV_EXPEDIDO; } set { _PV_EXPEDIDO = value; } }
        public string PV_COD_CARGO { get { return _PV_COD_CARGO; } set { _PV_COD_CARGO = value; } }
        public int PN_CELULAR { get { return _PN_CELULAR; } set { _PN_CELULAR = value; } }
        public Int64 PN_FIJO { get { return _PN_FIJO; } set { _PN_FIJO = value; } }
        public Int64 PN_INTERNO { get { return _PN_INTERNO; } set { _PN_INTERNO = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public DateTime PD_FECHA_DESDE { get { return _PD_FECHA_DESDE; } set { _PD_FECHA_DESDE = value; } }
        public DateTime PD_FECHA_HASTA { get { return _PD_FECHA_HASTA; } set { _PD_FECHA_HASTA = value; } }
        public string PV_ROL { get { return _PV_ROL; } set { _PV_ROL = value; } }
        public string PV_USUARIOI { get { return _PV_USUARIOI; } set { _PV_USUARIOI = value; } }
        public string PV_PASSWORD { get { return _PV_PASSWORD; } set { _PV_PASSWORD = value; } }
        public string PV_PASSWORD_ANTERIOR { get { return _PV_PASSWORD_ANTERIOR; } set { _PV_PASSWORD_ANTERIOR = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_EMAILOUT { get { return _PV_EMAILOUT; } set { _PV_EMAILOUT = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Personal(string pV_USUARIO, string pV_COD_PERSONAL)
        {
            _PV_USUARIO = pV_USUARIO;
            _PV_COD_PERSONAL = pV_COD_PERSONAL;
            RecuperarDatos();
        }
        public Personal(string pV_COD_CLIENTE, string pV_COD_PERSONAL, string pV_SUPERVISOR_INMEDIATO,
            string pV_COD_SUCURSAL, string pV_NOMBRE_COMPLETO, string pV_TIPO_DOCUMENTO, string pV_NUMERO_DOCUMENTO,
            string pV_EXPEDIDO, string pV_COD_CARGO, int pN_CELULAR, Int64 pN_FIJO, Int64 pN_INTERNO, string pV_EMAIL,
            string pV_USUARIOI, string pV_PASSWORD, string pV_PASSWORD_ANTERIOR, string pV_DESCRIPCION,
            DateTime pD_FECHA_DESDE, DateTime pD_FECHA_HASTA, string pV_ROL, string pV_USUARIO)
        {
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            _PV_COD_PERSONAL = pV_COD_PERSONAL;
            _PV_SUPERVISOR_INMEDIATO = pV_SUPERVISOR_INMEDIATO;
            _PV_COD_SUCURSAL = pV_COD_SUCURSAL;
            _PV_NOMBRE_COMPLETO = pV_NOMBRE_COMPLETO;
            _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_EXPEDIDO = pV_EXPEDIDO;
            _PV_COD_CARGO = pV_COD_CARGO;
            _PN_CELULAR = pN_CELULAR;
            _PN_FIJO = pN_FIJO;
            _PN_INTERNO = pN_INTERNO;
            _PV_EMAIL = pV_EMAIL;
            _PV_USUARIOI = pV_USUARIOI;
            _PV_PASSWORD = pV_PASSWORD;
            _PV_PASSWORD_ANTERIOR = pV_PASSWORD_ANTERIOR;
            _PV_DESCRIPCION = pV_DESCRIPCION;
            _PD_FECHA_DESDE = pD_FECHA_DESDE;
            _PD_FECHA_HASTA = pD_FECHA_HASTA;
            _PV_ROL = pV_ROL;
            _PV_USUARIO = pV_USUARIO;

        }
        #endregion
        #region Métodos que NO requieren constructor

        public static DataTable PR_PAR_GET_PERSONAL(string pV_COD_CLIENTE)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_PERSONAL", Conexion);
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
        public static DataTable PR_PAR_GET_USUARIOS(string pV_COD_PERSONAL)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_USUARIOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_COD_PERSONAL;
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
                if (_PV_USUARIO != "")
                {
                    if (Conexion.State.ToString().ToUpper() == "CLOSED")
                        Conexion.Open();

                    OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_USUARIOS_IND", Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
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
                            _PV_USUARIOI = (string)dr["USUARIO"];
                            _PV_TIPO_DOCUMENTO = (string)dr["TIPO_DOCUMENTO"];
                            _PV_DESCRIPCION = (string)dr["DESCRIPCION"];
                            _PD_FECHA_DESDE = (DateTime)dr["FECHA_DESDE"];
                            _PD_FECHA_HASTA = (DateTime)dr["FECHA_HASTA"];
                            _PV_ROL = (string)dr["rol"];
                        }

                    }
                }
                else
                {
                    if (Conexion.State.ToString().ToUpper() == "CLOSED")
                        Conexion.Open();

                    OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_PERSONAL_IND", Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_PERSONAL;
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
                            _PV_NOMBRE_COMPLETO = (string)dr["NOMBRE_COMPLETO"];
                            _PV_TIPO_DOCUMENTO = (string)dr["TIPO_DOCUMENTO"];
                            _PV_NUMERO_DOCUMENTO = (string)dr["NUMERO_DOCUMENTO"];
                            _PV_EXPEDIDO = (string)dr["EXPEDIDO"];
                            _PV_COD_CARGO = (string)dr["COD_CARGO"];
                            _PN_CELULAR = (int)dr["CELULAR"];
                            _PN_FIJO = (Int64)dr["FIJO"];
                            _PN_INTERNO = (Int64)dr["INTERNO"];

                            if (string.IsNullOrEmpty(dr["EMAIL"].ToString()))
                            { _PV_EMAIL = ""; }
                            else
                            { _PV_EMAIL = (string)dr["EMAIL"]; }

                            _PV_COD_SUCURSAL = (string)dr["COD_SUCURSAL"];
                        }

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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_I_PERSONAL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if(_PV_SUPERVISOR_INMEDIATO=="SELECCIONAR")
                    cmd.Parameters.Add("PV_SUPERVISOR_INMEDIATO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_SUPERVISOR_INMEDIATO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_SUPERVISOR_INMEDIATO;
                cmd.Parameters.Add("PV_COD_SUCURSAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_SUCURSAL;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_NOMBRE_COMPLETO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NOMBRE_COMPLETO;
                cmd.Parameters.Add("PV_TIPO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_DOCUMENTO;
                cmd.Parameters.Add("PV_NUMERO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NUMERO_DOCUMENTO;
                cmd.Parameters.Add("PV_EXPEDIDO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_EXPEDIDO;
                cmd.Parameters.Add("PV_COD_CARGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CARGO;
                cmd.Parameters.Add("PN_CELULAR", OracleDbType.Int32, ParameterDirection.Input).Value = _PN_CELULAR;
                cmd.Parameters.Add("PN_FIJO", OracleDbType.Int64, ParameterDirection.Input).Value = _PN_FIJO;
                cmd.Parameters.Add("PN_INTERNO", OracleDbType.Int64, ParameterDirection.Input).Value = _PN_INTERNO;
                cmd.Parameters.Add("PV_EMAIL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_EMAIL;
                cmd.Parameters.Add("PV_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCION;
                cmd.Parameters.Add("PD_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = _PD_FECHA_DESDE;
                cmd.Parameters.Add("PD_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PD_FECHA_HASTA;
                cmd.Parameters.Add("PV_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_ROL;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_EMAILOUT", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

               

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

                if (String.IsNullOrEmpty(cmd.Parameters["PV_EMAILOUT"].Value.ToString()))
                    PV_EMAILOUT = "";
                else
                    PV_EMAILOUT = cmd.Parameters["PV_EMAILOUT"].Value.ToString();
                Conexion.Close();
                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR + "|" + PV_EMAILOUT;
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_U_PERSONAL", Conexion);
                cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_PERSONAL;
                if(_PV_SUPERVISOR_INMEDIATO=="SELECCIONAR")
                    cmd.Parameters.Add("PV_SUPERVISOR_INMEDIATO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_SUPERVISOR_INMEDIATO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_SUPERVISOR_INMEDIATO;
                cmd.Parameters.Add("PV_COD_SUCURSAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_SUCURSAL;
                cmd.Parameters.Add("PV_NOMBRE_COMPLETO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NOMBRE_COMPLETO;
                cmd.Parameters.Add("PV_TIPO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_DOCUMENTO;
                cmd.Parameters.Add("PV_NUMERO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NUMERO_DOCUMENTO;
                cmd.Parameters.Add("PV_EXPEDIDO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_EXPEDIDO;
                cmd.Parameters.Add("PV_COD_CARGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CARGO;
                cmd.Parameters.Add("PN_CELULAR", OracleDbType.Int32, ParameterDirection.Input).Value = _PN_CELULAR;
                cmd.Parameters.Add("PN_FIJO", OracleDbType.Int64, ParameterDirection.Input).Value = _PN_FIJO;
                cmd.Parameters.Add("PN_INTERNO", OracleDbType.Int64, ParameterDirection.Input).Value = _PN_INTERNO;
                cmd.Parameters.Add("PV_USUARIOI", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIOI;
                cmd.Parameters.Add("PV_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCION;
                cmd.Parameters.Add("PD_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = _PD_FECHA_DESDE;
                cmd.Parameters.Add("PD_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PD_FECHA_HASTA;
                cmd.Parameters.Add("PV_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_ROL;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;

               

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
                Conexion.Close();
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_D_PERSONAL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_PERSONAL;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                

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
                Conexion.Close();
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

        public string ABM_A()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_A_PERSONAL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_PERSONAL;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                

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
                Conexion.Close();
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

        public string ABM_C()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_C_PERSONAL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_USUARIOI", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIOI;
                cmd.Parameters.Add("PV_PASSWORD_ANTERIOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_PASSWORD_ANTERIOR;
                cmd.Parameters.Add("PV_PASSWORD", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_PASSWORD;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                

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
                Conexion.Close();
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

        public string ABM_R()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_R_PERSONAL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_USUARIOI", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIOI;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_EMAILOUT", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

               

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

                if (String.IsNullOrEmpty(cmd.Parameters["PV_EMAILOUT"].Value.ToString()))
                    PV_EMAILOUT = "";
                else
                    PV_EMAILOUT = cmd.Parameters["PV_EMAILOUT"].Value.ToString();
                Conexion.Close();
                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR + "|" + PV_EMAILOUT;
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