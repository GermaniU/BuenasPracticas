using Interfaces;
using System;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorFechaActual :IObtenedorFechaActual
    {
        public DateTime ObtenerFechaActual()
        {
            return new DateTime();
        }
    }
}
