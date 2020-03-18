using System;
using Entidades;
using Interfaces;

namespace Business
{
    public class CalculaCostoAdiccionalEnvioTerrestre : ICalculaCostoAdiccionalEnvio
    {
        private readonly ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria;

        public CalculaCostoAdiccionalEnvioTerrestre(ICalculaUtilidadPaqueteria calculaUtilidadPaqueteria)
        {
            this.calculaUtilidadPaqueteria = calculaUtilidadPaqueteria ??
                                             throw new ArgumentNullException(nameof(calculaUtilidadPaqueteria));
        }

        public decimal CalcularCostoAdiccionalEnvio(decimal costoTransporte, decimal distancia, DateTime fechaPedido, string paqueteria)
        {
            return calculaUtilidadPaqueteria.CalcularUtilidadEmpresa(paqueteria, fechaPedido, costoTransporte);
        }
    }
}