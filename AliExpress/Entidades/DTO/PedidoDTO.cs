using System;

namespace Entidades
{
    public class PedidoDTO
    {
        public decimal Distancia { get; set; }
        public string Paqueteria { get; set; }
        public string MedioTransporte { get; set; }
        public string PaisOrigen { get; set; }
        public string OrigenPaquete { get; set; }
        public string Destino { get; set; }
        public DateTime FechaPedido { get; set; }
        public string paisDestino { get; set; }

    }
}
