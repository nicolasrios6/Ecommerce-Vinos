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
	}
}
