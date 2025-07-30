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
	public partial class FormularioVarietal : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					CargarVarietal(id);
					btnGuardar.Text = "Modificar";
				}
			}
		}

		private void CargarVarietal(int id)
		{
			VarietalNegocio negocio = new VarietalNegocio();
			Varietal varietal = negocio.ObtenerPorId(id);

			if (varietal != null)
			{
				txtNombre.Text = varietal.Nombre;
				chkActivo.Checked = varietal.Activo;
				Session["VarietalId"] = varietal.Id;
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			string nombre = txtNombre.Text.Trim();
			if (string.IsNullOrWhiteSpace(nombre))
			{
				lblError.Text = "El Nombre es obligatorio";
				return;
			}

			VarietalNegocio varietalNegocio = new VarietalNegocio();
			Varietal varietal = new Varietal
			{
				Nombre = nombre,
				Activo = chkActivo.Checked,
			};

			try
			{
				if (Session["VarietalId"] != null)
				{
					varietal.Id = (int)Session["VarietalId"];
					varietalNegocio.Modificar(varietal);
					Session.Remove("VarietalId");
				}
				else
				{
					varietalNegocio.Agregar(varietal.Nombre);
				}
				Response.Redirect("Varietales.aspx", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al guardar el varietal.", ex);
			}
		}
	}
}