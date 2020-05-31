using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase para guardar los datos de una Universidad.
    /// </summary>
    public class Universidad
    {
        #region Enumerado y atributos
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion
        #region Constructor, indexador y propiedades
        /// <summary>
        /// Instancia una universidad, inicializando todos sus atributos.
        /// </summary>

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

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
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                jornada[i] = value;
            }
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Un alumno es igual a una universidad si el alumno está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="a">Alumno a Comparar</param>
        /// <returns>Devuelve true si el alumno´está en la Universidad, o false si no.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Un alumno es distinto a una universidad si el alumno no está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="a">Alumno a Comparar</param>
        /// <returns>Devuelve false si el alumno está en la Universidad, o true si no.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un profesor es igual a una universidad si el profesor está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="i">Profesor a Comparar</param>
        /// <returns>Devuelve true si el profesor´está en la Universidad, o false si no.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Un profesor es distinto a una universidad si el profesor no está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="i">Profesor a Comparar</param>
        /// <returns>Devuelve true si el profesor está en la Universidad, o false si no.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Una universidad es igual a una clase si hay algun profesor dandola.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="clase">Clase a Comparar</param>
        /// <returns>Devuelve el profesor que la está dando si lo hay, y si no lanza SinProfesorException.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe == clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="clase">Clase a Comparar</param>
        /// <returns>Devuelve el primer profesor que no pueda dar la clase, y si no lanza SinProfesorException.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe != clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega una clase a la universidad, asignando una Jornada para la misma, con su profesor y alumnos correspondientes.
        /// </summary>
        /// <param name="g">Universidad a la cual se le agregará.</param>
        /// <param name="clase">Clase a Agregar</param>
        /// <returns>Devuelve la universidad a la cual se le agregó la clase.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        /// <summary>
        /// Agrega un profesor a la universidad si no existe en la misma.
        /// </summary>
        /// <param name="u">Universidad a la cual se le agregará.</param>
        /// <param name="i">Profesor a agregar./param>
        /// <returns>Devuelve la universidad, con el profesor agregado (si se pudo agregar) o no.</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return g;
            }
            g.Instructores.Add(i);
            return g;
        }
        /// <summary>
        /// Añade un alumno a la universidad si no existe en la misma.
        /// </summary>
        /// <param name="u">Universidad a la cual se le agregará.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Devuelve la universidad con el alumno agregado si se agregó, o lanza AlumnoRepetidoException si no.</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {

                if (alumno == a)
                    throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Muestra los datos de la universidad, mostrando que clase se da en cada Jornada.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string  MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.jornada)
            {
                sb.Append(item.ToString());
                sb.AppendLine("<---------------------------------------------------->\n");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve los datos de la universidad.
        /// </summary>
        /// <returns>Datos de la Universidad.</returns>
        public override string ToString()
        {
            return MostrarDatos(this); 
        }
        /// <summary>
        /// Guarda la Universidad en un archivo XML.
        /// </summary>
        /// <param name="uni">Universidad a Guardar.</param>
        /// <returns>Devuelve True si se pudo guardar, o lanza ArchivosException si no se pudo.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Lee la Universidad guardada en un archivo XML.
        /// </summary>
        /// <param name="uni">Universidad a Leer.</param>
        /// <returns>Devuelve True si se pudo leer, o lanza ArchivosException si no se pudo.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out Universidad universidad);
            return universidad;
        }
        #endregion
    }
}



