using Entidades;
using Interfaces;

namespace Business.CalculosCostosAdiccionales
{
    public class CalculaCostoAdiccionalPorTemporadaInvierno : ICalculaCostoAdiccionalPorTemporada
    {
        public decimal CalcularCostoAdiccionalPorTemporada(decimal costoTransporte)
        {
            return (costoTransporte * (1 + 0.23M));
        }
    }
}
