using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class BD_REDBOX_DISTRIBUIDORAContext : DbContext
    {
        public BD_REDBOX_DISTRIBUIDORAContext()
        {
        }

        public BD_REDBOX_DISTRIBUIDORAContext(DbContextOptions<BD_REDBOX_DISTRIBUIDORAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BitacoraErrore> BitacoraErrores { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<SP_Ante_Pedido_Result> SP_Ante_Pedido_Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //Jose:
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BD_REDBOX_DISTRIBUIDORA;User Id=sa;Password=Serkes2022!*;");

                /*Rob:*/
                //optionsBuilder.UseSqlServer("data source=localhost,1433;Database=BD_REDBOX_DISTRIBUIDORA;User Id=sa;Password=yourStrong(!)Password;");

                //Dario:
                //optionsBuilder.UseSqlServer("Server=localhost;Database=BD_REDBOX_DISTRIBUIDORA;Integrated Security=True;Trusted_Connection=True;");

                //Gianca
                //optionsBuilder.UseSqlServer("Server=localhost;Database=BD_REDBOX_DISTRIBUIDORA;Integrated Security=True;Trusted_Connection=True;");

                // My connection string (JuanK)
                //optionsBuilder.UseSqlServer("Server=.;Database=BD_REDBOX_DISTRIBUIDORA;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitacoraErrore>(entity =>
            {
                entity.HasKey(e => e.IdError)
                    .HasName("XPKBITACORA_ERRORES");

                entity.ToTable("BITACORA_ERRORES");

                entity.Property(e => e.IdError).HasColumnName("ID_ERROR");

                entity.Property(e => e.Detalle)
                    .IsUnicode(false)
                    .HasColumnName("DETALLE");

                entity.Property(e => e.FechaError)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ERROR");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.UsuarioAfectado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO_AFECTADO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.BitacoraErrores)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_7");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("XPKCATEGORIA");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CATEGORIA");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("XPKESTADO");

                entity.ToTable("ESTADO");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.DescripcionEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_ESTADO");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("XPKPEDIDO");

                entity.ToTable("PEDIDO");

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.CantidadProducto).HasColumnName("CANTIDAD_PRODUCTO");

                entity.Property(e => e.FechaPedido)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_PEDIDO");

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.NumeroPedido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_PEDIDO");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("R_3");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("R_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("R_5");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("XPKPRODUCTO");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.CantidadDisponible).HasColumnName("CANTIDAD_DISPONIBLE");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_ACTUALIZACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PRODUCTO");

                entity.Property(e => e.PrecioProducto).HasColumnName("PRECIO_PRODUCTO");

                entity.Property(e => e.RutaImagen)
                    .HasColumnType("image")
                    .HasColumnName("RUTA_IMAGEN");

                entity.Property(e => e.TallaProducto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TALLA_PRODUCTO");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_1");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_4");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("XPKPROVEEDOR");

                entity.ToTable("PROVEEDOR");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA_JURIDICA");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.NombreProveedor)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_PROVEEDOR");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("XPKROL");

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ROL");

                entity.Property(e => e.DescRol)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESC_ROL");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("XPKUSUARIO");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.ContraseniaUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENIA_USUARIO");

                entity.Property(e => e.Direccion)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_USUARIO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
