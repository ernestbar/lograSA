using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Utilitarios
    {
        //Base de datos
        //private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Métodos que NO requieren constructor

        public static DataTable PR_SEG_GET_MENUS_PADRE_ROL(string pv_usuario,string PV_SISTEMA)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_SEG_GET_MENUS_PADRE_ROL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pv_usuario", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_usuario;
                if (PV_SISTEMA == "")
                    cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SISTEMA;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                DataView dtv = ds.Tables[0].DefaultView;
                dtv.Sort = "RN DESC";
                return dtv.ToTable();
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_SEG_GET_MENUS_RLES(string PB_ROL_ID_ROL,string PV_SISTEMA)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_SEG_GET_MENUS_RLES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_ROL_ID_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = PB_ROL_ID_ROL;
                cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SISTEMA;
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

        public static DataTable PR_SEG_GET_MENUS_ROL(string pv_usuario, string pv_MEN_COD_MENU_PADRE, string PV_SISTEMA)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_SEG_GET_MENUS_ROL", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pv_usuario", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_usuario;
                cmd.Parameters.Add("pv_MEN_COD_MENU_PADRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_MEN_COD_MENU_PADRE;
                if(PV_SISTEMA=="")
                    cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                else
                    cmd.Parameters.Add("PV_SISTEMA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SISTEMA;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                DataView dtv = ds.Tables[0].DefaultView;
                dtv.Sort = "RN ASC";
                return dtv.ToTable();
            }
            catch (Exception ex)
            {
                Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_SEG_GET_OPCIONES_ROLES(string pv_usuario, string PD_MEN_COD_MENU)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_SEG_GET_OPCIONES_ROLES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PD_MEN_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = PD_MEN_COD_MENU;
                cmd.Parameters.Add("pv_usuario", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_usuario;
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

        public static string PR_INGRESO_APP(string pv_usuario,string pv_password)
        {
            try
            {
                string resultado = "";
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_INGRESO_APP", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pv_usuario", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_usuario;
                if(pv_password=="")
                    cmd.Parameters.Add("pv_password", OracleDbType.Varchar2, ParameterDirection.Input).Value = '1';
                else
                    cmd.Parameters.Add("pv_password", OracleDbType.Varchar2, ParameterDirection.Input).Value = pv_password;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_TEMPORAL", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ES_MASTER", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Conexion.Close();
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_TEMPORAL = "";
                string PV_COD_CLIENTE = "";
                string PV_ES_MASTER = "";
                if (String.IsNullOrEmpty(cmd.Parameters["PV_ESTADOPR"].Value.ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = cmd.Parameters["PV_ESTADOPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = cmd.Parameters["PV_DESCRIPCIONPR"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_TEMPORAL"].Value.ToString()))
                    PV_TEMPORAL = "";
                else
                    PV_TEMPORAL = cmd.Parameters["PV_TEMPORAL"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_COD_CLIENTE"].Value.ToString()))
                    PV_COD_CLIENTE = "";
                else
                    PV_COD_CLIENTE = cmd.Parameters["PV_COD_CLIENTE"].Value.ToString();

                if (String.IsNullOrEmpty(cmd.Parameters["PV_ES_MASTER"].Value.ToString()))
                    PV_ES_MASTER = "";
                else
                    PV_ES_MASTER = cmd.Parameters["PV_ES_MASTER"].Value.ToString();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_TEMPORAL + "|" + PV_COD_CLIENTE + "|" + PV_ES_MASTER;
                return resultado;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                
              
                return ex.ToString(); 
            }

        }

        public static string PR_SEG_CAMBIOPASSWORD(string PV_COD_USUARIO,string PV_PASSWORDANTERIOR,string PV_PASSWORDNUEVO, string PV_USUARIO)
        {
            try
            {
                string resultado = "";
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_UTILITARIOS_SIGAL.PR_SEG_CAMBIOPASSWORD", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_USUARIO;
                cmd.Parameters.Add("PV_PASSWORDANTERIOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_PASSWORDANTERIOR;
                cmd.Parameters.Add("PV_PASSWORDNUEVO", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_PASSWORDNUEVO;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Conexion.Close();
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_ERROR = "";
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
                Conexion.Close();


                return ex.ToString();
            }

        }
        #endregion
    }
}