using Business.CalculosCostosAdiccionales;
using Business.ObtenedoresInformacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Business.Test
{
    [TestClass()]
    public class CalculaCostoEnvioMaritimoTest
    {
        [TestMethod()]
        public void CalcularCostoAdiccionalEnvio_DHLMaritimo9000KMInvierno_CalculoCorrecto()
        {
            //Arrange 
            var distancia = 9000;
            var paqueteria = "DHL";
            var fechaPedido = new DateTime(2020, 01, 23, 8, 00, 00);
            var costoEsperado = 4981.5M;
            var costoTransportacion = 2700M;

            var docObtenedorUtilidadDHL = new ObtenedorUtilidadDHL();
            var docCalculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria( docObtenedorUtilidadDHL);
            var docCalculaCostoPorTemporadaInvierno = new CalculaCostoAdiccionalPorTemporadaInvierno();


            var SUT = new CalculaCostoAdiccionalEnvioMaritimo(docCalculaUtilidadPaqueteria, docCalculaCostoPorTemporadaInvierno);

            //Act
            var costoEnvioMaritimo =  SUT.CalcularCostoAdiccionalEnvio(costoTransportacion, distancia, fechaPedido, paqueteria);

            //Assert
            Assert.AreEqual(costoEsperado, costoEnvioMaritimo);
        }

        [TestMethod()]
        public void CalcularCostoAdiccionalEnvio_DHLMaritimo9000KMPrimavera_CalculoCorrecto()
        {
            //Arrange 
            var distancia = 9000;
            var paqueteria = "DHL";
            var fechaPedido = new DateTime(2020, 03, 23, 8, 00, 00);
            var costoEsperado = 4050M;
            var costoTransportacion = 2700M;

            var docObtenedorUtilidadDHL = new ObtenedorUtilidadDHL();
            var docCalculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria(docObtenedorUtilidadDHL);
            var docCalculaCostoPorTemporadaPrimavera = new CalculaCostoAdiccionalPorTemporadaPrimavera();

            var SUT = new CalculaCostoAdiccionalEnvioMaritimo(docCalculaUtilidadPaqueteria, docCalculaCostoPorTemporadaPrimavera);

            //Act
            var costoEnvioMaritimo = SUT.CalcularCostoAdiccionalEnvio(costoTransportacion, distancia, fechaPedido, paqueteria);

            //Assert
            Assert.AreEqual(costoEsperado, costoEnvioMaritimo);
        }

        [TestMethod()]
        public void CalcularCostoAdiccionalEnvio_EstafetaMaritimo9000KMOtonio_CalculoCorrecto()
        {
            //Arrange 
            var distancia = 9000;
            var paqueteria = "Estafeta";
            var fechaPedido = new DateTime(2020, 09, 23, 8, 00, 00);
            var costoEsperado = 4502.25M;
            var costoTransportacion = 2700M;

            var docObtenedorUtilidadDHL = new ObtenedorUtilidadEstafeta();
            var docCalculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria(docObtenedorUtilidadDHL);
            var docCalculaCostoPorTemporadaOtonio = new CalculaCostoAdiccionalPorTemporadaOtonio();

            var SUT = new CalculaCostoAdiccionalEnvioMaritimo(docCalculaUtilidadPaqueteria, docCalculaCostoPorTemporadaOtonio);

            //Act
            var costoEnvioMaritimo = SUT.CalcularCostoAdiccionalEnvio(costoTransportacion, distancia, fechaPedido, paqueteria);

            //Assert
            Assert.AreEqual(costoEsperado, costoEnvioMaritimo);
        }

    }
}