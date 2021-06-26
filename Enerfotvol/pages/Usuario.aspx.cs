using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol
{
    public partial class Usuario : System.Web.UI.Page
    {
        BE.Usuario usuario = new BE.Usuario();

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

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            Cargar();
        }

        protected void dgvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvUsuarios.EditIndex = -1;
            Cargar();
        }

        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            usuario.Id = Convert.ToString(dgvUsuarios.DataKeys[e.RowIndex].Value);
            Borrar();
        }

        protected void dgvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvUsuarios.EditIndex = e.NewEditIndex;
            Cargar();
        }

        protected void dgvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            usuario.Id = Convert.ToString(dgvUsuarios.DataKeys[e.RowIndex].Value);
            usuario.Nombre = ((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            usuario.Apellido = ((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            usuario.Descripcion = ((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            usuario.Mail = ((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            usuario.UltimoLogin = Convert.ToDateTime(((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            usuario.UltimoIntentoF = Convert.ToDateTime(((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            usuario.IntentosF = Convert.ToInt32(((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            usuario.Bloqueado = Convert.ToBoolean(((TextBox)dgvUsuarios.Rows[e.RowIndex].Cells[7].Controls[0]).Text);
            usuario.Estado = true;
            Editar(usuario);
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

        private void Cargar()
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            usuario.Id = txtUsuarioB.Text;
            usuario.Nombre = txtNombreB.Text;
            usuario.Apellido = txtApellidoB.Text;
            usuario.Mail = txtMailB.Text;
            dgvUsuarios.DataSource = negUsuario.Listar(usuario);
            dgvUsuarios.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Crear();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void Crear()
        {
            CargarUsuario();
            BLL.Usuario negUsuario = new BLL.Usuario();
            if (negUsuario.Crear(usuario))
                Cargar();
            LimpiarTextBox();
        }

        private void Editar(BE.Usuario usr)
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            negUsuario.Actualizar(usr);
            dgvUsuarios.EditIndex = -1;
            Cargar();
            LimpiarTextBox();
        }

        private void Borrar()
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            negUsuario.Borrar(usuario);
            dgvUsuarios.EditIndex = -1;
            Cargar();
            LimpiarTextBox();
        }

        private void CargarUsuario()
        {
            usuario = new BE.Usuario();
            usuario.Id = txtUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Descripcion = txtDescripcion.Text;
            usuario.Mail = txtMail.Text;
            usuario.EncPassword = txtClave.Text;
        }

        private void LimpiarTextBox()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDescripcion.Text = "";
            txtMail.Text = "";
            txtClave.Text = "";
            txtClave2.Text = "";
        }

        protected void dgvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}