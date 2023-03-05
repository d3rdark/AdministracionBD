using Ejercicio1SpTutorias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Repository
{
    public interface IAlumnoRepository
    {
        public Alumnos? GetAlumnoById(int id);
        public IEnumerable<Alumnos> GetAlumnos();
        public void CreateSP(Alumnos entity);
        public void UpdateSP(Alumnos entity);
        public void Upadate(Alumnos entity);
        public void Delete(Alumnos entity);
        public void Save();
        
    }
}
