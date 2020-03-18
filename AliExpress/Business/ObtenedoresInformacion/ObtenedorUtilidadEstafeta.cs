using System;
using Entidades;
using Interfaces;

namespace Business
{
    public class ObtenedorUtilidadEstafeta : IObtenedorUtilidadPaqueteria
    {
        public decimal ObtenerUtilidadEmpresa(DateTime fechaPedido)
        {
            decimal UtilidadEmpresa;
            var diaPedido = fechaPedido.Day;
            var mesPedido = fechaPedido.Month;

            var utilidadFija = .45M;

            UtilidadEmpresa = utilidadFija;

            if (diaPedido == 14 && mesPedido == (int)EnumMeses.Febrero)
            {
                UtilidadEmpresa = utilidadFija + .10M;
            }

            if (mesPedido ==(int) EnumMeses.Diciembre)
            {
                UtilidadEmpresa = utilidadFija + .50M;
            }

            return UtilidadEmpresa;
        }
    }
}