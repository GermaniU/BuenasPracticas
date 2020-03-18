using Entidades;
using Interfaces;

namespace Business
{
    public class ObtenedorCostoPorKilometroTerrestre : IObtenedorCostoPorKilometro
    {
        public decimal ObtenerCostoPorKilometro(decimal distancia)
        {
            decimal costoKilometro = 0M;

            if (distancia >= 1 && distancia <= 50)
            {
                costoKilometro = 15;
            }

            if (distancia >= 51 && distancia <= 200)
            {
                costoKilometro = 10;
            }

            if (distancia >= 201 && distancia <= 300)
            {
                costoKilometro = 8;
            }

            if (distancia >= 301)
            {
                costoKilometro = 7;
            }


            return costoKilometro;
        }
    }
}
