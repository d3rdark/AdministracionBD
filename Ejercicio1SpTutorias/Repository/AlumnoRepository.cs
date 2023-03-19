using Ejercicio1SpTutorias.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly TutoriasContext context = new TutoriasContext();

        public void CreateSP(Alumnos entity)
        {
            context.Database.ExecuteSqlRaw($"execute sp_registraralumno @P_Nombre ='{entity.Nombre}', @P_NumeroControl ='{entity.NumeroControl}', @P_Promedio={entity.Promedio} ;");
        }

        public void Delete(Alumnos entity)
        {
            context.Remove(entity);
        }

        public Alumnos? GetAlumnoById(int id)
        {
            return context.Alumnos.Find(id);
        }

        public IEnumerable<Alumnos> GetAlumnos()
        {
            return context.Alumnos.Include(x => x.Asesorias).OrderBy(x => x.Nombre);
        }

        public void UpdateSP(Alumnos entity)
        {
            context.Database.ExecuteSqlRaw($"execute SP_Actualizar_alumno @P_Id ={entity.Id}, @P_Nombre ='{entity.Nombre}', @P_NumeroControl ='{entity.NumeroControl}', @P_Promedio={entity.Promedio} ;");
        }

        public void Update(Alumnos entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
