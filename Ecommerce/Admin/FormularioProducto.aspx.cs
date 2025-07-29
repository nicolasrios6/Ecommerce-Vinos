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
			if (!IsPostBack)
			{
				CargarCombos();
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
	}
}