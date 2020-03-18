using Entidades;
using Interfaces;

namespace Business.CalculosCostosAdiccionales
{
    public class CalculaCostoAdiccionalPorTemporadaVeran:ICalculaCostoAdiccionalPorTemporada
    {
        public decimal CalcularCostoAdiccionalPorTemporada(decimal costoTransporte)
        {
           return costoTransporte * (1 + 0.10M);;
        }
    }
}
