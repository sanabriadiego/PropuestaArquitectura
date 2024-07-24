using PA.Dominio.Entidades;
using PA.Infraestructura.Interfaces;
using PA.Aplicacion.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Aplicacion.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void AddProducto()
        {
            Console.WriteLine("Por favor ingrese los siguientes datos para el Producto:\n");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Asigne el tipo de Producto");
            foreach (var tipo in _unitOfWork.TiposProducto.GetAll())
            {
                Console.WriteLine($"- {tipo.Descripcion}");
            }
            string tipo_producto = Console.ReadLine();
            Console.WriteLine("Precio:");
            string precio = Console.ReadLine();
            Console.WriteLine("Fecha de Vencimiento:");
            string fecha_vencimiento = Console.ReadLine();
            Console.WriteLine("Observaciones:");
            string observaciones = Console.ReadLine();



            Producto producto = new Producto
            {
                Nombre = nombre,
                Precio = Convert.ToDecimal(precio),
                FechaVencimiento = DateOnly.Parse(fecha_vencimiento),
                Observaciones = observaciones,
                TipoProducto = _unitOfWork.TiposProducto.GetByDescripcion(tipo_producto)
            };


            CodigoBarras codigo_barras = new CodigoBarras();
            codigo_barras.Producto = producto;

            _unitOfWork.Productos.Add(producto, codigo_barras);
            _unitOfWork.Complete();
            Console.WriteLine("Producto creado con exito!");

        }
    }
}
