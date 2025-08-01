using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class Varietales1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				VarietalNegocio negocio = new VarietalNegocio();
				Session.Add("listaVarietales", negocio.ObtenerTodos());
				gvVarietales.DataSource = Session["listaVarietales"];
				gvVarietales.DataBind();
			}
		}

        protected void gvVarietales_SelectedIndexChanged(object sender, EventArgs e)
        {
			int idSeleccionado = Convert.ToInt32(gvVarietales.SelectedDataKey.Value);
			Response.Redirect($"FormularioVarietal.aspx?id={idSeleccionado}");
		}
    }
}