﻿using Ecommerce.Entidades;
using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class DetallePedido : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				int id = Convert.ToInt32(Request.QueryString["id"]);
				lblNumeroPedidoTitulo.Text = id.ToString();
				CargarPedido(id);
			}
		}

		private void CargarPedido(int id)
		{
			PedidoNegocio negocio = new PedidoNegocio();
			Pedido pedido = negocio.ObtenerPorId(id);

			lblNumeroPedido.Text = pedido.Id.ToString();
			lblCliente.Text = pedido.NombreUsuario;
			lblFecha.Text = pedido.Fecha.ToString("dd/MM/yyyy");
			lblMetodoEnvio.Text = pedido.MetodoEnvio;
			lblDireccion.Text = pedido.DireccionEnvio;
			lblMetodoPago.Text = pedido.MetodoPago;
			lblObservaciones.Text = pedido.Observaciones;

			lblSubtotal.Text = $"${pedido.Subtotal:N0}";
			lblEnvio.Text = $"${pedido.Envio:N0}";
			lblTotal.Text = $"${pedido.Total:N0}";

			ddlEstado.SelectedValue = pedido.Estado;

			gvDetalles.DataSource = pedido.Detalles;
			gvDetalles.DataBind();
		}

		protected void btnActualizarEstado_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			string nuevoEstado = ddlEstado.SelectedValue;

			PedidoNegocio negocio = new PedidoNegocio();
			negocio.ActualizarEstado(id, nuevoEstado);
			Response.Redirect("Pedidos.aspx", false);
		}
	}
}