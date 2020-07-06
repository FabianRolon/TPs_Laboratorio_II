using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepción que se lanzará en caso que un Tracking ID se encuentre repetido.
    /// </summary>
    [Serializable]
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
