using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion para controlar los casos en que no coincida el dni con una nacionalidad.
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            :base("La nacionalidadno no se condice con el número de DNI")
        {

        }
        public NacionalidadInvalidaException(string message)
            :base(message)
        {

        }
    }
}
