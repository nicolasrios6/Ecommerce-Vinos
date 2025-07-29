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
	}
}
