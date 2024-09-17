using KioscoInformaticoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoServices.Class
{
    public static class ApiEndpoints
    {
        public static string Cliente { get; set; } = "Clientes";
        public static string Compra { get; set; } = "Compras";
        public static string DetalleCompra { get; set; } = "DetallesCompras";
        public static string Venta { get; set; } = "Ventas";
        public static string DetalleVenta { get; set; } = "DetallesVentas";
        public static string Localidad { get; set; } = "Localidades";
        public static string Producto { get; set; } = "Productos";
        public static string Proveedor { get; set; } = "Proveedores";
        

        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Cliente) => Cliente,
                nameof(Compra) => Compra,
                nameof(DetalleCompra) => DetalleCompra,
                nameof(Venta) => Venta,
                nameof(DetalleVenta) => DetalleVenta,
                nameof(Localidad) => Localidad,
                nameof(Producto) => Producto,
                nameof(Proveedor) => Proveedor,
                
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
