using Ecommerce.Entidades;
using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class FormularioProducto : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				CargarCombos();
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					Session["ProductoId"] = id;
					CargarProducto(id);
				}
			}
		}

		private void CargarProducto(int id)
		{
			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(id);

			if(producto != null)
			{
				txtNombre.Text = producto.Nombre;
				txtDescripcion.Text = producto.Descripcion;
				txtImagenUrl.Text = producto.ImagenUrl;
				txtPrecio.Text = producto.Precio.ToString("0");
				txtStock.Text = producto.Stock.ToString();
				chkActivo.Checked = producto.Activo;
				imgProducto.ImageUrl = producto.ImagenUrl;

				ddlCategoria.SelectedValue = producto.CategoriaId.ToString();

				if(producto.BodegaId.HasValue)
					ddlBodega.SelectedValue = producto.BodegaId.Value.ToString();

				if (producto.VarietalId.HasValue)
					ddlVarietal.SelectedValue = producto.VarietalId.Value.ToString();
			}
		}

		private void CargarCombos()
		{
			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
			ddlCategoria.DataSource = categoriaNegocio.ObtenerActivas();
			ddlCategoria.DataTextField = "Nombre";
			ddlCategoria.DataValueField = "Id";
			ddlCategoria.DataBind();

			BodegaNegocio bodegaNegocio = new BodegaNegocio();
			ddlBodega.DataSource = bodegaNegocio.ObtenerActivas();
			ddlBodega.DataTextField = "Nombre";
			ddlBodega.DataValueField = "Id";
			ddlBodega.DataBind();

			VarietalNegocio varietalNegocio = new VarietalNegocio();
			ddlVarietal.DataSource = varietalNegocio.ObtenerActivos();
			ddlVarietal.DataTextField = "Nombre";
			ddlVarietal.DataValueField= "Id";
			ddlVarietal.DataBind();

			// Agregar opción vacía si es combo opcional
			ddlBodega.Items.Insert(0, new ListItem("Sin bodega", ""));
			ddlVarietal.Items.Insert(0, new ListItem("Sin varietal", ""));
		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
			try
			{
				if(string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
				{
					return;
				}

				Producto producto = new Producto
				{
					Nombre = txtNombre.Text.Trim(),
					Descripcion = txtDescripcion.Text.Trim(),
					ImagenUrl = txtImagenUrl.Text.Trim(),
					Precio = decimal.Parse(txtPrecio.Text),
					Stock = int.Parse(txtStock.Text),
					CategoriaId = int.Parse(ddlCategoria.SelectedValue),
					Activo = chkActivo.Checked,
					BodegaId = string.IsNullOrEmpty(ddlBodega.SelectedValue) ? (int?)null : int.Parse(ddlBodega.SelectedValue),
					VarietalId = string.IsNullOrEmpty(ddlVarietal.SelectedValue) ? (int?)null : int.Parse(ddlVarietal.SelectedValue)
				};

				ProductoNegocio negocio = new ProductoNegocio();

				if (Session["ProductoId"] != null)
				{
					producto.Id = (int)Session["ProductoId"];
					negocio.Modificar(producto);
					Session.Remove("ProductoId");
				}
				else
				{
					producto.Activo = true;
					negocio.Agregar(producto);
				}

				Response.Redirect("Productos.aspx", false);
			}
			catch (Exception ex)
			{
				lblError.Text = "Error al guardar el producto.";
				throw new Exception("Error al guardar el producto.", ex);
			}
        }

		protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
		{
			imgProducto.ImageUrl = txtImagenUrl.Text;
		}
	}
}