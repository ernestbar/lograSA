using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
                    //DateTime fecha1 = DateTime.Now;
                    //string dia = "";
                    //string mes = "";
                    //if (fecha1.Day.ToString().Length == 1)
                    //    dia = "0" + fecha1.Day.ToString();
                    //else
                    //    dia = fecha1.Day.ToString();
                    //if (fecha1.Month.ToString().Length == 1)
                    //    mes = "0" + fecha1.Month.ToString();
                    //else
                    //    mes = fecha1.Month.ToString();
                    //hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);

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
            
            GridView1.DataSource = Clases.Reportes.PR_DASHBOARD_SALIDAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            GridView1.DataBind();
           
            //ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);

            pnlDashboard.Visible = true;
            String Cadena = "";
            String Cadena2 = "";
            // DataTable obj;

            // ********** Gráfico de Barras INGRESOS
            Cadena = Clases.Reportes.PR_DASHBOARD_INGRESOS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            hfgBarraSerie1.Value = Cadena;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras", "graficoBarras();", true);
            // ********** Gráfico de Barras SALIDAS
            Cadena2 = Clases.Reportes.PR_DASHBOARD_SALIDAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            hfgBarraSerie2.Value = Cadena2;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoBarras2", "graficoBarras2();", true);

            CodigoProyJSon();
            NombreProyJSon();

            // ********** Gráfico de Líneas
            // Serie 1: Avance Financiero
            //obj = new DataTable();
            //obj = Clases.Reportes.PR_DASHBOARD_EXISTENCIAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //Cadena = Clases.Reportes.PR_DASHBOARD_INGRESOS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //hfgLineaSerie1.Value = Cadena;
            // Serie 2: Avance Técnico
            //obj = new DataTable();
            //obj = Clases.Reportes.PR_DASHBOARD_EXISTENCIAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //Cadena = Clases.Reportes.PR_DASHBOARD_EXISTENCIAS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //hfgLineaSerie2.Value = Cadena;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "graficoLineas", "graficoLineas();", true);
            // Carga códigos y nombres de proyectos



        }
        public string CodigoProyJSon()
        {
            DataTable obj;
            obj = new DataTable();
            //obj = Clases.Reportes.PR_DASHBOARD_INGRESOS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //int[] codigoProyecto = new int[obj.Rows.Count];

            //for (int i = 0; i < obj.Rows.Count; i++)
            //{
            //    codigoProyecto[i] = Convert.ToInt32(obj.Rows[i][2]);
            //}
            return (new JavaScriptSerializer()).Serialize("");
        }

        public string NombreProyJSon()
        {
            DataTable obj;
            obj = new DataTable();
            //obj = Clases.Reportes.PR_DASHBOARD_INGRESOS(ddlGestion.SelectedValue, ddlClientes.SelectedValue, lblCodServidor.Text);
            //string[] nombreProyecto = new string[obj.Rows.Count];

            //for (int i = 0; i < obj.Rows.Count; i++)
            //{
            //    nombreProyecto[i] = obj.Rows[i][1].ToString();
            //}
            return (new JavaScriptSerializer()).Serialize("");
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