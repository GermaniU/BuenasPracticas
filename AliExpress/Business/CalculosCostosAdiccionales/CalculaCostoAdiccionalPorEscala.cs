using Interfaces;

namespace Business
{
    public class CalculaCostoAdiccionalPorEscala:ICalculaCostoAdiccionalPorEscala
    {
        public decimal CalcularCostoPorEscala(decimal distancia)
        {
            var numeroEscalas = ObtenerNumeroEscalas(distancia);
            var costoPorEscala = 200;
            var costoTotal = numeroEscalas * 200;

            return costoTotal;
        }

        private  int ObtenerNumeroEscalas(decimal distancia)
        {
            var numeroEscalas = 0;

            if (distancia > 1000)
            {
                numeroEscalas = (int)(distancia / 1000);
            }

            return numeroEscalas;
        }
    }
}
