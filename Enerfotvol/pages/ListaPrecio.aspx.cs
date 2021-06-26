using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol.pages
{
    public partial class ListaPrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!VerificarPermiso())
            {
                Response.Redirect("~/pages/NoAutorizado.aspx");
            }
            else
            {
                CambiarIdioma();
            }
        }

        private bool VerificarPermiso()
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            return negUsuario.VerificarPermiso((BE.Usuario)Session["Usuario"], this.AppRelativeVirtualPath);
        }

        public void CambiarIdioma()
        {
            foreach (BE.Idioma idioma in (List<BE.Idioma>)Application["Idiomas"])
            {
                if (idioma.Id == Int32.Parse(Session["IDOMA"].ToString()))
                {
                    Controles.ActualizarControles(idioma, this);
                }
            }
        }
    }
}