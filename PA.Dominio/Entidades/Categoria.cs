using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Dominio.Entidades
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public ICollection<ProductosCategorias> ProductosCategorias { get; set; }
    }
}
