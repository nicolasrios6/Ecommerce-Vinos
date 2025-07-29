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
	}
}
