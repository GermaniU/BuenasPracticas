using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class MaritimoDHL :ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return new TimeSpan(0,20,0,0);
        }
    }
}