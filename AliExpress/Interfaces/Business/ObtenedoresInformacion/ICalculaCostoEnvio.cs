using System;

namespace Interfaces
{
    public interface ICalculaCostoEnvio
    {
        decimal costoPaquete(decimal distancia, string paqueteria, DateTime fechaPedido);
    }
}
