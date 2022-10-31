using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class cambio_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblCodServidor.Text = Session["cod_servidor"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                    string temporal= Request.QueryString["temp"].ToString();
                    if (temporal == "1")
                        lblAviso.Text = "Su password es temporal, debe realizar el cambio gracias.";
                    else
                        lblAviso.Text = "";
                    //btnNuevo.Visible = false;
                    //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["OPC_DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}

                }

            }
        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.Personal per = new Clases.Personal("", "", "", "", "", "", "", "", "", 0, 0, 0,
                      "", lblUsuario.Text, txtPassword.Text,txtPasswordAnterior.Text, "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                lblAviso.Text = per.ABM_C().Replace("|", "").Replace("0", "").Replace("null", "");
                if (lblAviso.Text == "PASSWORD CORRECTAMENTE REGISTRADO")
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cambio_password_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}