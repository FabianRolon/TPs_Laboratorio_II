using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
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
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
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
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }
        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out string jornada);
            return jornada;
        }
    }
}
