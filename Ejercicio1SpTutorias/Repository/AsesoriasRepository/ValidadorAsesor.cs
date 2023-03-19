using Ejercicio1SpTutorias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Repository.AsesoriasRepository
{
    public class ValidadorAsesor
    {
        public static bool Validar(Asesorias entity, out List<string> Errores)
        {
            Errores = new List<string>();
            if (string.IsNullOrWhiteSpace(entity.Asesor))
            {
                Errores.Add("Escribe el nombre del asesor.");
            }
            else if(!Regex.IsMatch(entity.Asesor, @"^[a-z A-Z]+$"))
            {
                Errores.Add("Los nombres no pueden estar conformados por números.");
            }

            return Errores.Count == 0;
        }
    }
}
