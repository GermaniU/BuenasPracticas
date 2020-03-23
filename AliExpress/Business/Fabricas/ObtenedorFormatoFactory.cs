using Business.ObtenedoresInformacion.Patrones.CadenResponsabilidadColaborativa;
using Interfaces.Business.ObtenedoresInformacion;
using Interfaces.Fabricas;

namespace Business.Fabricas
{
    public class ObtenedorFormatoFactory:IObtenedorFormatoFactory
    {
        public IObtenedorFormatoFecha CrearInstanciaCadena()
        {
            var ObtenedorFormatoDia =  new ObtenerFormatoDia();
            var ObtenedorFormatoMes = new ObtenerFomatoMeses();
            var ObtenedorFormatoHoras =  new ObtenerFormatoHoras();
            var ObtenedorFormatoMinutos =  new ObtenerFormatoMinutos();

        }
    }
}