using KioscoInformaticoServices.Models;
using Microsoft.EntityFrameworkCore;
namespace KioscoInformaticoDesktop.DataContext;

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

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=Kioscocontext;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.LocalidadId, "IX_Clientes_LocalidadId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FechaNacimiento).HasMaxLength(6);
            entity.Property(e => e.LocalidadId).HasColumnType("int(11)");

            //entity.HasOne(d => d.Localidad).WithMany(p => p.Clientes)
            //    .HasForeignKey(d => d.LocalidadId)
            //    .HasConstraintName("FK_Clientes_Localidades_LocalidadId");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("compras");

            entity.HasIndex(e => e.ProveedorId, "IX_Compras_ProveedorID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Fecha).HasMaxLength(6);
            entity.Property(e => e.FormaDePago).HasColumnType("int(11)");
            entity.Property(e => e.Iva).HasColumnType("int(11)");
            entity.Property(e => e.ProveedorId)
                .HasColumnType("int(11)")
                .HasColumnName("ProveedorID");
            entity.Property(e => e.Total).HasColumnType("int(11)");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_Compras_Proveedores_ProveedorID");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallescompras");

            entity.HasIndex(e => e.CompraId, "IX_DetallesCompras_CompraId");

            entity.HasIndex(e => e.ProductoId, "IX_DetallesCompras_ProductoId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cantidad).HasColumnType("int(11)");
            entity.Property(e => e.CompraId).HasColumnType("int(11)");
            entity.Property(e => e.ProductoId).HasColumnType("int(11)");

            entity.HasOne(d => d.Compra).WithMany(p => p.Detallescompras)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("FK_DetallesCompras_Compras_CompraId");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallescompras)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_DetallesCompras_Productos_ProductoId");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallesventas");

            entity.HasIndex(e => e.ProductoId, "IX_DetallesVentas_ProductoId");

            entity.HasIndex(e => e.VentaId, "IX_DetallesVentas_VentaId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cantidad).HasColumnType("int(11)");
            entity.Property(e => e.ProductoId).HasColumnType("int(11)");
            entity.Property(e => e.VentaId).HasColumnType("int(11)");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallesventa)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_DetallesVentas_Productos_ProductoId");

            entity.HasOne(d => d.Venta).WithMany(p => p.Detallesventa)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK_DetallesVentas_Ventas_VentaId");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("localidades");

            entity.Property(e => e.Id).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.LocalidadId, "IX_Proveedores_LocalidadId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CondicionIva).HasColumnType("int(11)");
            entity.Property(e => e.LocalidadId).HasColumnType("int(11)");

            //entity.HasOne(d => d.Localidad).WithMany(p => p.Proveedores)
            //    .HasForeignKey(d => d.LocalidadId)
            //    .HasConstraintName("FK_Proveedores_Localidades_LocalidadId");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.ClienteId, "IX_Ventas_ClienteId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClienteId).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasMaxLength(6);
            entity.Property(e => e.FormaPago).HasColumnType("int(11)");

            //entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
            //    .HasForeignKey(d => d.ClienteId)
            //    .HasConstraintName("FK_Ventas_Clientes_ClienteId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
