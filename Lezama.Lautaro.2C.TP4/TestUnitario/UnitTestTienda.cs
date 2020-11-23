using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTestTienda
    {
        [TestMethod]
        public void ValidarSerializacionXml()
        {
            Tienda tienda = new Tienda("Tienda Unitaria", "Acoyte 1423", 11, 16);
            Remera r1 = new Remera(123, 200, Prenda.EColor.Azul, Remera.EManga.Musculosa);
            Tienda tiendaTest;
            Xml<Tienda> xml = new Xml<Tienda>();
            xml.Guardar(tienda, "TestUnitario.xml");
            tiendaTest = xml.Leer("TestUnitario.xml");
            Assert.IsTrue(tienda.Nombre == tiendaTest.Nombre && tienda.HorasAbierto == tiendaTest.HorasAbierto);
        }

        [ExpectedException(typeof(ErrorArchivoException))]
        [TestMethod]
        public void ValidarExcepcionDeArchivoInexistente()
        {
            Texto texto = new Texto();
            texto.Leer("ArchivoInexistente.txt");
        }
    }
}
