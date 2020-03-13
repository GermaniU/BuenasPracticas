using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;

namespace viewModel
{
    public class ObtenedorMensajePedido
    {
        private readonly IObtenedorFechaActual obtenerFechaActual;
        private readonly IObtenedorFechaEntrega obtenerFechaEntrega;
        private readonly IObtenerCostoEnvio obtenerCostoEnvio;
        private readonly IObtenerFormatoTiempoEntrega obtenerFormatoTiempoEntrega;
        private readonly IGeneradorMensajesEstatusTiempo generadorMensajesEstatusTiempo;
        private readonly IConfiguradorMensajeBuilder _configuradorMensajeBuilder;


        public ObtenedorMensajePedido(IObtenedorFechaActual obtenerFechaActual, IObtenedorFechaEntrega obtenerFechaEntrega, IObtenerCostoEnvio obtenerCostoEnvio, IObtenerFormatoTiempoEntrega obtenerFormatoTiempoEntrega, IGeneradorMensajesEstatusTiempo generadorMensajesEstatusTiempo,
            IConfiguradorMensajeBuilder configuradorMensajeBuilder)
        {
            this.obtenerFechaActual = obtenerFechaActual ?? throw new ArgumentNullException(nameof(obtenerFechaActual));
            this.obtenerFechaEntrega = obtenerFechaEntrega ?? throw new ArgumentNullException(nameof(obtenerFechaEntrega));
            this.obtenerCostoEnvio = obtenerCostoEnvio ?? throw new ArgumentNullException(nameof(obtenerCostoEnvio));
            this.obtenerFormatoTiempoEntrega = obtenerFormatoTiempoEntrega ?? throw new ArgumentNullException(nameof(obtenerFormatoTiempoEntrega));
            this.generadorMensajesEstatusTiempo = generadorMensajesEstatusTiempo;
            _configuradorMensajeBuilder = configuradorMensajeBuilder;
        }

        public List<string> ObtenerInformacionEnvio(List<PedidoDTO> lstPedidos)
        {
            var lstInformacionEnvio = new List<string>();

            foreach (var pedido in lstPedidos)
            {
                var informacionPaquete = ObtenerMensajePaquete(pedido);

                lstInformacionEnvio.Add(informacionPaquete);
            }

            return lstInformacionEnvio;
        }

        private string ObtenerMensajePaquete(PedidoDTO pedido)
        {
            var FechaEntrega = ObtenerFechaEntrega(pedido);
            var FechaActual = obtenerFechaActual.ObtenerFechaActual();

            return  preparMensaje(pedido, FechaEntrega,FechaActual);

        }

        private string preparMensaje(PedidoDTO pedido, DateTime FechaEntrega, DateTime FechaActual)
        {
            return _configuradorMensajeBuilder.IniciarConfiguracionPedido(pedido)
                .AsignarEstatusEntrega(generadorMensajesEstatusTiempo.ObtenerEstatusEntrega(FechaEntrega, FechaActual))
                .AsignarEstatusTiempoEntrega(
                    generadorMensajesEstatusTiempo.ObtenerEstatusTiempoEntrega(FechaEntrega, FechaActual))
                .AsignarEstatusTiempoPedido(
                    generadorMensajesEstatusTiempo.ObtenerEstatusPedido(FechaEntrega, FechaActual))
                .AsignarFormatoTiempo(
                    obtenerFormatoTiempoEntrega.ObtenerFormatoEntrega(pedido.FechaPedido, ObtenerFechaEntrega(pedido)))
                .AsignarMensajeCosto(obtenerCostoEnvio.costoPaquete(pedido.Distancia, pedido.Paqueteria,
                    pedido.FechaPedido))
                .AsignarMensajeFormatoCosto(
                    generadorMensajesEstatusTiempo.ObtenerMensajeCosto(FechaEntrega, FechaActual))
                .ObtenerResultado();

        }

        private DateTime ObtenerFechaEntrega(PedidoDTO pedido)
        {
            return obtenerFechaEntrega.dtFechaEntrega(pedido.Distancia, pedido.MedioTransporte, pedido.FechaPedido,
                pedido.Paqueteria);
        }

    }
}