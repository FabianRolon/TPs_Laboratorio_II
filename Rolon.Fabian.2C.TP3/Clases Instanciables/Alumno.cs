using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{   /// <summary>
    /// Clase sellada para definir los datoa de un Alumno universitario
    /// </summary>
    public sealed class Alumno : Universitario
    {
        #region Atributos y enumerados
        /// <summary>
        /// Posibles estados de cuenta de un Alumno.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Alumno()
            :base()
        {

        }
        /// <summary>
        /// Crea un alumno con todos sus datos sin el estado de la cuenta.
        /// </summary>
        /// <param name="id">Legajo del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Crea un alumno con todos sus datos.
        /// </summary>
        /// <param name="id">Legajo del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        /// <param name="estadoCuenta">Estado de la Cuenta con sus pagos.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Muestra los datos del Alumno.
        /// </summary>
        /// <returns>Devuelve los datos del Alumno tipo string</returns>
        #endregion
        #region Metodos y operadores
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.MostrarDatos()}");
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine($"ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.AppendLine($"{this.ParticiparEnClase()}");
            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura de Participar en clase
        /// </summary>
        /// <returns>Devuelve en string la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format($"TOMA CLASE DE {this.claseQueToma}");
        }
        /// <summary>
        /// Devuelve los datos del Alumno y los hace publicos.
        /// </summary>
        /// <returns>Devuelve los datos del Alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase con la que compara</param>
        /// <returns>Devuelve true si es igual, false si no.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return clase == a.claseQueToma && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase con la que compara</param>
        /// <returns>Devuelve false si es igual, true si no.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return clase != a.claseQueToma;
        }
        #endregion  
    }
}
