using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Interfaces;

namespace Business
{
    public class CalcularUtilidadPaqueteria : ICalculaUtilidadPaqueteria
    {
        private readonly IObtenedorEmpresaPaqueteria ObtenedorEmpresaPaqueteria;
        private readonly IObtenedorUtilidadPaqueteria ObtenedorUtilidadPaqueteria;

        public CalcularUtilidadPaqueteria(IObtenedorEmpresaPaqueteria obtenedorEmpresaPaqueteria,
            IObtenedorUtilidadPaqueteria obtenedorUtilidadPaqueteria)
        {
            ObtenedorEmpresaPaqueteria = obtenedorEmpresaPaqueteria ??
                                         throw new ArgumentNullException(nameof(obtenedorEmpresaPaqueteria));
            ObtenedorUtilidadPaqueteria = obtenedorUtilidadPaqueteria ??
                                          throw new ArgumentNullException(nameof(obtenedorUtilidadPaqueteria));
        }

        public decimal CalcularUtilidadEmpresa(string paqueteria,DateTime fechaPedido , decimal costoTransporte)
        {
            var empresaPaqueteria = ObtenedorEmpresaPaqueteria.ObtenerIdentificadorPaqueteria(paqueteria);
            var utilidadEmpresa = ObtenedorUtilidadPaqueteria.ObtenerUtilidadEmpresa(empresaPaqueteria, fechaPedido);

            return CalcularCostoServicio(costoTransporte, utilidadEmpresa);
        }

        private decimal CalcularCostoServicio(decimal costoTransporte, decimal utilidadEmpresa)
        {
            return costoTransporte * (1 + utilidadEmpresa);

        }
    }
}