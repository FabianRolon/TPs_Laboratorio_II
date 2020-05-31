using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase sellada para definir los datos de un profesor universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        #region Atributos y constructores
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Profesor()
            :base()
        {
           
        }
        /// <summary>
        /// Constructor estatico que inicializa el Random.
        /// </summary>
        static Profesor()  
        {
            random = new Random();
        }
        /// <summary>
        /// Instancia un profesor con todos sus datos.
        /// </summary>
        /// <param name="id">Legajo del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor como String</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion
        #region Metodos y sobrecargas de operadores
        /// <summary>
        /// Un profesor es igual a una clase si la está dando.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a encontrar</param>
        /// <returns>Devuelve true si está dando la clase, o false si no.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.claseDelDia.Contains(clase);
        }
        /// <summary>
        /// Un profesor es distinto a una clase si no la está dando.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a encontrar</param>
        /// <returns>Devuelve true si no está dando la clase, o false caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Genera una clase random de cualquiera de los 4 tipos de clase posibles.
        /// </summary>
        private void _randomClases()
        {
            int index = random.Next(0, 4);
            this.claseDelDia.Enqueue((Universidad.EClases)index);
        }
        /// <summary>
        /// Muestra en que clases participa el Profesor.
        /// </summary>
        /// <returns>Clases como String.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{string.Format($"CLASES DEL DIA: ")}");
            foreach (Universidad.EClases e in this.claseDelDia)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve los datos del profesor, incluyendo las clases en las que participa.
        /// </summary>
        /// <returns>Datos del Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"{this.ParticiparEnClase()}");
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del profesor.
        /// </summary>
        /// <returns>Datos del Profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
        #endregion
    }
}
