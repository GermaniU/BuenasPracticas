using Entidades;
using Interfaces;

namespace Business
{
    public class  ObtenedorCostoPorKilometroAereo: IObtenedorCostoPorKilometro
    {
        public decimal ObtenerCostoPorKilometro(decimal distancia)
        {
            return 10;
        }
    }
}
