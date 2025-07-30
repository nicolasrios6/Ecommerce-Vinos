using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class VarietalDatos
	{
		public List<Varietal> ObtenerTodos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Varietal> lista = new List<Varietal>();

			try
			{
				datos.setConsulta("SELECT * FROM Varietales");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Varietal varietal = new Varietal
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(varietal);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los varietales", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Varietal> ObtenerActivos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Varietal> lista = new List<Varietal>();

			try
			{
				datos.setConsulta("SELECT * FROM Varietales WHERE Activo = 1");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Varietal varietal = new Varietal
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(varietal);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los varietales activos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Varietal ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT Id, Nombre, Activo FROM Varietales WHERE Id = @id");
				datos.setParametro("@id", id);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					return new Varietal
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
				throw new Exception("Error al obtener el varietal.", ex);
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
				datos.setConsulta("INSERT INTO Varietales (Nombre, Activo) VALUES (@nombre, 1)");
				datos.setParametro("@nombre", nombre);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar varietal.", ex);
			}
		}

		public void Modificar(Varietal varietal)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE Varietales SET Nombre = @nombre, Activo = @activo WHERE Id = @id");
				datos.setParametro("@nombre", varietal.Nombre);
				datos.setParametro("@activo", varietal.Activo);
				datos.setParametro("@id", varietal.Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar varietal.", ex);
			}
		}
	}
}
