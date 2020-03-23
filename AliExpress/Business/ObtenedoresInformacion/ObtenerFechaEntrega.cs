using Interfaces;
using Interfaces.Business.CalculaFechaEntrega;
using System;

namespace Business.ObtenedoresInformacion
{
    public class ObtenerFechaEntrega : IObtenedorFechaEntrega
    {
        private ICalcularFechaEntregaMedioTransporte calcularFechaEntregaMedioTransporte;

        public ObtenerFechaEntrega(ICalcularFechaEntregaMedioTransporte calcularFechaEntregaMedioTransporte)
        {
            this.calcularFechaEntregaMedioTransporte = calcularFechaEntregaMedioTransporte ??
                                                       throw new ArgumentNullException(
                                                           nameof(calcularFechaEntregaMedioTransporte));
        }

        public DateTime dtFechaEntrega(decimal distancia, DateTime fechaPedido)
        {
            return calcularFechaEntregaMedioTransporte.ObtenerFechaEntregaMedioTransporte(distancia, fechaPedido);
        }
    }
}
