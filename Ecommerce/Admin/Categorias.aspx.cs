using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class Categorias : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CategoriaNegocio negocio = new CategoriaNegocio();
				Session.Add("listaCategorias", negocio.ObtenerTodas());
				gvCategorias.DataSource = Session["listaCategorias"];
				gvCategorias.DataBind();
			}
		}

		protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idSeleccionado = Convert.ToInt32(gvCategorias.SelectedDataKey.Value);
			Response.Redirect($"FormularioCategoria.aspx?id={idSeleccionado}");
		}
	}
}