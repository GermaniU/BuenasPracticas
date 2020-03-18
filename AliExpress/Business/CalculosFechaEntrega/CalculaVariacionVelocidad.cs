using System;
using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.CalculosFechaEntrega
{
    public class CalculaVariacionVelocidad :ICalculaVariacionVelocidad
    {
        private readonly IObtenedorVariacionVelocidad obtenedorVariacionVelocidad;

        public CalculaVariacionVelocidad(IObtenedorVariacionVelocidad obtenedorVariacionVelocidad)
        {
            this.obtenedorVariacionVelocidad = obtenedorVariacionVelocidad ??
                                               throw new ArgumentNullException(nameof(obtenedorVariacionVelocidad));
        }

        public decimal CalcularVariacionVelocidad(decimal velocidadVehiculo)
        {
            var variacionVelocidad = obtenedorVariacionVelocidad.ObtenerVariacionVelocidad();

            return CalcularVelociadConVariacion(velocidadVehiculo,variacionVelocidad);
        }

        private decimal CalcularVelociadConVariacion(decimal velocidadVehiculo, decimal variaciacionVelocidad)
        {
            return velocidadVehiculo * (1 + variaciacionVelocidad);
        }
    }
}
