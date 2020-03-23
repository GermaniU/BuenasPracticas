using Business;
using Business.CalculosCostosAdiccionales;
using Business.CalculosFechaEntrega;
using Business.Fabricas;
using Business.ObtenedoresInformacion;
using Business.ObtenedoresInformacion.Patrones.Bridge;
using Interfaces;
using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;
using Interfaces.Fabricas;
using Interfaces.ViewModel;
using StructureMap;
using viewModel;

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
            For<IObtenedorFechaActual>().Use<ObtenedorFechaActual>(); 
            For<IProcesarPedido>().Use<ProcesarPedido>();
            For<ICalculaCostoEnvio>().Use<CalculaCostoEnvio>();
            For<IObtenedorCostoPorKilometro>().Use<ObtenedorCostoPorKilometroAereo>().Named("CostoPorKilometroAereo");
            For<IObtenedorCostoPorKilometro>().Use<ObtenedorCostoPorKilometroMaritimo>().Named("CostoPorKilometroMaritimo");
            For<IObtenedorCostoPorKilometro>().Use<ObtenedorCostoPorKilometroTerrestre>().Named("CostoPorKilometroTerrestre");
            For<IGeneradorMensajePaquete>().Use<GeneradorMensajePaquete>();
            For<ICalculaCostoAdiccionalPorEscala>().Use<CalculaCostoAdiccionalPorEscala>();
            For<IGeneradorMensajeBuilder>().Use<GeneradorMensajeBuilder>();
            For<ICalcularFechaEntregaMedioTransporte>().Use<CalculaFechaEntregaTerrestre>().Named("CalculaFechaEntregaTerrestre");
            For<ICalcularFechaEntregaMedioTransporte>().Use<CalculaFechaEntregaMaritimo>().Named("CalculaFechaEntregaMaritimo");
            For<IGeneradorMensajeBuilder>().Use<GeneradorMensajeBuilder>();
            For<ITiempoReparto>().Use<AereoDHL>().Named("TiempoRepartoAereoDHL");
            For<ITiempoReparto>().Use<TerrestreFedex>().Named("TiempoRepartoTerrestreFedex");
            For<ITiempoReparto>().Use<MaritimoFedex>().Named("TiempoRepartoMaritimoFedex");
            For<ITiempoReparto>().Use<GeneralEstafeta>().Named("TiempoRepartoGeneralEstafeta");
            For<ITiempoReparto>().Use<TerrestreDHL>().Named("TiempoRepartoAereTerrestreDHL");
            For<IObtenedorTiempoReparto>().Use<ObtenedorTiempoReparto>();
            For<ICalculaRetrasoPorDia>().Use<CalculaRetrasoPorDia>();
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaInvierno>().Named("TiempoDescansoInvierno");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaOtonio>().Named("TiempoDescansoOtonio");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaPrimavera>().Named("TiempoDescansoPrimavera");
            For<IObtenedorTiempoDescansoPorDia>().Use<ObtenedorTiempoDescansoPorDiaVerano>().Named("TiempoDescansoVerano");

            For<IObtenedorFechaEntrega>().Use<ObtenerFechaEntrega>();
            For<ICalcularTiempoEntrega>().Use<CalcularTiempoEntrega>();
            For<IObtenedorVariacionVelocidad>().Use<ObtenerVariacionVelocidadInvierno>().Named("ObtenerVariacionVelocidadInvierno");
            For<IObtenedorVariacionVelocidad>().Use<ObtenerVariacionVelocidadOtonio>().Named("ObtenerVariacionVelocidadOtonio");
            For<ICalculaCostoAdiccionalEnvio>().Use<CalculaCostoAdiccionalEnvioMaritimo>().Named("CalculaCostoAdiccionalEnvioMaritimo");
            For<ICalculaCostoAdiccionalEnvio>().Use<CalculaCostoAdiccionalEnvioTerrestre>().Named("CalculaCostoAdiccionalEnvioTerrestre");
            For<ICalculaCostoAdiccionalEnvio>().Use<CalculaCostoAdiccionalAdiccionalEnvioAereo>().Named("CalculaCostoAdiccionalAdiccionalEnvioAereo");
            For<ICalculaUtilidadPaqueteria>().Use<CalcularUtilidadPaqueteria>();
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadDHL>().Named("ObtenedorUtilidadDHL");
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadEstafeta>().Named("ObtenedorUtilidadEstafeta");
            For<IObtenedorUtilidadPaqueteria>().Use<ObtenedorUtilidadFedex>().Named("ObtenedorUtilidadFedex"); 

            For<ICalculaVariacionVelocidad>().Use<CalculaVariacionVelocidad>();
            


        }

    }
}
