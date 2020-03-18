using Entidades;
using System;

namespace Interfaces
{
    public interface IObtenedorUtilidadPaqueteria
    {
        decimal ObtenerUtilidadEmpresa(EnumEmpresasPaqueteria paqueteria, DateTime fechaPedido);
    }
}
