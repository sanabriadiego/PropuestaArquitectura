using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Dominio.Entidades
{
    public class ProductosCategorias
    {
        public int IdDetalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Producto Producto { get; set; }
        public Categoria Categoria { get; set; }
    }
}
