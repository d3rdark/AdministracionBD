using System;
using System.Collections.Generic;

namespace FilmAfin.Models;

public partial class Peliculas
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Año { get; set; }

    public string? Pais { get; set; }

    public string? TituloOriginal { get; set; }

    public virtual ICollection<Generos> Generos { get; set; } = new List<Generos>();
}
