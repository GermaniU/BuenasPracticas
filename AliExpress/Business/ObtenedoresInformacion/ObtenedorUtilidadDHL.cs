using Entidades;
using Interfaces;
using System;

namespace Business
{
    public class ObtenedorUtilidadDHL : IObtenedorUtilidadPaqueteria
    {
        public decimal ObtenerUtilidadEmpresa(DateTime fechaPedido)
        {
            decimal UtilidadEmpresa = 0.0M;
            int mesPedido = fechaPedido.Month;

            if (mesPedido >= (int)EnumMeses.Enero && mesPedido <= (int)EnumMeses.Junio)
            {
                UtilidadEmpresa = .50M;
            }

            if (mesPedido >= (int)EnumMeses.Julio && mesPedido <= (int)EnumMeses.Diciembre)
            {
                UtilidadEmpresa = .10M;
            }

            return UtilidadEmpresa;
        }
    }
}