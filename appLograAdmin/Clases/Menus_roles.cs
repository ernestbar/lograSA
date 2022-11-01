using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Menus_roles
    {
        //Base de datos
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PB_ID_ROL = "";
        private string _PB_COD_MENU = "";
        private string _PB_ROL_MENU = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PB_ROL_MENU { get { return _PB_ROL_MENU; } set { _PB_ROL_MENU = value; } }
        public string PB_ID_ROL { get { return _PB_ID_ROL; } set { _PB_ID_ROL = value; } }
        public string PB_COD_MENU { get { return _PB_COD_MENU; } set { _PB_COD_MENU = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }


        #endregion

        #region Constructores
        public Menus_roles(string pB_ROL_MENU)
        {
            _PB_ROL_MENU = pB_ROL_MENU;
            RecuperarDatos();
        }
        public Menus_roles(string pB_ROL_MENU, string pB_ID_ROL, string pB_COD_MENU, string pV_USUARIO)
        {
            _PB_ROL_MENU = pB_ROL_MENU;
            _PB_ID_ROL = pB_ID_ROL;
            _PB_COD_MENU = pB_COD_MENU;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_SEG_GET_MENUS_A_ASIGNAR(string pB_ROL_ID_ROL,string pV_SISTEMA)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_ROLES_SEGAL.PR_SEG_GET_MENUS_A_ASIGNAR", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_ROL_ID_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = pB_ROL_ID_ROL;
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

        public static DataTable PR_SEG_GET_MENUS_ASIGNADOS(string pB_ROL_ID_ROL, string pV_SISTEMA)
        {

            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_ROLES_SEGAL.PR_SEG_GET_MENUS_ASIGNADOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_ROL_ID_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = pB_ROL_ID_ROL;
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
                //DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CARGOS_IND");
                //db1.AddInParameter(cmd, "PI_COD_CARGO", DbType.String, _PI_COD_CARGO);
                //db1.AddInParameter(cmd, "PV_CAR_VERSION_DIA", DbType.String, _PV_VERSION_DIA);
                //db1.AddInParameter(cmd, "PV_CAR_VERSION_MES", DbType.String, _PV_VERSION_MES);
                //db1.AddInParameter(cmd, "PV_CAR_VERSION_ANIO", DbType.String, _PV_VERSION_ANIO);
                //db1.AddInParameter(cmd, "PV_CAR_VERSION_SECUENCIA", DbType.String, _PV_VERSION_SECUENCIA);
                //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                //DataTable dt = new DataTable();
                //dt = db1.ExecuteDataSet(cmd).Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        _PI_COD_CARGO = (string)dr["CAR_COD_CARGO"];
                //        _PV_NOMBRE_CARGO = (string)dr["CAR_NOMBRE_CARGO"];
                //        _PB_ID_ROL = (Int64)dr["PAT_ID_AREA_TRABAJO"];
                //        _PV_OBJETIVO_CARGO = (string)dr["CAR_OBJETIVO"];
                //        _PB_COD_MENU = (Int64)dr["CAR_EXPERIENCIA_GENERAL"];
                //        _PV_CAR_NIVEL_ACADEMICO = (string)dr["CAR_NIVEL_ACADEMICO"];
                //        _PI_CAR_CANT_PUESTOS = (int)dr["CAR_CANT_PUESTOS"];
                //        if (string.IsNullOrEmpty(dr["SUC_ID_SUCURSAL"].ToString()))
                //            _PI_ID_SUCURSAL = 0;
                //        else
                //            _PI_ID_SUCURSAL = (Int64)dr["SUC_ID_SUCURSAL"];
                //        if (string.IsNullOrEmpty(dr["CAR_EXPERIENCIA_ESPECIFICA"].ToString()))
                //            _PI_EXPERIENCIA_ESPECIFICA = 0;
                //        else
                //            _PI_EXPERIENCIA_ESPECIFICA = (Int64)dr["CAR_EXPERIENCIA_ESPECIFICA"];


                //        if (string.IsNullOrEmpty(dr["CAR_EXPERIENCIA_GENERAL_DESC"].ToString()))
                //            _PV_CAR_EXPERIENCIA_ANIOS_DESC = "";
                //        else
                //            _PV_CAR_EXPERIENCIA_ANIOS_DESC = (string)dr["CAR_EXPERIENCIA_GENERAL_DESC"];

                //        if (string.IsNullOrEmpty(dr["CAR_EXPERIENCIA_ESPECIFICA_DESC"].ToString()))
                //            _PV_CAR_EXPERIENCIA_ESPECIFICA_DESC = "";
                //        else
                //            _PV_CAR_EXPERIENCIA_ESPECIFICA_DESC = (string)dr["CAR_EXPERIENCIA_ESPECIFICA_DESC"];

                //        if (string.IsNullOrEmpty(dr["CAR_NIVEL_ACADEMICO_DESC"].ToString()))
                //            _PV_CAR_NIVEL_ACADEMICO_DESC = "";
                //        else
                //            _PV_CAR_NIVEL_ACADEMICO_DESC = (string)dr["CAR_NIVEL_ACADEMICO_DESC"];
                //    }
                //}
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_ROLES_SEGAL.PR_I_MENUS_ROLES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_ID_ROL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PB_ID_ROL;
                cmd.Parameters.Add("PB_COD_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PB_COD_MENU;
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_MENUS_ROLES_SEGAL.PR_D_MENUS_ROLES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PB_ROL_MENU", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PB_ROL_MENU;
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