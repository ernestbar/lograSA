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
    public partial class campos_admin : System.Web.UI.Page
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
                //   // lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                //    lblUsuario.Text = Session["usuario"].ToString();
                //    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();

            
                //}
                lblUsuario.Text = "admin";
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
                //string[] datos = id.Split('|');
                Clases.Campos_clientes obj_mr = new Clases.Campos_clientes(id,ddlClientes.SelectedValue, lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM_D().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
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

                Clases.Campos_clientes obj_mr = new Clases.Campos_clientes(id, ddlClientes.SelectedValue, lblUsuario.Text);
                lblAviso.Text = obj_mr.ABM_I().Replace("0", "").Replace("|", "").Replace("1", "").Replace("null", "");
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

       

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsCamposAsignado.DataBind();odsCamposNoAsignado.DataBind();
            Repeater1.DataBind(); Repeater2.DataBind();
        }

        protected void ddlClientes_DataBound(object sender, EventArgs e)
        {
            ddlClientes.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlReporte_DataBound(object sender, EventArgs e)
        {
            ddlReporte.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsCamposAsignado.DataBind(); odsCamposNoAsignado.DataBind();
            Repeater1.DataBind(); Repeater2.DataBind();
        }
    }
}