using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorTiempoDescansoPorDiaPrimavera : IObtenedorTiempoDescansoPorDia
    {
        public decimal ObtenerTiempoDescansoPorDia()
        {
            return 4M;
        }
    }
}