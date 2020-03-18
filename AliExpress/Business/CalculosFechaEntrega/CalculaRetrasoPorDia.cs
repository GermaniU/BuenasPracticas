using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;
using System;

namespace Business.CalculosFechaEntrega
{
    public class CalculaRetrasoPorDia : ICalculaRetrasoPorDia
    {
        private readonly IObtenedorTiempoDescansoPorDia _obtenedorTiempoDescansoPorDia;

        public CalculaRetrasoPorDia(IObtenedorTiempoDescansoPorDia obtenedorTiempoDescansoPorDia)
        {
            _obtenedorTiempoDescansoPorDia = obtenedorTiempoDescansoPorDia ??
                                             throw new ArgumentNullException(nameof(obtenedorTiempoDescansoPorDia));
        }

        public DateTime CalcularTiempoRetrasoPorDia(DateTime fechaEntrega, DateTime fechaPedido)
        {
            var horaDescansoPorDia = _obtenedorTiempoDescansoPorDia.ObtenerTiempoDescansoPorDia();
            var diasEntrega = ObtenerDiasEntrega(fechaEntrega, fechaPedido);
            var tiempoDescansoHoras = ObtenerHorasDescanso(diasEntrega, horaDescansoPorDia);
            fechaEntrega = AgregarHorasDescansoFechaEntrega(fechaEntrega, tiempoDescansoHoras);

            return fechaEntrega;
        }

        private int ObtenerDiasEntrega(DateTime fechaEntrega, DateTime fechaPedido)
        {
            return fechaEntrega.Day - fechaPedido.Day;
        }

        private int ObtenerHorasDescanso(int diasEntrega, decimal horaDescansoPorDia)
        {
            return (int)(diasEntrega * horaDescansoPorDia);
        }

        private DateTime AgregarHorasDescansoFechaEntrega(DateTime fechaEntrega, int tiempoDescansoHoras)
        {
            return fechaEntrega.AddHours(tiempoDescansoHoras);
        }
    }
}
