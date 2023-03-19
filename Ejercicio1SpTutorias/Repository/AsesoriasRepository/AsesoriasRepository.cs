using Ejercicio1SpTutorias.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Repository.AsesoriasRepository
{
    public class AsesoriasRepository
    {
        private readonly TutoriasContext context = new TutoriasContext();

        public AsesoriasRepository()
        {
            
        }

        public Asesorias? GetAsesoriasById(int id)
        {
            return context.Asesorias.Find(id);
        }

        public IEnumerable<Asesorias> GetAsesorias()
        {
            return context.Asesorias.Include(x => x.IdTutoradoNavigation).OrderBy(x => x.Asesor);
        }
        public IEnumerable<Asesorias> GetAllAsesoriasById(int id)
        {
            return context.Asesorias.Include(x => x.IdTutoradoNavigation).Where(x => x.IdTutorado == id);
        }
        public void Create(Asesorias entity)
        {
            context.Add(entity);
        }

        public void Update(Asesorias entity)
        {
            context.Update(entity);
        }

        public void Delete(Asesorias entity)
        {
            context.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
