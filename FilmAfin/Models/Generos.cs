using System;
using System.Collections.Generic;

namespace FilmAfin.Models;

public partial class Generos
{
    public int Id { get; set; }

    public int IdPelicula { get; set; }

    public int IdGenero { get; set; }

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual Peliculas IdPeliculaNavigation { get; set; } = null!;
}
