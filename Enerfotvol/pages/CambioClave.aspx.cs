using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol.pages
{
    public partial class CambioClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CambiarIdioma();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensajes.Visible = true;
            BE.Usuario usr = new BE.Usuario();
            usr = (BE.Usuario)Session["Usuario"];
            if (Validar(usr.Id, txtClaveActual.Text))
            {
                usr.EncPassword = txtClave.Text;
                if (CambiarClave(usr))
                {
                    lblMensajes.Text = "Se cambió su contraseña exitosamente.";
                }
                else
                {
                    lblMensajes.Text = "No se pudo cambiar la contraseña.";
                }                
            }
            else
            {
                lblMensajes.Text = "La contraseña actual no es correcta.";
            }
        }

        private bool CambiarClave(BE.Usuario u)
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            return negUsuario.CambiarClave(u);
        }

        private bool Validar(string usr, string pass)
        {
            BLL.USesion login = new BLL.USesion();
            if (login.Login(usr, pass)==1)
                return true;
            else
                return false;
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