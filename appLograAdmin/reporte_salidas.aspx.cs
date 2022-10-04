using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class reporte_salidas : System.Web.UI.Page
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

                    if (Session["es_master"].ToString() != "S")
                    {
                        odsClientesTodos.FilterExpression = "COD_CLIENTE='" + Session["cod_cliente"] + "'";
                        ddlClientes.DataBind();
                    }

                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        protected void ddlServidor_DataBound(object sender, EventArgs e)
        {
            ddlServidor.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClientes_DataBound(object sender, EventArgs e)
        {
            ddlClientes.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Repeater1.DataSource = Clases.Reportes.PR_SALIDAS(DateTime.Parse(hfFechaSalida.Value), DateTime.Parse(hfFechaRetorno.Value), ddlClientes.SelectedValue, ddlServidor.SelectedValue);
            Repeater1.DataBind();
        }
    }
}