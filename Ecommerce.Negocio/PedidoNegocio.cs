using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class PedidoNegocio
	{
		public void Crear(Pedido pedido) 
		{
			PedidoDatos datos = new PedidoDatos();
			try
			{
				datos.Crear(pedido);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al crear el pedido.", ex);
			}
		}
	}
}
