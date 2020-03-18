namespace Interfaces
{
    public interface ICalculaCostoAdiccionalEnvio
    {
        decimal CalcularCostoAdiccionalEnvio(decimal costoTransporte, decimal distancia, System.DateTime fechaPedido, string paqueteria);
    }
}
