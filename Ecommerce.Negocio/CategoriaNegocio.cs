using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class CategoriaNegocio
	{
		public List<Categoria> ObtenerTodas()
		{
			CategoriaDatos datos = new CategoriaDatos();
			try
			{
				return datos.ObtenerTodas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las categorias.", ex);
			}
		}

		public List<Categoria> ObtenerActivas()
		{
			CategoriaDatos datos = new CategoriaDatos();
			try
			{
				return datos.ObtenerActivas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las categorias activas.", ex);
			}
		}

		public Categoria ObtenerPorId(int id)
		{
			CategoriaDatos datos = new CategoriaDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener la categoria.", ex);
			}
		}

		public void Agregar(string nombre)
		{
			CategoriaDatos datos = new CategoriaDatos();
			try
			{
				datos.Agregar(nombre);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar categoría.", ex);
			}
		}

		public void Modificar(Categoria categoria)
		{
			CategoriaDatos datos = new CategoriaDatos();
			try
			{
				datos.Modificar(categoria);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar la categoria.", ex);
			}
		}

		//public void Inactivar(int id)
		//{
		//	CategoriaDatos datos = new CategoriaDatos();
		//	try
		//	{
		//		datos.Inactivar(id);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception("Error al inactivar categoria.", ex);
		//	}
		//}
	}
}
