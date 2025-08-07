using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class PedidoDatos
	{
		public void Crear(Pedido pedido)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setProcedimiento("Pedido_Crear");
				datos.setParametro("@UsuarioId", pedido.UsuarioId);
				datos.setParametro("@Fecha", pedido.Fecha);
				datos.setParametro("@Estado", pedido.Estado);
				datos.setParametro("@Subtotal", pedido.Subtotal);
				datos.setParametro("@Envio", pedido.Envio);
				datos.setParametro("@Total", pedido.Total);
				datos.setParametro("@DireccionEnvio", (object)pedido.DireccionEnvio ?? DBNull.Value);
				datos.setParametro("@MetodoEnvio", pedido.MetodoEnvio);
				datos.setParametro("@MetodoPago", pedido.MetodoPago);
				datos.setParametro("@Observaciones", (object)pedido.Observaciones ?? DBNull.Value);

				datos.setParametro("@NuevoId", 0);
				datos.comando.Parameters["@NuevoId"].Direction = System.Data.ParameterDirection.Output;

				datos.ejecutarAccion();

				int nuevoId = Convert.ToInt32(datos.comando.Parameters["@NuevoId"].Value);
				pedido.Id = nuevoId;

				foreach(var detalle in pedido.Detalles)
				{
					AccesoDatos datosDetalle = new AccesoDatos();
					try
					{
						datosDetalle.setProcedimiento("DetallePedido_Crear");
						datosDetalle.setParametro("@PedidoId", nuevoId);
						datosDetalle.setParametro("@ProductoId", detalle.ProductoId);
						datosDetalle.setParametro("@NombreProducto", detalle.NombreProducto);
						datosDetalle.setParametro("@Cantidad", detalle.Cantidad);
						datosDetalle.setParametro("@PrecioUnitario", detalle.PrecioUnitario);

						datosDetalle.ejecutarAccion();
					} finally
					{
						datosDetalle.cerrarConexion();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error al crear el pedido.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
