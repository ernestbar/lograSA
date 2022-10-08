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
    public partial class menu_rol_admin : System.Web.UI.Page
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
                    // lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();


                }
               // lblUsuario.Text = "admin";
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                Clases.Menus_roles obj_mr = new Clases.Menus_roles( datos[0], ddlRol.SelectedValue, datos[1], lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM_D().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                odsMenusAsignado.DataBind();
                odsMenusNoAsignado.DataBind();
                Repeater1.DataBind();
                Repeater2.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();

                Clases.Menus_roles obj_mr = new Clases.Menus_roles( "", ddlRol.SelectedValue, id, lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM_I().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
                //odsMenusAsignado.DataBind();
                //odsMenusNoAsignado.DataBind();
                Repeater1.DataBind();
                Repeater2.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }

        }
        protected void ddlRol_DataBound(object sender, EventArgs e)
        {
            ddlRol.Items.Insert(0, "SELECCIONAR");
        }

      
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bQuitar = (Button)e.Item.FindControl("btnQuitar");
                bQuitar.Visible = false;
                DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "QUITAR")
                            bQuitar.Visible = true;
                    }

                }
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bAgregar = (Button)e.Item.FindControl("btnAgregar");
                bAgregar.Visible = false;
                DataTable dt = Clases.Utilitarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, lblCodMenuRol.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "AGREGAR")
                            bAgregar.Visible = true;
                    }

                }
            }
        }

        protected void ddlSistema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSistema_DataBound(object sender, EventArgs e)
        {
            ddlSistema.Items.Insert(0, "SELECCIOANR");
        }
    }
}