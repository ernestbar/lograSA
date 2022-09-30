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
    public partial class opciones_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (Session["usuario"] == null)
                //{
                //    Response.Redirect("login.aspx");
                //}
                //else
                //{

                //    lblUsuario.Text = Session["usuario"].ToString();
                //    btnNuevo.Visible = false;
                //    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                //    DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //    if (dt.Rows.Count > 0)
                //    {
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //            if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                //                btnNuevo.Visible = true;
                //        }

                //    }
                //    MultiView1.ActiveViewIndex = 0;
                //}
                lblUsuario.Text = "admin";
                MultiView1.ActiveViewIndex = 0;
            }
        }

        

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repeater1.DataBind();
        }

       
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_menu_padre = "";
                cod_menu_padre = ddlMenuPadre.SelectedValue;
                if (lblCodOpcion.Text == "")
                {
                    Clases.Opciones obj = new Clases.Opciones("I", "", cod_menu_padre, txtDescripcion.Text, txtDetalle.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Opciones obj = new Clases.Opciones("U", lblCodOpcion.Text, cod_menu_padre, txtDescripcion.Text, txtDetalle.Text, lblUsuario.Text);
                    lblAviso.Text = obj.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_opciones_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
            lblCodOpcion.Text = "";
           
            txtMenu.Text = ddlMenuPadre.SelectedItem.Text;
            MultiView1.ActiveViewIndex = 1;

        }
        public void limpiar()
        {
            txtDescripcion.Text = "";
            txtDetalle.Text = "";
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodOpcion.Text = id;
                Clases.Opciones obj_m = new Clases.Opciones(id);
                limpiar();
                txtDescripcion.Text = obj_m.PV_DESCRIPCIONMEN;
                txtDetalle.Text = obj_m.PV_DETALLE;
               
                txtMenu.Text = ddlMenuPadre.SelectedItem.Text;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_opciones_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodOpcion.Text = datos[0];
                if (datos[1] == "ACTIVO")
                {
                    Clases.Opciones obj_m = new Clases.Opciones("D", lblCodOpcion.Text, "", "", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                }
                else
                {
                    Clases.Opciones obj_m = new Clases.Opciones("A", lblCodOpcion.Text, "", "", "", lblUsuario.Text);
                    lblAviso.Text = obj_m.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                }
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_opciones_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void ddlMenuPadre_DataBound(object sender, EventArgs e)
        {
            ddlMenuPadre.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlMenuPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bEdit = (Button)e.Item.FindControl("btnEditar");
                //Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                //bEdit.Visible = false;
                //bEliminar.Visible = false;
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                //            bEdit.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                //            bEliminar.Visible = true;
                //    }

                //}


            }
        }
    }
}