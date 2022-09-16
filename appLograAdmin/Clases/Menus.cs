using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appLograAdmin.Clases
{
    public class Menus
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PB_COD_MENU = "";
        private string _PB_COD_MENU_PADRE = "";
        private string _PV_DESCRIPCIONMEN = "";
        private string _PV_DETALLE = "";
        
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PB_COD_MENU { get { return _PB_COD_MENU; } set { _PB_COD_MENU = value; } }
        public string PB_COD_MENU_PADRE { get { return _PB_COD_MENU_PADRE; } set { _PB_COD_MENU_PADRE = value; } }
        public string PV_DESCRIPCIONMEN { get { return _PV_DESCRIPCIONMEN; } set { _PV_DESCRIPCIONMEN = value; } }
        public string PV_DETALLE { get { return _PV_DETALLE; } set { _PV_DETALLE = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Menus(string pB_COD_MENU)
        {
            _PB_COD_MENU = pB_COD_MENU;
            RecuperarDatos();
        }
        public Menus(string pV_TIPO_OPERACION, string pB_COD_MENU, string pB_COD_MENU_PADRE, 
         string pV_DESCRIPCIONMEN, string pV_DETALLE, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_COD_MENU = pB_COD_MENU;
            _PB_COD_MENU_PADRE = pB_COD_MENU_PADRE;
            _PV_DESCRIPCIONMEN = pV_DESCRIPCIONMEN;
            _PV_DETALLE = pV_DETALLE;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_MENUS()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS");
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




        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_IND");
                db1.AddInParameter(cmd, "PV_COD_MENU", DbType.String, _PB_COD_MENU);
                db1.ExecuteNonQuery(cmd);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["COD_MENU_PADRE"].ToString()))
                        { _PB_COD_MENU_PADRE = ""; }
                        else
                        { _PB_COD_MENU_PADRE = (string)dr["COD_MENU_PADRE"]; }
                        _PV_DESCRIPCIONMEN = (string)dr["DESCRIPCION"];
                        _PV_DETALLE = (string)dr["DETALLE"];
                    }

                }

            }
            catch { }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_ABM_MENUS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if (_PB_COD_MENU == "")
                    db1.AddInParameter(cmd, "PB_COD_MENU", DbType.Int64, null);
                else
                    db1.AddInParameter(cmd, "PB_COD_MENU", DbType.Int64, _PB_COD_MENU);
                if (_PB_COD_MENU_PADRE == "")
                    db1.AddInParameter(cmd, "PB_COD_MENU_PADRE", DbType.Int64, null);
                else
                    db1.AddInParameter(cmd, "PB_COD_MENU_PADRE", DbType.Int64, _PB_COD_MENU_PADRE);

                db1.AddInParameter(cmd, "PV_DESCRIPCIONMEN", DbType.String, _PV_DESCRIPCIONMEN);
                db1.AddInParameter(cmd, "PV_DETALLE", DbType.String, _PV_DETALLE);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_USER").ToString()))
                //    PV_USUARIO = "";
                //else
                //    PV_USUARIO = (string)db1.GetParameterValue(cmd, "PV_USER");
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCIONPR;
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