namespace Interfaces
{
    public interface ICalculaCostoAdiccionalTemporada
    {
        decimal CalcularCostoAdiccionalPorTemporada(decimal costoEnvio, decimal porcentajeCostoPorTemporada);
    }
}
