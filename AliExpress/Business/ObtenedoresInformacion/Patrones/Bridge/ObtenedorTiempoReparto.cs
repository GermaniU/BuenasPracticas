using System;

namespace Interfaces.Business.ObtenedoresInformacion
{
    public class ObtenedorTiempoReparto : IObtenedorTiempoReparto
    {
        private readonly ITiempoReparto tiempoReparto;

        public ObtenedorTiempoReparto(ITiempoReparto tiempoReparto)
        {
            this.tiempoReparto = tiempoReparto ?? throw new ArgumentNullException(nameof(tiempoReparto));
        }

        public TimeSpan ObtenerTiempoReparto()
        {
            return tiempoReparto.ObtenerTiempoReparto();
        }
    }
}