﻿using Ecommerce.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Admin
{
	public partial class Productos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ProductoNegocio negocio = new ProductoNegocio();
				Session.Add("listaProductos", negocio.ObtenerTodos());
				gvProductos.DataSource = Session["listaProductos"];
				gvProductos.DataBind();
			}
		}
	}
}