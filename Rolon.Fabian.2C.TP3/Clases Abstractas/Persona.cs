using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringtoDNI = dni;
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public ENacionalidad Naciolidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string StringtoDNI
        {
            get
            {
                return this.dni.ToString();
            }
            set
            {
                this.dni = int.Parse(value);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"DNI: {this.DNI}");
            sb.AppendLine($"Nacionalidad: {this.Naciolidad}");
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && dato < 89999999 && dato >1)
            {
                return dato;
            }
            return 1;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 1;
        }
    }
}
