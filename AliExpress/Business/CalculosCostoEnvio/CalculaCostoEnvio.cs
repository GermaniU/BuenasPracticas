using Interfaces;
using System;
using Entidades;

namespace Business
{
    public class CalculaCostoEnvio : ICalculaCostoEnvio
    {
        private readonly IObtenedorCostoPorKilometro ObtenedorCostoPorKilometro;
        private readonly ICalculaCostoAdiccionalEnvio _calculaCostoAdiccionalEnvio;

        public CalculaCostoEnvio(IObtenedorCostoPorKilometro obtenedorCostoPorKilometro,
            ICalculaCostoAdiccionalEnvio calculaCostoAdiccionalEnvio)
        {
            ObtenedorCostoPorKilometro = obtenedorCostoPorKilometro ??
                                         throw new ArgumentNullException(nameof(obtenedorCostoPorKilometro));
            this._calculaCostoAdiccionalEnvio = calculaCostoAdiccionalEnvio ?? throw new ArgumentNullException(nameof(calculaCostoAdiccionalEnvio));
        }

        public decimal costoPaquete(decimal distancia, string paqueteria, DateTime fechaPedido)
        {
            var costoKilometro = ObtenedorCostoPorKilometro.ObtenerCostoPorKilometro(distancia);

            return ObtenerCalcularCostoServicio(distancia, costoKilometro, paqueteria,fechaPedido);
        }

        private decimal ObtenerCalcularCostoServicio(decimal distancia, decimal costoKilometro, string paqueteria, DateTime fechaPedido)
        {
            var costoTransporte = CalcularCostoTransporte(costoKilometro, distancia);

            var costoServicio =
                _calculaCostoAdiccionalEnvio.CalcularCostoAdiccionalEnvio(costoTransporte, distancia, fechaPedido, paqueteria);

            return costoServicio;

        }

        private  decimal CalcularCostoTransporte(decimal costoPorKilometro, decimal distancia)
        {
            return (costoPorKilometro * distancia);
        }

        
    }
}
