using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce
{
	public class CarritoHelper
	{
		public List<ItemCarrito> ObtenerCarrito()
		{
			if (HttpContext.Current.Session["Carrito"] == null)
				HttpContext.Current.Session["Carrito"] = new List<ItemCarrito>();

			return (List<ItemCarrito>)HttpContext.Current.Session["Carrito"];
		}

		public void GuardarCarrito(List<ItemCarrito> carrito)
		{
			HttpContext.Current.Session["Carrito"] = carrito;
		}

		public void VaciarCarrito()
		{
			HttpContext.Current.Session["Current"] = new List<ItemCarrito>();
		}

		public decimal CalcularTotal()
		{
			var carrito = ObtenerCarrito();
			return carrito.Sum(item => item.Subtotal);
		}
	}
}