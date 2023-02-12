using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Models;

namespace Ejercicio1.Repository
{
    internal interface IMenoresRepository
    {
        IEnumerable<Menor> GetMenores();
        IEnumerable<Vwcumplehoy> GetMenoresCumplenHoy();
        IEnumerable<Vwcumplemes> GetMenoresCumplenMes();
        IEnumerable<Vwmayoredad> GetMayoresEdad();
        IEnumerable<Vwmenoresedad> GetMenoresEDad();
    }
}
