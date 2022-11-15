using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appLograAdmin
{
    public partial class dashboard : System.Web.UI.Page
    {
        string lista_proyectos = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                { Response.Redirect("login.aspx"); }
                else
                {
                    lblCodServidor.Text = Session["cod_servidor"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                }
            }
        }
        
    }
}