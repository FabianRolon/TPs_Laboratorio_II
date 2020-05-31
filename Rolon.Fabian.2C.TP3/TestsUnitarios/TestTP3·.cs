using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestTP3
    {
        /// <summary>
        /// Metod que testea que lance la excepcion correcta al querer añadir un alumno repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "Juana", "Martinez", "12234458",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            uni += a1;
            uni += a2;  
        }
        /// <summary>
        /// Metodo que testea que al ingresar un dni invalido lance la excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "16556h44",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// Metodo que testea que al no coincidir el dni con la nacionalidad lance una excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "1655644",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// Metodo que testea que las listas se inicialicen correctamente en la clase Universidad
        /// </summary>
        [TestMethod]
        public void ListasUniversidadNoNull()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);
        }
    }
}
