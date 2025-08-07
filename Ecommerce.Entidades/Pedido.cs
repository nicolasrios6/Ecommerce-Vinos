﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entidades
{
	public class Pedido
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public DateTime Fecha { get; set; }
		public string Estado { get; set; } = "Pendiente";
		public decimal Subtotal { get; set; }
		public decimal Envio { get; set; }
		public decimal Total { get; set; }
		public string DireccionEnvio { get; set; }
		public string MetodoEnvio { get; set; }
		public string MetodoPago { get; set; }
		public string Observaciones { get; set; }

		public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
	}
}
