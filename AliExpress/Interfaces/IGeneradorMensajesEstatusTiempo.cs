using System;

namespace Interfaces
{
    public interface IGeneradorMensajesEstatusTiempo
    {
        string ObtenerEstatusPedido(DateTime FechaEntrega, DateTime FechaActual);
        string ObtenerEstatusEntrega(DateTime FechaEntrega, DateTime FechaActual);
        string ObtenerEstatusTiempoEntrega(DateTime FechaEntrega, DateTime FechaActual);
        string ObtenerMensajeCosto(DateTime FechaEntrega, DateTime FechaActual);
    }
}