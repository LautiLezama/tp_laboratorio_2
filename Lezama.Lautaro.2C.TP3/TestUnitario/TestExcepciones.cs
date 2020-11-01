using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDniInvalido()
        {
            Alumno unAlumno = new Alumno(30, "Pepe", "Mujica", "DniInvalido", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidarAlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno unAlumno = new Alumno();
            uni += unAlumno;
            uni += unAlumno;
        }

        [TestMethod]
        public void ValidarColeccion()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
        }
    }


}
