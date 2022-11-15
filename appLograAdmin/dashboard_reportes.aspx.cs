using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class dashboard_reportes : System.Web.UI.Page
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
                    DateTime fecha1 = DateTime.Now;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();
                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);

                    if (Session["es_master"].ToString() != "S")
                    {
                        odsClientesTodos.FilterExpression = "COD_CLIENTE='" + Session["cod_cliente"] + "'";
                        ddlClientes.DataBind();
                    }
                    lblCodServidor.Text = Session["cod_servidor"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        

        protected void ddlClientes_DataBound(object sender, EventArgs e)
        {
            ddlClientes.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string fecha_ini = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            if (hfFechaSalida.Value != "")
                fecha_ini = hfFechaSalida.Value;
            if (rblTipoReporte.SelectedValue == "RESUMEN")
            {
                GridView1.DataSource = Clases.Reportes.PR_DASHBOARD_EXISTENCIAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = Clases.Reportes.PR_DASHBOARD_EXISTENCIAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
                GridView1.DataBind();

            }
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

        protected void GridView_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody>
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody>
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#0a3147");
                foreach (TableCell celda in e.Row.Cells)
                {
                    celda.Font.Size = 9;
                    celda.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
        }

        protected void ddlGestion_DataBound(object sender, EventArgs e)
        {
            ddlGestion.Items.Insert(0, "SELECCIONAR GESTION");
        }
    }
}