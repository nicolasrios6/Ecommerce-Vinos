﻿using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Usuario"] != null && !IsPostBack)
			{
				Usuario usuario = (Usuario)Session["Usuario"];
				lblNombre.Text = $"Hola, {usuario.Nombre}!";
			}
		}
	}
}