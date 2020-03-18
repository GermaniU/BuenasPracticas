using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenerVariacionVelocidadVerano : IObtenedorVariacionVelocidad
    {
        public decimal ObtenerVariacionVelocidad()
        {
            return 0.10M;
        }
    }
}