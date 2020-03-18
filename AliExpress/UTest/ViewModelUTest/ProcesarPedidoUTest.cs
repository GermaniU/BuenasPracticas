using Entidades;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace viewModel.Test
{
    [TestClass()]
    public class ProcesarPedidoTest
    {
        [TestMethod()]
        public void ProcesarInformacionPedido_EstafetaTerrestre_GeneracionMensajeCorrecto()
        {
            //Arrange
            List<string> lstMensajesEsperados = new List<string>();

            var resultadoEsperado =
                "Tu paquete salió de Ticul, México y llegó a Motul, México hace 1 hora y tuvo un costo de $1160(cualquier reclamación con Estafeta).";

            lstMensajesEsperados.Add(resultadoEsperado);

            var lstPedidos = ObtenerEntidadPedido();

            var docObtenedoFechaActual = new Mock<IObtenedorFechaActual>();
            var docObtenerFechaEntrega = new Mock<IObtenedorFechaEntrega>();
            var docObtenerCostoEnvio = new Mock<ICalculaCostoEnvio>();
            var docObtenerdorMensajePedido = new Mock<IGeneradorMensajePaquete>();

            docObtenerdorMensajePedido.Setup(doc => doc.prepararMensajePedido(It.IsAny<PedidoDTO>(),
                It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>())).Returns(() => resultadoEsperado);

            ////Act
            var SUT = new ProcesarPedido(docObtenedoFechaActual.Object, docObtenerFechaEntrega.Object, docObtenerCostoEnvio.Object, docObtenerdorMensajePedido.Object);

            var lstMensajes = SUT.ProcesarInformacionPedido(lstPedidos);

            //Assert
            Assert.AreEqual(lstMensajesEsperados[0], lstMensajes[0]);

        }

        private List<PedidoDTO> ObtenerEntidadPedido()
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