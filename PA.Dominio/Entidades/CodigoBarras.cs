using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Dominio.Entidades
{
    public class CodigoBarras
    {
        public int IdCodigoBarra { get; set; }
        public bool Activo { get; set; } = true;
        public Producto Producto { get; set; }

    }
}
