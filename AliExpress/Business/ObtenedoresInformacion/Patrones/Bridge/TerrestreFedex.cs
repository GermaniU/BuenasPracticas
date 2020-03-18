using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class TerrestreFedex : ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return  new TimeSpan(10,0,0);
        }
    }
}