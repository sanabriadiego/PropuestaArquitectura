using PA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Infraestructura.Interfaces
{
    public interface IProductoRepositorio
    {
        public Producto GetProductobyId(int id);
        void Add(Producto producto, CodigoBarras codigo_barras);
    }
}
