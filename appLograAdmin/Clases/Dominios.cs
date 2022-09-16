using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appLograAdmin.Clases
{
    public class Dominios
    { //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
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
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
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
        public Dominios(string pV_TIPO_OPERACION, string pV_DOMINIO, string pV_CODIGO,
         string pV_DESCRIPCION, string pV_VALOR_CARACTER, int pV_VALOR_NUMERICO,
         DateTime pV_VALOR_DATE, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
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

        public static DataTable Lista(string PV_DOMINIO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_DOMINIO");

                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, PV_DOMINIO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_PAR_GET_DOMINIOS(string PV_DOMINIO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_DOMINIOS");

                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, PV_DOMINIO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_PAR_GET_PROCESOS(string PV_PROCESO_ASOCIADO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_PROCESOS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, "PROCESO DETALLE");
                db1.AddInParameter(cmd, "PV_VALOR_CARACTER", DbType.String, PV_PROCESO_ASOCIADO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_PAR_GET_ONLY_DOMINIOS()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_ONLY_DOMINIOS");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static bool VerificarPlazo(decimal PD_PLAZO)
        {
            try
            {
                bool verifica = false;
                decimal valor1 = 1;
                decimal valor2 = 24;
                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_DOMINIOS");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, "PLAZO");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable veri = db1.ExecuteDataSet(cmd).Tables[0];
                foreach (DataRow dr in veri.Rows)
                {
                    valor1 = decimal.Parse(dr["valor_caracter"].ToString());
                    valor2 = (decimal)dr["valor_numerico"];
                }
                if (PD_PLAZO >= valor1 & PD_PLAZO <= valor2)
                {
                    verifica = true;
                }
                return verifica;
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return false;
            }
            //try
            //{
            //    string verifica = "";
            //    //Database db = DatabaseFactory.CreateDatabase();
            //    string SQL_FU = "select dbo.FU_getPlazo("+PD_PLAZO+") as campo1";
            //    //string SQL_FU = "select dbo.FU_getPlazo(0) as campo1";
            //    DbCommand cmd = db1.GetSqlStringCommand(SQL_FU);
            //    //db1.AddInParameter(cmd, "PD_PLAZO", DbType.Decimal, PD_PLAZO);
            //    //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            //    //verifica = db1.ExecuteNonQuery(cmd).ToString();
            //    DataTable veri = db1.ExecuteDataSet(cmd).Tables[0];

            //    return verifica;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //    //DataTable dt = new DataTable();
            //    return "";
            //}

        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_DOMINIOS_IND");
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, _PV_DOMINIO);
                db1.AddInParameter(cmd, "PV_CODIGO", DbType.String, _PV_CODIGO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["dominio"].ToString()))
                        { _PV_DOMINIO = ""; }
                        else
                        { _PV_DOMINIO = (string)dr["dominio"]; }


                        if (string.IsNullOrEmpty(dr["codigo"].ToString()))
                        { _PV_CODIGO = ""; }
                        else
                        { _PV_CODIGO = (string)dr["codigo"]; }

                        if (string.IsNullOrEmpty(dr["descripcion"].ToString()))
                        { _PV_DESCRIPCION = ""; }
                        else
                        { _PV_DESCRIPCION = (string)dr["descripcion"]; }

                        if (string.IsNullOrEmpty(dr["valor_caracter"].ToString()))
                        { _PV_VALOR_CARACTER = ""; }
                        else
                        { _PV_VALOR_CARACTER = (string)dr["valor_caracter"]; }

                        if (string.IsNullOrEmpty(dr["valor_numerico"].ToString()))
                        { _PV_VALOR_NUMERICO = 0; }
                        else
                        { _PV_VALOR_NUMERICO = (int)dr["valor_numerico"]; }

                        if (string.IsNullOrEmpty(dr["valor_date"].ToString()))
                        { _PV_VALOR_DATE = DateTime.Now; }
                        else
                        { _PV_VALOR_DATE = (DateTime)dr["valor_date"]; }



                    }

                }
            }
            catch (Exception ex)
            {

            }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_DOMINIOS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_DOMINIO", DbType.String, _PV_DOMINIO);
                db1.AddInParameter(cmd, "PV_CODIGO", DbType.String, _PV_CODIGO);
                db1.AddInParameter(cmd, "PV_DESCRIPCION", DbType.String, _PV_DESCRIPCION);
                db1.AddInParameter(cmd, "PV_VALOR_CARACTER", DbType.String, null);
                if (_PV_TIPO_OPERACION == "D")
                    db1.AddInParameter(cmd, "PV_VALOR_DATE", DbType.DateTime, DateTime.Now);
                else
                    db1.AddInParameter(cmd, "PV_VALOR_DATE", DbType.DateTime, null);
                db1.AddInParameter(cmd, "PV_VALOR_NUMERICO", DbType.Int32, null);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");


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