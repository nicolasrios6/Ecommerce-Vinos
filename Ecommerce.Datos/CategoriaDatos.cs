using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class CategoriaDatos
	{
		public List<Categoria> ObtenerTodas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Categoria> lista = new List<Categoria>();

			try
			{
				datos.setConsulta("SELECT * FROM Categorias");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Categoria categoria = new Categoria
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(categoria);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las categorias.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Categoria> ObtenerActivas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Categoria> lista = new List<Categoria>();

			try
			{
				datos.setConsulta("SELECT * FROM Categorias WHERE Activo = 1");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Categoria categoria = new Categoria
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(categoria);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las categorias activas.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Categoria ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setConsulta("SELECT Id, Nombre, Activo FROM Categorias WHERE Id = @id");
				datos.setParametro("@id", id);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					return new Categoria
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener la categoria.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public void Agregar(string nombre)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta(@"INSERT INTO Categorias (Nombre, Activo) VALUES (@nombre, 1);");
				datos.setParametro("@nombre", nombre);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar categoría.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public void Modificar(Categoria cat)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE Categorias SET Nombre = @nombre, Activo = @activo WHERE Id = @id");
				datos.setParametro("@nombre", cat.Nombre);
				datos.setParametro("@activo", cat.Activo);
				datos.setParametro("@id", cat.Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar categoría.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		//public void Inactivar(int id)
		//{
		//	AccesoDatos datos = new AccesoDatos();
		//	try
		//	{
		//		datos.setConsulta("UPDATE Categorias SET Activo = 0 WHERE Id = @id");
		//		datos.setParametro("@id", id);
		//		datos.ejecutarAccion();
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception("Error al inactivar categoría.", ex);
		//	}
		//	finally
		//	{
		//		datos.cerrarConexion();
		//	}
		//}

	}
}
