using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenerVariacionVelocidadInvierno : IObtenedorVariacionVelocidad
    {
        public decimal ObtenerVariacionVelocidad()
        {
            return -0.3M;
        }
    }
}