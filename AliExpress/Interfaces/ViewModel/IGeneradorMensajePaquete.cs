using System;
using Entidades;

namespace viewModel
{
    public interface IGeneradorMensajePaquete
    {
        string prepararMensajePedido(PedidoDTO pedido, DateTime fechaEntrega, DateTime fechaActual,decimal costoPedido);
    }
}