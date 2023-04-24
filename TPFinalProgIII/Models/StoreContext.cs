﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TPFinalProgIII.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<DatosEnvioVenta> DatosEnvioVenta { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<EnvioCompra> EnvioCompra { get; set; }
        public virtual DbSet<EnvioVenta> EnvioVenta { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=WebApiDatabase");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EE68A41D9B");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdCuitDni).HasColumnName("idCuit_Dni");

                entity.HasOne(d => d.IdCuitDniNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdCuitDni)
                    .HasConstraintName("FK_Cliente");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__48B99DB7994FF517");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Compra");
            });

            modelBuilder.Entity<DatosEnvioVenta>(entity =>
            {
                entity.HasKey(e => e.IdDatosEnvioVenta)
                    .HasName("PK__DatosEnv__99B2E6D8858BC8C4");

                entity.Property(e => e.IdDatosEnvioVenta).HasColumnName("idDatosEnvioVenta");

                entity.Property(e => e.Aclaraciones)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__DetalleC__62C252C180CA77D9");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("idDetalleCompra");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompra)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_DetalleCompra");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleCompra)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_DetalleCompraProducto");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PK__DetalleV__BFE2843F44A54509");

                entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_DetalleVentaProducto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK_DetalleVenta");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__Direccio__B49878C9BADAEEFB");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCuitDni).HasColumnName("idCuit_Dni");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCuitDniNavigation)
                    .WithMany(p => p.Direccion)
                    .HasForeignKey(d => d.IdCuitDni)
                    .HasConstraintName("FK_Direccion");
            });

            modelBuilder.Entity<EnvioCompra>(entity =>
            {
                entity.HasKey(e => e.IdCodigoSeguimiento)
                    .HasName("PK__EnvioCom__62A20D8F0AF1D59E");

                entity.Property(e => e.IdCodigoSeguimiento)
                    .ValueGeneratedNever()
                    .HasColumnName("idCodigoSeguimiento");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDetalleCompra).HasColumnName("idDetalleCompra");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDetalleCompraNavigation)
                    .WithMany(p => p.EnvioCompra)
                    .HasForeignKey(d => d.IdDetalleCompra)
                    .HasConstraintName("FK_EnvioCompra");
            });

            modelBuilder.Entity<EnvioVenta>(entity =>
            {
                entity.HasKey(e => e.IdCodigoSeguimiento)
                    .HasName("PK__EnvioVen__62A20D8FE185BDDD");

                entity.Property(e => e.IdCodigoSeguimiento)
                    .ValueGeneratedNever()
                    .HasColumnName("idCodigoSeguimiento");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDatosEnvioVenta).HasColumnName("idDatosEnvioVenta");

                entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDatosEnvioVentaNavigation)
                    .WithMany(p => p.EnvioVenta)
                    .HasForeignKey(d => d.IdDatosEnvioVenta)
                    .HasConstraintName("FK_DatosEnvioVenta");

                entity.HasOne(d => d.IdDetalleVentaNavigation)
                    .WithMany(p => p.EnvioVenta)
                    .HasForeignKey(d => d.IdDetalleVenta)
                    .HasConstraintName("FK_EnvioVenta");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.EnvioVenta)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_PersonaCargada");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdCuitDni)
                    .HasName("PK__Persona__3C0BF2A944BF89C4");

                entity.Property(e => e.IdCuitDni)
                    .ValueGeneratedNever()
                    .HasColumnName("idCuit_Dni");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A13247290A69");

                entity.HasIndex(e => e.CodigoProducto, "CodigoProducto")
                    .IsUnique();

                entity.HasIndex(e => e.CodigoProducto, "UQ__Producto__785B009F2F74E941")
                    .IsUnique();

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("idProducto");

                entity.Property(e => e.CodigoProducto).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdTipoProducto).HasColumnName("idTipoProducto");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .HasConstraintName("FK_TipoProducto");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__A3FA8E6B8C0BC11F");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdCuitDni).HasColumnName("idCuit_Dni");

                entity.Property(e => e.Rubro)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCuitDniNavigation)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.IdCuitDni)
                    .HasConstraintName("FK_Proveedor");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PK__TipoProd__2552C5A56ED8470B");

                entity.Property(e => e.IdTipoProducto).HasColumnName("idTipoProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__077D5614D3A6690B");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.SucursalVenta)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Venta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}