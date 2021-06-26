using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CambiarIdioma();
        }
        //public void CambiarIdioma()
        //{
        //    foreach (BE.Idioma idioma in (List<BE.Idioma>)Application["Idiomas"])
        //    {
        //        if (idioma.Id == Int32.Parse(Session["IDOMA"].ToString()))
        //        {
        //            Controles.ActualizarControles(idioma, this);
        //        }
        //    }
        //}

    }
}