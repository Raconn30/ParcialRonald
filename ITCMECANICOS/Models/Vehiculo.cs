using System;
using System.Collections.Generic;

namespace ITCMECANICOS.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public string? Placa { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
