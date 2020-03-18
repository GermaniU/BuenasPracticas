using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces.Business.CalculaFechaEntrega;

namespace Interfaces.Fabricas
{
    public interface ICalculaVariacionVelocidadFactory
    {
         ICalculaVariacionVelocidad CrearInstancia(EnumEstacionesAnio estacionesAnio);
    }
}
