using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Dominio.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
        public DateOnly FechaVencimiento { get; set; }
        public string Observaciones { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public ICollection<ProductosCategorias> ProductosCategorias { get; set; }
    }
}
