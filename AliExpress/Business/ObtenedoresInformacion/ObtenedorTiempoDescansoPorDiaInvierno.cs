using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorTiempoDescansoPorDiaInvierno : IObtenedorTiempoDescansoPorDia
    {
        public decimal ObtenerTiempoDescansoPorDia()
        {
            return 8M;
        }
    }
}