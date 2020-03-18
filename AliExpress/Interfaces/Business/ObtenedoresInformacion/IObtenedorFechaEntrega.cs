using System;

namespace Interfaces
{
    public interface IObtenedorFechaEntrega
    {
        DateTime dtFechaEntrega(decimal distancia, string medioTransporte, DateTime fechaPedido, string paqueteria);
    }
}
