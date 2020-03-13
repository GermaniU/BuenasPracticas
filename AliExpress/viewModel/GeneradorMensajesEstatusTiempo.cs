using System;
using Entidades;
using Interfaces;

namespace viewModel
{
    public class GeneradorMensajesEstatusTiempo : IGeneradorMensajesEstatusTiempo
    {
        public string ObtenerEstatusPedido(DateTime FechaEntrega, DateTime FechaActual)
        {
            return ObtenerMensaje(FechaEntrega, FechaActual,"llegó","llegará");
        }

        public string ObtenerEstatusEntrega(DateTime FechaEntrega, DateTime FechaActual)
        {
            return ObtenerMensaje(FechaEntrega, FechaActual, "salió", "ha salido");
        }

        public string ObtenerEstatusTiempoEntrega(DateTime FechaEntrega, DateTime FechaActual)
        {
            return ObtenerMensaje(FechaEntrega, FechaActual, "hace", "dentro de");
        }

        public string ObtenerMensajeCosto(DateTime FechaEntrega, DateTime FechaActual)
        {
            return ObtenerMensaje(FechaEntrega, FechaActual, "tuvo", "Tendra");
        }

        private string ObtenerMensaje(DateTime FechaEntrega, DateTime FechaActual, string MensajeFechaEntregaMenor, string MensajeFechaEntregaMayor)
        {
            if (FechaEntrega < FechaActual)
            {
                return MensajeFechaEntregaMenor;
            }
            else
            {
                return MensajeFechaEntregaMayor;
            }
        }
    }
}