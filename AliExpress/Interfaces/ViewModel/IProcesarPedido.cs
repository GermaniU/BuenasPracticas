using System.Collections.Generic;
using Entidades;

namespace Interfaces.ViewModel
{
    public interface IProcesarPedido
    {
        List<string> ProcesarInformacionPedido(List<PedidoDTO> paquetes);

    }
}