using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        T datos;
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer;
            XmlSerializer ser;
            //Se indica ubicación del archivo XML y su codificación.
            writer = new XmlTextWriter(, Codificación);
            //Se indica el tipo de objeto ha serializar.
            ser = new XmlSerializer(typeof(Dato));
            //Serializa el objeto p en el archivo contenido en writer.
            ser.Serialize(writer, p);
            //Se cierra la conexión al archivo
            writer.Close();

            return true;
        }
        public bool Leer(string archivo, out T datos)
        {
            return true;
        }
    }
}
