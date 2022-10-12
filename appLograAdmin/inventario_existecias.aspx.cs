using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace appLograAdmin
{
    public partial class inventario_existecias : System.Web.UI.Page
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
            if (rblTipoReporte.SelectedValue == "RESUMEN")
            {
                GridView1.DataSource = Clases.Reportes.PR_EXISTENCIAS_RESUMEN(DateTime.Parse(hfFechaSalida.Value), ddlClientes.SelectedValue, ddlServidor.SelectedValue);
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = Clases.Reportes.PR_EXISTENCIAS(DateTime.Parse(hfFechaSalida.Value), ddlClientes.SelectedValue, ddlServidor.SelectedValue);
                GridView1.DataBind();
            }
            
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

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            imgLogo.Src = Server.MapPath("~") + "/ClienteLogos/sin_logo.png";
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            imgLogo.Visible = true;
            pnlPrint.RenderControl(hw);
            imgLogo.Visible = false;
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}