using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Infraestructura.Interfaces;
using PA.Infraestructura.Repositorios;
using PA.Infraestructura.Conection;

namespace PA.Infraestructura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            TiposProducto = new TipoProductoRepositorio(_context);
            Categorias = new CategoriaRepositorio(_context);
            Productos = new ProductoRepositorio(_context);
            Productos_Categorias = new ProductosCategoriasRepositorio(_context);

        }

        public ITipoProductoRepositorio TiposProducto { get; private set; }
        public ICategoriaRepositorio Categorias { get; private set; }

        public IProductoRepositorio Productos { get; private set; }
        public IProductosCategoriasRepositorio Productos_Categorias { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
