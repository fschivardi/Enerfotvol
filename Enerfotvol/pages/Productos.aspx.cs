using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Enerfotvol
{
    public partial class Productos : System.Web.UI.Page
    {
        BE.Producto prod = new BE.Producto();
        List<BE.TipoProducto> ls = new List<BE.TipoProducto>();


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
            if (!this.IsPostBack)
            {
                CargarCombo();
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

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            Cargar();
        }

        private void CargarCombo()
        {
            CargarListaTipos();
            cmbTipoProdB.DataSource = ls;
            cmbTipoProdB.DataValueField = "Id";
            cmbTipoProdB.DataTextField = "Descripcion";
            cmbTipoProdB.DataBind();
            cmbTipoProd.DataSource = ls;
            cmbTipoProd.DataValueField = "Id";
            cmbTipoProd.DataTextField = "Descripcion";
            cmbTipoProd.DataBind();
            ListItem itemvacio = new ListItem();
            itemvacio.Value = "0";
            itemvacio.Text = "";
            cmbTipoProdB.Items.Insert(0, itemvacio);
        }

        private void LimpiarTextBox()
        {
            txtCodProd.Text="";
            txtNombreProd.Text="";
            txtDescripcion.Text = "";
            //cmbTipoProd.Items.FindByValue("0").Selected = true;
            txtSKU.Text = "";
            txtPuntoStock.Text = "0";
        }

        private void CargarListaTipos()
        {
            BLL.TipoProducto negTipoProd = new BLL.TipoProducto();
            ls = negTipoProd.Listar();
        }

        private void CargarUsuario()
        {
            prod.Codigo = txtCodProd.Text;
            prod.Nombre = txtNombreProd.Text;
            prod.Descripcion = txtDescripcion.Text;
            prod.Tipo.Id = Int32.Parse(cmbTipoProd.SelectedValue.ToString());
            prod.SKU = txtSKU.Text;
            prod.PuntoStock = Int32.Parse(txtPuntoStock.Text);
        }

        private void Cargar()
        {
            BLL.Producto negProd = new BLL.Producto();
            prod.Codigo = txtCodProdB.Text;
            prod.Nombre = txtNombreB.Text;
            prod.Tipo.Id = Int32.Parse(cmbTipoProdB.SelectedValue.ToString());
            prod.SKU = txtSKUB.Text;
            dgvProductos.DataSource = negProd.Listar(prod);
            dgvProductos.DataBind();            
        }

        protected void dgvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProductos.EditIndex = -1;
            Cargar();
        }

        protected void dgvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProductos.EditIndex = e.NewEditIndex;
            Cargar();
        }

        protected void dgvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            prod.Codigo = Convert.ToString(dgvProductos.DataKeys[e.RowIndex].Value);
            prod.Nombre = ((TextBox)dgvProductos.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            Borrar();
        }

        protected void dgvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            prod.Codigo = Convert.ToString(dgvProductos.DataKeys[e.RowIndex].Value);
            prod.SKU = ((TextBox)dgvProductos.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            prod.Nombre = ((TextBox)dgvProductos.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            prod.Descripcion = ((TextBox)dgvProductos.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            DropDownList ddl = (DropDownList)dgvProductos.Rows[e.RowIndex].FindControl("ddlTipoProd");
            prod.Tipo.Id = Convert.ToInt32(ddl.SelectedItem.Value);
            prod.Tipo.Descripcion = ddl.SelectedItem.Text;
            prod.PuntoStock = Convert.ToInt32(((TextBox)dgvProductos.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            Editar(prod);
        }

        private void Crear()
        {
            CargarUsuario();
            BLL.Producto negProd = new BLL.Producto();
            if (negProd.Crear(prod))
                Cargar();
            LimpiarTextBox();
        }

        private void Editar(BE.Producto prod)
        {            
            BLL.Producto negProd = new BLL.Producto();
            negProd.Actualizar(prod);
            dgvProductos.EditIndex = -1;
            Cargar();
            LimpiarTextBox();
        }

        private void Borrar()
        {
            BLL.Producto negProd = new BLL.Producto();
            negProd.Borrar(prod);
            dgvProductos.EditIndex = -1;
            Cargar();
            LimpiarTextBox();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Crear();
        }

        protected void dgvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CargarListaTipos();
                //Busco la DropDownList en la fila
                DropDownList ddlTipoProd = (e.Row.FindControl("ddlTipoProd") as DropDownList);
                ddlTipoProd.DataSource = ls;
                ddlTipoProd.DataTextField = "Descripcion";
                ddlTipoProd.DataValueField = "Id";
                ddlTipoProd.DataBind();

                string tipoprod = (e.Row.FindControl("lblTipoProd") as Label).Text;
                ddlTipoProd.Items.FindByValue(tipoprod).Selected = true;               
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

    }
}