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
	public partial class Registro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
			UsuarioNegocio negocio = new UsuarioNegocio();
			var nuevoUsuario = new Usuario
			{
				Nombre = txtNombre.Text.Trim(),
				Apellido = txtApellido.Text.Trim(),
				Email = txtEmail.Text.Trim(),
				Contrasenia = txtContrasenia.Text.Trim(),
				Rol = "Cliente",
				Activo = true
			};

			try
			{
				bool registrado = negocio.Registrar(nuevoUsuario);

				if (registrado)
				{
					lblMensaje.Text = "Registro completado exitosamente. Ahora podés iniciar sesión.";
					lblMensaje.ForeColor = System.Drawing.Color.Green;

					Response.AddHeader("REFRESH", "5;URL=Login.aspx");
				} else
				{
					lblMensaje.Text = "El email ya está registrado";
					lblMensaje.ForeColor = System.Drawing.Color.Red;
				}
			}
			catch (Exception ex)
			{
				lblMensaje.Text = "Ocurrió un error inesperado al registrar el usuario.";
				lblMensaje.ForeColor = System.Drawing.Color.Red;
			}
        }
    }
}