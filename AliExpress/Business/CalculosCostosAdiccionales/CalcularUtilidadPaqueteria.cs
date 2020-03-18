using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Interfaces;

namespace Business
{
    public class CalcularUtilidadPaqueteria : ICalculaUtilidadPaqueteria
    {
        private readonly IObtenedorUtilidadPaqueteria ObtenedorUtilidadPaqueteria;

        public CalcularUtilidadPaqueteria(
            IObtenedorUtilidadPaqueteria obtenedorUtilidadPaqueteria)
        {

            ObtenedorUtilidadPaqueteria = obtenedorUtilidadPaqueteria ??
                                          throw new ArgumentNullException(nameof(obtenedorUtilidadPaqueteria));
        }

        public decimal CalcularUtilidadEmpresa(string paqueteria,DateTime fechaPedido , decimal costoTransporte)
        {
            var utilidadEmpresa = ObtenedorUtilidadPaqueteria.ObtenerUtilidadEmpresa(fechaPedido);

            return CalcularCostoServicio(costoTransporte, utilidadEmpresa);
        }

        private decimal CalcularCostoServicio(decimal costoTransporte, decimal utilidadEmpresa)
        {
            return costoTransporte * (1 + utilidadEmpresa);

        }
    }
}