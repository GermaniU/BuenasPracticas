using Interfaces;

namespace Business.CalculosCostosAdiccionales
{
    public class CalculaCostoAdiccionalPorTemporadaPrimavera:ICalculaCostoAdiccionalPorTemporada
    {
        public decimal CalcularCostoAdiccionalPorTemporada(decimal costoTransporte)
        {
            return costoTransporte;
        }
    }
}