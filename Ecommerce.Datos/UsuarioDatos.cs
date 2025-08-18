using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class UsuarioDatos
	{
		//private AccesoDatos datos = new AccesoDatos();

		public void Registrar(Usuario nuevoUsuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Usuario_Registrar");
				datos.setParametro("@Nombre", nuevoUsuario.Nombre);
				datos.setParametro("@Apellido", nuevoUsuario.Apellido);
				datos.setParametro("@Email", nuevoUsuario.Email);
				datos.setParametro("@Contrasenia", nuevoUsuario.Contrasenia);
				datos.setParametro("@Rol", nuevoUsuario.Rol);
				datos.setParametro("@Activo", nuevoUsuario.Activo);
				datos.setParametro("@Telefono", nuevoUsuario.Telefono);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al registrar el usuario.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Usuario Login(string email, string contrasenia)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT * FROM Usuarios WHERE Email = @Email AND Contrasenia = @Contrasenia");
				datos.setParametro("@Email", email);
				datos.setParametro("@Contrasenia", contrasenia);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					Usuario usuario = new Usuario();
					usuario.Id = (int)datos.Lector["Id"];
					usuario.Nombre = datos.Lector["Nombre"].ToString();
					usuario.Apellido = datos.Lector["Apellido"].ToString();
					usuario.Email = datos.Lector["Email"].ToString();
					usuario.Contrasenia = datos.Lector["Contrasenia"].ToString();
					usuario.Rol = datos.Lector["Rol"].ToString();
					usuario.Activo = (bool)datos.Lector["Activo"];
					usuario.Telefono = datos.Lector["Telefono"].ToString();

					return usuario;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al intentar iniciar sesión", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
		public bool BuscarPorEmail(string email)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT * FROM Usuarios WHERE Email = @Email");
				datos.setParametro("@Email", email);
				datos.ejecutarLectura();

				return datos.Lector.Read();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al buscar usuario por email en la base de datos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Usuario BuscarPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT * FROM Usuarios WHERE Id = @Id");
				datos.setParametro("@Id", id);
				datos.ejecutarLectura();

				if(datos.Lector.Read())
				{
					Usuario usuario = new Usuario
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Apellido = datos.Lector["Apellido"].ToString(),
						Email = datos.Lector["Email"].ToString(),
						Activo = (bool)datos.Lector["Activo"],
						Telefono = datos.Lector["Telefono"].ToString(),
					};
					return usuario;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al buscar usuario por id en la base de datos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Usuario> ObtenerClientes()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Usuario> lista = new List<Usuario>();
			try
			{
				datos.setProcedimiento("Usuario_ObtenerClientes");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Usuario usuario = new Usuario
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Apellido = datos.Lector["Apellido"].ToString(),
						Email = datos.Lector["Email"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};
					lista.Add(usuario);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al traer los usuarios clientes.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void ActualizarEstado(int id, bool activo)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Usuario_ActualizarEstado");
				datos.setParametro("@Id", id);
				datos.setParametro("@Activo", activo);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al actualizar el estado del usuario.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

	}
}
