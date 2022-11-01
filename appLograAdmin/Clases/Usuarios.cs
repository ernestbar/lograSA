using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace appLograAdmin.Clases
{
    public class Usuarios
    {
        //Base de datos
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
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
        private int _PN_FIJO = 0;
        private int _PN_INTERNO = 0;
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
        public int PN_FIJO { get { return _PN_FIJO; } set { _PN_FIJO = value; } }
        public int PN_INTERNO { get { return _PN_INTERNO; } set { _PN_INTERNO = value; } }
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

        //#region Constructores
        //public Usuarios(string pV_USUARIO,string pV_COD_PERSONAL)
        //{
        //    _PV_USUARIO = pV_USUARIO;
        //    _PV_COD_PERSONAL = pV_COD_PERSONAL;
        //    RecuperarDatos();
        //}
        //public Usuarios(string pV_COD_CLIENTE, string pV_COD_PERSONAL,string pV_SUPERVISOR_INMEDIATO,
        //    string pV_COD_SUCURSAL,string pV_NOMBRE_COMPLETO,string pV_TIPO_DOCUMENTO,string pV_NUMERO_DOCUMENTO,
        //    string pV_EXPEDIDO,string pV_COD_CARGO,int pN_CELULAR,int pN_FIJO,int pN_INTERNO,string pV_EMAIL,
        //    string pV_USUARIOI,string pV_PASSWORD,string pV_PASSWORD_ANTERIOR,string pV_DESCRIPCION,
        //    DateTime pD_FECHA_DESDE,DateTime pD_FECHA_HASTA,string pV_ROL,string pV_USUARIO)
        //{
        //    _PV_COD_CLIENTE = pV_COD_CLIENTE;
        //    _PV_COD_PERSONAL = pV_COD_PERSONAL;
        //    _PV_SUPERVISOR_INMEDIATO = pV_SUPERVISOR_INMEDIATO;
        //    _PV_COD_SUCURSAL = pV_COD_SUCURSAL;
        //    _PV_NOMBRE_COMPLETO = pV_NOMBRE_COMPLETO;
        //    _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
        //    _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
        //    _PV_EXPEDIDO = pV_EXPEDIDO;
        //    _PV_COD_CARGO = pV_COD_CARGO;
        //    _PN_CELULAR = pN_CELULAR;
        //    _PN_FIJO = pN_FIJO;
        //    _PN_INTERNO = pN_INTERNO;
        //    _PV_EMAIL = pV_EMAIL;
        //    _PV_USUARIOI = pV_USUARIOI;
        //    _PV_PASSWORD = pV_PASSWORD;
        //    _PV_PASSWORD_ANTERIOR = pV_PASSWORD_ANTERIOR;
        //    _PV_DESCRIPCION = pV_DESCRIPCION;
        //    _PD_FECHA_DESDE = pD_FECHA_DESDE;
        //    _PD_FECHA_HASTA = pD_FECHA_HASTA;
        //    _PV_ROL = pV_ROL;
        //    _PV_USUARIO = pV_USUARIO;

        //}
        //#endregion
        //#region Métodos que NO requieren constructor
        ////public static string PR_SEG_CAMBIOPASSWORD(string PV_COD_USUARIO, string PV_PASSWORDANTERIOR,string PV_PASSWORDNUEVO,string PV_USUARIO)
        ////{
        ////    try
        ////    {
        ////        if (Conexion.State.ToString().ToUpper() == "CLOSED")
        ////            Conexion.Open();

        ////        OracleCommand cmd = new OracleCommand("PAQ_DOMINIOS.PR_PAR_GET_DOMINIOS", Conexion);
        ////        cmd.CommandType = CommandType.StoredProcedure;
        ////        cmd.Parameters.Add("PV_DOMINIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_DOMINIO;
        ////        cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
        ////        cmd.ExecuteNonQuery();
        ////        DataSet ds = new DataSet();
        ////        OracleDataAdapter da = new OracleDataAdapter(cmd);
        ////        da.Fill(ds);
        ////        Conexion.Close();

        ////        return ds.Tables[0];
        ////        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
        ////            stradopr = "";
        ////        else
        ////            stradopr = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
        ////        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
        ////            descripcionpr = "";
        ////        else
        ////            descripcionpr = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
        ////        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
        ////            error = "";
        ////        else
        ////            error = (string)db1.GetParameterValue(cmd, "PV_ERROR");
        ////        string resultado = "";
        ////        resultado = stradopr + "|" + descripcionpr + "|" + error;
        ////        return resultado;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return ex.ToString()+"||";
        ////    }

        ////}

        //public static DataTable PR_PAR_GET_PERSONAL(string PV_COD_CLIENTE)
        //{
        //    try
        //    {
        //        if (Conexion.State.ToString().ToUpper() == "CLOSED")
        //            Conexion.Open();

        //        OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_PERSONAL", Conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
        //        cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
        //        cmd.ExecuteNonQuery();
        //        DataSet ds = new DataSet();
        //        OracleDataAdapter da = new OracleDataAdapter(cmd);
        //        da.Fill(ds);
        //        Conexion.Close();
        //        return ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        Conexion.Close();
        //        ex.ToString();
        //        DataTable dt = new DataTable();
        //        return dt;
        //    }
        //}

        //public static DataTable PR_PAR_GET_USUARIOS(string PV_COD_PERSONAL)
        //{
        //    try
        //    {
        //        if (Conexion.State.ToString().ToUpper() == "CLOSED")
        //            Conexion.Open();

        //        OracleCommand cmd = new OracleCommand("PAQ_CLI_PERSONAL.PR_PAR_GET_USUARIOS", Conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("PV_COD_PERSONAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_PERSONAL;
        //        cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
        //        cmd.ExecuteNonQuery();
        //        DataSet ds = new DataSet();
        //        OracleDataAdapter da = new OracleDataAdapter(cmd);
        //        da.Fill(ds);
        //        Conexion.Close();
        //        return ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        Conexion.Close();
        //        ex.ToString();
        //        DataTable dt = new DataTable();
        //        return dt;
        //    }
        //}

        //public static DataTable PR_SEG_GET_MENUS_PADRE_ROL(string PV_USUARIO)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_PADRE_ROL");
        //    db1.AddInParameter(cmd, "pv_usuario", DbType.String, PV_USUARIO);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable PR_SEG_GET_MENUS_ROL(string PV_USUARIO, Int64 COD_MENU_PADRE)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_ROL");
        //    db1.AddInParameter(cmd, "pv_usuario", DbType.String, PV_USUARIO);
        //    db1.AddInParameter(cmd, "pv_MEN_COD_MENU_PADRE", DbType.Int64, COD_MENU_PADRE);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable PR_SEG_GET_MENUS_RLES(Int64 PB_ROL_ID_ROL)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_MENUS_ROL");
        //    db1.AddInParameter(cmd, "PB_ROL_ID_ROL", DbType.Int64, PB_ROL_ID_ROL);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable PR_SEG_GET_OPCIONES_ROLES(string PV_USUARIO, Int64 COD_MENU)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_OPCIONES_ROLES");
        //    db1.AddInParameter(cmd, "pv_usuario", DbType.String, PV_USUARIO);
        //    db1.AddInParameter(cmd, "PD_MEN_COD_MENU", DbType.Int64, COD_MENU);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        ////public static DataTable Lista_plan_pago(string PV_COD_SIMULADOR)
        ////{
        ////    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_PLANPAGO");
        ////    db1.AddInParameter(cmd, "PV_COD_SIMULADOR", DbType.String, PV_COD_SIMULADOR);
        ////    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        ////    return db1.ExecuteDataSet(cmd).Tables[0];
        ////}
        ////public static DataTable Datos_cliente_simuldor(string PV_COD_CLIENTE)
        ////{
        ////    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
        ////    db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, PV_COD_CLIENTE);
        ////    db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, null);
        ////    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        ////    return db1.ExecuteDataSet(cmd).Tables[0];
        ////}

        ////public static DataTable Datos_cliente_simuldor_x_DOC(string pV_NUMERO_DOCUMENTO)
        ////{
        ////    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
        ////    db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
        ////    db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, pV_NUMERO_DOCUMENTO);
        ////    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        ////    return db1.ExecuteDataSet(cmd).Tables[0];
        ////}

        ////public static List<Cliente> ListaTodos(int USUARIO)
        ////{
        ////    List<Cliente> listaObj = new List<Cliente>();
        ////    DataTable dtDatos = Lista(USUARIO);
        ////    foreach (DataRow dr in dtDatos.Rows)
        ////    {
        ////        Cliente obj = new Cliente();
        ////        obj.id_cliente = (int)dr["id_cliente"];
        ////        obj.razon_social = (string)dr["razon_social"];
        ////        obj.nit = (string)dr["nit"];
        ////        obj.paterno = (string)dr["paterno"];
        ////        obj.materno = (string)dr["materno"];
        ////        obj.nombre = (string)dr["nombre"];
        ////        obj.activo = (Boolean)dr["activo"];
        ////        obj.id_tipocliente = (int)dr["id_tipocliente"];
        ////        obj.id_tiponegocio = (int)dr["id_tiponegocio"];
        ////        obj.fecha_ini = (DateTime)dr["fecha_ini"];
        ////        obj.abierto = (Boolean)dr["abierto"];
        ////        obj.agenda = (Boolean)dr["agenda"];
        ////        listaObj.Add(obj);
        ////    }
        ////    return listaObj;
        ////}
        //public static string Ingreso_usuario(string Pv_usuario, string Pv_password)
        //{
        //    try
        //    {
        //        string resultado = "";
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_INGRESO_APP");
        //        db1.AddInParameter(cmd, "pv_usuario", DbType.String, Pv_usuario);
        //        db1.AddInParameter(cmd, "pv_password", DbType.String, Pv_password);
        //        db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 255);
        //        db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 255);
        //        db1.AddOutParameter(cmd, "PV_TEMPORAL", DbType.String, 255);
        //        db1.ExecuteNonQuery(cmd);

        //        resultado = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR") + "|" + (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR") + "|" + (string)db1.GetParameterValue(cmd, "PV_TEMPORAL");
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }

        //}


        //#endregion

        //#region Métodos que requieren constructor
        //private void RecuperarDatos()
        //{
        //    try
        //    {
        //        if (_PV_USUARIO != "")
        //        {
        //            DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_USUARIOS_IND");
        //            db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
        //            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //            DataTable dt = db1.ExecuteDataSet(cmd).Tables[0];

        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    _PV_DESCRIPCION = (string)dr["DESCRIPCION"];
        //                    _PD_FECHA_DESDE = DateTime.Parse(dr["FECHA_DESDE"].ToString());
        //                    _PD_FECHA_HASTA = DateTime.Parse(dr["FECHA_HASTA"].ToString());
        //                    _PV_ROL = (string)dr["rol"];
        //                }
        //            }
        //        }
        //        if (_PV_COD_PERSONAL != "")
        //        {
        //            DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_PERSONAL_IND");
        //            db1.AddInParameter(cmd, "PV_COD_PERSONAL", DbType.String, _PV_COD_PERSONAL);
        //            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //            DataTable dt = db1.ExecuteDataSet(cmd).Tables[0];

        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    _PV_COD_PERSONAL = (string)dr["COD_PERSONAL"];
        //                    _PV_NOMBRE_COMPLETO = (string)dr["NOMBRE_COMPLETO"];
        //                    _PV_TIPO_DOCUMENTO = (string)dr["TIPO_DOCUMENTO"];
        //                    _PV_NUMERO_DOCUMENTO = (string)dr["NUMERO_DOCUMENTO"];
        //                    _PV_EXPEDIDO = (string)dr["EXPEDIDO"];
        //                    _PV_COD_CARGO = (string)dr["COD_CARGO"];
        //                    _PV_COD_SUCURSAL = (string)dr["COD_SUCURSAL"];
        //                    _PN_CELULAR = int.Parse(dr["CELULAR"].ToString());
        //                    _PN_FIJO = int.Parse(dr["FIJO"].ToString());
        //                    _PN_INTERNO = int.Parse(dr["INTERNO"].ToString());
        //                    _PV_EMAIL = (string)dr["EMAIL"];
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex) { }
        //}



        //public string ABM()
        //{
        //    string resultado = "";
        //    try
        //    {
        //        // verificar_vacios();
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_ABM_USUARIOS");
        //        db1.AddInParameter(cmd, "PV_COD_CLIENTE", DbType.String, _PV_COD_CLIENTE);
        //        db1.AddInParameter(cmd, "PV_COD_PERSONAL", DbType.String, _PV_COD_PERSONAL);
        //        db1.AddInParameter(cmd, "PV_SUPERVISOR_INMEDIATO", DbType.String, _PV_SUPERVISOR_INMEDIATO);
        //        db1.AddInParameter(cmd, "PV_COD_SUCURSAL", DbType.String, _PV_COD_SUCURSAL);
        //        db1.AddInParameter(cmd, "PV_NOMBRE_COMPLETO", DbType.String, _PV_NOMBRE_COMPLETO);
        //        db1.AddInParameter(cmd, "PV_TIPO_DOCUMENTO", DbType.String, _PV_TIPO_DOCUMENTO);
        //        db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
        //        db1.AddInParameter(cmd, "PV_EXPEDIDO", DbType.String, _PV_EXPEDIDO);
        //        db1.AddInParameter(cmd, "PV_COD_CARGO", DbType.String, _PV_COD_CARGO);
        //        db1.AddInParameter(cmd, "PN_CELULAR", DbType.Int32, _PN_CELULAR);
        //        db1.AddInParameter(cmd, "PN_FIJO", DbType.Int32, _PN_FIJO);
        //        db1.AddInParameter(cmd, "PN_INTERNO", DbType.Int32, _PN_INTERNO);
        //        db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                
        //        db1.AddInParameter(cmd, "PV_USUARIOI", DbType.String, _PV_USUARIOI);
        //        db1.AddInParameter(cmd, "PV_PASSWORD", DbType.String, _PV_PASSWORD);
        //        db1.AddInParameter(cmd, "PV_PASSWORD_ANTERIOR", DbType.String, _PV_PASSWORD_ANTERIOR);
        //        db1.AddInParameter(cmd, "PV_DESCRIPCION", DbType.String, _PV_DESCRIPCION);
        //        db1.AddInParameter(cmd, "PD_FECHA_DESDE", DbType.DateTime, _PD_FECHA_DESDE);
        //        db1.AddInParameter(cmd, "PD_FECHA_HASTA", DbType.DateTime, _PD_FECHA_HASTA);
        //        db1.AddInParameter(cmd, "PV_ROL", DbType.String, _PV_ROL);
        //        db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);

        //        db1.AddOutParameter(cmd, "PV_EMAILOUT", DbType.String, 300);
        //        db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
        //        db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
        //        db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);

        //        db1.ExecuteNonQuery(cmd);
        //        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_EMAILOUT").ToString()))
        //            PV_EMAILOUT = "";
        //        else
        //            PV_EMAILOUT = (string)db1.GetParameterValue(cmd, "PV_EMAILOUT");
        //        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
        //            PV_ESTADOPR = "";
        //        else
        //            PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
        //        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
        //            PV_DESCRIPCIONPR = "";
        //        else
        //            PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
        //        if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
        //            PV_ERROR = "";
        //        else
        //            PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
        //        resultado = PV_EMAILOUT + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        //_error = ex.Message;
        //        resultado = "|||Se produjo un error al registrar";
        //        return resultado;
        //    }
        //}

        //#endregion


    }
}