using System;
using System.Collections.Generic;

namespace FilmAfin.Models;

public partial class Genero
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Generos> Generos { get; set; } = new List<Generos>();
}
