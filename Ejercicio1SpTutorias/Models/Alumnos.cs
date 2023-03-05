using System;
using System.Collections.Generic;

namespace Ejercicio1SpTutorias.Models;

public partial class Alumnos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string NumeroControl { get; set; } = null!;

    public double Promedio { get; set; }

    public string? Evaluacion { get; set; }
}
