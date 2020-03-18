using Microsoft.VisualStudio.TestTools.UnitTesting;
using viewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;
using Moq;

namespace viewModel.Test
{
    [TestClass()]
    public class ObtenedorMensajePedidoTest
    {
        [TestMethod()]
        public void prepararMensajePedido_GenerarMensajeEstafetaTerestre_GeneraMensajePedido()
        {
            var resultadoEsperado =
                "Tu paquete salió de Ticul, México y llegó a Motul, México hace 1 hora y tuvo un costo de $1160(cualquier reclamación con Estafeta).";

            //Arrange
            var docObtenerFomatoTiempoEntrega = new Mock<IObtenerFormatoTiempoEntrega>();
            var docGeneradorMensajesEstatusTiempo = new GeneradorMensajesEstatusTiempo();
            var docConfiguradorMensajeBuilder =  new GeneradorMensajeBuilder();
            var pedido =  ObtenerEntidadPedido();


            var fechaActual = new DateTime(2020, 01, 23, 14, 00, 00);

            var fechaEntrega = new DateTime(2020, 01, 23, 01, 00, 00);

            docObtenerFomatoTiempoEntrega.Setup(doc =>
                doc.ObtenerFormatoEntrega(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(() => "1 hora");


            //Act
            var SUT = new GeneradorMensajePaquete(docObtenerFomatoTiempoEntrega.Object, docGeneradorMensajesEstatusTiempo,docConfiguradorMensajeBuilder);


            var mensajePedido = SUT.prepararMensajePedido(pedido, fechaEntrega, fechaActual, 1160);


            //Assert

            Assert.AreEqual(resultadoEsperado,mensajePedido);
        }

        private PedidoDTO ObtenerEntidadPedido()
        {
            var pedido = new PedidoDTO();
            pedido.Distancia = 80M;
            pedido.Paqueteria = "Estafeta";
            pedido.MedioTransporte = "Terrestre";
            pedido.PaisOrigen = "México";
            pedido.OrigenPaquete = "Ticul";
            pedido.Destino = "Motul";
            pedido.paisDestino = "México";
            pedido.FechaPedido = new DateTime(2020, 01, 23, 12, 00, 00);

            return pedido;
        }
    }
}