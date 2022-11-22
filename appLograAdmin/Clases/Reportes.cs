using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.ManagedDataAccess.Client;

using iText.Kernel.Pdf;
using iText.Layout;
using iTextLE = iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;

namespace appLograAdmin.Clases
{
    public class Reportes
    {
        #region Métodos que NO requieren constructor
        public static String PR_DASHBOARD_EXISTENCIAS(string PV_GESTION, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                string resultado = "[";
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_DASHBOARD_EXISTENCIAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_GESTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_GESTION;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                int x = 0;
                string Comillas = "\"";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (x == 0)
                    {
                        resultado = resultado + "{"+ Comillas+ "nombre"+ Comillas+":"+ Comillas + dr[1].ToString() + Comillas+","+ Comillas+"valor"+ Comillas+":" + dr[2].ToString() + "}";
                    }
                    else
                    {
                        resultado = resultado + ",{" + Comillas + "nombre" + Comillas + ":" + Comillas + dr[1].ToString() + Comillas + "," + Comillas + "valor" + Comillas + ":" + dr[2].ToString() + "}";
                    }
                    x++;
                }
                resultado = resultado + "]";
                return resultado;
            }
            catch (Exception ex)
            {
               return ex.ToString();
            }

        }

        public static void PR_DASHBOARD_EXISTENCIAS2(string PV_GESTION, string PV_COD_CLIENTE, string PV_SERVIDOR, out string strEtiqueta, out string strDatos, out string strColorFondo)
        {
            strEtiqueta = "";
            strDatos = "";
            strColorFondo = "";

            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_DASHBOARD_EXISTENCIAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_GESTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_GESTION;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                string[] etiquetas = new string[ds.Tables[0].Rows.Count];
                string[] datos = new string[ds.Tables[0].Rows.Count];
                string[] colorFondo = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    etiquetas[i] = ds.Tables[0].Rows[i][1].ToString();
                    datos[i] = ds.Tables[0].Rows[i][2].ToString();
                    colorFondo[i] = "rgba(61, 109, 200, 0.6)";
                }

                strEtiqueta = (new JavaScriptSerializer()).Serialize(etiquetas);
                strDatos = (new JavaScriptSerializer()).Serialize(datos);
                strColorFondo = (new JavaScriptSerializer()).Serialize(colorFondo);
            }
            catch (Exception ex)
            {

            }
        }

        public static string PR_DASHBOARD_INGRESOS(string PV_GESTION, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                string resultado = "[";
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_DASHBOARD_INGRESOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_GESTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_GESTION;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                int x = 0;
                string Comillas = "\"";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (x == 0)
                    {
                        resultado = resultado + "{" + Comillas + "nombre" + Comillas + ":" + Comillas + dr[1].ToString() + Comillas + "," + Comillas + "valor" + Comillas + ":" + dr[3].ToString() + "}";
                    }
                    else
                    {
                        resultado = resultado + ",{" + Comillas + "nombre" + Comillas + ":" + Comillas + dr[1].ToString() + Comillas + "," + Comillas + "valor" + Comillas + ":" + dr[3].ToString() + "}";
                    }
                    x++;
                }
                resultado = resultado + "]";
                return resultado;
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                return ex.ToString();
            }

        }
        public static void PR_DASHBOARD_INGRESOS2(string PV_GESTION, string PV_COD_CLIENTE, string PV_SERVIDOR,out string strEtiqueta, out string strDatos, out string strColorFondo)
        {
            strEtiqueta = "";
            strDatos = "";
            strColorFondo = "";
            try
            {
                string resultado = "[";
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_DASHBOARD_INGRESOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_GESTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_GESTION;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                string[] etiquetas = new string[ds.Tables[0].Rows.Count];
                string[] datos = new string[ds.Tables[0].Rows.Count];
                string[] colorFondo = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    etiquetas[i] = ds.Tables[0].Rows[i][1].ToString();
                    datos[i] = ds.Tables[0].Rows[i][2].ToString();
                    colorFondo[i] = "rgba(61, 109, 200, 0.6)";
                }

                strEtiqueta = (new JavaScriptSerializer()).Serialize(etiquetas);
                strDatos = (new JavaScriptSerializer()).Serialize(datos);
                strColorFondo = (new JavaScriptSerializer()).Serialize(colorFondo);
            }
            catch (Exception ex)
            {
                //Conexion.Close();
            }

        }
        public static string PR_DASHBOARD_SALIDAS(string PV_GESTION, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                string resultado = "[";
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_DASHBOARD_SALIDAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_GESTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_GESTION;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                int x = 0;
                string Comillas = "\"";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (x == 0)
                    {
                        resultado = resultado + "{" + Comillas + "nombre" + Comillas + ":" + Comillas + dr[1].ToString() + Comillas + "," + Comillas + "valor" + Comillas + ":" + dr[3].ToString() + "}";
                    }
                    else
                    {
                        resultado = resultado + ",{" + Comillas + "nombre" + Comillas + ":" + Comillas + dr[1].ToString() + Comillas + "," + Comillas + "valor" + Comillas + ":" + dr[3].ToString() + "}";
                    }
                    x++;
                }
                resultado = resultado + "]";
                return resultado;
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                return ex.ToString();
                
            }

        }
        public static DataTable PR_INGRESOS(DateTime PV_FECHA_DESDE, DateTime PV_FECHA_HASTA, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_INGRESOS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_HASTA;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_SALIDAS(DateTime PV_FECHA_DESDE, DateTime PV_FECHA_HASTA, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL_SEGAL.PR_SALIDAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA_DESDE", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_FECHA_HASTA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_HASTA;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }


        public static DataTable PR_EXISTENCIAS(DateTime PV_FECHA_DESDE, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL.PR_EXISTENCIAS", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_EXISTENCIAS_RESUMEN(DateTime PV_FECHA_DESDE, string PV_COD_CLIENTE, string PV_SERVIDOR)
        {
            try
            {
                OracleConnection Conexion = new OracleConnection("User Id=sigal;Password=siga123;Data Source=200.12.254.22:1521/XE");
                if (Conexion.State.ToString().ToUpper() == "CLOSED")
                    Conexion.Open();

                OracleCommand cmd = new OracleCommand("PAQ_REPORTES_SEGAL.PR_EXISTENCIAS_RESUMEN", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PV_FECHA", OracleDbType.Date, ParameterDirection.Input).Value = PV_FECHA_DESDE;
                cmd.Parameters.Add("PV_COD_CLIENTE", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_COD_CLIENTE;
                cmd.Parameters.Add("PV_SERVIDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = PV_SERVIDOR;
                cmd.Parameters.Add("PV_QUERY", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tabla", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                Conexion.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //Conexion.Close();
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static byte[] ExportarPDF(GridView gvDatos, string archivoLogo, string titulo)
        {
            iTextLE.Image img = new iTextLE.Image(ImageDataFactory.Create(archivoLogo)).SetTextAlignment(TextAlignment.LEFT);
            img.SetHeight(50);
            img.SetWidth(60);
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                using (var pdfDoc = new PdfDocument(writer))
                {
                    pdfDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                    Document doc = new Document(pdfDoc);
                    doc.SetFontSize(7);

                    // Cabecera en Tabla
                    iTextLE.Table tablaTitulo = new iTextLE.Table(3);
                    tablaTitulo.SetWidth(UnitValue.CreatePercentValue(100));

                    iTextLE.Cell celdaTitulo;
                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    celdaTitulo.Add(img);
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(20));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    tablaTitulo.AddCell(celdaTitulo);

                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    celdaTitulo.Add(new iTextLE.Paragraph(titulo));
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(60));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetTextAlignment(TextAlignment.CENTER);
                    celdaTitulo.SetFontSize(14);
                    celdaTitulo.SetBold();
                    tablaTitulo.AddCell(celdaTitulo);

                    celdaTitulo = new iTextLE.Cell();
                    celdaTitulo.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    celdaTitulo.Add(new iTextLE.Paragraph(""));
                    celdaTitulo.SetWidth(UnitValue.CreatePercentValue(20));
                    celdaTitulo.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    celdaTitulo.SetTextAlignment(TextAlignment.CENTER);
                    celdaTitulo.SetFontSize(14);
                    tablaTitulo.AddCell(celdaTitulo);

                    doc.Add(tablaTitulo);
                    //

                    // Cabecera Normal
                    //doc.Add(img);
                    //iTextLE.Paragraph c1 = new iTextLE.Paragraph(titulo);
                    //c1.SetFontSize(10);
                    //c1.SetTextAlignment(TextAlignment.CENTER);
                    //doc.Add(c1);

                    // Datos
                    iText.Kernel.Colors.Color colorFondoCabecera = new iText.Kernel.Colors.DeviceRgb(10, 49, 71);

                    if (gvDatos.Rows.Count > 0)
                    {
                        iTextLE.Table tabla = new iTextLE.Table(gvDatos.Rows[0].Cells.Count);
                        iTextLE.Cell celda;
                        for (int i = 0; i < gvDatos.HeaderRow.Cells.Count; i++)
                        {
                            celda = new iTextLE.Cell();
                            celda.Add(new iTextLE.Paragraph(WebUtility.HtmlDecode(gvDatos.HeaderRow.Cells[i].Text)));
                            celda.SetBold();
                            celda.SetBackgroundColor(colorFondoCabecera);
                            celda.SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE);
                            tabla.AddHeaderCell(celda);
                        }

                        for (int i = 0; i < gvDatos.Rows.Count; i++)
                        {
                            for (int j = 0; j < gvDatos.Rows[i].Cells.Count; j++)
                            {
                                celda = new iTextLE.Cell();
                                celda.Add(new iTextLE.Paragraph(WebUtility.HtmlDecode(gvDatos.Rows[i].Cells[j].Text)));
                                tabla.AddCell(celda);
                            }
                        }
                        doc.Add(tabla);
                    }
                    doc.Close();
                    writer.Close();

                    byte[] buffer = ms.ToArray();
                    return buffer;
                }
            }
        }

        public static byte[] ExportarExcel(GridView gvDatos, FileInfo infoLogo, string titulo)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage ep = new ExcelPackage())
                {
                    ep.Workbook.Worksheets.Add("Reporte");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                    // Cabecera
                    ExcelPicture pic = ew.Drawings.AddPicture("Logo", infoLogo);
                    pic.SetPosition(0, 0, 0, 0);
                    pic.SetSize(60, 50);

                    ew.Cells[1, 2].Value = titulo;
                    ew.Cells[1, 2].Style.Font.Size = 14;
                    ew.Cells[1, 2].Style.Font.Bold = true;
                    ew.Cells[1, 2, 2, gvDatos.HeaderRow.Cells.Count].Merge = true;
                    ew.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ew.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ew.Row(1).Height = 25;
                    // Datos
                    System.Drawing.Color colorFondoCabecera = System.Drawing.ColorTranslator.FromHtml("#0a3147");
                    if (gvDatos.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvDatos.HeaderRow.Cells.Count; i++)
                        {
                            ew.Cells[3, i + 1].Value = WebUtility.HtmlDecode(gvDatos.HeaderRow.Cells[i].Text);
                            ew.Cells[3, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ew.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(colorFondoCabecera);
                            ew.Cells[3, i + 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                            ew.Cells[3, i + 1].Style.Font.Bold = true;
                            ew.Column(i + 1).Width = 30;
                        }

                        for (int i = 0; i < gvDatos.Rows.Count; i++)
                        {
                            for (int j = 0; j < gvDatos.Rows[0].Cells.Count; j++)
                            {
                                ew.Cells[i + 4, j + 1].Value = WebUtility.HtmlDecode(gvDatos.Rows[i].Cells[j].Text);
                            }
                        }
                    }
                    ep.SaveAs(ms);

                    byte[] buffer = ms.ToArray();
                    return buffer;
                }
            }
        }
        #endregion
    }
}