using PA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Infraestructura.Interfaces
{
    public interface ICategoriaRepositorio
    {
        void Add(Categoria categoria);
        IEnumerable<Categoria> GetAll();
        public Categoria GetByDescripcion(string descripcion);
    }
}
