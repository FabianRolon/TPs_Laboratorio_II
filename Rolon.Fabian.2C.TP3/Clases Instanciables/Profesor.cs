using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        public Profesor()
            :base()
        {
           
        }
        static Profesor()  
        {
            random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.claseDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        private void _randomClases()
        {
            int index = random.Next(0, 4);
            this.claseDelDia.Enqueue((Universidad.EClases)index);
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"{this.ParticiparEnClase()}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
    }
}
