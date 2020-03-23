using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using Interfaces.ViewModel;

namespace viewModel
{
    public class ProcesarPedido: IProcesarPedido
    {
        private readonly IObtenedorFechaActual _obtenerFechaActual;
        private readonly IObtenedorFechaEntrega _obtenerFechaEntrega;
        private readonly ICalculaCostoEnvio _calculaCostoEnvio;
        private readonly IGeneradorMensajePaquete _generadorMensajePaquete;

        public ProcesarPedido(IObtenedorFechaActual obtenerFechaActual, IObtenedorFechaEntrega obtenerFechaEntrega, ICalculaCostoEnvio calculaCostoEnvio,
            IGeneradorMensajePaquete generadorMensajePaquete)
        {
            this._obtenerFechaActual = obtenerFechaActual ?? throw new ArgumentNullException(nameof(obtenerFechaActual));
            this._obtenerFechaEntrega = obtenerFechaEntrega ?? throw new ArgumentNullException(nameof(obtenerFechaEntrega));
            this._calculaCostoEnvio = calculaCostoEnvio ?? throw new ArgumentNullException(nameof(calculaCostoEnvio));
            _generadorMensajePaquete = generadorMensajePaquete;
        }

        public List<string> ProcesarInformacionPedido(List<PedidoDTO> paquetes)
        {
            var InformacionEnvios = new List<string>();

            foreach (var pedido in paquetes)
            {
                var paquete = ObtenerMensajePaquete(pedido);

                InformacionEnvios.Add(paquete);
            }

            return InformacionEnvios;
        }

        private string ObtenerMensajePaquete(PedidoDTO pedido)
        {
            var fechaEntregaPaquete = ObtenerFechaEntrega(pedido);
            var FechaActual = _obtenerFechaActual.ObtenerFechaActual();
            var costoPaquete = _calculaCostoEnvio.costoPaquete(pedido.Distancia, pedido.Paqueteria,
                pedido.FechaPedido);

            return _generadorMensajePaquete.prepararMensajePedido(pedido, fechaEntregaPaquete,FechaActual, costoPaquete);

        }

        private DateTime ObtenerFechaEntrega(PedidoDTO pedido)
        {
            return _obtenerFechaEntrega.dtFechaEntrega(pedido.Distancia, pedido.FechaPedido);
        }

    }
}