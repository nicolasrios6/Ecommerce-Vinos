using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class ProductoNegocio
	{
		public List<Producto> ObtenerTodos()
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				return datos.ObtenerTodos();
			}
			catch (Exception ex)
			{

				throw new Exception("Error al obtener los productos.", ex);
			}
		}
	}
}
