﻿using Ecommerce.Datos;
using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Negocio
{
	public class ProductoNegocio
	{
		public List<Producto> ObtenerTodos()
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				return datos.ObtenerTodos();
			}
			catch (Exception ex)
			{

				throw new Exception("Error al obtener los productos.", ex);
			}
		}

		public List<Producto> ObtenerActivos()
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				return datos.ObtenerActivos();
			}
			catch (Exception ex)
			{

				throw new Exception("Error al obtener los productos activos.", ex);
			}
		}

		public Producto ObtenerPorId(int id)
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{

				throw new Exception("Error al obtener el producto.", ex);
			}
		}

		public List<Producto> ObtenerPorCategoria(int categoriaId)
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				return datos.ObtenerPorCategoria(categoriaId);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener productos por categoria.", ex);
			}
		}

		public void Agregar(Producto producto)
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				datos.Agregar(producto);
			}
			catch (Exception ex)
			{

				throw new Exception("Error al agregar producto.", ex);
			}
		}

		public void Modificar(Producto producto)
		{
			ProductoDatos datos = new ProductoDatos();
			try
			{
				datos.Modificar(producto);
			}
			catch (Exception ex)
			{

				throw new Exception("Error al modificar producto.", ex);
			}
		}
	}
}
