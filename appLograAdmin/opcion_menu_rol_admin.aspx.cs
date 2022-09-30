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
    public partial class opcion_menu_rol_admin : System.Web.UI.Page
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
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                }
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
                Clases.Opciones_Menu_Rol obj_mr = new Clases.Opciones_Menu_Rol("D", datos[0], ddlMenuRol.SelectedValue, ddlRol.SelectedValue, "", datos[1], lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM();
                Repeater1.DataBind();
                Repeater2.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_opciones_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

                Clases.Opciones_Menu_Rol obj_mr = new Clases.Opciones_Menu_Rol("I", "", ddlMenuRol.SelectedValue, ddlRol.SelectedValue, "", id, lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater1.DataBind();
                Repeater2.DataBind();

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_opciones_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

        protected void ddlMenuRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMenuRol_DataBound(object sender, EventArgs e)
        {
            ddlMenuRol.Items.Insert(0, "SELECCIONAR");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bQuitar = (Button)e.Item.FindControl("btnQuitar");
                //bQuitar.Visible = false;
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "QUITAR")
                //            bQuitar.Visible = true;
                //    }

                //}
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bAgregar = (Button)e.Item.FindControl("btnAgregar");
                //bAgregar.Visible = false;
                //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "AGREGAR")
                //            bAgregar.Visible = true;
                //    }

                //}
            }
        }
    }
}