using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Infraestructura.Interfaces;

namespace PA.Infraestructura.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITipoProductoRepositorio TiposProducto { get; }
        ICategoriaRepositorio Categorias { get; }
        IProductoRepositorio Productos { get; }
        IProductosCategoriasRepositorio Productos_Categorias { get; }
        int Complete();
    }
}
