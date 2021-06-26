using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol.pages
{
    public partial class TipoProducto : System.Web.UI.Page
    {
        BE.TipoProducto tipoprod = new BE.TipoProducto();
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BLL.TipoProducto negTipoProd = new BLL.TipoProducto();
            dgvTipoProd.DataSource = negTipoProd.Listar();
            dgvTipoProd.DataBind();
        }

        protected void dgvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvTipoProd.PageIndex = e.NewPageIndex;
            this.dgvTipoProd.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Crear();
        }
        private void Crear() 
        {
            tipoprod.Descripcion = txtDescripcion.Text;
            BLL.TipoProducto negTipoProd = new BLL.TipoProducto();
            if (negTipoProd.Crear(tipoprod))
                Cargar();
        }

        protected void dgvTipoProd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvTipoProd.EditIndex = e.NewEditIndex;
            Cargar();
        }
        private void Editar(BE.TipoProducto tipoprod)
        {
            BLL.TipoProducto negTipoProd = new BLL.TipoProducto();            
            negTipoProd.Actualizar(tipoprod);
            dgvTipoProd.EditIndex = -1;
            Cargar();
        }

        protected void dgvTipoProd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BE.TipoProducto tipoprod = new BE.TipoProducto();
            tipoprod.Id = Convert.ToInt32(dgvTipoProd.DataKeys[e.RowIndex]["Id"]);
            tipoprod.Descripcion = ((TextBox)dgvTipoProd.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            Editar(tipoprod);
        }

        protected void dgvTipoProd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(dgvTipoProd.DataKeys[e.RowIndex]["Id"]);
            tipoprod.Descripcion = ((TextBox)dgvTipoProd.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            Borrar(id);
        }

        private void Borrar(int id)
        {
            BLL.TipoProducto negTipoProd = new BLL.TipoProducto();
            BE.TipoProducto tipoprod = new BE.TipoProducto();
            tipoprod.Id = id;
            negTipoProd.Borrar(tipoprod);
            dgvTipoProd.EditIndex = -1;
            Cargar();
        }

        protected void dgvTipoProd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvTipoProd.EditIndex = -1;
            Cargar();
        }
    }
}