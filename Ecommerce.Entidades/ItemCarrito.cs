using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entidades
{
	public class ItemCarrito
	{
		public int ProductoId { get; set; }
		public string Nombre { get; set; }
		public string ImagenUrl { get; set; }
		public decimal Precio { get; set; }
		public int Cantidad { get; set; }

		public decimal Subtotal => Precio * Cantidad;
	}
}
