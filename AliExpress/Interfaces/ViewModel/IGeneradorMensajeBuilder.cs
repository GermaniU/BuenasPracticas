namespace Interfaces
{
    public interface IGeneradorMensajeBuilder
    {
        IGeneradorMensajeBuilder AsignarEstatusEntrega(string estatusEntrega);

        IGeneradorMensajeBuilder AsignarEstatusTiempoPedido(string estatusTiempoPedido);

        IGeneradorMensajeBuilder AsignarEstatusTiempoEntrega(string estatusTiempoEntrega);

        IGeneradorMensajeBuilder AsignarFormatoTiempo(string formatoTiempoEntrega);

        IGeneradorMensajeBuilder AsignarMensajeFormatoCosto(string mensajeFormatoCosto);

        IGeneradorMensajeBuilder AsignarMensajeCosto(decimal costo);
        string ObtenerResultado();
    }
}
