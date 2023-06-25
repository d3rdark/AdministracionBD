using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAfin.Repositories
{
    public class Repository<T> where T : class
    {
        public DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
        }


        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual T Get(object id)
        {
            return Context.Find<T>(id);
        }

    }
}
