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
    public partial class contenedores_admin : System.Web.UI.Page
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
        public void limpiar()
        {
            txtTamaño.Text = "";
            ddlClase.DataBind();
            ddlClaseLabel.DataBind();
            ddlEnvase.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            lblCodContenedor.Text = "";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodContenedor.Text = id;
                Clases.Contenedores obj_m = new Clases.Contenedores(id);
                txtTamaño.Text = obj_m.PV_TAMANO.ToString();
                ddlEnvase.SelectedValue = obj_m.PV_ENBASE;
                ddlClase.SelectedValue = obj_m.PV_CLASE;
                ddlClaseLabel.SelectedValue = obj_m.PV_CLASE_LABEL;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                string[] datos = id.Split('|');
                if (datos[1] == "ACTIVO")
                {
                    Clases.Contenedores obj_m = new Clases.Contenedores(datos[0], "",0,"", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM_D().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                }
                else
                {
                    Clases.Contenedores obj_m = new Clases.Contenedores(datos[0], "", 0, "", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM_A().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                }


                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void ddlEnvase_DataBound(object sender, EventArgs e)
        {
            ddlEnvase.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClase_DataBound(object sender, EventArgs e)
        {
            ddlClase.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClaseLabel_DataBound(object sender, EventArgs e)
        {
            ddlClaseLabel.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (lblCodContenedor.Text == "")
                {
                    Clases.Contenedores obj = new Clases.Contenedores("", ddlEnvase.SelectedValue, Int64.Parse(txtTamaño.Text), ddlClaseLabel.SelectedValue,ddlClaseLabel.SelectedValue, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_I().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Contenedores obj = new Clases.Contenedores(lblCodContenedor.Text, ddlEnvase.SelectedValue, Int64.Parse(txtTamaño.Text), ddlClaseLabel.SelectedValue, ddlClaseLabel.SelectedValue, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_U().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
        }
    }
}