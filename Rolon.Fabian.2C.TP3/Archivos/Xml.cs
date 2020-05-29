using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        T datos;
        public bool Guardar(string archivo, T datos)
        {
            return true;
        }
        public bool Leer(string archivo, out T datos)
        {
            return true;
        }
    }
}
