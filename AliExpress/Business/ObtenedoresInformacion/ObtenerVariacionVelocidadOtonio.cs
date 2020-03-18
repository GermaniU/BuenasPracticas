using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenerVariacionVelocidadOtonio : IObtenedorVariacionVelocidad
    {
        public decimal ObtenerVariacionVelocidad()
        {
            return 0.15M;
        }
    }
}