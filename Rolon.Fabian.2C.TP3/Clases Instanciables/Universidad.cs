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
    public class Universidad
    {
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
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #region Propiedades e Indexador
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
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
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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
        public override string ToString()
        {
            return MostrarDatos(this); 
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out Universidad universidad);
            return universidad;
        }
    }
}



