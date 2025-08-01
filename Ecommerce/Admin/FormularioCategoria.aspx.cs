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
	public partial class FormularioCategoria : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					CargarCategoría(id);
					btnGuardar.Text = "Modificar";
				}
			}
		}

		private void CargarCategoría(int id)
		{
			CategoriaNegocio negocio = new CategoriaNegocio();
			Categoria categoria = negocio.ObtenerPorId(id);

			if(categoria != null)
			{
				txtNombre.Text = categoria.Nombre;
				chkActivo.Checked = categoria.Activo;
				Session["CategoriaId"] = categoria.Id;
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

			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
			Categoria categoria = new Categoria
			{
				Nombre = nombre,
				Activo = chkActivo.Checked,
			};

			try
			{
				if (Session["CategoriaId"] != null)
				{
					categoria.Id = (int)Session["CategoriaId"];
					categoriaNegocio.Modificar(categoria);
					Session.Remove("CategoriaId");
				} else
				{
					categoriaNegocio.Agregar(categoria.Nombre);
				}

				Response.Redirect("Categorias.aspx", false);
			}
			catch (Exception ex)
			{

				throw new Exception("Error al guardar la categoría.", ex);
			}
        }
    }
}