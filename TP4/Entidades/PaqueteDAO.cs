using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase para Guardar paquetes en una base de datos.
    /// </summary>
    public static class PaqueteDAO
    {
        private const string alumno = "Fabian Rolon";
        private const string localHost = "FAO";
        private static SqlCommand comando;
        private static SqlConnection conexion;
        /// <summary>
        /// Inicializa las variables para utilizarse en los metodos, con el comando y el connection string.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source=" + localHost + "\\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = true;");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        /// <summary>
        /// Inserta un paquete en la base de datos.
        /// </summary>
        /// <param name="p">Paquete a Guardar</param>
        /// <returns>Devuelve true si salio todo bien, lanza una excepcion si falló algo.</returns>
        public static void Insertar(Paquete p)
        {
            try
            {
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Paquetes VALUES(@direccionEntrega, @trackingID, @alumno)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID));
                comando.Parameters.Add(new SqlParameter("alumno", alumno));
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.ExecuteNonQuery();
            }
            
            catch (Exception ex)
            {
                throw new Exception("Error de SQL", ex);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
