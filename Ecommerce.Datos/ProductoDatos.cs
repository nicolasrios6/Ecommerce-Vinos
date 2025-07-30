using Ecommerce.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Datos
{
	public class ProductoDatos
	{
		public List<Producto> ObtenerTodos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Producto> lista = new List<Producto>();
			try
			{
				datos.setProcedimiento("Producto_ObtenerTodos");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						Activo = (bool)datos.Lector["Activo"],

						Categoria = new Categoria
						{
							Id = (int)datos.Lector["CategoriaId"],
							Nombre = datos.Lector["CategoriaNombre"].ToString(),
							Activo = (bool)datos.Lector["CategoriaActivo"]
						},
						Bodega = datos.Lector["BodegaId"] != DBNull.Value
						? new Varietal
						{
							Id = (int)datos.Lector["BodegaId"],
							Nombre = datos.Lector["BodegaNombre"].ToString(),
							Activo = (bool)datos.Lector["BodegaActivo"]
						}
						: null,
						Varietal = datos.Lector["VarietalId"] != DBNull.Value
						? new Varietal
						{
							Id = (int)datos.Lector["VarietalId"],
							Nombre = datos.Lector["VarietalNombre"].ToString(),
							Activo = (bool)datos.Lector["VarietalActivo"]
						}
						: null
					};

					lista.Add(producto);
				}
				return lista;
			}
			catch (Exception ex)
			{

				throw new Exception("Error al obtener la lista de productos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Producto> ObtenerActivos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Producto> lista = new List<Producto>();

			try
			{
				datos.setProcedimiento("Producto_ObtenerActivos");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						Activo = (bool)datos.Lector["Activo"],

						Categoria = new Categoria
						{
							Id = (int)datos.Lector["CategoriaId"],
							Nombre = datos.Lector["CategoriaNombre"].ToString(),
							Activo = (bool)datos.Lector["CategoriaActivo"]
						},
						Bodega = datos.Lector["BodegaId"] != DBNull.Value
						? new Varietal
						{
							Id = (int)datos.Lector["BodegaId"],
							Nombre = datos.Lector["BodegaNombre"].ToString(),
							Activo = (bool)datos.Lector["BodegaActivo"]
						}
						: null,
						Varietal = datos.Lector["VarietalId"] != DBNull.Value
						? new Varietal
						{
							Id = (int)datos.Lector["VarietalId"],
							Nombre = datos.Lector["VarietalNombre"].ToString(),
							Activo = (bool)datos.Lector["VarietalActivo"]
						}
						: null
					};
					lista.Add(producto);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los productos activos.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public Producto ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setProcedimiento("Producto_ObtenerPorId");
				datos.setParametro("@Id", id);
				datos.ejecutarLectura();

				if(datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						Activo = (bool)datos.Lector["Activo"],
						CategoriaId = (int)datos.Lector["CategoriaId"],
						BodegaId = datos.Lector["BodegaId"] != DBNull.Value ? (int?)datos.Lector["BodegaId"] : null,
						VarietalId = datos.Lector["VarietalId"] != DBNull.Value ? (int?)datos.Lector["VarietalId"] : null
					};
					return producto;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el producto.", ex);
			}
		}

		public void Agregar(Producto producto)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Producto_Crear");
				datos.setParametro("@Nombre", producto.Nombre);
				datos.setParametro("@Descripcion", producto.Descripcion);
				datos.setParametro("@ImagenUrl", producto.ImagenUrl);
				datos.setParametro("Precio", producto.Precio);
				datos.setParametro("Stock", producto.Stock);
				datos.setParametro("CategoriaId", producto.CategoriaId);
				datos.setParametro("BodegaId", (object)producto.BodegaId ?? DBNull.Value);
				datos.setParametro("@VarietalId", (object)producto.VarietalId ?? DBNull.Value);
				datos.setParametro("@Activo", producto.Activo);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar producto.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void Modificar(Producto producto)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Producto_Modificar");
				datos.setParametro("@Id", producto.Id);
				datos.setParametro("@Nombre", producto.Nombre);
				datos.setParametro("@Descripcion", producto.Descripcion ?? "");
				datos.setParametro("@ImagenUrl", producto.ImagenUrl ?? "");
				datos.setParametro("Precio", producto.Precio);
				datos.setParametro("Stock", producto.Stock);
				datos.setParametro("CategoriaId", producto.CategoriaId);
				datos.setParametro("BodegaId", (object)producto.BodegaId ?? DBNull.Value);
				datos.setParametro("@VarietalId", (object)producto.VarietalId ?? DBNull.Value);
				datos.setParametro("@Activo", producto.Activo);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar producto.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
