using System;
using System.Collections.Generic;

namespace FilmAfin.Models;

public partial class PeliculasBackup
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Año { get; set; }

    public string? Pais { get; set; }

    public string? TituloOriginal { get; set; }
}
