using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;
using System.Web.Security;

namespace Enerfotvol
{
    public partial class Login : System.Web.UI.Page, IIdiomaObserbable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //List<BE.Idioma> idiomas = (List<BE.Idioma>)Application["Idiomas"];
                cmbIdioma.DataSource = Application["Idiomas"];
                cmbIdioma.DataValueField = "Id";
                cmbIdioma.DataTextField = "Descripcion";
                cmbIdioma.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int res = Validar(txtUsuario.Text, txtClave.Text);

            if (res==1)
            {
                BLL.Usuario negUsuario = new BLL.Usuario();
                BE.Usuario usuario = new BE.Usuario();
                usuario = negUsuario.CargarUsr(txtUsuario.Text);
                Session["USUARIO"] = usuario;
                Session["IDOMA"] = cmbIdioma.SelectedValue.ToString();
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtUsuario.Text, DateTime.Now,DateTime.Now.AddMinutes(30), false, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "~/default.aspx";
                Response.Redirect(strRedirect, true);
                //FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
                //Response.Redirect("Usuario.aspx",true);
            }
            else if (res==0)
            {                
                lblMensajes.Text = "Usuario o Contraseña incorrectos.";
            }
            else
            {
                lblMensajes.Text = "El usuario se encuentra bloqueado por intentos fallidos. Debe esperar 15 minutos desde el último login fallido para poder acceder.";
            }
        }

        private int Validar(string usr, string pass)
        {
            BLL.USesion login = new BLL.USesion();
            return login.Login(usr, pass);            
        }

        protected void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarIdioma();
        }
        public void CambiarIdioma()
        {
            foreach (BE.Idioma idioma in (List<BE.Idioma>)Application["Idiomas"])
            {
                if (idioma.Id == Int32.Parse(cmbIdioma.SelectedValue.ToString()))
                {
                    Controles.ActualizarControles(idioma, this);                    
                }
            }
        }
    }
}