using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class personal_admin : System.Web.UI.Page
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

                    lblUsuario.Text = Session["usuario"].ToString();
                    btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                                btnNuevo.Visible = true;
                        }

                    }
                    MultiView1.ActiveViewIndex = 0;
                }
                //lblUsuario.Text = "admin";
                //MultiView1.ActiveViewIndex = 0;

            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bUsuarios = (Button)e.Item.FindControl("btnUsuarios");
                bEdit.Visible = false;
                bUsuarios.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "USUARIOS")
                            bUsuarios.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                            bEliminar.Visible = true;
                    }

                }


            }
        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodPersonal.Text = "";
            txtEmail.Text = "";
            txtNombres.Text = "";
            txtNumeroDocumento.Text = "";
            txtUsuario.Text = "";
            lblFechaDesde.Text = "";
            lblFechaHasta.Text = "";
            ddlExpedido.DataBind();
            ddlTipoDocumento.DataBind();
            ddlCargo.DataBind();
            ddlSupervisor.DataBind();
            ddlSucursal.DataBind();

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 1;
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodPersonal.Text = id;
                Clases.Personal cli = new Clases.Personal("", lblCodPersonal.Text);
                txtCelular.Text = cli.PN_CELULAR.ToString();
                txtEmail.Text = cli.PV_EMAIL;
                txtNombres.Text = cli.PV_NOMBRE_COMPLETO;
                txtNumeroDocumento.Text = cli.PV_NUMERO_DOCUMENTO;
                txtFijo.Text = cli.PN_FIJO.ToString();
                txtInterno.Text = cli.PN_INTERNO.ToString();
                ddlExpedido.SelectedValue = cli.PV_EXPEDIDO.ToString();
                ddlCargo.SelectedValue = cli.PV_COD_CARGO;
                ddlSucursal.SelectedValue = cli.PV_COD_SUCURSAL;
                ddlTipoDocumento.SelectedValue = cli.PV_TIPO_DOCUMENTO;

                DataTable dt = new DataTable();
                dt = Clases.Personal.PR_PAR_GET_USUARIOS(lblCodPersonal.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lblCodUsuarioI.Text = dr["usuario"].ToString();
                        txtUsuario.Text = dr["usuario"].ToString();
                        txtDescripcion.Text = dr["descripcion"].ToString();
                        lblFechaDesde.Text = dr["fecha_desde"].ToString();
                        lblFechaHasta.Text = dr["fecha_hasta"].ToString();
                        ddlRol.SelectedValue = dr["rol"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();

                string[] dat = id.Split('|');
                if (dat[1] == "ACTIVO")
                {
                    Clases.Personal cli = new Clases.Personal("", dat[0], "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                    string resultado = cli.ABM_D();
                }
                else
                {
                    Clases.Personal cli = new Clases.Personal("", dat[0], "", "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                    string resultado = cli.ABM_A();
                }

                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }


        }

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ddlExpedido.Items.Insert(0, "SELECCIONAR");
        }



        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, "SELECCIONAR");
        }
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //string s;
                //string fecha = "";
                //s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                string fecha_retorno = "01/01/3000";
                if (hfFechaRetorno.Value != "")
                    fecha_retorno = hfFechaRetorno.Value;
                string fecha_salida = "01/01/3000";
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaRetorno.Value;

                string[] datos_cargo = ddlCargo.SelectedValue.Split('&');
                string aux = "";
                if (lblCodPersonal.Text == "")
                {
                    Clases.Personal per = new Clases.Personal(ddlClientes.SelectedValue, "", ddlSupervisor.SelectedValue, ddlSucursal.SelectedValue, txtNombres.Text,
                        ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, ddlExpedido.SelectedValue,
                        ddlCargo.SelectedValue, int.Parse(txtCelular.Text), Int64.Parse(txtFijo.Text), Int64.Parse(txtInterno.Text),
                        txtEmail.Text, txtUsuario.Text, "", "", txtDescripcion.Text, DateTime.Parse(fecha_salida), DateTime.Parse(fecha_retorno), ddlRol.SelectedValue, lblUsuario.Text);
                    aux = per.ABM_I();
                }
                else
                {
                    string fecha_desde = "";
                    string fecha_hasta = "";
                    if (hfFechaSalida.Value == "")
                    { fecha_desde = lblFechaDesde.Text; }
                    else
                    { fecha_desde = hfFechaSalida.Value; }
                    if (hfFechaRetorno.Value == "")
                    { fecha_hasta = lblFechaHasta.Text; }
                    else
                    { fecha_hasta = hfFechaRetorno.Value; }
                    Clases.Personal per = new Clases.Personal(ddlClientes.SelectedValue, lblCodPersonal.Text, ddlSupervisor.SelectedValue, ddlSucursal.SelectedValue, txtNombres.Text,
                         ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, ddlExpedido.SelectedValue,
                         ddlCargo.SelectedValue, int.Parse(txtCelular.Text), Int64.Parse(txtFijo.Text), Int64.Parse(txtInterno.Text),
                         txtEmail.Text, txtUsuario.Text, "", "", txtDescripcion.Text, DateTime.Parse(fecha_desde), DateTime.Parse(fecha_retorno), ddlRol.SelectedValue, lblUsuario.Text);
                    aux = per.ABM_U();
                }

                string[] datos = aux.Split('|');
                lblAviso.Text = aux.Replace("|", "").Replace("0", "").Replace("null", "");
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }





        protected void ddlCargo_DataBound(object sender, EventArgs e)
        {
            ddlCargo.Items.Insert(0, "SELECCIONAR");
        }




        protected void ddlSupervisor_DataBound(object sender, EventArgs e)
        {
            ddlSupervisor.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlSucursal_DataBound(object sender, EventArgs e)
        {
            ddlSucursal.Items.Insert(0, "SELECCIONAR");
        }
        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            ddlClientes.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repeater1.DataBind();
        }
        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodPersonal.Text = id;
                MultiView1.ActiveViewIndex = 2;
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Clases.Personal per = new Clases.Personal("", "", "", "", "", "", "", "", "", 0, 0, 0,
                        "", id, "", "", "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                lblAviso.Text = per.ABM_R().Replace("|", "").Replace("0", "").Replace("null", "");
                //if (datos[2] == "PASSWORD CORRECTAMENTE RESETEADO")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password se reseteo correctamente a 123');", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su password NO se reseteo correctamente a 123');", true);
                //}

                //PASSWORD CORRECTAMENTE REGISTRADO

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodUsuarioI.Text = id;
                MultiView1.ActiveViewIndex = 3;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }


        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.Personal per = new Clases.Personal("", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", lblCodUsuarioI.Text, txtPassword.Text, txtPasswordAnterior.Text, "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                lblAviso.Text = per.ABM_C().Replace("|", "").Replace("0", "").Replace("null", "");
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_personal_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPasswordAnterior.Text = "";
            lblCodUsuarioI.Text = "";
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bRestear = (Button)e.Item.FindControl("btnResetear");
                Button bCambiarPassword = (Button)e.Item.FindControl("btnCambiarPassword");
                bRestear.Visible = false;
                bCambiarPassword.Visible = false;
                DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "RESET")
                            bRestear.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "CHANGE")
                            bCambiarPassword.Visible = true;

                    }

                }


            }
        }

        protected void ddlRol_DataBound(object sender, EventArgs e)
        {
            ddlRol.Items.Insert(0, "SELECCIONAR");
        }
    }
}