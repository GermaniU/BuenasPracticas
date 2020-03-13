using Entidades;

namespace Interfaces
{
    public interface IConfiguradorMensajeBuilder
    {
        IGeneradorMensajeBuilder IniciarConfiguracionPedido(PedidoDTO pedido);
    }
}
