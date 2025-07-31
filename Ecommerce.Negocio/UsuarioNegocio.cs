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

		public Usuario BuscarPorId(int id)
		{
			UsuarioDatos datos = new UsuarioDatos();
			try
			{
				return datos.BuscarPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al buscar el usuario por id.", ex);
			}
		}

		public List<Usuario> ObtenerClientes()
		{
			UsuarioDatos datos = new UsuarioDatos();
			try
			{
				return datos.ObtenerClientes();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los usuarios clientes.", ex);
			}
		}

		public void ActualizarEstado(int id, bool activo)
		{
			UsuarioDatos datos = new UsuarioDatos();
			datos.ActualizarEstado(id, activo);
		}
	}
}
