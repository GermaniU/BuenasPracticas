using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorTiempoDescansoPorDiaVerano: IObtenedorTiempoDescansoPorDia
    {
        public decimal ObtenerTiempoDescansoPorDia()
        {
            return 6M;
        }
    }
}
