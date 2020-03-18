using System;
using Entidades;
using Interfaces;

namespace viewModel
{
    public class GeneradorMensajePaquete : IGeneradorMensajePaquete
    {
        private readonly IObtenerFormatoTiempoEntrega _obtenerFormatoTiempoEntrega;
        private readonly IGeneradorMensajesEstatusTiempo _generadorMensajesEstatusTiempo;
        private readonly IConfiguradorMensajeBuilder _configuradorMensajeBuilder;

        public GeneradorMensajePaquete(IObtenerFormatoTiempoEntrega obtenerFormatoTiempoEntrega,
            IGeneradorMensajesEstatusTiempo generadorMensajesEstatusTiempo,
            IConfiguradorMensajeBuilder configuradorMensajeBuilder)
        {
            _obtenerFormatoTiempoEntrega = obtenerFormatoTiempoEntrega ??
                                           throw new ArgumentNullException(nameof(obtenerFormatoTiempoEntrega));
            _generadorMensajesEstatusTiempo = generadorMensajesEstatusTiempo ??
                                              throw new ArgumentNullException(nameof(generadorMensajesEstatusTiempo));
            _configuradorMensajeBuilder = configuradorMensajeBuilder ??
                                          throw new ArgumentNullException(nameof(configuradorMensajeBuilder));
        }

        public  string prepararMensajePedido(PedidoDTO pedido, DateTime fechaEntrega, DateTime fechaActual,decimal costoPedido)
        {
            return _configuradorMensajeBuilder.IniciarConfiguracionPedido(pedido)
                .AsignarEstatusEntrega(_generadorMensajesEstatusTiempo.ObtenerEstatusEntrega(fechaEntrega, fechaActual))
                .AsignarEstatusTiempoEntrega(
                    _generadorMensajesEstatusTiempo.ObtenerEstatusTiempoEntrega(fechaEntrega, fechaActual))
                .AsignarEstatusTiempoPedido(
                    _generadorMensajesEstatusTiempo.ObtenerEstatusPedido(fechaEntrega, fechaActual))
                .AsignarFormatoTiempo(
                    _obtenerFormatoTiempoEntrega.ObtenerFormatoEntrega(pedido.FechaPedido, fechaEntrega))
                .AsignarMensajeCosto(costoPedido)
                .AsignarMensajeFormatoCosto(
                    _generadorMensajesEstatusTiempo.ObtenerMensajeCosto(fechaEntrega, fechaActual))
                .ObtenerResultado();
        }
    }
}