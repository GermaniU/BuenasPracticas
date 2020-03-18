using Entidades;
using System;

namespace Interfaces
{
    public interface IObtenedorEstacionAnio
    {
        EnumEstacionesAnio ObtenerEstacion(DateTime date);
    }
}
