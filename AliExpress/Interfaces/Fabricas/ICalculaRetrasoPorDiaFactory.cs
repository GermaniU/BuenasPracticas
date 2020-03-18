using Entidades;
using Interfaces.Business.CalculaFechaEntrega;

namespace Interfaces.Fabricas
{
    public interface ICalculaRetrasoPorDiaFactory
    {
        ICalculaRetrasoPorDia CrearInstancia(EnumEstacionesAnio estacionesAnio);
    }
}