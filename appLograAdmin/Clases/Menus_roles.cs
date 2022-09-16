using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appLograAdmin.Clases
{
    public class Menus_roles
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PB_ROL_MENU = "";
        private string _PB_ID_ROL = "";
        private string _PB_COD_MENU = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PB_ROL_MENU { get { return _PB_ROL_MENU; } set { _PB_ROL_MENU = value; } }
        public string PB_ID_ROL { get { return _PB_ID_ROL; } set { _PB_ID_ROL = value; } }
        public string PB_COD_MENU { get { return _PB_COD_MENU; } set { _PB_COD_MENU = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }


        #endregion

        #region Constructores
        public Menus_roles(string pB_ROL_MENU)
        {
            _PB_ROL_MENU = pB_ROL_MENU;
            RecuperarDatos();
        }
        public Menus_roles(string pV_TIPO_OPERACION, string pB_ROL_MENU, string pB_ID_ROL, string pB_COD_MENU, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ROL_MENU = pB_ROL_MENU;
            _PB_ID_ROL = pB_ID_ROL;
            _PB_COD_MENU = pB_COD_MENU;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_SEG_GET_MENUS_A_ASIGNAR(string PB_ROL_ID_ROL)
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_A_ASIGNAR");
            if (PB_ROL_ID_ROL == "SELECCIONAR")
                db1.AddInParameter(cmd, "PB_ROL_ID_ROL", DbType.String, null);
            else
                db1.AddInParameter(cmd, "PB_ROL_ID_ROL", DbType.String, PB_ROL_ID_ROL);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_SEG_GET_MENUS_ASIGNADOS(string PB_ROL_ID_ROL)
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_ASIGNADOS");
            if (PB_ROL_ID_ROL == "SELECCIONAR")
                db1.AddInParameter(cmd, "PB_ROL_ID_ROL", DbType.String, null);
            else
                db1.AddInParameter(cmd, "PB_ROL_ID_ROL", DbType.String, PB_ROL_ID_ROL);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
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

        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_ABM_MENUS_ROLES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ROL_MENU", DbType.String, _PB_ROL_MENU);
                db1.AddInParameter(cmd, "PB_ID_ROL", DbType.String, _PB_ID_ROL);
                db1.AddInParameter(cmd, "PB_COD_MENU", DbType.String, _PB_COD_MENU);

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
                    PV_DESCRIPCION = "";
                else
                    PV_DESCRIPCION = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCION + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "1|Se produjo un error al registrar|1";
                return resultado;
            }
        }

        #endregion
    }
}