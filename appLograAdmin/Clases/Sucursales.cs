using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appLograAdmin.Clases
{
    public class Sucursales
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_CODIGO = "";
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
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_CODIGO { get { return _PV_CODIGO; } set { _PV_CODIGO = value; } }
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
        public Sucursales(string pV_CODIGO)
        {
            _PV_CODIGO = pV_CODIGO;
            RecuperarDatos();
        }
        public Sucursales(string pV_TIPO_OPERACION, string pV_CODIGO, string pV_NOMBRE_SUCURSAL,
            string pV_DIRECCION,string pB_ID_PAIS,string pB_ID_CIUDAD ,string pV_LATITUD, string pV_LONGITUD, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_PAIS = pB_ID_PAIS;
            _PB_ID_CIUDAD = pB_ID_CIUDAD;
            _PV_CODIGO = pV_CODIGO;
            _PV_NOMBRE_SUCURSAL = pV_NOMBRE_SUCURSAL;
            _PV_DIRECCION = pV_DIRECCION;
            _PV_LATITUD = pV_LATITUD;
            _PV_LONGITUD = pV_LONGITUD;
            _PV_USUARIO = pV_USUARIO;
        }

        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_PAR_GET_SUCURSALES()
        {

            DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_SUCURSALES");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_SUCURSALES_IND");
                db1.AddInParameter(cmd, "PV_COD_SUCURSAL", DbType.String, _PV_CODIGO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PB_ID_PAIS = (string)dr["PAIS"];
                        _PB_ID_CIUDAD = (string)dr["CIUDAD"];
                        _PV_NOMBRE_SUCURSAL = (string)dr["DESCRIPCION"];
                        _PV_DIRECCION = (string)dr["DIRECCION"];
                        _PV_LATITUD = (string)dr["LATITUD"];
                        _PV_LONGITUD = (string)dr["LONGITUD"];
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_SUCURSALES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if(_PV_CODIGO=="")
                    db1.AddInParameter(cmd, "PV_CODIGO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_CODIGO", DbType.String, _PV_CODIGO);
                db1.AddInParameter(cmd, "PV_NOMBRE_SUCURSAL", DbType.String, _PV_NOMBRE_SUCURSAL);
                db1.AddInParameter(cmd, "PV_DIRECCION", DbType.String, _PV_DIRECCION);
                db1.AddInParameter(cmd, "PB_ID_PAIS", DbType.String, _PB_ID_PAIS);
                db1.AddInParameter(cmd, "PB_ID_CIUDAD", DbType.String, _PB_ID_CIUDAD);
                
                db1.AddInParameter(cmd, "PV_LATITUD", DbType.String, _PV_LATITUD);
                db1.AddInParameter(cmd, "PV_LONGITUD", DbType.String, _PV_LONGITUD);
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

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR ;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar||";
                return resultado;
            }
        }

        #endregion
    }
}