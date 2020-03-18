using System;

namespace Interfaces.Business.CalculaFechaEntrega
{
    public interface ICalcularTiempoEntrega
    {
         DateTime ObtenerTiempoEntrega(decimal distancia, decimal velocidadVehiculo, DateTime fechaPedido, TimeSpan tiempoAdiccionalReparto);
    }
}