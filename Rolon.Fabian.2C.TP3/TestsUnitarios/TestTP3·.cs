using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestTP3
    {
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
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "16556h44",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
        }
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "1655644",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
        }
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
