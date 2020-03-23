using System;
using System.Runtime.InteropServices;
using Entidades;
using Entidades.DTO;
using Interfaces;
using Interfaces.Fabricas;

namespace viewModel
{
    public class GeneradorMensajePaquete : IGeneradorMensajePaquete
    {
        private readonly IObtenedorFormatoFactory _obtenerFormatoTiempoEntregaFactory;
        private readonly IGeneradorMensajesEstatusTiempo _generadorMensajesEstatusTiempo;
        private readonly IConfiguradorMensajeBuilder _configuradorMensajeBuilder;

        public GeneradorMensajePaquete(IObtenedorFormatoFactory obtenerFormatoTiempoEntrega,
            IGeneradorMensajesEstatusTiempo generadorMensajesEstatusTiempo,
            IConfiguradorMensajeBuilder configuradorMensajeBuilder)
        {
            _obtenerFormatoTiempoEntregaFactory = obtenerFormatoTiempoEntrega ??
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
                    _obtenerFormatoTiempoEntregaFactory.ObtenerFormatoEntrega(pedido.FechaPedido, fechaEntrega))
                .AsignarMensajeCosto(costoPedido)
                .AsignarMensajeFormatoCosto(
                    _generadorMensajesEstatusTiempo.ObtenerMensajeCosto(fechaEntrega, fechaActual))
                .ObtenerResultado();
        }

        private string ObtenerFormatoEntrega(PedidoDTO pedido, DateTime fechaEntrega)
        {
           var instanciaObtenedor = _obtenerFormatoTiempoEntregaFactory.CrearInstanciaCadena();

           instanciaObtenedor.
        }

        private FechasPedidoDTO obtenerFechasPedidoDto(DateTime fechaEntrega , PedidoDTO pedido)
        {
            return new FechasPedidoDTO() {FechaPedido =  pedido.FechaPedido, FechaEntrega = fechaEntrega};
        }
    }
}