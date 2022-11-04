using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;


namespace appLograAdmin.Clases
{
    public class Contenedores
    {
        //Base de datos
        //private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        private static OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_CONTENEDOR= "";
        private string _PV_ENBASE = "";
        private Int64 _PV_TAMANO = 0;
        private string _PV_CLASE = "";
        private string _PV_CLASE_LABEL = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_CONTENEDOR{ get { return _PV_CONTENEDOR; } set { _PV_CONTENEDOR= value; } }
        public string PV_ENBASE { get { return _PV_ENBASE; } set { _PV_ENBASE = value; } }
        public Int64 PV_TAMANO { get { return _PV_TAMANO; } set { _PV_TAMANO = value; } }
        public string PV_CLASE { get { return _PV_CLASE; } set { _PV_CLASE = value; } }
        public string PV_CLASE_LABEL { get { return _PV_CLASE_LABEL; } set { _PV_CLASE_LABEL = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Contenedores(string pV_CONTENEDOR)
        {
            _PV_CONTENEDOR = pV_CONTENEDOR;
            PR_PAR_GET_CONTENEDORES_IND();
        }
        public Contenedores(string pV_CONTENEDOR, string pV_ENBASE,
         Int64 pV_TAMANO, string pV_CLASE, string pV_CLASE_LABEL,
        string pV_USUARIO)
        {
            _PV_CONTENEDOR = pV_CONTENEDOR;
            _PV_ENBASE = pV_ENBASE;
            _PV_TAMANO = pV_TAMANO;
            _PV_CLASE = pV_CLASE;
            _PV_CLASE_LABEL = pV_CLASE_LABEL;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_PAR_GET_CONTENEDORES()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_GET_CONTENEDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public static DataTable PR_PAR_GET_CONTENEDORES_LOGRA(DateTime Pd_fecha, string pV_SERVIDOR,string pV_CODIGO_SICI, string pV_USUARIO)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_GET_CONTENEDORES_LOGRA", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pd_fecha", OracleDbType.Date, ParameterDirection.Input).Value = Pd_fecha;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_SERVIDOR;
                cmd.Parameters.Add("PV_CODIGO_SICI", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_CODIGO_SICI;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_USUARIO;
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
        public static DataTable PR_PAR_GET_CONTENEDORES_SICI(DateTime Pd_fecha, string pV_SERVIDOR, string pV_CODIGO_SICI, string pV_USUARIO)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_GET_CONTENEDORES_SICI", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pd_fecha", OracleDbType.Date, ParameterDirection.Input).Value = Pd_fecha;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_SERVIDOR;
                cmd.Parameters.Add("PV_CODIGO_SICI", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_CODIGO_SICI;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_USUARIO;
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
        public static DataTable PR_PAR_GET_CONTENEDORES_CHOFER(string pV_SERVIDOR)
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_GET_CONTENEDORES_CHOFER", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_SERVIDOR;
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
        public static string PR_PAR_SET_CONTENEDORES_LOGRA(string PV_contenedor_sici, Int32 PN_cantidad_generada,string pV_USUARIO)
        {
            try
            {
                string resultado = "";
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_SET_CONTENEDORES_LOGRA", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_contenedor_sici", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_contenedor_sici;
                cmd.Parameters.Add("PN_cantidad_generada", OracleDbType.Int32, ParameterDirection.Input).Value = PN_cantidad_generada;
                
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = pV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                string PV_ESTADOPR, PV_DESCRIPCIONPR, PV_ERROR;

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

                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + " ID: |" + PV_ERROR;
                return resultado;

            }
            catch (Exception ex)
            {
                Conexion.Close();


                return ex.ToString();
            }

        }
        #endregion

        #region Métodos que requieren constructor
        private void PR_PAR_GET_CONTENEDORES_IND()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_PAR_GET_CONTENEDORES_IND", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_CONTENEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CONTENEDOR;
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
                        _PV_ENBASE = (string)dr["ENBASE"];
                        _PV_TAMANO = Int32.Parse(dr["TAMANO"].ToString());
                        if (String.IsNullOrEmpty(dr["CLASE"].ToString()))
                            _PV_CLASE = "";
                        else
                            _PV_CLASE = (string)dr["CLASE"];
                        if (String.IsNullOrEmpty(dr["CLASE_LABEL"].ToString()))
                            _PV_CLASE_LABEL = "";
                        else
                            _PV_CLASE_LABEL = (string)dr["CLASE_LABEL"];
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

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_I_CONTENEDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_ENBASE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_ENBASE;
                cmd.Parameters.Add("PV_TAMANO", OracleDbType.Int64, ParameterDirection.Input).Value = _PV_TAMANO;
                cmd.Parameters.Add("PV_CLASE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CLASE;
                cmd.Parameters.Add("PV_CLASE_LABEL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CLASE_LABEL;
               
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();



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

                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + " ID: |" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar (" + ex.ToString() + ")";
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

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_U_CONTENEDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_CONTENEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CONTENEDOR;
                cmd.Parameters.Add("PV_ENBASE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_ENBASE;
                cmd.Parameters.Add("PV_TAMANO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TAMANO;
                cmd.Parameters.Add("PV_CLASE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CLASE;
                cmd.Parameters.Add("PV_CLASE_LABEL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CLASE_LABEL;
              
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();



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

                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar (" + ex.ToString() + ")";
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

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_D_CONTENEDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_CONTENEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CONTENEDOR;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();



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


                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar (" + ex.ToString() + ")";
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

                OracleCommand cmd = new OracleCommand("PAQ_ADM_CONTENEDORES_SIGAL.PR_A_CONTENEDORES", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_CONTENEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_CONTENEDOR;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

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

                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar (" + ex.ToString() + ")";
                return resultado;
            }
        }
        #endregion
    }
}