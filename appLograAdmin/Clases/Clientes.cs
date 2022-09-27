using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;


namespace appLograAdmin.Clases
{
    public class Clientes
    {//Base de datos
        //private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        private static OracleConnection Conexion = new OracleConnection("User Id=seguridad;Password=segu123;Data Source=200.12.254.22:1521/XE");

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_CLIENTE = "";
        private string _PV_COD_CLIENTE_SICI = "";
        private string _PV_TIPO_CLIENTE = "";
        private string _PV_RAZON_SOCIAL = "";
        private string _PV_NOMBRE = "";
        private string _PV_APELLIDO_PATERNO = "";
        private string _PV_APELLIDO_MATERNO = "";
        private string _PV_TIPO_DOCUMENTO = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_PAIS = "";
        private string _PV_LOGO = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_CLIENTE { get { return _PV_COD_CLIENTE; } set { _PV_COD_CLIENTE = value; } }
        public string PV_COD_CLIENTE_SICI { get { return _PV_COD_CLIENTE_SICI; } set { _PV_COD_CLIENTE_SICI = value; } }
        public string PV_TIPO_CLIENTE { get { return _PV_TIPO_CLIENTE; } set { _PV_TIPO_CLIENTE = value; } }
        public string PV_RAZON_SOCIAL { get { return _PV_RAZON_SOCIAL; } set { _PV_RAZON_SOCIAL = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_APELLIDO_PATERNO { get { return _PV_APELLIDO_PATERNO; } set { _PV_APELLIDO_PATERNO = value; } }
        public string PV_APELLIDO_MATERNO { get { return _PV_APELLIDO_MATERNO; } set { _PV_APELLIDO_MATERNO = value; } }
        public string PV_TIPO_DOCUMENTO { get { return _PV_TIPO_DOCUMENTO; } set { _PV_TIPO_DOCUMENTO = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_PAIS { get { return _PV_PAIS; } set { _PV_PAIS = value; } }
        public string PV_LOGO { get { return _PV_LOGO; } set { _PV_LOGO = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Clientes(string pV_COD_CLIENTE)
        {
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            PR_GET_CLIENTE();
        }
        public Clientes(string pV_COD_CLIENTE, string pV_COD_CLIENTE_SICI,
         string pV_TIPO_CLIENTE, string pV_RAZON_SOCIAL, string pV_NOMBRE,
         string pV_APELLIDO_PATERNO,string pV_APELLIDO_MATERNO,string pV_TIPO_DOCUMENTO, 
         string pV_NUMERO_DOCUMENTO,string pV_PAIS,string pV_LOGO, string pV_USUARIO)
        {
            _PV_COD_CLIENTE = pV_COD_CLIENTE;
            _PV_COD_CLIENTE_SICI = pV_COD_CLIENTE_SICI;
            _PV_TIPO_CLIENTE = pV_TIPO_CLIENTE;
            _PV_RAZON_SOCIAL = pV_RAZON_SOCIAL;
            _PV_NOMBRE = pV_NOMBRE;
            _PV_APELLIDO_PATERNO = pV_APELLIDO_PATERNO;
            _PV_APELLIDO_MATERNO = pV_APELLIDO_MATERNO;
            _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_PAIS = pV_PAIS;
            _PV_LOGO = pV_LOGO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_GET_CLIENTE_ALL()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_GET_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
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
        private void PR_GET_CLIENTE()
        {
            try
            {
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_GET_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
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
                        _PV_COD_CLIENTE_SICI = (string)dr["COD_CLIENTE_SICI"];
                        _PV_TIPO_CLIENTE = (string)dr["TIPO_CLIENTE"];
                        if (String.IsNullOrEmpty(dr["RAZON_SOCIAL"].ToString()))
                            _PV_RAZON_SOCIAL = "";
                        else
                            _PV_RAZON_SOCIAL = (string)dr["RAZON_SOCIAL"];
                        if (String.IsNullOrEmpty(dr["NOMBRE"].ToString()))
                            _PV_NOMBRE = "";
                        else
                            _PV_NOMBRE = (string)dr["NOMBRE"];

                        if (String.IsNullOrEmpty(dr["APELLIDO_PATERNO"].ToString()))
                            _PV_APELLIDO_PATERNO = "";
                        else
                            _PV_APELLIDO_PATERNO = (string)dr["APELLIDO_PATERNO"];

                        if (String.IsNullOrEmpty(dr["APELLIDO_MATERNO"].ToString()))
                            _PV_APELLIDO_MATERNO = "";
                        else
                            _PV_APELLIDO_MATERNO = (string)dr["APELLIDO_MATERNO"];

                        _PV_TIPO_DOCUMENTO = (string)dr["TIPO_DOCUMENTO"];
                        _PV_NUMERO_DOCUMENTO = (string)dr["NUMERO_DOCUMENTO"];
                        _PV_PAIS = (string)dr["PAIS"];

                        if (string.IsNullOrEmpty(dr["LOGO"].ToString()))
                        { _PV_LOGO = ""; }
                        else
                        { _PV_LOGO = (string)dr["LOGO"]; }

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

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_I_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE_SICI", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE_SICI;
                cmd.Parameters.Add("PV_TIPO_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_CLIENTE;
                if (_PV_RAZON_SOCIAL == "")
                {
                    cmd.Parameters.Add("PV_RAZON_SOCIAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NOMBRE;
                    cmd.Parameters.Add("PV_APELLIDO_PATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_APELLIDO_PATERNO;
                    cmd.Parameters.Add("PV_APELLIDO_MATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_APELLIDO_PATERNO;
                }

                else
                {
                    cmd.Parameters.Add("PV_RAZON_SOCIAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_RAZON_SOCIAL;
                    cmd.Parameters.Add("PV_NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_APELLIDO_PATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_APELLIDO_MATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                    
                
                cmd.Parameters.Add("PV_TIPO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_DOCUMENTO;
                cmd.Parameters.Add("PV_NUMERO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NUMERO_DOCUMENTO;
                cmd.Parameters.Add("PV_PAIS", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_PAIS;
                cmd.Parameters.Add("PV_LOGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_LOGO;
                cmd.Parameters.Add("PV_USUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_USUARIO;
                cmd.Parameters.Add("PV_ESTADOPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_DESCRIPCIONPR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_ERROR", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
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

                if (String.IsNullOrEmpty(cmd.Parameters["PV_COD_CLIENTE"].Value.ToString()))
                    PV_COD_CLIENTE = "";
                else
                    PV_COD_CLIENTE = cmd.Parameters["PV_COD_CLIENTE"].Value.ToString();

                Conexion.Close();

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR + "|" + PV_COD_CLIENTE;
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

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_U_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_COD_CLIENTE_SICI", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE_SICI;
                cmd.Parameters.Add("PV_TIPO_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_CLIENTE;
                if (_PV_RAZON_SOCIAL == "")
                {
                    cmd.Parameters.Add("PV_RAZON_SOCIAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NOMBRE;
                    cmd.Parameters.Add("PV_APELLIDO_PATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_APELLIDO_PATERNO;
                    cmd.Parameters.Add("PV_APELLIDO_MATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_APELLIDO_PATERNO;
                }

                else
                {
                    cmd.Parameters.Add("PV_RAZON_SOCIAL", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_RAZON_SOCIAL;
                    cmd.Parameters.Add("PV_NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_APELLIDO_PATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                    cmd.Parameters.Add("PV_APELLIDO_MATERNO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
                }
                cmd.Parameters.Add("PV_TIPO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_TIPO_DOCUMENTO;
                cmd.Parameters.Add("PV_NUMERO_DOCUMENTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_NUMERO_DOCUMENTO;
                cmd.Parameters.Add("PV_PAIS", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_PAIS;
                cmd.Parameters.Add("PV_LOGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_LOGO;
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

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR ;
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

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_D_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
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

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR ;
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

                OracleCommand cmd = new OracleCommand("PAQ_CLI_CLIENTES.PR_A_CLIENTE", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = _PV_COD_CLIENTE;
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