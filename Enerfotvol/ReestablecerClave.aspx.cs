using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerfotvol
{
    public partial class ReestablecerClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!VerificarToken(Request.QueryString["user"], Request.QueryString["token"]))
            {
                Response.Redirect("Login.aspx");
            }
        }

        private bool VerificarToken(string usuario, string token)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(token))
            {
                return false;
            }
            else
            {
                lblMensaje.Text = "Se recibió como parametro user: "+usuario+" <br>y como token: "+token;
                return true;
            }
        }
    }
}