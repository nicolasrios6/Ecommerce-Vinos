using Ecommerce.Entidades;
using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CargarCategorias();
				if (Session["CategoriaSeleccionada"] != null)
				{
					int categoriaId = (int)Session["CategoriaSeleccionada"];
					rblCategorias.SelectedValue = categoriaId.ToString();
				}
				CargarCatalogo();
			}
			
		}

		private void CargarCatalogo()
		{
			ProductoNegocio productoNegocio = new ProductoNegocio();
			List<Producto> productos;

			int categoriaId = int.Parse(rblCategorias.SelectedValue);

			if(categoriaId == 0)
			{
				productos = productoNegocio.ObtenerActivos();
			} else
			{
				productos = productoNegocio.ObtenerPorCategoria(categoriaId);
			}

			repCatalogo.DataSource = productos;
			repCatalogo.DataBind();
		}

		private void CargarCategorias()
		{
			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
			rblCategorias.DataSource = categoriaNegocio.ObtenerActivas();
			rblCategorias.DataTextField = "Nombre";
			rblCategorias.DataValueField = "Id";
			rblCategorias.DataBind();

			rblCategorias.Items.Insert(0, new ListItem("Todas", "0"));
			rblCategorias.SelectedIndex = 0;
		}

		protected void rblCategorias_SelectedIndexChanged(object sender, EventArgs e)
		{
			int categoriaId = int.Parse(rblCategorias.SelectedValue);
			Session["CategoriaSeleccionada"] = categoriaId;
			CargarCatalogo();
		}

        protected void repCatalogo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
			//Seguridad seguridad = new Seguridad();
			if(e.CommandName == "Agregar")
			{
				int productoId = Convert.ToInt32(e.CommandArgument);
				ProductoNegocio negocio = new ProductoNegocio();
				Producto producto = negocio.ObtenerPorId(productoId);

				if(producto == null)
				{
					return;
				}

				List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

				ItemCarrito existente = carrito.Find(x => x.ProductoId == productoId);
				if(existente != null)
				{
					existente.Cantidad++;
				} else
				{
					ItemCarrito nuevoItem = new ItemCarrito
					{
						ProductoId = productoId,
						Nombre = producto.Nombre,
						ImagenUrl = producto.ImagenUrl,
						Precio = producto.Precio,
						Cantidad = 1
					};
					carrito.Add(nuevoItem);
				}
				((SiteMaster)Master).CargarCarrito();
				((SiteMaster)Master).ActualizarUpdatePanel();
				Session["Carrito"] = carrito;
				//Response.Redirect(Request.RawUrl);
			}
        }
    }
}