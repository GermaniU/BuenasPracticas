using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorTiempoDescansoPorDiaOtonio: IObtenedorTiempoDescansoPorDia
    {
        public decimal ObtenerTiempoDescansoPorDia()
        {
            return 5M;
        }
    }
}