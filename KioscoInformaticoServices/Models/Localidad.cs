using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KioscoInformaticoServices.Models;

public partial class Localidad
{
    public int Id { get; set; }

    [Required (ErrorMessage = "El campo nombre es obligatorio")]
    public string Nombre { get; set; } = null!;
    public override string ToString() => Nombre;

    public bool Eliminado { get; set; } = false;
}
