using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        BE.Usuario usuario = new BE.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                CambiarIdioma();
                usuario = (BE.Usuario)Session["Usuario"];
                Label1.Text = usuario.Id;
                DeshabilitarControles();
                HabilitarControles();
            }
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

        private void HabilitarControles()
        {
            foreach (Control ct in this.Controls)
            {
                if (ct is HyperLink)
                {
                    HyperLink myHyperlink = (HyperLink)ct;
                    if (usuario.Perfil.Count > 0)
                    {
                        foreach (BE.Componente c in usuario.Perfil)
                        {
                            if (ct.ID == "men" + c.Permiso)
                            {
                                try
                                {
                                    myHyperlink.Visible = true;
                                    myHyperlink.Enabled = true;
                                }
                                catch { }
                            }                            
                        }
                    }                                     
                }
            }
        }

        private void DeshabilitarControles()
        {
            foreach (Control ct in this.Controls)
            {
                if (ct is HyperLink)
                {
                    HyperLink myHyperlink = (HyperLink)ct;
                    try
                    {
                        myHyperlink.Visible = false;
                        myHyperlink.Enabled = false;
                    }
                    catch { }
                }
            }
        }
    }
}