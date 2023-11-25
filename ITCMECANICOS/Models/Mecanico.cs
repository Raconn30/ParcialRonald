using System;
using System.Collections.Generic;

namespace ITCMECANICOS.Models;

public partial class Mecanico
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }
}
