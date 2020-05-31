using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase Abstracta de Universitarios.
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region Constructores
        private int legajo;
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Universitario()
            :base()
        {

        }
        /// <summary>
        /// Instancia un universitario.
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
        #region Operadores y sobrecargas
        /// <summary>
        /// Un universitario es igual a otro si son del mismo tipo, y su legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Primer Universitario a Comparar</param>
        /// <param name="pg2">Segundo Universitario a Comparar</param>
        /// <returns>Devuelve true si son iguales o false si no.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }
        /// <summary>
        /// Un universitario es igual a otro si son del mismo tipo, y su legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Primer Universitario a Comparar</param>
        /// <param name="pg2">Segundo Universitario a Comparar</param>
        /// <returns>Devuelve false si son iguales o true si no.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Verifica si son del mismo tipo.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>Devuelve true si son iguales, o false si no.</returns>
        public override bool Equals(Object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Muestra los datos de un universitario.
        /// </summary>
        /// <returns>Devuelve los datos completos.</returns>
        #endregion
        #region Metodos
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }
        /// <summary>
        /// Metodo abstracto a implemtar en las clases derivadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
