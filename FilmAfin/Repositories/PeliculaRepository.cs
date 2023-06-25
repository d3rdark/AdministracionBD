using FilmAfin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAfin.Repositories
{
    public class PeliculaRepository : Repository<Peliculas>
    {
        

        public PeliculaRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Peliculas> GetAll()
        {
            return Context.Set<Peliculas>().OrderBy(x => x.TituloOriginal);
        }
    }
}
