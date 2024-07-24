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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetByDescripcion(string descripcion)
        {
            return _context.Categorias.SingleOrDefault(c => c.Descripcion == descripcion);
        }
    }
}
