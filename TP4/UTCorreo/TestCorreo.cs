using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UTCorreo
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correoPrueba;
            correoPrueba = new Correo();
            Assert.IsNotNull(correoPrueba.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Correo_SumaPaqueteRepetido_Throws()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Calle Falsa 1234", "6346346222");
            Paquete PaqueteDos = new Paquete("Av. SiempreViva 742", "6346346222");
            correo += paqueteUno;
            correo += PaqueteDos;
        }
    }
}
