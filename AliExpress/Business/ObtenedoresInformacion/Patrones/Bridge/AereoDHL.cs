using System;
using Interfaces.Business.ObtenedoresInformacion;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class AereoDHL : ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return  new TimeSpan(3,0,0);
        }
    }
}