using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase Abstracta para definir todas las clases del tipo Persona
    /// </summary>
    public abstract class Persona
    {
        #region Atributos y Enumerados
        /// <summary>
        /// Nacionalidades posibles.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion
        #region Constructores
        public Persona()
        {

        }
        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos menos el DNI.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos, solo DNI del tipo int.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos, solo DNI del tipo string.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringtoDNI = dni;
        }
        #endregion
        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != String.Empty)
                {
                    this.apellido = value;
                }
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
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
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
                if (ValidarNombreApellido(value) != String.Empty)
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Guarda un String como DNI.
        /// </summary>
        public string StringtoDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Muestra los datos de la Persona.
        /// </summary>
        /// <returns>Datos de la Persona como String.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");        
            sb.AppendLine($"DNI: {this.DNI}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            return sb.ToString();
        }
        /// <summary>
        /// Comprueba que el nombre o apellido no posean espacios y que sean letras.
        /// </summary>
        /// <param name="dato">Dato a validar.</param>
        /// <returns>Devuelve el nombre si es valido, o null si no.</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!Char.IsLetter(item) || Char.IsWhiteSpace(item))
                {
                    return String.Empty;
                }
            }
            return dato;
        }
        /// <summary>
        /// Comprueba que el DNI sea valido.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI de la Persona.</param>
        /// <returns>Devuelve el DNi si es valido, si no lanza NacionalidadInvalidaException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }
        /// <summary>
        /// Compureba que el DNI como String sea valido.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI de la Persona.</param>
        /// <returns>Devuelve el DNI si es valido, si no lanza DniInvalidoException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (int.TryParse(dato, out int dni))
            {
                return ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        #endregion
    }
}
