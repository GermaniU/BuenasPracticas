using System;

namespace Interfaces
{
    public interface IObtenerCostoEnvio
    {
        decimal costoPaquete(decimal distancia, string paqueteria, DateTime fechaPedido);
    }
}
