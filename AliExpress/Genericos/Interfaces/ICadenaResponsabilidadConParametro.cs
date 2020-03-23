namespace Genericos.Interfaces
{
    public interface ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro>
    {
        ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro> RegistrarSiguiente(ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro> _siguienteResponsabilidad);

        void ProcesarYAvanzar(TEntidadPorProcesar _InformacionFuente, TParametro _Parametro);
    }
}
