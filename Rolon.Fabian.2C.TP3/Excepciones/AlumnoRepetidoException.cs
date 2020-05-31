using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para el caso que haya alumnos repetidos.
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
            :base("Alumno repetido")
        {

        }
    }
}
