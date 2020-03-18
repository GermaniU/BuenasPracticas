using System;
using Business.CalculosCostosAdiccionales;
using Business.ObtenedoresInformacion;
using Entidades;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Business.Test
{
    [TestClass()]
    public class ObtenedorCostoEnvioTest
    {
        [TestMethod()]
        public void costoPaquete_EstafetaTerrestre80KM_CalculoCorrecto()
        {
            //Arrange
            var distancia = 80M;
            var paqueteria = "Estafeta";
            var FechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var costoEsperado = 1160M;
            var tipoTransporte = "Terrestre";

            var docObtenerCostoPorKilometroTerrestre = new ObtenedorCostoPorKilometroTerrestre();
            var docCalculaAdiccionalPorEscala = new CalculaCostoAdiccionalPorEscala();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadEstafeta();
            var calculaUtilidadFedex = new CalcularUtilidadPaqueteria(docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalAdiccionalEnvioAereo(docCalculaAdiccionalPorEscala, calculaUtilidadFedex);

            var SUT = new CalculaCostoEnvio(docObtenerCostoPorKilometroTerrestre, docCalculaCostoAereo);

            //Act 

            var costoPedido = SUT.costoPaquete(distancia,paqueteria, FechaPedido);
          
            //Assert
            Assert.AreEqual(costoEsperado, costoPedido);
        }

        [TestMethod()]
        public void costoPaquete_DHLAereo400KM_CalculoCorrecto()
        {
            //Arrange
            var distancia = 400M;
            var paqueteria = "DHL";
            var fechaPedido = new DateTime(2020,01,23,13,50,00);
            var costoEsperado = 6000.00M;
            var tipoTransporte = "Aereo";

            var docObtenerCostoPorKilometroAereo = new ObtenedorCostoPorKilometroAereo();
            var docCalculaAdiccionalPorEscala = new CalculaCostoAdiccionalPorEscala();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadDHL();
            var calculaUtilidadFedex = new CalcularUtilidadPaqueteria(docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalAdiccionalEnvioAereo(docCalculaAdiccionalPorEscala, calculaUtilidadFedex);

            var SUT = new CalculaCostoEnvio(docObtenerCostoPorKilometroAereo, docCalculaCostoAereo);

            //Act
            var costoPedido = SUT.costoPaquete(distancia, paqueteria, fechaPedido);
            
            //Assert
            Assert.AreEqual(costoEsperado, costoPedido);
        }

        [TestMethod()]
        public void costoPaquete_FedexAereo400KM_CalculoCorrecto()
        {
            //Arrange
            var distancia = 400M;
            var paqueteria = "Fedex";
            var fechaPedido = new DateTime(2020, 01, 23, 13, 50, 00);
            var costoEsparado = 5200.00M;
            var tipoTransporte = "Aereo";

            var docObtenerCostoPorKilometroAereo = new ObtenedorCostoPorKilometroAereo();
            var docCalculaAdiccionalPorEscala = new CalculaCostoAdiccionalPorEscala();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadFedex();
            var calculaUtilidadFedex = new CalcularUtilidadPaqueteria(docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalAdiccionalEnvioAereo(docCalculaAdiccionalPorEscala, calculaUtilidadFedex);

            var SUT = new CalculaCostoEnvio(docObtenerCostoPorKilometroAereo, docCalculaCostoAereo);

            //Act
            var costoPedido = SUT.costoPaquete(distancia, paqueteria, fechaPedido);

            //Assert
            Assert.AreEqual(costoEsparado, costoPedido);
        }


        [TestMethod()]
        public void costoPaquete_DHLAereo446400KMAplicaCostoAdiccionalPorEscala_CalculoCorrecto()
        {
            //Arrange
            var distancia = 446400;
            var paqueteria = "DHL";
            var fechaPedido = new DateTime(2020, 01, 23, 8, 00, 00);
            var costoEsparado = 6829800M;
            var tipoTransporte = "Aereo";

            var docObtenerCostoPorKilometroAereo = new ObtenedorCostoPorKilometroAereo();
            var docCalculaAdiccionalPorEscala = new CalculaCostoAdiccionalPorEscala();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadDHL();
            var calculaUtilidadFedex = new CalcularUtilidadPaqueteria( docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalAdiccionalEnvioAereo(docCalculaAdiccionalPorEscala, calculaUtilidadFedex);

            var SUT = new CalculaCostoEnvio(docObtenerCostoPorKilometroAereo, docCalculaCostoAereo);

            //Act
            var costoPedido = SUT.costoPaquete(distancia, paqueteria, fechaPedido);


            Assert.AreEqual(costoEsparado, costoPedido);
        }


        [TestMethod()]
        public void costoPaquete_FedexAereo446400KMAplicaCostoAdiccionalPorEscala_CalculoCorrecto()
        {
            //Arrange
            var distancia = 446400;
            var paqueteria = "Fedex";
            var fechaPedido = new DateTime(2020, 01, 23, 8, 00, 00);
            var costoEsparado = 5919160M;
            var tipoTransporte = "Aereo";

            var docObtenerCostoPorKilometroAereo = new ObtenedorCostoPorKilometroAereo();
            var docCalculaAdiccionalPorEscala =  new CalculaCostoAdiccionalPorEscala();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadFedex();
            var calculaUtilidad = new CalcularUtilidadPaqueteria(docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalAdiccionalEnvioAereo(docCalculaAdiccionalPorEscala, calculaUtilidad);

            var SUT = new CalculaCostoEnvio(docObtenerCostoPorKilometroAereo, docCalculaCostoAereo);

            //Act
            var costoPedido = SUT.costoPaquete(distancia, paqueteria, fechaPedido);


            Assert.AreEqual(costoEsparado, costoPedido);
        }

        [TestMethod()]
        public void costoPaquete_DHLMaritimo9000KMAplicaCostoAdiccionalPorEscala_CalculoCorrecto()
        {
            //Arrange
            var distancia = 9000;
            var paqueteria = "DHL";
            var fechaPedido = new DateTime(2020, 01, 23, 8, 00, 00);
            var costoEsparado = 4981.5M;
            var tipoTransporte = "Maritimo";

            var obtenedorCostoPorKilometroMaritimo = new ObtenedorCostoPorKilometroMaritimo();
            var docCalculaAdiccionalPorTemporada = new CalculaCostoAdiccionalPorTemporadaInvierno();
            var docObtenedorUtilidadPaqueteria = new ObtenedorUtilidadDHL();
            var calculaUtilidadDHL = new CalcularUtilidadPaqueteria(docObtenedorUtilidadPaqueteria);
            var docCalculaCostoAereo = new CalculaCostoAdiccionalEnvioMaritimo(calculaUtilidadDHL, docCalculaAdiccionalPorTemporada);

            var SUT = new CalculaCostoEnvio(obtenedorCostoPorKilometroMaritimo, docCalculaCostoAereo);


            //Act
            var costoPedido = SUT.costoPaquete(distancia, paqueteria, fechaPedido);


            Assert.AreEqual(costoEsparado, costoPedido);
        }
    }
}