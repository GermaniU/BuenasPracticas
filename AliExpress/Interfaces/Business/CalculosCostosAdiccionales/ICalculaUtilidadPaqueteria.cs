using System;

namespace Interfaces
{
    public interface ICalculaUtilidadPaqueteria
    {
        decimal CalcularUtilidadEmpresa(string paqueteria, DateTime fechaPedido, decimal costoTransporte);
    }
}