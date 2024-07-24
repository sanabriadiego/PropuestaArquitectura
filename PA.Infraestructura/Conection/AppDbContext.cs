using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace PA.Infraestructura.Conection
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProductosCategorias> ProductosCategorias { get; set; }
        public DbSet<CodigoBarras> CodigosBarras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=PADb;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.IdProducto);
                entity.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(p => p.Precio)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();
                entity.Property(p => p.Activo)
                    .HasDefaultValue(true);
                entity.Property(p => p.FechaVencimiento)
                    .IsRequired();
                entity.Property(p => p.Observaciones)
                    .HasDefaultValue("");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {

                entity.HasKey(tp => tp.IdTipoProducto);
                entity.Property(tp => tp.Descripcion)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.Descripcion)
                    .HasMaxLength(255)
                    .IsRequired(true);
                entity.Property(c => c.Activo)
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<ProductosCategorias>(entity =>
            {
                entity.HasKey(pc => pc.IdDetalle);
                entity.Property(pc => pc.FechaCreacion);
            });

            modelBuilder.Entity<CodigoBarras>(entity =>
            {
                entity.HasKey(cb => cb.IdCodigoBarra);
                entity.Property(cb => cb.Activo)
                   .IsRequired(true)
                   .HasDefaultValue(true);
            });
        }
    }
}
