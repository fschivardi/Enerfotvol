using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerfotvol
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!VerificarPermiso())
            {
                Response.Redirect("~/pages/NoAutorizado.aspx");
            }
        }

        private bool VerificarPermiso()
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            return negUsuario.VerificarPermiso((BE.Usuario)Session["Usuario"], this.AppRelativeVirtualPath);
        }
    }
}