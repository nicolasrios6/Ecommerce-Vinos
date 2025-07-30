using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

		public Bodega ObtenerPorId(int id)
		{
			BodegaDatos datos = new BodegaDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener la bodega.", ex);
			}
		}

		public void Agregar(string nombre)
		{
			BodegaDatos datos = new BodegaDatos();
			try
			{
				datos.Agregar(nombre);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar la bodega.", ex);
			}
		}

		public void Modificar(Bodega bodega)
		{
			BodegaDatos datos = new BodegaDatos();
			try
			{
				datos.Modificar(bodega);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar la bodega.", ex);
			}
		}
	}
}
