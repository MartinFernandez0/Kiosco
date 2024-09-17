using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KioscoInformaticoBackend.Migrations
{
    /// <inheritdoc />
    public partial class InicioProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductVersion = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonos = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    LocalidadId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "localidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonos = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cbu = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CondicionIva = table.Column<int>(type: "int(11)", nullable: false),
                    LocalidadId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "localidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormaPago = table.Column<int>(type: "int(11)", nullable: false),
                    ClienteId = table.Column<int>(type: "int(11)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormaDePago = table.Column<int>(type: "int(11)", nullable: false),
                    Iva = table.Column<int>(type: "int(11)", nullable: false),
                    Total = table.Column<int>(type: "int(11)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    ProveedorID = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "proveedores",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "detallesventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VentaId = table.Column<int>(type: "int(11)", nullable: false),
                    ProductoId = table.Column<int>(type: "int(11)", nullable: false),
                    Cantidad = table.Column<int>(type: "int(11)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "detallescompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int(11)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cantidad = table.Column<int>(type: "int(11)", nullable: false),
                    CompraId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "localidades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "San Justo" },
                    { 2, "Videla" },
                    { 3, "Reconquista" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "Id", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Coca-Cola 2lts", 2500m },
                    { 2, "Papas Lays 160grs", 1500m },
                    { 3, "Agua Mineral 2lts", 2000m }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "Direccion", "FechaNacimiento", "LocalidadId", "Nombre", "Telefonos" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Juan Pérez", "123456789" },
                    { 2, "Avenida Siempre Viva 742", new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "María López", "987654321" },
                    { 3, "Boulevard de los Sueños Rotos 101", new DateTime(1978, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carlos García", "555666777" },
                    { 4, "Ruta Nacional 19 Km 58", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ana Martínez", "444555666" }
                });

            migrationBuilder.InsertData(
                table: "proveedores",
                columns: new[] { "Id", "Cbu", "CondicionIva", "Direccion", "LocalidadId", "Nombre", "Telefonos" },
                values: new object[,]
                {
                    { 1, "0000003100010000000001", 0, "Calle 1", 1, "Proveedor A", "111111111" },
                    { 2, "0000003100010000000002", 5, "Calle 2", 2, "Proveedor B", "222222222" },
                    { 3, "0000003100010000000003", 4, "Calle 3", 3, "Proveedor C", "333333333" },
                    { 4, "0000003100010000000004", 2, "Calle 4", 1, "Proveedor D", "444444444" },
                    { 5, "0000003100010000000005", 3, "Calle 5", 1, "Proveedor E", "555555555" },
                    { 6, "0000003100010000000006", 1, "Calle 6", 2, "Proveedor F", "666666666" },
                    { 7, "0000003100010000000007", 0, "Calle 7", 3, "Proveedor G", "777777777" },
                    { 8, "0000003100010000000008", 6, "Calle 8", 2, "Proveedor H", "888888888" },
                    { 9, "0000003100010000000009", 5, "Calle 9", 3, "Proveedor I", "999999999" },
                    { 10, "0000003100010000000010", 2, "Calle 10", 3, "Proveedor J", "101010101" }
                });

            migrationBuilder.InsertData(
                table: "compras",
                columns: new[] { "ID", "Fecha", "FormaDePago", "Iva", "ProveedorID", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 21, 1, 1000 },
                    { 2, new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, 2, 2000 },
                    { 3, new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3, 3000 },
                    { 4, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 4, 4000 }
                });

            migrationBuilder.InsertData(
                table: "ventas",
                columns: new[] { "Id", "ClienteId", "Fecha", "FormaPago", "Iva", "Total" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 13, 15, 27, 39, 298, DateTimeKind.Local).AddTicks(301), 0, 21m, 3000m },
                    { 2, 2, new DateTime(2024, 9, 13, 15, 27, 39, 298, DateTimeKind.Local).AddTicks(313), 1, 10m, 5000m },
                    { 3, 1, new DateTime(2024, 9, 13, 15, 27, 39, 298, DateTimeKind.Local).AddTicks(315), 2, 21m, 8000m }
                });

            migrationBuilder.InsertData(
                table: "detallescompras",
                columns: new[] { "Id", "Cantidad", "CompraId", "PrecioUnitario", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2650m, 1 },
                    { 2, 2, 2, 2450m, 2 },
                    { 3, 1, 3, 2550m, 3 }
                });

            migrationBuilder.InsertData(
                table: "detallesventas",
                columns: new[] { "Id", "Cantidad", "PrecioUnitario", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 1, 2650m, 1, 1 },
                    { 2, 2, 2450m, 2, 2 },
                    { 3, 1, 2550m, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadId",
                table: "clientes",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorID",
                table: "compras",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_CompraId",
                table: "detallescompras",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_ProductoId",
                table: "detallescompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_ProductoId",
                table: "detallesventas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_VentaId",
                table: "detallesventas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_LocalidadId",
                table: "proveedores",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "ventas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "detallescompras");

            migrationBuilder.DropTable(
                name: "detallesventas");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "localidades");
        }
    }
}
