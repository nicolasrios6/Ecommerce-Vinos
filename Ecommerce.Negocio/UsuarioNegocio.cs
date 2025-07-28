using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class UsuarioNegocio
	{
		public bool Registrar(Usuario nuevoUsuario)
		{
			UsuarioDatos datos = new UsuarioDatos();

			if(datos.BuscarPorEmail(nuevoUsuario.Email))
			{
				return false;
			}

			datos.Registrar(nuevoUsuario);
			return true;
		}

		public Usuario Login(string email, string constrasenia)
		{
			UsuarioDatos datos = new UsuarioDatos();
			Usuario usuario = datos.Login(email, constrasenia);

			if(usuario != null && usuario.Activo)
			{
				return usuario;
			}

			return null;
		}
	}
}
