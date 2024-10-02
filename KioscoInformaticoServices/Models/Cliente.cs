using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KioscoInformaticoServices.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Direccion { get; set; }

    public string Telefonos { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int? LocalidadId { get; set; }

    public virtual Localidad? Localidad { get; set; }

    //public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
