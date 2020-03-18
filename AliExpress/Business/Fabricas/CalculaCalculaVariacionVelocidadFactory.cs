using System;
using Business.CalculosFechaEntrega;
using Entidades;
using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;
using Interfaces.Fabricas;
using StructureMap;

namespace Business.Fabricas
{
    public class CalculaCalculaVariacionVelocidadFactory:ICalculaVariacionVelocidadFactory
    {
        private readonly IContainer _factoryGenericContainer;

        public CalculaCalculaVariacionVelocidadFactory(IContainer factoryGenericContainer)
        {
            _factoryGenericContainer = factoryGenericContainer;
        }

        public ICalculaVariacionVelocidad CrearInstancia(EnumEstacionesAnio estacionesAnio)
        {
            ICalculaVariacionVelocidad variacionVelocidad = null;
            IObtenedorVariacionVelocidad obtenedorVariacionVelocidad ;

            switch (estacionesAnio)
            {
                case EnumEstacionesAnio.Invierno:
                    obtenedorVariacionVelocidad = _factoryGenericContainer.GetInstance<IObtenedorVariacionVelocidad>("ObtenedorVelocidadInvierno");
                    variacionVelocidad = new CalculaVariacionVelocidad(obtenedorVariacionVelocidad);
                    break;
                case EnumEstacionesAnio.Otonio:
                    obtenedorVariacionVelocidad = _factoryGenericContainer.GetInstance<IObtenedorVariacionVelocidad>("ObtenedorVelocidadOtonio");
                    variacionVelocidad = new CalculaVariacionVelocidad(obtenedorVariacionVelocidad);
                    break;
                case EnumEstacionesAnio.Verano:
                   obtenedorVariacionVelocidad = _factoryGenericContainer.GetInstance<IObtenedorVariacionVelocidad>("ObtenedorVelocidadVerano");
                   variacionVelocidad = new CalculaVariacionVelocidad(obtenedorVariacionVelocidad);
                   break;
            }

            return variacionVelocidad;
        }
    }
}