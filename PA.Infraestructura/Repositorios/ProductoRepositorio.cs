using PA.Dominio.Entidades;
using PA.Infraestructura.Interfaces;
using PA.Infraestructura.Conection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Infraestructura.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AppDbContext _context;

        public ProductoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Producto producto, CodigoBarras codigo_barras)
        {

            _context.Productos.Add(producto);
            Console.WriteLine("Producto Añadido");
            _context.CodigosBarras.Add(codigo_barras);
            Console.WriteLine("Codigo de Barras Añadido");

        }

        public Producto GetProductobyId(int id)
        {
            return _context.Productos.Find(id);
        }
    }
}
