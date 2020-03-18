using Entidades;

namespace Interfaces.Fabricas
{
    public interface ICalcularUtilidadPaqueteriaFactory
    {
        ICalculaUtilidadPaqueteria CrearInstancia(EnumEmpresasPaqueteria paqueteria);
    }
}