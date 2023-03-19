using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1SpTutorias.Models
{
    public partial class Alumnos
    {
        public string? NumeroControlNombre
        {
            get
            {
                return $"{NumeroControl.ToUpper()} - {Nombre.ToUpper()}";
            }
        }
    }
}
