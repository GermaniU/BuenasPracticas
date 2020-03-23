using Entidades.DTO;
using Genericos.Clases;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.CadenResponsabilidadColaborativa
{
    public class ObtenerFomatoMeses : CadenaResponsabilidadConParametroBase<string, FechasPedidoDTO>, IObtenedorFormatoFecha
    {
        protected override void Procesar(string _InformacionFuente, FechasPedidoDTO _Parametro)
        {
            var tiempoEntregaMes = _Parametro.FechaEntrega.Month;
            var tiempoPedidoMes = _Parametro.FechaPedido.Month;
            var tiempoMes = tiempoEntregaMes - tiempoPedidoMes;

            if (tiempoMes <= 30)
            {
                _InformacionFuente = tiempoMes.ToString();
            }
        }
    }
}