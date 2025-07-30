using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class VarietalNegocio
	{
		public List<Varietal> ObtenerTodos()
		{
			VarietalDatos datos = new VarietalDatos();
			try
			{
				return datos.ObtenerTodos();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los varietales.", ex);
			}
		}

		public List<Varietal> ObtenerActivos()
		{
			VarietalDatos datos = new VarietalDatos();
			try
			{
				return datos.ObtenerActivos();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los varietales activos.", ex);
			}
		}

		public Varietal ObtenerPorId(int id)
		{
			VarietalDatos datos = new VarietalDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el varietal.", ex);
			}
		}

		public void Agregar(string nombre)
		{
			VarietalDatos datos = new VarietalDatos();
			try
			{
				datos.Agregar(nombre);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar el varietal.", ex);
			}
		}

		public void Modificar(Varietal varietal)
		{
			VarietalDatos datos = new VarietalDatos();
			try
			{
				datos.Modificar(varietal);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar el varietal.", ex);
			}
		}
	}
}
