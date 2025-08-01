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
			CargarCatalogo();
		}
	}
}