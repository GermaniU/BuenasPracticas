using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICalculaCotizacionPaqueteria
    {
        decimal ObtenerCostoServicio(decimal distanciaEntrega, decimal costoGeneralEntrega, int porcentajemargenUtilidad);

        decimal ObtenerTiempoServicio(decimal distanciaEntrega, decimal kilometroHoraServicio, int tiempoAdiccionalReparto);
    }
}
