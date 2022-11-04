using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class contenedores_driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlServidor.DataBind();
                
                MultiView1.ActiveViewIndex = 0;
                string[] datosServ = ddlServidor.SelectedValue.Split('|');
               
                Repeater1.DataSource = Clases.Contenedores.PR_PAR_GET_CONTENEDORES_CHOFER(datosServ[0]);
                Repeater1.DataBind();
                //if (Session["usuario"] == null)
                //{
                //    Response.Redirect("login.aspx");
                //}
                //else
                //{
                //    lblUsuario.Text = Session["usuario"].ToString();
                //    DateTime fecha1 = DateTime.Now;
                //    string dia = "";
                //    string mes = "";
                //    if (fecha1.Day.ToString().Length == 1)
                //        dia = "0" + fecha1.Day.ToString();
                //    else
                //        dia = fecha1.Day.ToString();
                //    if (fecha1.Month.ToString().Length == 1)
                //        mes = "0" + fecha1.Month.ToString();
                //    else
                //        mes = fecha1.Month.ToString();
                //    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                //    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);

                //    if (Session["es_master"].ToString() != "S")
                //    {
                //        odsClientesTodos.FilterExpression = "COD_CLIENTE='" + Session["cod_cliente"] + "'";
                //        ddlClientes.DataBind();
                //    }
                //    lblCodServidor.Text = Session["cod_servidor"].ToString();
                //    MultiView1.ActiveViewIndex = 0;
                //}
            }
        }

        protected void ddlServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] datosServ = ddlServidor.SelectedValue.Split('|');
            Repeater1.DataSource = Clases.Contenedores.PR_PAR_GET_CONTENEDORES_CHOFER(datosServ[0]);
            Repeater1.DataBind();
        }
    }
}