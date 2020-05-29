using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public enum Eclase
    {
        Programacion,
        Laboratorio,
        Legislacion,
        SPD
    }

    public sealed class Alumno : Universitario
    {
        public enum EEstadoDeCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Eclase claseQueToma;
        private EEstadoDeCuenta estadoCuenta;

        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Eclase claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Eclase claseQueToma, EEstadoDeCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Estado Cuenta: {this.estadoCuenta}");
            sb.AppendLine($"Clase: {this.claseQueToma}");
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return string.Format($"TOMA CLASE DE: {this.claseQueToma}");
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Eclase clase)
        {
            return clase == a.claseQueToma && a.estadoCuenta != EEstadoDeCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Eclase clase)
        {
            return clase == a.claseQueToma;
        }
    }
}
