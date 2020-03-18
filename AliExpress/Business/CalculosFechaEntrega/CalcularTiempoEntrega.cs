using Interfaces.Business.CalculaFechaEntrega;
using System;

namespace Business.CalculosFechaEntrega
{
    public class CalcularTiempoEntrega : ICalcularTiempoEntrega
    {
        public DateTime ObtenerTiempoEntrega(decimal distancia, decimal velocidadVehiculo, DateTime fechaPedido, TimeSpan tiempoAdiccionalReparto)
        {
            var tiempoTransporte = ObtenerTiempoTransporteMinutos(distancia,velocidadVehiculo);
            var minutosTiempoReparto = ObtenerTiempoRepartoMinutos(tiempoAdiccionalReparto);
            var tiempoTotal = CalcularTiempoTotalEntrega(tiempoTransporte, minutosTiempoReparto);

            return AgregarHorasFechaPedido(fechaPedido,tiempoTotal);
        }

        private decimal ObtenerTiempoTransporteMinutos(decimal distancia, decimal velocidadVehiculo)
        {
           return  (distancia / velocidadVehiculo) * 60;
        }

        private decimal ObtenerTiempoRepartoMinutos(TimeSpan tiempoAdiccionalReparto)
        {
            return  (decimal)tiempoAdiccionalReparto.TotalMinutes;
        }

        private int CalcularTiempoTotalEntrega(decimal tiempoTransporte, decimal minutosTiempoReparto)
        {
            return (int)(tiempoTransporte + minutosTiempoReparto) / 60;
        }

        private DateTime AgregarHorasFechaPedido(DateTime fechaPedido, int HorasEntrega )
        {
             return  fechaPedido.AddHours(HorasEntrega);
        }
    }
}