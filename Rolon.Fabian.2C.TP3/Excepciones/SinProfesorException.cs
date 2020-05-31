using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Exceocion para controlar cuando no hay profesores disponibles para una clase.
    /// </summary>
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            :base("No hay profesor para la clase")
        {
        }
    }
}
