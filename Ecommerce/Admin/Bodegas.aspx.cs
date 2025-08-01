using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class Bodegas : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				BodegaNegocio negocio = new BodegaNegocio();
				Session.Add("listaBodegas", negocio.ObtenerTodas());
				gvBodegas.DataSource = Session["listaBodegas"];
				gvBodegas.DataBind();
			}
		}

        protected void gvBodegas_SelectedIndexChanged(object sender, EventArgs e)
        {
			int idSeleccionado = Convert.ToInt32(gvBodegas.SelectedDataKey.Value);
			Response.Redirect($"FormularioBodega.aspx?id={idSeleccionado}");
        }
    }
}