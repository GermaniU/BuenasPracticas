namespace Genericos.Interfaces
{ 
    public interface ICadenaResponsabilidad<TEntidadPorProcesar>
    {
        ICadenaResponsabilidad<TEntidadPorProcesar> RegistrarSiguiente(ICadenaResponsabilidad<TEntidadPorProcesar> _siguienteResponsabilidad);

        void ProcesarYAvanzar(TEntidadPorProcesar _InformacionFuente);
    }
}
