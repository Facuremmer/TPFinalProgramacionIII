﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPFinalProgIII.Models;

namespace TPFinalProgIII.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TPFinalProgIII.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCliente")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("IdCuitDni")
                        .HasColumnType("bigint")
                        .HasColumnName("idCuit_Dni");

                    b.HasKey("IdCliente")
                        .HasName("PK__Cliente__885457EE68A41D9B");

                    b.HasIndex("IdCuitDni");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCompra")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdProveedor")
                        .HasColumnType("int")
                        .HasColumnName("idProveedor");

                    b.Property<double?>("TotalCompra")
                        .HasColumnType("float");

                    b.HasKey("IdCompra")
                        .HasName("PK__Compra__48B99DB7994FF517");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DatosEnvioVenta", b =>
                {
                    b.Property<int>("IdDatosEnvioVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDatosEnvioVenta")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aclaraciones")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.Property<string>("Calle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.HasKey("IdDatosEnvioVenta")
                        .HasName("PK__DatosEnv__99B2E6D8858BC8C4");

                    b.ToTable("DatosEnvioVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleCompra", b =>
                {
                    b.Property<int>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetalleCompra")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdCompra")
                        .HasColumnType("int")
                        .HasColumnName("idCompra");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int")
                        .HasColumnName("idProducto");

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.Property<double?>("Retencion")
                        .HasColumnType("float");

                    b.HasKey("IdDetalleCompra")
                        .HasName("PK__DetalleC__62C252C180CA77D9");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleCompra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleVenta", b =>
                {
                    b.Property<int>("IdDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetalleVenta")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double?>("Descuento")
                        .HasColumnType("float");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int")
                        .HasColumnName("idProducto");

                    b.Property<int?>("IdVenta")
                        .HasColumnType("int")
                        .HasColumnName("idVenta");

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.Property<double?>("Recargo")
                        .HasColumnType("float");

                    b.HasKey("IdDetalleVenta")
                        .HasName("PK__DetalleV__BFE2843F44A54509");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Direccion", b =>
                {
                    b.Property<int>("IdDireccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDireccion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.Property<long?>("IdCuitDni")
                        .HasColumnType("bigint")
                        .HasColumnName("idCuit_Dni");

                    b.Property<string>("Provincia")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.HasKey("IdDireccion")
                        .HasName("PK__Direccio__B49878C9BADAEEFB");

                    b.HasIndex("IdCuitDni");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.EnvioCompra", b =>
                {
                    b.Property<long>("IdCodigoSeguimiento")
                        .HasColumnType("bigint")
                        .HasColumnName("idCodigoSeguimiento");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("IdDetalleCompra")
                        .HasColumnType("int")
                        .HasColumnName("idDetalleCompra");

                    b.Property<string>("Sucursal")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigoSeguimiento")
                        .HasName("PK__EnvioCom__62A20D8F0AF1D59E");

                    b.HasIndex("IdDetalleCompra");

                    b.ToTable("EnvioCompra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.EnvioVenta", b =>
                {
                    b.Property<long>("IdCodigoSeguimiento")
                        .HasColumnType("bigint")
                        .HasColumnName("idCodigoSeguimiento");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("IdDatosEnvioVenta")
                        .HasColumnType("int")
                        .HasColumnName("idDatosEnvioVenta");

                    b.Property<int?>("IdDetalleVenta")
                        .HasColumnType("int")
                        .HasColumnName("idDetalleVenta");

                    b.Property<int?>("IdDireccion")
                        .HasColumnType("int")
                        .HasColumnName("idDireccion");

                    b.Property<string>("Sucursal")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigoSeguimiento")
                        .HasName("PK__EnvioVen__62A20D8FE185BDDD");

                    b.HasIndex("IdDatosEnvioVenta");

                    b.HasIndex("IdDetalleVenta");

                    b.HasIndex("IdDireccion");

                    b.ToTable("EnvioVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Persona", b =>
                {
                    b.Property<long>("IdCuitDni")
                        .HasColumnType("bigint")
                        .HasColumnName("idCuit_Dni");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength(true);

                    b.HasKey("IdCuitDni")
                        .HasName("PK__Persona__3C0BF2A944BF89C4");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnType("int")
                        .HasColumnName("idProducto");

                    b.Property<decimal?>("CodigoProducto")
                        .HasColumnType("numeric(18,0)");

                    b.Property<int?>("IdTipoProducto")
                        .HasColumnType("int")
                        .HasColumnName("idTipoProducto");

                    b.Property<int?>("StockActual")
                        .HasColumnType("int");

                    b.HasKey("IdProducto")
                        .HasName("PK__Producto__07F4A13247290A69");

                    b.HasIndex("IdTipoProducto");

                    b.HasIndex(new[] { "CodigoProducto" }, "CodigoProducto")
                        .IsUnique()
                        .HasFilter("[CodigoProducto] IS NOT NULL");

                    b.HasIndex(new[] { "CodigoProducto" }, "UQ__Producto__785B009F2F74E941")
                        .IsUnique()
                        .HasFilter("[CodigoProducto] IS NOT NULL");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idProveedor")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("IdCuitDni")
                        .HasColumnType("bigint")
                        .HasColumnName("idCuit_Dni");

                    b.Property<string>("Rubro")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("char(30)")
                        .IsFixedLength(true);

                    b.HasKey("IdProveedor")
                        .HasName("PK__Proveedo__A3FA8E6B8C0BC11F");

                    b.HasIndex("IdCuitDni");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.TipoProducto", b =>
                {
                    b.Property<int>("IdTipoProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoProducto")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTipoProducto")
                        .HasName("PK__TipoProd__2552C5A56ED8470B");

                    b.ToTable("TipoProducto");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idVenta")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<string>("SucursalVenta")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<double?>("TotalVenta")
                        .HasColumnType("float");

                    b.HasKey("IdVenta")
                        .HasName("PK__Venta__077D5614D3A6690B");

                    b.HasIndex("IdCliente");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Cliente", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Persona", "IdCuitDniNavigation")
                        .WithMany("Cliente")
                        .HasForeignKey("IdCuitDni")
                        .HasConstraintName("FK_Cliente");

                    b.Navigation("IdCuitDniNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Compra", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Proveedor", "IdProveedorNavigation")
                        .WithMany("Compra")
                        .HasForeignKey("IdProveedor")
                        .HasConstraintName("FK_Compra");

                    b.Navigation("IdProveedorNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleCompra", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Compra", "IdCompraNavigation")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("IdCompra")
                        .HasConstraintName("FK_DetalleCompra");

                    b.HasOne("TPFinalProgIII.Models.Producto", "IdProductoNavigation")
                        .WithMany("DetalleCompra")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_DetalleCompraProducto");

                    b.Navigation("IdCompraNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleVenta", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Producto", "IdProductoNavigation")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_DetalleVentaProducto");

                    b.HasOne("TPFinalProgIII.Models.Venta", "IdVentaNavigation")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdVenta")
                        .HasConstraintName("FK_DetalleVenta");

                    b.Navigation("IdProductoNavigation");

                    b.Navigation("IdVentaNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Direccion", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Persona", "IdCuitDniNavigation")
                        .WithMany("Direccion")
                        .HasForeignKey("IdCuitDni")
                        .HasConstraintName("FK_Direccion");

                    b.Navigation("IdCuitDniNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.EnvioCompra", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.DetalleCompra", "IdDetalleCompraNavigation")
                        .WithMany("EnvioCompra")
                        .HasForeignKey("IdDetalleCompra")
                        .HasConstraintName("FK_EnvioCompra");

                    b.Navigation("IdDetalleCompraNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.EnvioVenta", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.DatosEnvioVenta", "IdDatosEnvioVentaNavigation")
                        .WithMany("EnvioVenta")
                        .HasForeignKey("IdDatosEnvioVenta")
                        .HasConstraintName("FK_DatosEnvioVenta");

                    b.HasOne("TPFinalProgIII.Models.DetalleVenta", "IdDetalleVentaNavigation")
                        .WithMany("EnvioVenta")
                        .HasForeignKey("IdDetalleVenta")
                        .HasConstraintName("FK_EnvioVenta");

                    b.HasOne("TPFinalProgIII.Models.Direccion", "IdDireccionNavigation")
                        .WithMany("EnvioVenta")
                        .HasForeignKey("IdDireccion")
                        .HasConstraintName("FK_PersonaCargada");

                    b.Navigation("IdDatosEnvioVentaNavigation");

                    b.Navigation("IdDetalleVentaNavigation");

                    b.Navigation("IdDireccionNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Producto", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.TipoProducto", "IdTipoProductoNavigation")
                        .WithMany("Producto")
                        .HasForeignKey("IdTipoProducto")
                        .HasConstraintName("FK_TipoProducto");

                    b.Navigation("IdTipoProductoNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Proveedor", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Persona", "IdCuitDniNavigation")
                        .WithMany("Proveedor")
                        .HasForeignKey("IdCuitDni")
                        .HasConstraintName("FK_Proveedor");

                    b.Navigation("IdCuitDniNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Venta", b =>
                {
                    b.HasOne("TPFinalProgIII.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Venta");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Cliente", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Compra", b =>
                {
                    b.Navigation("DetalleCompra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DatosEnvioVenta", b =>
                {
                    b.Navigation("EnvioVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleCompra", b =>
                {
                    b.Navigation("EnvioCompra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.DetalleVenta", b =>
                {
                    b.Navigation("EnvioVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Direccion", b =>
                {
                    b.Navigation("EnvioVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Persona", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Direccion");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Producto", b =>
                {
                    b.Navigation("DetalleCompra");

                    b.Navigation("DetalleVenta");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Proveedor", b =>
                {
                    b.Navigation("Compra");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.TipoProducto", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TPFinalProgIII.Models.Venta", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}