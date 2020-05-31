using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase para definir Jornadas universitarias, con su clase, profesor y lista de alumnos inscriptos. 
    /// </summary>
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region Constructores
        /// <summary>
        /// Instancia una Jornada, inicializando la lista de Alumnos.
        /// </summary>

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Instancia una jornada con su clase y profesor.
        /// </summary>
        /// <param name="clase">Clase que se dará en la Jornada</param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion
        #region Metodos y sobrecargas de operadoes
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a Comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si el alumno toma la clase, si no devuelve false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }
        /// <summary>
        /// Una Jornada será distinto a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a Comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si el alumno no toma la clase, si no devuelve false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada indicada si no se encuentra en la lista.
        /// </summary>
        /// <param name="j">Jornada a la cual se le agregará el Alumno.</param>
        /// <param name="a">Alumno a Agregar.</param>
        /// <returns>Devuelve la Jornada, ya sea que se le pudo agregar el alumno o no.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {

            if (j == a)
            {
                foreach (Alumno alumno in j.alumnos)
                {
                    if (a == alumno)
                    {
                        return j;
                    }
                }
                j.alumnos.Add(a);
                return j; 
            }
            return j;
        }
        /// <summary>
        /// Devuelve los datos de la jornada.
        /// </summary>
        /// <returns>Devuelve los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CLASE DE: {this.Clase} ");
            sb.Append($"POR {this.Instructor.ToString()}");
            sb.AppendLine($"Alumnos:");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine($"{alumno.ToString()}");
            }
            return sb.ToString(); 
        }
        /// <summary>
        /// Guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar en el archivo</param>
        /// <returns>Devuelve true si la Jornada fue guardada, o lanza ArchivosException si no se pudo.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee la jornada guardada y la devuelve como string.
        /// </summary>
        /// <returns>Contenido de la Jornada como String.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out string jornada);
            return jornada;
        }
        #endregion
    }
}
