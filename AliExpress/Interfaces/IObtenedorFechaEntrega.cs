using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IObtenedorFechaEntrega
    {
        DateTime dtFechaEntrega(decimal distancia, string medioTransporte, DateTime fechaPedido, string paqueteria);
    }
}
