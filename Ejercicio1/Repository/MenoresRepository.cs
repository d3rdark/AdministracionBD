using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Models;

namespace Ejercicio1.Repository
{
    public class MenoresRepository: IMenoresRepository
    {
        FestejoContext context = new FestejoContext();

        public IEnumerable<Vwmayoredad> GetMayoresEdad()
        {
            return context.Vwmayoredad.OrderBy(x => x.Nombre);
        }

        public IEnumerable<Menor> GetMenores()
        {
            return context.Menor.OrderBy(x => x.Id);
        }

        public IEnumerable<Vwcumplehoy> GetMenoresCumplenHoy()
        {
            return context.Vwcumplehoy.OrderBy(x => x.Nombre);
        }

        public IEnumerable<Vwcumplemes> GetMenoresCumplenMes()
        {
            return context.Vwcumplemes.OrderBy(x => x.Nombre);
        }

        public IEnumerable<Vwmenoresedad> GetMenoresEDad()
        {
            return context.Vwmenoresedad.OrderBy(x => x.Nombre);
        }
    }
}
