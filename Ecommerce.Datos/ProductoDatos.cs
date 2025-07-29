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
						? new Bodega
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
			} finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
