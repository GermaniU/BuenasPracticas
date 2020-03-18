using Entidades;
using Interfaces;

namespace Business.CalculosCostosAdiccionales
{
    public class CalculaCostoAdiccionalPorTemporadaOtonio :ICalculaCostoAdiccionalPorTemporada
    {
        public decimal CalcularCostoAdiccionalPorTemporada(decimal costoTransporte)
        {
            return costoTransporte * (1 + 0.15M);
        }
    }
}
