using Interfaces.Business.ObtenedoresInformacion;
using System;
using System.Runtime.Remoting.Messaging;

namespace Business.ObtenedoresInformacion.Patrones.Bridge
{
    public class MaritimoFedex :ITiempoReparto
    {
        public TimeSpan ObtenerTiempoReparto()
        {
            return new TimeSpan(21 ,0,0);
        }
    }
}
