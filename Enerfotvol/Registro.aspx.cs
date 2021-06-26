using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Enerfotvol
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static Boolean UsuarioDisponible(string sUser)
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            
            if (negUsuario.CargarUsr(sUser).Id != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [WebMethod()]
        public static Boolean MailDisponible(string sUser)
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            BE.Usuario usuario = new BE.Usuario("", "", "", "", sUser);
            if (negUsuario.Listar(usuario).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void RegistrarUsuario(object sender, EventArgs e)
        {
            lblMensajes.Text = "Se registró correctamente el usuario "+ txtUsuario.Text +" con el mail "+ txtMail.Text + ". Será redirigido al login en 5 segundos.";
            Response.AppendHeader("Refresh", "5;url=Login.aspx");
        }
               
    }
}