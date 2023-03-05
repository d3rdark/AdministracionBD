using Ejercicio1SpTutorias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Repository
{
    public class ValidadorAlumno
    {
        public static bool Validar(Alumnos entity, out List<string> Errores)
        {
            Errores = new List<string>();

            if (string.IsNullOrWhiteSpace(entity.NumeroControl))
            {
                Errores.Add("Escribe un numero de control.");
            }
            else if (!Regex.IsMatch(entity.NumeroControl, @"\A([00-22]|[91-99]){2}[1](G|D|M|T|P|A|I|){1}(0|D|C|E){1}[0-9]{3}\Z"))
            {
                Errores.Add("El numero de control está formado por lo siguiente: El año de ingreso con dos dígitos por ejemplo: 2022 sería 22." +
                    "Después del año sigue el número 1 que corresponde con el tecnológico desentralizado campus región carbonífera." +
                    "Enseguida sigue la letra de la carrera en esta se cita:" +
                    "Petrolera = P, Industrial=D, Sistemas=G, Mecatrónica=M, Electromecánica=T, Administración=A, Informática=I, Después sigue" +
                    "un caracter el cual puede ser 0 si ingresó regular, C si entro como convalidación, D si es semipresencial, E si es equivalencia" +
                    "y los últimos son 3 dígitos referentes al folio del registro.");
            }

            if (string.IsNullOrWhiteSpace(entity.Nombre))
            {
                Errores.Add("Escribe el nombre de alumno.");
            }
            else if (!Regex.IsMatch(entity.Nombre, @"^[a-z A-Z]+$"))
            {
                Errores.Add("Los nombres no pueden estar conformados por números.");
            }
            if (entity.Promedio > 100)
            {
                Errores.Add("Inserte un promedio valido");
            }

            return Errores.Count == 0;
        }
    }
}
