using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class BodegaDatos
	{
		public List<Bodega> ObtenerTodas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Bodega> lista = new List<Bodega>();

			try
			{
				datos.setConsulta("SELECT * FROM Bodegas");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Bodega bodega = new Bodega
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(bodega);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las bodegas", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Bodega> ObtenerActivas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Bodega> lista = new List<Bodega>();

			try
			{
				datos.setConsulta("SELECT * FROM Bodegas WHERE Activo = 1");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Bodega bodega = new Bodega
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(bodega);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las bodegas activas.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Bodega ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT Id, Nombre, Activo FROM Bodegas WHERE Id = @id");
				datos.setParametro("@id", id);
				datos.ejecutarLectura();

				if(datos.Lector.Read())
				{
					return new Bodega
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
				throw new Exception("Error al obtener la bodega.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void Agregar(string nombre)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("INSERT INTO Bodegas (Nombre, Activo) VALUES (@nombre, 1)");
				datos.setParametro("@nombre", nombre);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar bodega.", ex);
			}
		}

		public void Modificar(Bodega bodega)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE Bodegas SET Nombre = @nombre, Activo = @activo WHERE Id = @id");
				datos.setParametro("@nombre", bodega.Nombre);
				datos.setParametro("@activo", bodega.Activo);
				datos.setParametro("@id", bodega.Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar bodega.", ex);
			}
		}
	}
}
