using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KioscoInformaticoServices.Models;

public partial class Producto
{
    public int Id { get; set; }

    [Required] 
    public string Nombre { get; set; } = null!;

    [Required]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
    public decimal Precio { get; set; }

    public virtual ICollection<DetalleCompra> Detallescompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> Detallesventa { get; set; } = new List<DetalleVenta>();
}
