using PA.Dominio.Entidades;
using PA.Infraestructura.Interfaces;
using PA.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Aplicacion.Servicios
{
    public class ProductosCategoriasServicio : IProductosCategoriasServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductosCategoriasServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProductoCategoria()
        {
            Console.WriteLine("Por favor ingrese los siguientes datos para agregar un Producto a una Categoria:\n");
            Console.WriteLine("ID Producto:");
            string id = Console.ReadLine();
            Console.WriteLine("Categoria:");
            foreach (var cat in _unitOfWork.Categorias.GetAll())
            {
                Console.WriteLine($"- {cat.Descripcion}");
            }
            string descripcion_categoria = Console.ReadLine();
            Producto producto = _unitOfWork.Productos.GetProductobyId(Int32.Parse(id));
            Categoria categoria = _unitOfWork.Categorias.GetByDescripcion(descripcion_categoria);
            //Console.WriteLine(categoria.IdCategoria);
            ProductosCategorias producto_categoria = new ProductosCategorias
            {
                FechaCreacion = DateTime.Now,
                Producto = producto,
                Categoria = categoria
            };
            _unitOfWork.Productos_Categorias.Add(producto_categoria);
            _unitOfWork.Complete();
            Console.WriteLine("Producto añadido a Categoria con exito!");

        }
    }
}
