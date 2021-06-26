using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol
{
    public partial class Formulario_web5 : System.Web.UI.Page
    {
        BE.Bitacora bit = new BE.Bitacora();
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
            if (!IsPostBack)
            {
                cldFechaDesde.SelectedDate = DateTime.Now.AddDays(-1);
                cldFechaHasta.SelectedDate = DateTime.Now;
                cldFechaDesde.Visible = false;
                cldFechaHasta.Visible = false;
            }
            
        }

        private bool VerificarPermiso()
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            return negUsuario.VerificarPermiso((BE.Usuario)Session["Usuario"], this.AppRelativeVirtualPath);
        }
        private void Cargar()
        {
            bit.Objeto = txtObjAudit.Text;
            bit.Autor = txtAutor.Text;
            BLL.Bitacora negBitacora = new BLL.Bitacora();
            dgvBitacora.DataSource = negBitacora.ListarBitacora(bit,cldFechaDesde.SelectedDate,cldFechaHasta.SelectedDate, Int32.Parse(Session["IDOMA"].ToString()));
            dgvBitacora.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        protected void dgvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvBitacora.PageIndex = e.NewPageIndex;
            Cargar();
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