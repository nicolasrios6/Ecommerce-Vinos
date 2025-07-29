using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class BodegaNegocio
	{
		public List<Bodega> ObtenerTodas()
		{
			BodegaDatos datos = new BodegaDatos();
			try
			{
				return datos.ObtenerTodas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las bodegas.", ex);
			}
		}

		public List<Bodega> ObtenerActivas()
		{
			BodegaDatos datos = new BodegaDatos();
			try
			{
				return datos.ObtenerActivas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las bodegas activas.", ex);
			}
		}
	}
}
