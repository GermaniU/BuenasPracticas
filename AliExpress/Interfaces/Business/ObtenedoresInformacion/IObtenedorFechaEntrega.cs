using System;

namespace Interfaces
{
    public interface IObtenedorFechaEntrega
    {
        DateTime dtFechaEntrega(decimal distancia, DateTime fechaPedido);
    }
}
