using Entidades;
using Interfaces;
using System;

namespace Business
{
    public class ObtenedorUtilidadFedex : IObtenedorUtilidadPaqueteria
    {
        public decimal ObtenerUtilidadEmpresa(EnumEmpresasPaqueteria paqueteria, DateTime fechaPedido)
        {
            decimal UtilidadEmpresa = 0.0M;
            int mesPedido = fechaPedido.Month;

            if ((mesPedido % 2) == 0)
            {
                UtilidadEmpresa = .40M;
            }
            else
            {
                UtilidadEmpresa = .30M;
            }

            return UtilidadEmpresa;
        }
    }
}