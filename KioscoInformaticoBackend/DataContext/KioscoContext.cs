using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using KioscoInformaticoServices.Enums;
using KioscoInformaticoServices.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KioscoInformaticoBackend.DataContext;

public partial class KioscoContext : DbContext
{
    public KioscoContext()
    {
    }

    public KioscoContext(DbContextOptions<KioscoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> Detallescompras { get; set; }

    public virtual DbSet<DetalleVenta> Detallesventas { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        string? cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

        optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region  Datos semilla
        // Carga de datos semilla de Productos
        modelBuilder.Entity<Producto>().HasData(
            new Producto() { Id = 1, Nombre = "Coca-Cola 2lts", Precio = 2500 },
            new Producto() { Id = 2, Nombre = "Papas Lays 160grs", Precio = 1500 },
            new Producto() { Id = 3, Nombre = "Agua Mineral 2lts", Precio = 2000 }
            );

        // Carga de datos semilla de Localidades
        modelBuilder.Entity<Localidad>().HasData(
            new Localidad() { Id = 1, Nombre = "San Justo" },
            new Localidad() { Id = 2, Nombre = "Videla" },
            new Localidad() { Id = 3, Nombre = "Reconquista" }
            );

        // Carga de datos semilla de Clientes
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente
            {
                Id = 1,
                Nombre = "Juan Pérez",
                Direccion = "Calle Falsa 123",
                Telefonos = "123456789",
                FechaNacimiento = new DateTime(1985, 5, 15),
                LocalidadId = 1
            },
            new Cliente
            {
                Id = 2,
                Nombre = "María López",
                Direccion = "Avenida Siempre Viva 742",
                Telefonos = "987654321",
                FechaNacimiento = new DateTime(1990, 8, 25),
                LocalidadId = 2
            },
            new Cliente
            {
                Id = 3,
                Nombre = "Carlos García",
                Direccion = "Boulevard de los Sueños Rotos 101",
                Telefonos = "555666777",
                FechaNacimiento = new DateTime(1978, 2, 3),
                LocalidadId = 3
            }
            );

        // Carga de datos semilla de Proveedores
        modelBuilder.Entity<Proveedor>().HasData(
        new Proveedor
        {
            Id = 1,
            Nombre = "Proveedor A",
            Direccion = "Calle 1",
            Telefonos = "111111111",
            Cbu = "0000003100010000000001",
            CondicionIva = CondicionIvaEnum.Responsable_Inscripto,
            LocalidadId = 1
        },
        new Proveedor
        {
            Id = 2,
            Nombre = "Proveedor B",
            Direccion = "Calle 2",
            Telefonos = "222222222",
            Cbu = "0000003100010000000002",
            CondicionIva = CondicionIvaEnum.Monotributista,
            LocalidadId = 2
        },
        new Proveedor
        {
            Id = 3,
            Nombre = "Proveedor C",
            Direccion = "Calle 3",
            Telefonos = "333333333",
            Cbu = "0000003100010000000003",
            CondicionIva = CondicionIvaEnum.Consumidor_Final,
            LocalidadId = 3
        }
    );
        // Carga de datos semilla de Ventas
        modelBuilder.Entity<Venta>().HasData(
            new Venta()
            {
                Id = 1,
                FormaPago = FormaDePagoEnum.Efectivo,
                Iva = 21m,
                Total = 3000m,
                ClienteId = 1,
                Fecha = DateTime.Now
            },
            new Venta()
            {
                Id = 2,
                FormaPago = FormaDePagoEnum.Tarjeta_Credito,
                Iva = 10,
                Total = 5000m,
                ClienteId = 2,
                Fecha = DateTime.Now
            },
            new Venta()
            {
                Id = 3,
                FormaPago = FormaDePagoEnum.Tarjeta_Debito,
                Iva = 21,
                Total = 8000m,
                ClienteId = 3,
                Fecha = DateTime.Now
            }
        );

        // Carga de datos semilla de Compras
        modelBuilder.Entity<Compra>().HasData(
            new Compra
            {
                Id = 1,
                FormaDePago = FormaDePagoEnum.Efectivo,
                Iva = 21,
                Total = 1000,
                Fecha = new DateTime(2021, 5, 15),
                ProveedorId = 1
            },
            new Compra
            {
                Id = 2,
                FormaDePago = FormaDePagoEnum.Tarjeta_Credito,
                Iva = 10,
                Total = 2000,
                Fecha = new DateTime(2021, 5, 16),
                ProveedorId = 2
            },
            new Compra
            {
                Id = 3,
                FormaDePago = FormaDePagoEnum.Tarjeta_Debito,
                Iva = 5,
                Total = 3000,
                Fecha = new DateTime(2021, 5, 17),
                ProveedorId = 3
            }
        );

        // Carga de datos semilla de DetallesCompras
        modelBuilder.Entity<DetalleCompra>().HasData(
        new DetalleCompra { Id = 1, ProductoId = 1, PrecioUnitario = 2650, Cantidad = 1, CompraId = 1 },
        new DetalleCompra { Id = 2, ProductoId = 2, PrecioUnitario = 2450, Cantidad = 2, CompraId = 2 },
        new DetalleCompra { Id = 3, ProductoId = 3, PrecioUnitario = 2550, Cantidad = 1, CompraId = 3 }
        );

        // Carga de datos semilla de DetallesVentas
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, Cantidad = 1, PrecioUnitario = 2650 },
            new DetalleVenta { Id = 2, VentaId = 2, ProductoId = 2, Cantidad = 2, PrecioUnitario = 2450 },
            new DetalleVenta { Id = 3, VentaId = 3, ProductoId = 3, Cantidad = 1, PrecioUnitario = 2550 }
            );
        #endregion

        #region definición de filtros de eliminación
        // (este código no lo habilitamos todavía porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
        // ApiControllers para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuración de
        // eliminación hace que el sistema ignore los registros que tengan el eliminado en verdadero, así que hace que en
        // apariencia y funcionalidad esté "eliminado", pero van a seguir estando ahí para que podamos observar las eliminaciones que hubo)
        modelBuilder.Entity<Cliente>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Compra>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<DetalleCompra>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<DetalleVenta>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Localidad>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Producto>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Proveedor>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Venta>().HasQueryFilter(m => !m.Eliminado);

        #endregion

    }
}
