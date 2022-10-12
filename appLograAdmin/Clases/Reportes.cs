using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Reportes
    {
        #region Métodos que NO requieren constructor

        public static DataTable PR_INGRESOS(DateTime PV_FECHA_DESDE, DateTime PV_FECHA_HASTA, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_INGRESOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_HASTA;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
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
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_SALIDAS(DateTime PV_FECHA_DESDE, DateTime PV_FECHA_HASTA, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_SALIDAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_HASTA;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
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
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }


        public static DataTable PR_EXISTENCIAS(DateTime PV_FECHA_DESDE, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL.PR_EXISTENCIAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
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
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_EXISTENCIAS_RESUMEN(DateTime PV_FECHA_DESDE, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL.PR_EXISTENCIAS_RESUMEN", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
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
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        #endregion

    }
}