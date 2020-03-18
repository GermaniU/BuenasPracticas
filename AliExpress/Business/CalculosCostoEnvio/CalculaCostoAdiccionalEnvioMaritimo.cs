using Interfaces;
using System;

namespace Business
{
    public class CalculaCostoAdiccionalEnvioMaritimo:ICalculaCostoAdiccionalEnvio
    {
        private readonly ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria;
        private readonly ICalculaCostoAdiccionalPorTemporada calculaCostoAdiccionalPorTemporada;

        public CalculaCostoAdiccionalEnvioMaritimo(ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria,
            ICalculaCostoAdiccionalPorTemporada calculaCostoAdiccionalPorTemporada)
        {
            this.calculaUtilidadPaqueteria = calculaUtilidadPaqueteria ??
                                             throw new ArgumentNullException(nameof(calculaUtilidadPaqueteria));
            this.calculaCostoAdiccionalPorTemporada = calculaCostoAdiccionalPorTemporada ??
                                                      throw new ArgumentNullException(
                                                          nameof(calculaCostoAdiccionalPorTemporada));
        }

        public decimal CalcularCostoAdiccionalEnvio(decimal costoTransporte, decimal distancia, DateTime fechaPedido, string paqueteria)
        {
            var costoAdiccionalPorTemporada = CalcularCostoAdiccionalPorTemporada(costoTransporte);

            return calculaUtilidadPaqueteria.CalcularUtilidadEmpresa(paqueteria, fechaPedido, costoAdiccionalPorTemporada);
        }

        private decimal CalcularCostoAdiccionalPorTemporada(decimal costoTransporte)
        {
            return calculaCostoAdiccionalPorTemporada.CalcularCostoAdiccionalPorTemporada(costoTransporte);
        }
    }
}