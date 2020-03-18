using Interfaces;
using System;

namespace Business
{
    public class CalculaCostoAdiccionalAdiccionalEnvioAereo : ICalculaCostoAdiccionalEnvio
    {
        private readonly ICalculaCostoAdiccionalPorEscala calculaCostoAdiccionalPorEscala;
        private readonly ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria;

        public CalculaCostoAdiccionalAdiccionalEnvioAereo(ICalculaCostoAdiccionalPorEscala calculaCostoAdiccionalPorEscala,
            ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria)
        {
            this.calculaCostoAdiccionalPorEscala = calculaCostoAdiccionalPorEscala ??
                                                   throw new ArgumentNullException(
                                                       nameof(calculaCostoAdiccionalPorEscala));
            this.calculaUtilidadPaqueteria = calculaUtilidadPaqueteria ??
                                             throw new ArgumentNullException(nameof(calculaUtilidadPaqueteria));
        }

        public decimal CalcularCostoAdiccionalEnvio(decimal costoTransporte, decimal distancia, DateTime fechaPedido, string paqueteria)
        {
            var costoEnvioAereo = 0M;

            var costoAdiccional = calculaCostoAdiccionalPorEscala.CalcularCostoPorEscala(distancia);

            costoEnvioAereo = costoTransporte + costoAdiccional;

            return calculaUtilidadPaqueteria.CalcularUtilidadEmpresa(paqueteria,fechaPedido,costoEnvioAereo);

        }
    }
}
