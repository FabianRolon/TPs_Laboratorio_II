using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        /// <summary>
        /// Crea un nuevo correo inicializando sus atributos.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Devuelve todos los paquetes del correo.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        /// <summary>
        /// Le da fin a todos los hilos de las entregas activas.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hiloPaquete in this.mockPaquetes)
            {
                if (hiloPaquete.IsAlive)
                    hiloPaquete.Abort();
            }
        }
        /// <summary>
        /// Publica los datos del correo, con los datos y estado de todos sus paquetes.
        /// </summary>
        /// <param name="elemento">Correo a mostrar.</param>
        /// <returns>Datos del correo.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            Correo correo = (Correo)elemento;
            string datos = String.Empty;
            foreach (Paquete p in correo.Paquetes)
            {
                datos += string.Format("{0} para {1} ({2}) \n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return datos;
        }
        /// <summary>
        /// Agrega un paquete a un correo.
        /// </summary>
        /// <param name="c">Correo al cual se le agregará</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>Correo con el paquete agregado si se pudo agregar.</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("Paquete repetido.");
            }
            c.paquetes.Add(p);
            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();
            return c;
        }
    }
}
