using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;


namespace appLograAdmin.Clases
{
    public class Menus
    {
        //Base de datos
        //private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_COD_MENU = "";
        private string _PV_COD_MENU_PADRE = "";
        private string _PV_DESCRIPCIONMEN = "";
        private string _PV_DETALLE = "";
        private string _PV_SISTEMAS = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_COD_MENU { get { return _PV_COD_MENU; } set { _PV_COD_MENU = value; } }
        public string PV_COD_MENU_PADRE { get { return _PV_COD_MENU_PADRE; } set { _PV_COD_MENU_PADRE = value; } }
        public string PV_DESCRIPCIONMEN { get { return _PV_DESCRIPCIONMEN; } set { _PV_DESCRIPCIONMEN = value; } }
        public string PV_DETALLE { get { return _PV_DETALLE; } set { _PV_DETALLE = value; } }
        public string PV_SISTEMAS { get { return _PV_SISTEMAS; } set { _PV_SISTEMAS = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Menus(string pV_COD_MENU)
        {
            _PV_COD_MENU = pV_COD_MENU;
            RecuperarDatos();
        }
        public Menus(string pV_COD_MENU, string pV_COD_MENU_PADRE, string pV_DESCRIPCIONMEN,string pV_DETALLE,string pV_SISTEMAS, string pV_USUARIO)
        {
            _PV_COD_MENU = pV_COD_MENU;
            _PV_COD_MENU_PADRE = pV_COD_MENU_PADRE;
            _PV_DESCRIPCIONMEN = pV_DESCRIPCIONMEN;
            _PV_DETALLE = pV_DETALLE;
            _PV_SISTEMAS = pV_SISTEMAS;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_SEG_GET_MENUS(string pV_SISTEMA)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_SEG_GET_MENUS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_SISTEMA;
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

                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_SEG_GET_MENUS_IND", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU;
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
                        if (String.IsNullOrEmpty(dr["cod_menu_padre"].ToString()))
                            _PV_COD_MENU_PADRE = "";
                        else
                            _PV_COD_MENU_PADRE = dr["cod_menu_padre"].ToString();

                        _PV_DESCRIPCIONMEN = (string)dr["descripcion"];

                        if (String.IsNullOrEmpty(dr["detalle"].ToString()))
                            _PV_DETALLE = "";
                        else
                            _PV_DETALLE = dr["detalle"].ToString();


                        //_PV_SISTEMAS = (string)dr["sistema"];
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_I_MENUS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if(_PV_COD_MENU_PADRE=="")
                    cmd.Parameters.Add("PV_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU_PADRE;
                cmd.Parameters.Add("PV_DESCRIPCIONMEN", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCIONMEN;
                cmd.Parameters.Add("PV_DETALLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DETALLE;
                cmd.Parameters.Add("PV_SISTEMAS", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_SISTEMAS;
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_U_MENUS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU;
                cmd.Parameters.Add("PB_COD_MENU_PADRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU_PADRE;
                cmd.Parameters.Add("PV_DESCRIPCIONMEN", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DESCRIPCIONMEN;
                cmd.Parameters.Add("PV_DETALLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_DETALLE;
                cmd.Parameters.Add("PV_SISTEMAS", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_SISTEMAS;
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_D_MENUS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU;
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

        public string ABM_A()
        {
            string resultado = "";
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_SIGAL.PR_A_MENUS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_MENU;
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