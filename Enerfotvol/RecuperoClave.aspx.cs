using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerfotvol
{
    public partial class RecuperoClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RecuperarClave();
        }

        private void RecuperarClave()
        {
            BLL.USesion negUsesion = new BLL.USesion();
            if (negUsesion.IniciarRecuperoClave(txtMail.Text))
            {
                lblMensajes.Text = "Se envió un correo a su mail para que recupere su contraseña.";
            }
            else
            {
                lblMensajes.Text = "No se encontró un usuario asociado a la dirección de correo ingresada.";
            }
        }

    }
}