using Entidades;
using Interfaces;
using Interfaces.Fabricas;
using StructureMap;

namespace Business.Fabricas
{
    public class CalcularUtilidadPaqueteriaFactory: ICalcularUtilidadPaqueteriaFactory 
    {
        private readonly IContainer _factoryGenericContainer;

        public CalcularUtilidadPaqueteriaFactory(IContainer factoryGenericContainer)
        {
            _factoryGenericContainer = factoryGenericContainer;
        }

        public ICalculaUtilidadPaqueteria CrearInstancia(EnumEmpresasPaqueteria paqueteria)
        {
            ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria = null;
            IObtenedorUtilidadPaqueteria obtenedorUtilidadPaqueteria;

            switch (paqueteria)
            {
                case EnumEmpresasPaqueteria.DHL:
                    obtenedorUtilidadPaqueteria = _factoryGenericContainer.GetInstance<IObtenedorUtilidadPaqueteria>("ObtenerUtilidadDHL");
                    calculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria(obtenedorUtilidadPaqueteria);
                    break;
                case EnumEmpresasPaqueteria.Estafeta:
                    obtenedorUtilidadPaqueteria = _factoryGenericContainer.GetInstance<IObtenedorUtilidadPaqueteria>("ObtenerUtilidadEstafeta");
                    calculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria(obtenedorUtilidadPaqueteria);
                    break;
                case EnumEmpresasPaqueteria.Fedex:
                    obtenedorUtilidadPaqueteria = _factoryGenericContainer.GetInstance<IObtenedorUtilidadPaqueteria>("ObtenerUtilidadFedex");
                    calculaUtilidadPaqueteria = new CalcularUtilidadPaqueteria(obtenedorUtilidadPaqueteria);
                    break;
            }

            return calculaUtilidadPaqueteria;
        }
    }
}