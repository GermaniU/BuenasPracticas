using Entidades.DTO;
using Genericos.Clases;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.CadenResponsabilidadColaborativa
{
    public class ObtenerFormatoHoras : CadenaResponsabilidadConParametroBase<string, FechasPedidoDTO>, IObtenedorFormatoFecha
    {
        protected override void Procesar(string _InformacionFuente, FechasPedidoDTO _Parametro)
        {
            var tiempoEntregaHoras = _Parametro.FechaEntrega.TimeOfDay.TotalHours;
            var tiempoPedidoHoras = _Parametro.FechaPedido.TimeOfDay.TotalHours;
            var tiempoHoras = tiempoEntregaHoras - tiempoPedidoHoras;

            if (tiempoEntregaHoras <= 23)
            {
                _InformacionFuente = tiempoHoras.ToString();
            }
        }
    }
}
