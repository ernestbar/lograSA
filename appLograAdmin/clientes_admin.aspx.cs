using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class clientes_admin : System.Web.UI.Page
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;
        }
        public void limpiar_controles()
        {
            txtCodSICI.Text = "";
            lblCodServidor.Text = "";
            lblLogoAnt.Text = "";
            lblCodCliente.Text = "";
            txtCodCliSis.Text = "";
            txtMaterno.Text = "";
            txtNombre.Text = "";
            txtNumDoc.Text = "";
            txtPaterno.Text = "";
            txtRazonSocial.Text = "";
            ddlPais.DataBind();
            ddlTipoCliente.DataBind();
            ddlTipoDocumento.DataBind();
            lblAviso.Text = "";

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodCliente.Text = id;
                Clases.Clientes cli = new Clases.Clientes(lblCodCliente.Text);
                txtCodCliSis.Text = cli.PV_COD_CLIENTE_SICI;
                txtMaterno.Text = cli.PV_APELLIDO_MATERNO;
                txtNombre.Text = cli.PV_NOMBRE;
                txtNumDoc.Text = cli.PV_NUMERO_DOCUMENTO;
                txtPaterno.Text = cli.PV_APELLIDO_PATERNO;
                txtRazonSocial.Text = cli.PV_RAZON_SOCIAL;
                ddlPais.SelectedValue= cli.PV_PAIS;
                ddlTipoCliente.SelectedValue= cli.PV_TIPO_CLIENTE;
                ddlTipoDocumento.SelectedValue= cli.PV_TIPO_DOCUMENTO;
                if (cli.PV_LOGO == "")
                { imgLogo.ImageUrl = "~/ClienteLogos/sin_logo.png"; lblLogoAnt.Text = ""; }
                else
                { 
                    imgLogo.ImageUrl = "~/ClienteLogos/"+cli.PV_COD_CLIENTE+"/"+cli.PV_LOGO; 
                    lblLogoAnt.Text = cli.PV_LOGO; 
                }
                if (cli.PV_TIPO_CLIENTE == "PN")
                { Panel_natural.Visible = true; Panel_juridica.Visible = false; }
                else
                { Panel_natural.Visible = false; Panel_juridica.Visible = true; }

                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                lblCodCliente.Text = datos[0];
                string estado = "";
                estado = datos[1];
                if (estado == "I")
                {
                    Clases.Clientes cli = new Clases.Clientes(lblCodCliente.Text, "", "", "", "", "", "", "", "", "", "", lblUsuario.Text);
                    lblAviso.Text = cli.ABM_A().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {
                    Clases.Clientes cli = new Clases.Clientes(lblCodCliente.Text, "", "", "", "", "", "", "", "", "", "", lblUsuario.Text);
                    lblAviso.Text = cli.ABM_D().Replace("|", "").Replace("0", "").Replace("null", "");
                }
               
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                bEdit.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                            bEliminar.Visible = true;
                    }

                }


            }
        }

        protected void ddlTipoCliente_DataBound(object sender, EventArgs e)
        {
            ddlTipoCliente.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCodCliente.Text == "")
                {
                    
                    Clases.Clientes cli = new Clases.Clientes("",txtCodCliSis.Text,ddlTipoCliente.SelectedValue,txtRazonSocial.Text,
                        txtNombre.Text,txtPaterno.Text,txtMaterno.Text,ddlTipoDocumento.SelectedValue,txtNumDoc.Text,ddlPais.SelectedValue,
                        "", lblUsuario.Text);
                    string res = cli.ABM_I();
                    string[] aux = res.Split('|');
                    lblAviso.Text = res.Replace("|", "").Replace("0", "").Replace("null", "");
                    if (aux[3] != "")
                    {
                        if (fuLogo.HasFile)
                        {
                            string Ruta = Server.MapPath("~/ClienteLogos/" + aux[3] + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);
                            }
                            string archivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuLogo.FileName;
                            fuLogo.PostedFile.SaveAs(Ruta + archivo);
                            Clases.Clientes cli2 = new Clases.Clientes(aux[3], txtCodCliSis.Text, ddlTipoCliente.SelectedValue, txtRazonSocial.Text,
                              txtNombre.Text, txtPaterno.Text, txtMaterno.Text, ddlTipoDocumento.SelectedValue, txtNumDoc.Text, ddlPais.SelectedValue,
                              archivo, lblUsuario.Text);
                            cli2.ABM_U();
                        }
                    }
                    
                }
                else
                {
                    if (fuLogo.HasFile)
                    {
                        string Ruta = Server.MapPath("~/ClienteLogos/" + lblCodCliente.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        string archivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuLogo.FileName;
                        lblLogoAnt.Text = archivo;
                        fuLogo.PostedFile.SaveAs(Ruta + archivo);
                    }
                    else
                    { 
                        
                    }
                    Clases.Clientes cli = new Clases.Clientes(lblCodCliente.Text, txtCodCliSis.Text, ddlTipoCliente.SelectedValue, txtRazonSocial.Text,
                        txtNombre.Text, txtPaterno.Text, txtMaterno.Text, ddlTipoDocumento.SelectedValue, txtNumDoc.Text, ddlPais.SelectedValue,
                        lblLogoAnt.Text, lblUsuario.Text);
                    lblAviso.Text = cli.ABM_U().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlPais_DataBound(object sender, EventArgs e)
        {
            ddlPais.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCliente.SelectedItem.Text == "PERSONA JURIDICA")
            { Panel_juridica.Visible = true;Panel_natural.Visible = false; }
            else
            { Panel_juridica.Visible = false; Panel_natural.Visible = true; }
        }

        protected void btnSICI_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodCliente.Text = id;
                Repeater2.DataSource = Clases.Clientes_servidores.PR_GET_CLIENTE_SERVIDOR(id);
                Repeater2.DataBind();
                MultiView1.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEditarSICI_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                Button obj = (Button)sender;
                string[]  id = obj.CommandArgument.ToString().Split('|');

                lblCodServidor.Text = id[0];
                lblCodCliente.Text = id[1];
                DataTable dt= Clases.Clientes_servidores.PR_GET_CLIENTE_SERVIDOR_IND(lblCodCliente.Text,lblCodServidor.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    txtCodSICI.Text = dr["COD_CLIENTE_SICI"].ToString();
                }
                MultiView1.ActiveViewIndex = 3;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnGuardarSICI_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";

                Clases.Clientes_servidores obj = new Clases.Clientes_servidores(txtCodSICI.Text, lblCodCliente.Text, lblCodServidor.Text,lblUsuario.Text);
                lblAviso.Text = obj.ABM_U().Replace("|", "").Replace("0", "").Replace("null", "");
                Repeater2.DataSource = Clases.Clientes_servidores.PR_GET_CLIENTE_SERVIDOR(lblCodCliente.Text);
                Repeater2.DataBind();
                MultiView1.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverSICI_Click(object sender, EventArgs e)
        {
            lblCodServidor.Text = "";
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnVolverSICI1_Click(object sender, EventArgs e)
        {
            //limpiar_controles();
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnSICIExtra_Click(object sender, EventArgs e)
        {
         

            try
            {
                lblAviso.Text = "";
                //limpiar_controles();
                Button obj = (Button)sender;
                string[] id = obj.CommandArgument.ToString().Split('|');

                lblCodServidorExtra.Text = id[0];
                lblCodClienteExtra.Text = id[1];
                Repeater3.DataSource = Clases.Cliente_servidor_extra.PR_GET_CLIENTE_SERVIDOR_EXTRA(lblCodClienteExtra.Text, lblCodServidorExtra.Text);
                Repeater3.DataBind();
                MultiView1.ActiveViewIndex = 4;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnNuevoCodExtra_Click(object sender, EventArgs e)
        {
            txtCodExtra.Text = "";
            txtCodExtra.Enabled = true;
            txtDetalleExtra.Text = "";
            lblCodClienteSICIextra.Text = "";
            MultiView1.ActiveViewIndex = 5;
        }

        protected void btnEditarSICIextra_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
               // limpiar_controles();
                Button obj = (Button)sender;
                string[] id = obj.CommandArgument.ToString().Split('|');

                lblCodServidorExtra.Text = id[0];
                lblCodClienteExtra.Text = id[1];
                lblCodClienteSICIextra.Text = id[2];

                DataTable dt = Clases.Cliente_servidor_extra.PR_GET_CLIENTE_SERVIDOR_E_IND(lblCodClienteExtra.Text, lblCodServidorExtra.Text, lblCodClienteSICIextra.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    txtDetalleExtra.Text = dr["DETALLE"].ToString();
                    txtCodExtra.Text = dr["COD_CLIENTE_SICI"].ToString();
                }
                txtCodExtra.Enabled = false;
                MultiView1.ActiveViewIndex = 5;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEliminarSICIExtra_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                //limpiar_controles();
                Button obj = (Button)sender;
                string[] id = obj.CommandArgument.ToString().Split('|');

                lblCodServidorExtra.Text = id[0];
                lblCodClienteExtra.Text = id[1];
                lblCodClienteSICIextra.Text = id[2];
                if (id[3] == "")
                {
                    Clases.Cliente_servidor_extra objE = new Clases.Cliente_servidor_extra(lblCodClienteSICIextra.Text, "", lblCodClienteExtra.Text, lblCodServidorExtra.Text, lblUsuario.Text);
                    lblAviso.Text = objE.ABM_D().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {
                    Clases.Cliente_servidor_extra objE = new Clases.Cliente_servidor_extra(lblCodClienteSICIextra.Text, "", lblCodClienteExtra.Text, lblCodServidorExtra.Text, lblUsuario.Text);
                    lblAviso.Text = objE.ABM_A().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                
                Repeater3.DataSource = Clases.Cliente_servidor_extra.PR_GET_CLIENTE_SERVIDOR_EXTRA(lblCodClienteExtra.Text, lblCodServidorExtra.Text);
                Repeater3.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnGuardarSICIextra_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                if (lblCodClienteSICIextra.Text == "")
                {
                    Clases.Cliente_servidor_extra obj = new Clases.Cliente_servidor_extra(txtCodExtra.Text, txtDetalleExtra.Text, lblCodClienteExtra.Text, lblCodServidorExtra.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_I().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {
                    Clases.Cliente_servidor_extra obj = new Clases.Cliente_servidor_extra(lblCodClienteSICIextra.Text, txtDetalleExtra.Text, lblCodClienteExtra.Text, lblCodServidorExtra.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_U().Replace("|", "").Replace("0", "").Replace("null", "");
                }

                Repeater3.DataSource = Clases.Cliente_servidor_extra.PR_GET_CLIENTE_SERVIDOR_EXTRA(lblCodClienteExtra.Text, lblCodServidorExtra.Text);
                Repeater3.DataBind();
                MultiView1.ActiveViewIndex = 4;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverSICIextra_Click(object sender, EventArgs e)
        {
            txtDetalleExtra.Text = "";
            lblCodClienteSICIextra.Text = "";
            MultiView1.ActiveViewIndex = 4;
        }
    }
}