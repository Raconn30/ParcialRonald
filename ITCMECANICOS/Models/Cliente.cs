using System;
using System.Collections.Generic;

namespace ITCMECANICOS.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
