using Ecommerce.Admin;
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
	public partial class DetalleProducto : System.Web.UI.Page
	{
		//private Producto ProductoActual
		//{
		//	get => (Producto)ViewState["ProductoActual"];
		//	set => ViewState["ProductoActual"] = value;
		//}
		public Producto ProductoActual { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idProducto))
				{
					CargarProducto(idProducto);
				}
				else
				{
					Response.Redirect("Default.aspx");
				}
			}
		}

		private void CargarProducto(int id)
		{
			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(id);

			if (producto == null)
			{
				Response.Redirect("Default.aspx");
				return;
			}

			ProductoActual = producto;
			imgProducto.ImageUrl = producto.ImagenUrl;
			lblNombre.Text = producto.Nombre;
			lblPrecio.Text = producto.Precio.ToString("N0");
			lblDescripcion.Text = producto.Descripcion;
			if(producto.Stock >= 2 && producto.Stock < 5)
			{
				lblStock.Text = "Quedan pocas unidades";
			} else if(producto.Stock > 5)
			{
				lblStock.Text = "En stock";
			} else
			{
				lblStock.Text = "Sin stock";
				btnAgregarCarrito.Enabled = false;
			}

			// Mostrar bodega y varietal si corresponde
			if (producto.Categoria?.Nombre == "Vinos")
			{
				pnlVino.Visible = true;
				lblBodega.Text = producto.Bodega?.Nombre ?? "Sin bodega";
				lblVarietal.Text = producto.Varietal?.Nombre ?? "Sin varietal";
			}
		}

		protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
			if (Request.QueryString["id"] == null || !int.TryParse(Request.QueryString["id"], out int productoId))
				return;

			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(productoId);

			if (producto == null)
				return;

			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

			ItemCarrito existente = carrito.Find(x => x.ProductoId == producto.Id);

			if (existente != null)
			{
				existente.Cantidad++;
			}
			else
			{
				ItemCarrito nuevoItem = new ItemCarrito
				{
					ProductoId = producto.Id,
					Nombre = producto.Nombre,
					ImagenUrl = producto.ImagenUrl,
					Precio = producto.Precio,
					Cantidad = 1
				};
				carrito.Add(nuevoItem);
			}

			Session["Carrito"] = carrito;
			Response.Redirect(Request.RawUrl);
		}
    }
}