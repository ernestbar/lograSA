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
    public partial class roles_admin : System.Web.UI.Page
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



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCodRol.Text == "")
                {
                    Clases.Roles obj = new Clases.Roles(txtCodRol.Text, txtDescripcion.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_I().Replace("|", "").Replace("0", "").Replace("null", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Roles obj = new Clases.Roles( lblCodRol.Text, txtDescripcion.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM_U().Replace("|", "").Replace("0", "").Replace("null", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            limpiar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            lblCodRol.Text = "";
            MultiView1.ActiveViewIndex = 1;

        }
        public void limpiar()
        {
            txtCodRol.Text = "";
            txtCodRol.Enabled = true;
            txtDescripcion.Text = "";
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodRol.Text = id;
                txtCodRol.Text = id;
                txtCodRol.Enabled = true;
                Clases.Roles obj_m = new Clases.Roles(id);
                txtDescripcion.Text = obj_m.PV_NOMBRE_ROL;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodRol.Text = datos[0];
                if (datos[1] == "ACTIVO")
                { 
                    Clases.Roles obj_m = new Clases.Roles(lblCodRol.Text, "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM_D().Replace("0","").Replace("|","").Replace("1", "");
                }
                else
                {
                    Clases.Roles obj_m = new Clases.Roles( lblCodRol.Text, "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM_A().Replace("0", "").Replace("|", "").Replace("1", "");
                }

                Repeater1.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
    }
}