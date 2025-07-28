﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entidades
{
	public class DetallePedido
	{
		public int Id { get; set; }
		public int PedidoId { get; set; }
		public int ProductoId { get; set; }
		public int Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
		public decimal Subtotal { get; set; }
	}
}
