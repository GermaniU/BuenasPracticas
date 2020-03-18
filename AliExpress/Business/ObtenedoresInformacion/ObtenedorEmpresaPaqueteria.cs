using Entidades;
using Interfaces;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorEmpresaPaqueteria: IObtenedorEmpresaPaqueteria
    {
        public EnumEmpresasPaqueteria ObtenerIdentificadorPaqueteria(string empresaPaqueteria)
        {
            var EnumEmpresa = EnumEmpresasPaqueteria.DHL;
            
            switch (empresaPaqueteria.ToUpper())
            {
                case "DHL":
                    EnumEmpresa = EnumEmpresasPaqueteria.DHL;
                    break;
                case "FEDEX":
                    EnumEmpresa = EnumEmpresasPaqueteria.Fedex;
                    break;
                case "ESTAFETA":
                    EnumEmpresa = EnumEmpresasPaqueteria.Estafeta;
                    break;
            }

            return EnumEmpresa;
        }
    }
}
