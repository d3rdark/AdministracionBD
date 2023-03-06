using System;
using System.Collections.Generic;

namespace Ejercicio1SpTutorias.Models;

public partial class Asesorias
{
    public int Id { get; set; }

    public string Asesor { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public string Hora { get; set; } = null!;

    public int IdTutorado { get; set; }

    public virtual Alumnos IdTutoradoNavigation { get; set; } = null!;
}
