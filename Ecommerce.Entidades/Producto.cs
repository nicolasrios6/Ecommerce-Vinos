using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entidades
{
	public class Producto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public string ImagenUrl { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }
		public int CategoriaId { get; set; }
		public int? BodegaId { get; set; }
		public int? VarietalId { get; set; }
		public bool Activo { get; set; }

		public Categoria Categoria { get; set; }
		public Bodega Bodega { get; set; }
		public Varietal Varietal { get; set; }

	}
}
