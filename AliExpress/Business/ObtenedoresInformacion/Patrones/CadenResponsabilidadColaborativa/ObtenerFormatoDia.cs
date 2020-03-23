using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DTO;
using Genericos.Clases;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.CadenResponsabilidadColaborativa
{
    public class ObtenerFormatoDia: CadenaResponsabilidadConParametroBase<string, FechasPedidoDTO>, IObtenedorFormatoFecha
    {
        protected override void Procesar(string _InformacionFuente, FechasPedidoDTO _Parametro)
        {
            var tiempoEntregaDia = _Parametro.FechaEntrega.TimeOfDay.TotalDays;
            var tiempoPedidoDia = _Parametro.FechaPedido.TimeOfDay.TotalDays;
            var tiempoDias = tiempoEntregaDia - tiempoPedidoDia;

            if (tiempoDias <= 30)
            {
                _InformacionFuente = tiempoDias.ToString();
            }
        }
    }
}
