using Business.CalculosFechaEntrega;
using Business.ObtenedoresInformacion;
using Business.ObtenedoresInformacion.Patrones.Bridge;
using Interfaces.Business.ObtenedoresInformacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Business.CalculosCostosAdiccionales.Test
{
    [TestClass()]
    public class CalculaFechaEntregaMaritimoTest
    {
        [TestMethod()]
        public void ObtenerFechaEntregaMedioTransporte_DHL2000KMMaritimoVariacionVelocidadVerano_resultadoCorrecto()
        {
            //Assert
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 2000M;
            var FechaEsperada = new DateTime(2020, 01, 26, 22, 00, 00);

            var docTiempoReparto = new MaritimoDHL();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenedorVariacionVelocidad = new ObtenerVariacionVelocidadInvierno();
            var docVariacionVelocidad = new CalculaVariacionVelocidad(docObtenedorVariacionVelocidad);


            var SUT = new CalculaFechaEntregaMaritimo(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docVariacionVelocidad);

            //Act
            var fechaEntrega =  SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntrega);
        }

        [TestMethod()]
        public void ObtenerFechaEntregaMedioTransporte_Fedex2000KMMaritimoVariacionVelocidadOtonio_resultadoCorrecto()
        {
            //Assert
            var fechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);
            var distancia = 2000M;
            var FechaEsperada = new DateTime(2020, 01, 25, 22, 00, 00);

            var docTiempoReparto = new MaritimoFedex();
            var docObtenedorTiempoReparto = new ObtenedorTiempoReparto(docTiempoReparto);
            var docCalculaTiempoEntrega = new CalcularTiempoEntrega();
            var docObtenedorVariacionVelocidad = new ObtenerVariacionVelocidadOtonio();
            var docVariacionVelocidad = new CalculaVariacionVelocidad(docObtenedorVariacionVelocidad);


            var SUT = new CalculaFechaEntregaMaritimo(docObtenedorTiempoReparto, docCalculaTiempoEntrega, docVariacionVelocidad);

            //Act
            var fechaEntrega = SUT.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);

            //Assert
            Assert.AreEqual(FechaEsperada, fechaEntrega);
        }
    }
}