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
	public partial class FormularioBodega : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					CargarBodega(id);
					btnGuardar.Text = "Modificar";
				}
			}
		}

		private void CargarBodega(int id)
		{
			BodegaNegocio negocio = new BodegaNegocio();
			Bodega bodega = negocio.ObtenerPorId(id);

			if (bodega != null)
			{
				txtNombre.Text = bodega.Nombre;
				chkActivo.Checked = bodega.Activo;
				Session["BodegaId"] = bodega.Id;
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			string nombre = txtNombre.Text.Trim();
			if(string.IsNullOrWhiteSpace(nombre))
			{
				lblError.Text = "El Nombre es obligatorio";
				return;
			}

			BodegaNegocio bodegaNegocio = new BodegaNegocio();
			Bodega bodega = new Bodega
			{
				Nombre = nombre,
				Activo = chkActivo.Checked,
			};

			try
			{
				if (Session["BodegaId"] != null)
				{
					bodega.Id = (int)Session["BodegaId"];
					bodegaNegocio.Modificar(bodega);
					Session.Remove("BodegaId");
				} else
				{
					bodegaNegocio.Agregar(bodega.Nombre);
				}
				Response.Redirect("Bodegas.aspx", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al guardar la bodega.", ex);
			}
		}
	}
}