using Entidades;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace viewModel.Test
{
    [TestClass()]
    public class ObtenedorMensajePedidoTest
    {
        [TestMethod()]
        public void ObtenerMensajePedidoTest()
        {
            //Arrange
            List<string> lstMensajesEsperados = new List<string>();

            var resultadoEsperado =
                "Tu paquete salió de Ticul, México y llegó a Motul, México hace 1 hora y tuvo un costo de $1160(cualquier reclamación con Estafeta).";
            lstMensajesEsperados.Add(resultadoEsperado);

            var lstPedidos = ObtenerEntidadPedido();

            var fechaActual = new DateTime(2020,01,23,14,00,00);

            var dtFechaEntrega = new DateTime(2020,01,23,01,00,00);

            var docObtenedoFechaActual = new Mock<IObtenedorFechaActual>();
            var docObtenerFechaEntrega = new Mock<IObtenedorFechaEntrega>();
            var docObtenerCostoEnvio = new Mock<IObtenerCostoEnvio>();
            var docObtenedorFormatoEntrega = new Mock<IObtenerFormatoTiempoEntrega>();
            var docobtenedorMensajes = new GeneradorMensajesEstatusTiempo();
            var docgeneradorMensajeBuilder = new GeneradorMensajeBuilder();

            docObtenedoFechaActual.Setup(doc => doc.ObtenerFechaActual()).Returns(fechaActual);

            docObtenerFechaEntrega.Setup(doc => doc.dtFechaEntrega(It.IsAny<decimal>(),It.IsAny<string>(),It.IsAny<DateTime>(),It.IsAny<string>())).Returns(dtFechaEntrega);

            docObtenerCostoEnvio.Setup(doc =>
                doc.costoPaquete(It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns(()=>1160);

            docObtenedorFormatoEntrega.Setup(doc =>
                doc.ObtenerFormatoEntrega(It.IsAny<DateTime>(),  It.IsAny<DateTime>())).Returns(() => "1 hora");

            //Act
            var SUT = new ObtenedorMensajePedido(docObtenedoFechaActual.Object, docObtenerFechaEntrega.Object, docObtenerCostoEnvio.Object, docObtenedorFormatoEntrega.Object, docobtenedorMensajes, docgeneradorMensajeBuilder);

            var lstMensajes = SUT.ObtenerInformacionEnvio(lstPedidos);


            //Assert
            Assert.AreEqual( lstMensajesEsperados[0], lstMensajes[0]);

        }

        private  List<PedidoDTO> ObtenerEntidadPedido()
        {
            var lstPedidos = new List<PedidoDTO>();

            var pedido = new PedidoDTO();
            pedido.Distancia = 80M;
            pedido.Paqueteria = "Estafeta";
            pedido.MedioTransporte = "Terrestre";
            pedido.PaisOrigen = "México";
            pedido.OrigenPaquete = "Ticul";
            pedido.Destino = "Motul";
            pedido.paisDestino = "México";
            pedido.FechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);

            lstPedidos.Add(pedido);

            return lstPedidos;
        }
    }
}