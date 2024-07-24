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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCategoria()
        {
            Console.WriteLine("Por favor ingrese una descripcion la nueva Categoria: ");
            string descripcion = Console.ReadLine();
            Categoria categoria = new Categoria();
            categoria.Descripcion = descripcion;
            _unitOfWork.Categorias.Add(categoria);
            _unitOfWork.Complete();
            Console.WriteLine("Categoria creada!");
        }

        public void GetCategorias()
        {
            foreach (var categoria in _unitOfWork.Categorias.GetAll())
            {
                Console.WriteLine($"ID: {categoria.IdCategoria}," +
                    $" Descripción: {categoria.Descripcion}," +
                    $" Activo: {categoria.Activo}");
            }
        }
    }
}
