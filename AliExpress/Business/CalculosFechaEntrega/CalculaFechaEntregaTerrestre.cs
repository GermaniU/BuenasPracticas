using Interfaces.Business.CalculaFechaEntrega;
using Interfaces.Business.ObtenedoresInformacion;
using System;

namespace Business.CalculosFechaEntrega
{
    public class CalculaFechaEntregaTerrestre : ICalcularFechaEntregaMedioTransporte
    {
        private readonly IObtenedorTiempoReparto obtenedorTiempoReparto;
        private readonly ICalcularTiempoEntrega calcularTiempoEntrega;
        private readonly ICalculaRetrasoPorDia _calculaRetrasoPorDia;
        private decimal VelocidadVehiculo = 80M;

        public CalculaFechaEntregaTerrestre(IObtenedorTiempoReparto obtenedorTiempoReparto,
            ICalcularTiempoEntrega calcularTiempoEntrega, ICalculaRetrasoPorDia calculaRetrasoPorDia)
        {
            this.obtenedorTiempoReparto = obtenedorTiempoReparto ??
                                          throw new ArgumentNullException(nameof(obtenedorTiempoReparto));
            this.calcularTiempoEntrega =
                calcularTiempoEntrega ?? throw new ArgumentNullException(nameof(calcularTiempoEntrega));
            this._calculaRetrasoPorDia =
                calculaRetrasoPorDia ?? throw new ArgumentNullException(nameof(calculaRetrasoPorDia));
        }

        public DateTime ObtenerFechaEntregaMedioTransporte(decimal distancia,DateTime fechaPedido)
        {
            var tiempoAdiccionalReparto = obtenedorTiempoReparto.ObtenerTiempoReparto();

            var fechaEntrega = calcularTiempoEntrega.ObtenerTiempoEntrega(distancia, VelocidadVehiculo, fechaPedido,tiempoAdiccionalReparto);

            fechaEntrega = _calculaRetrasoPorDia.CalcularTiempoRetrasoPorDia(fechaEntrega,fechaPedido);
            
            return fechaEntrega;
        }
    }
}
