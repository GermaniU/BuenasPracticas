using Business;
using Business.Fabricas;
using Business.ObtenedoresInformacion;
using Interfaces;
using Interfaces.Business.ObtenedoresInformacion;
using Interfaces.Fabricas;
using StructureMap;

namespace IoC
{
    public class DI_Envios : Registry
    {
        public DI_Envios()
        {
            For<IObtenedorVariacionVelocidad>().Use<ObtenerVariacionVelocidadInvierno>().Named("ObtenedorVelocidadInvierno");
            For<IObtenedorVariacionVelocidad>().Use<ObtenerVariacionVelocidadVerano>().Named("ObtenedorVelocidadVerano");
            For<IObtenedorVariacionVelocidad>().Use<ObtenerVariacionVelocidadOtonio>().Named("ObtenedorVelocidadOtonio");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaInvierno>().Named("ObtenedorTiempoDescansoInvierno");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaVerano>().Named("ObtenedorTiempoDescansoVerano");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaOtonio>().Named("ObtenedorTiempoDescansoOtonio");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaPrimavera>().Named("ObtenedorTiempoDescansoPrimavera");
            For<ICalculaRetrasoPorDiaFactory>().Use<CalculaRetrasoPorDiaFactory>();
            For<ICalculaVariacionVelocidadFactory>().Use<CalculaCalculaVariacionVelocidadFactory>();
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadDHL>().Named("ObtenerUtilidadDHL");
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadEstafeta>().Named("ObtenerUtilidadEstafeta");
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadFedex>().Named("ObtenerUtilidadFedex");

        }

    }
}
