using Entidades;
using Interfaces;

namespace viewModel
{
    public class GeneradorMensajeBuilder: IGeneradorMensajeBuilder, IConfiguradorMensajeBuilder
    {
        private string Mensaje = string.Empty;
        private PedidoDTO pedido;


        public IGeneradorMensajeBuilder IniciarConfiguracionPedido(PedidoDTO pedido)
        {
            this.pedido = pedido;
            Mensaje = prepararPlatillaIncial();
            sustituirDatos("E2", $"{pedido.OrigenPaquete}, {pedido.PaisOrigen}");
            sustituirDatos("E4", $"{pedido.Destino}, {pedido.paisDestino}");
            sustituirDatos("E9", pedido.Paqueteria);
            return this;
        }

        private string prepararPlatillaIncial()
        {
            return
                $"Tu paquete [E1] de [E2] y [E3] a [E4] [E5] [E6] y [E7] un costo de [E8](cualquier reclamación con [E9]).";
        }

        private void sustituirDatos(string token, string valor)
        {
            Mensaje = Mensaje.Replace($"[{token}]", valor);
        }

        public IGeneradorMensajeBuilder AsignarEstatusEntrega(string estatusEntrega)
        {
            sustituirDatos("E1",estatusEntrega);
            return this;
        }
        public IGeneradorMensajeBuilder AsignarEstatusTiempoPedido(string estatusTiempoPedido)
        {
            sustituirDatos("E3", estatusTiempoPedido);
            return this;
        }
        public IGeneradorMensajeBuilder AsignarEstatusTiempoEntrega(string estatusTiempoEntrega)
        {
            sustituirDatos("E5", estatusTiempoEntrega);
            return this;
        }
        public IGeneradorMensajeBuilder AsignarFormatoTiempo(string formatoTiempoEntrega)
        {
            sustituirDatos("E6", formatoTiempoEntrega);
            return this;
        }

        public IGeneradorMensajeBuilder AsignarMensajeFormatoCosto(string mensajeFormatoCosto)
        {
            sustituirDatos("E7", mensajeFormatoCosto);
            return this;
        }

        public IGeneradorMensajeBuilder AsignarMensajeCosto(decimal costo)
        {
            sustituirDatos("E8", $"${costo}");
            return this;
        }

        public string ObtenerResultado()
        {
            return Mensaje;
        }

    }
}
