using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Infraestructura.Interfaces
{
    public interface ITipoProductoRepositorio
    {
        void Add(TipoProducto tipo_producto);
        IEnumerable<TipoProducto> GetAll();
        TipoProducto GetById(int tipo_productoId);
        TipoProducto GetByDescripcion(string descripcion);

    }
}
