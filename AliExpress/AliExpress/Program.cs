using System;
using System.Collections.Generic;
using Entidades;
using Interfaces.ViewModel;
using IoC;
using StructureMap;

namespace AliExpress
{
    public class Program
    {
        static void Main(string[] args)
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


            var lstPedidos = new List<PedidoDTO>();
            lstPedidos.Add(pedido);

            var container = Container.For<DI_Envios>();

            var procesarPedido = container.GetInstance<IProcesarPedido>();

            procesarPedido.ProcesarInformacionPedido(lstPedidos);
        }

    }
}
