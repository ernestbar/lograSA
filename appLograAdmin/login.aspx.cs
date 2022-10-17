using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace appLograAdmin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    txtUsuario.Focus();
                    lblAviso.Text = "";
                    //string path = Server.MapPath("~/wkhtmltopdf/wkhtmltopdf.exe");
                    //string ruta_Archivo = Server.MapPath("~/Reportes/Seguro");


                    //ProcessStartInfo oProcessStarInfo = new ProcessStartInfo();
                    //oProcessStarInfo.UseShellExecute = false;
                    //oProcessStarInfo.FileName = path;
                    //oProcessStarInfo.Arguments = ruta_Archivo + "\\seguro1.aspx " + ruta_Archivo + "\\mipdf2.pdf";
                    ////oProcessStarInfo.Arguments = ruta_Archivo + "http://hdeleon.net/ "+ ruta_Archivo+ "\\mipdf.pdf";

                    //using (Process oProcess = Process.Start(oProcessStarInfo))
                    //{
                    //    oProcess.WaitForExit();

                    //}

                    //Console.WriteLine("pdf creado");
                    //Console.Read(); }
                }
                catch (Exception ex)
                {
                    string aux = ex.ToString();
                }
                
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string[] datos = Clases.Utilitarios.PR_INGRESO_APP(txtUsuario.Text, txtPassword.Text).Split('|');
            if (datos[1] == "Login correcto")
            {
                if (datos[2] == "1")
                {
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("cambio_password.aspx?temp=1");
                }
                else
                {
                    Session["cod_cliente"] = datos[3];
                    Session["es_master"] = datos[4];
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("dashboard.aspx");
                    lblAviso.Text = "";
                }

                //Session["cod_cliente"] = datos[3];
                //Session["es_master"] = datos[4];
                //Session["usuario"] = txtUsuario.Text;
                //Response.Redirect("dashboard.aspx");
                //lblAviso.Text = "";


            }
            else
            { lblAviso.Text = "Usuario y contraseña incorrectas!"; txtUsuario.Focus(); }


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            Clases.Personal per = new Clases.Personal("", "", "", "", "", "", "", "", "", 0, 0, 0,
                      "", txtUsuario.Text, "", "", "", DateTime.Now, DateTime.Now, "", txtUsuario.Text);
            lblAviso.Text = per.ABM_R().Replace("|", "").Replace("0", "").Replace("null", "");
            Clases.enviar_correo objC = new Clases.enviar_correo();
            string resultado2 = objC.enviar(txtUsuario.Text, "Reseteo de contraseña del usuario " +txtUsuario.Text, "Estimado usuario :" + "<br/><br/> Su password temporal es el 123: <br/><br/>" + " <br/><br/> Ahora debe ingresar al sistema del siguiente link: <br/><br/>" + "https://200.105.209.42:5554" + "<br/><br/>Saludos coordiales.", "");
                //lblAviso.Text = datos[3] + ". Te enviamos un correo con tu password temporal para ingresar, muchas gracias!!!!";
                //Response.Redirect("login.aspx?tipo=R");
        }
    }
}