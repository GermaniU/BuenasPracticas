using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class GeneralEstafeta :ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return new TimeSpan(0,0,5,0);
        }
    }
}