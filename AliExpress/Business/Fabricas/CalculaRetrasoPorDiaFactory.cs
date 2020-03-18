using Business.CalculosFechaEntrega;
using Entidades;
using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;
using Interfaces.Fabricas;
using StructureMap;

namespace Business.Fabricas
{
    public class CalculaRetrasoPorDiaFactory : ICalculaRetrasoPorDiaFactory
    {
        private readonly IContainer _factoryGenericContainer;

        public CalculaRetrasoPorDiaFactory(IContainer factoryGenericContainer)
        {
            _factoryGenericContainer = factoryGenericContainer;
        }

        public ICalculaRetrasoPorDia CrearInstancia(EnumEstacionesAnio estacionesAnio)
        {
            ICalculaRetrasoPorDia calculaRetrasoPorDia = null;
            IObtenedorTiempoDescansoPorDia obtenedorTiempoDescansoPorDia;

            switch (estacionesAnio)
            {
                case EnumEstacionesAnio.Invierno:
                    obtenedorTiempoDescansoPorDia = _factoryGenericContainer.GetInstance<IObtenedorTiempoDescansoPorDia>("ObtenedorTiempoDescansoInvierno");
                    calculaRetrasoPorDia = new CalculaRetrasoPorDia(obtenedorTiempoDescansoPorDia);
                    break;
                case EnumEstacionesAnio.Otonio:
                    obtenedorTiempoDescansoPorDia = _factoryGenericContainer.GetInstance<IObtenedorTiempoDescansoPorDia>("ObtenedorTiempoDescansoOtonio");
                    calculaRetrasoPorDia = new CalculaRetrasoPorDia(obtenedorTiempoDescansoPorDia);
                    break;
                case EnumEstacionesAnio.Verano:
                    obtenedorTiempoDescansoPorDia = _factoryGenericContainer.GetInstance<IObtenedorTiempoDescansoPorDia>("ObtenedorTiempoDescansoVerano");
                    calculaRetrasoPorDia = new CalculaRetrasoPorDia(obtenedorTiempoDescansoPorDia);
                    break;
                case EnumEstacionesAnio.Primavera:
                    obtenedorTiempoDescansoPorDia = _factoryGenericContainer.GetInstance<IObtenedorTiempoDescansoPorDia>("ObtenedorTiempoDescansoPrimavera");
                    calculaRetrasoPorDia = new CalculaRetrasoPorDia(obtenedorTiempoDescansoPorDia);
                    break;
            }

            return calculaRetrasoPorDia;
        }
    }
}
