using System;
using Interfaces;

namespace Business
{
    public class ObtenedorCostoPorKilometroMaritimo : IObtenedorCostoPorKilometro
    {
        public decimal ObtenerCostoPorKilometro(decimal distancia)
        {
            decimal costoKilometro = 0M;

            if (distancia >= 1 && distancia <=100)
            {
                costoKilometro = 1;
            }

            if (distancia >= 101 && distancia<= 1000)
            {
                costoKilometro = 0.5M;
            }

            if (distancia >= 1001)
            {
                costoKilometro = 0.3M;
            }

            return costoKilometro;
        }
    }
}