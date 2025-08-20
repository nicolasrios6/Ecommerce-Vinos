using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Session["Usuario"] != null)
				{
					Usuario usuario = (Usuario)Session["Usuario"];
					liLogin.Visible = false;
					liRegistro.Visible = false;
					liLogout.Visible = true; ;
					liMisPedidos.Visible = true;
				} else
				{
					liLogin.Visible = true;
					liRegistro.Visible = true;
					liLogout.Visible = false;
					liMisPedidos.Visible = false;
				}

				CargarCarrito();
			}
			//repCarrito.ItemCommand += repCarrito_ItemCommand;
		}

		public void CargarCarrito()
		{
			if (Session["Carrito"] != null)
			{
				var carrito = (List<ItemCarrito>)Session["Carrito"];
				repCarrito.DataSource = carrito;
				repCarrito.DataBind();

				if(carrito.Count > 0)
				{
					CarritoHelper helper = new CarritoHelper();
					decimal total = helper.CalcularTotal();
					lblTotal.Text = ((int)total).ToString();

					pnlResumenCarrito.Visible = true;
					pnlCarritoVacio.Visible = false;
				} else
				{
					pnlResumenCarrito.Visible = false;
					pnlCarritoVacio.Visible = true;
				}
			} else
			{
				repCarrito.DataSource = null;
				repCarrito.DataBind();

				pnlResumenCarrito.Visible = false;
				pnlCarritoVacio.Visible = true;
			}
		}

		protected void repCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (Session["Carrito"] == null)
				return;

			List<ItemCarrito> carrito = (List<ItemCarrito>)Session["Carrito"];
			int idProducto = Convert.ToInt32(e.CommandArgument);

			ItemCarrito item = carrito.FirstOrDefault(x => x.ProductoId == idProducto);
			if (item == null)
				return;

			switch (e.CommandName)
			{
				case "Sumar":
					item.Cantidad++;
					break;

				case "Restar":
					if (item.Cantidad > 1)
						item.Cantidad--;
					break;

				case "Eliminar":
					carrito.Remove(item);
					break;
			}

			Session["Carrito"] = carrito;
			CargarCarrito();
			//repCarrito.DataSource = carrito;
			//repCarrito.DataBind();

			CarritoHelper helper = new CarritoHelper();
			lblTotal.Text = ((int)helper.CalcularTotal()).ToString();
		}


		protected void btnLogout_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Session.Abandon();
			Response.Redirect("~/Login.aspx");
		}

		public void ActualizarUpdatePanel()
		{
			UpdatePanel1.Update();
		}
	}
}