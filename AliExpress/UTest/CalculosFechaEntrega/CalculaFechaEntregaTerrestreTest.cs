using Business.ObtenedoresInformacion;
using Business.ObtenedoresInformacion.Patrones.Bridge;
using Interfaces.Business.ObtenedoresInformacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Business.CalculosFechaEntrega.Test
{
    [TestClass()]
    public class CalculaFechaEntregaTerrestreTest
    {
        [TestMethod()]
        public void ObtenerFechaEntrega_Estafeta80KMTerrestre_ResultadoCorrecto()
        {
            //Arrange
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 80M;
            var  FechaEsperada = new DateTime(2020, 01, 23, 13, 00, 00);

            var docTiempoReparto = new GeneralEstafeta();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenerdorTiempoDescansoInvierno = new ObtenedorTiempoDescansoPorDiaInvierno();
            var docCalculaRetrasoPorDia = new CalculaRetrasoPorDia(docObtenerdorTiempoDescansoInvierno);

            var SUT = new CalculaFechaEntregaTerrestre(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docCalculaRetrasoPorDia);

            //Act
            var fechaEntregaPaquete = SUT.ObtenerFechaEntregaMedioTransporte(distancia,fechaPedido);
            
            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntregaPaquete);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_Estafeta4000KMTerrestreAplicaRetrasoPorDia_ResultadoCorrecto()
        {
            //Arrange
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 4000M;
            var FechaEsperada = new DateTime(2020, 01, 26, 6, 00, 00);

            var docTiempoReparto = new GeneralEstafeta();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenerdorTiempoDescansoInvierno = new ObtenedorTiempoDescansoPorDiaInvierno();
            var docCalculaRetrasoPorDia = new CalculaRetrasoPorDia(docObtenerdorTiempoDescansoInvierno);

            var SUT = new CalculaFechaEntregaTerrestre(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docCalculaRetrasoPorDia);

            //Act
            var fechaEntregaPaquete = SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntregaPaquete);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_Estafeta2000KMTerrestreAplicaRetrasoPorDiaVerano_ResultadoCorrecto()
        {
            //Arrange
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 2000M;
            var FechaEsperada = new DateTime(2020, 01, 24, 19, 00, 00);

            var docTiempoReparto = new GeneralEstafeta();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenerdorTiempoDescansoInvierno = new ObtenedorTiempoDescansoPorDiaVerano();
            var docCalculaRetrasoPorDia = new CalculaRetrasoPorDia(docObtenerdorTiempoDescansoInvierno);

            var SUT = new CalculaFechaEntregaTerrestre(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docCalculaRetrasoPorDia);

            //Act
            var fechaEntregaPaquete = SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntregaPaquete);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_DHL2000KMTerrestreAplicaRetrasoPorDiaInvierno_ResultadoCorrecto()
        {
            //Arrange
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 2000M;
            var FechaEsperada = new DateTime(2020, 01, 25, 17, 00, 00);

            var docTiempoReparto = new TerrestreDHL();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenerdorTiempoDescansoInvierno = new ObtenedorTiempoDescansoPorDiaInvierno();
            var docCalculaRetrasoPorDia = new CalculaRetrasoPorDia(docObtenerdorTiempoDescansoInvierno);

            var SUT = new CalculaFechaEntregaTerrestre(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docCalculaRetrasoPorDia);

            //Act
            var fechaEntregaPaquete = SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntregaPaquete);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_Fedex2000KMTerrestreAplicaRetrasoPorDia_ResultadoCorrecto()
        {
            //Arrange
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 2000M;
            var FechaEsperada = new DateTime(2020, 01, 25, 7, 00, 00);

            var docTiempoReparto = new TerrestreFedex();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenerdorTiempoDescansoInvierno = new ObtenedorTiempoDescansoPorDiaInvierno();
            var docCalculaRetrasoPorDia = new CalculaRetrasoPorDia(docObtenerdorTiempoDescansoInvierno);

            var SUT = new CalculaFechaEntregaTerrestre(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docCalculaRetrasoPorDia);

            //Act
            var fechaEntregaPaquete = SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntregaPaquete);
        }
    }
}