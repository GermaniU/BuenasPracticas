using Interfaces.Business.CalculaFechaEntrega;
using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.CalculosCostosAdiccionales
{
    public class CalculaFechaEntregaMaritimo: ICalcularFechaEntregaMedioTransporte
    {
        private readonly IObtenedorTiempoReparto obtenedorTiempoReparto;
        private readonly ICalcularTiempoEntrega calcularTiempoEntrega;
        private readonly ICalculaVariacionVelocidad calculaVariacionVelocidad;
        private decimal VelocidadVehiculo = 46M;

        public CalculaFechaEntregaMaritimo(IObtenedorTiempoReparto obtenedorTiempoReparto,
            ICalcularTiempoEntrega calcularTiempoEntrega, ICalculaVariacionVelocidad calculaVariacionVelocidad)
        {
            this.obtenedorTiempoReparto = obtenedorTiempoReparto ??
                                          throw new ArgumentNullException(nameof(obtenedorTiempoReparto));
            this.calcularTiempoEntrega =
                calcularTiempoEntrega ?? throw new ArgumentNullException(nameof(calcularTiempoEntrega));
            this.calculaVariacionVelocidad = calculaVariacionVelocidad ??
                                             throw new ArgumentNullException(nameof(calculaVariacionVelocidad));
        }

        public DateTime ObtenerFechaEntregaMedioTransporte(decimal distancia, DateTime fechaPedido)
        {
            var tiempoAdiccionalReparto = obtenedorTiempoReparto.ObtenerTiempoReparto();
            VelocidadVehiculo = calculaVariacionVelocidad.CalcularVariacionVelocidad(VelocidadVehiculo);
            var fechaEntrega = calcularTiempoEntrega.ObtenerTiempoEntrega(distancia, VelocidadVehiculo, fechaPedido, tiempoAdiccionalReparto);


            return fechaEntrega;
        }
    }
}
