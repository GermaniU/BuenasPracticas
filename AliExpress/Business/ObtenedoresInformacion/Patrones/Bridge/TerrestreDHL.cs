using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class TerrestreDHL : ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return  new  TimeSpan(12,0,0);
        }
    }
}