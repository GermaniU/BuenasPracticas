using System;

namespace Interfaces.Business.CalculaFechaEntrega
{
    public interface ICalcularFechaEntregaMedioTransporte
    {
        DateTime ObtenerFechaEntregaMedioTransporte(decimal distancia, DateTime fechaPedido);
    }
}
