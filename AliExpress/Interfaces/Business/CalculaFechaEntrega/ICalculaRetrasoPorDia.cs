using System;

namespace Interfaces.Business.CalculaFechaEntrega
{
    public interface ICalculaRetrasoPorDia
    {
        DateTime CalcularTiempoRetrasoPorDia(DateTime fechaEntrega, DateTime fechaPedido);
    }
}
