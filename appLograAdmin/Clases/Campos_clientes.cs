using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;


namespace appLograAdmin.Clases
{
    public class Campos_clientes
    {
        //Base de datos
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_COD_REPORTE = "";
        private string _PV_COD_CLIENTE = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_COD_REPORTE { get { return _PV_COD_REPORTE; } set { _PV_COD_REPORTE = value; } }
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }


        #endregion

        #region Constructores
        //public Campos_clientes(string pB_ROL_MENU)
        //{
        //    _PB_ROL_MENU = pB_ROL_MENU;
        //    RecuperarDatos();
        //}
        public Campos_clientes(string pV_COD_REPORTE, string pV_COD_CLIENTE, string pV_USUARIO)
        {
            _PV_COD_REPORTE = pV_COD_REPORTE;
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_GET_CAMPO_A_ASIGNAR_CLIENTE(string pV_COD_REPORTE, string pV_COD_CLIENTE)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CAMPOS_CLIENTES.PR_GET_CAMPO_A_ASIGNAR_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_TIPO_REPORTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_COD_REPORTE;
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

        public static DataTable PR_GET_CAMPO_ASIGNADO_CLIENTE(string pV_COD_REPORTE, string pV_COD_CLIENTE)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CAMPOS_CLIENTES.PR_GET_CAMPO_ASIGNADO_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_TIPO_REPORTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_COD_REPORTE;
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
                //        _PV_COD_REPORTE = (Int64)dr["PAT_ID_AREA_TRABAJO"];
                //        _PV_OBJETIVO_CARGO = (string)dr["CAR_OBJETIVO"];
                //        _PV_COD_CLIENTE = (Int64)dr["CAR_EXPERIENCIA_GENERAL"];
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_CAMPOS_CLIENTES.PR_I_CAMPOS_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_REPORTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_REPORTE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
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
                OracleCommand cmd = new OracleCommand("PAQ_CLI_CAMPOS_CLIENTES.PR_D_CAMPOS_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_REPORTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_REPORTE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
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