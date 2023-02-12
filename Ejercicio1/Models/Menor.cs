using System;
using System.Collections.Generic;

namespace Ejercicio1.Models;

public partial class Menor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Domicilio { get; set; }
}
