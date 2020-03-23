using Genericos.Interfaces;
using System;

namespace Genericos.Clases
{
    public abstract class CadenaResponsabilidadBase<TEntidadPorProcesar> : ICadenaResponsabilidad<TEntidadPorProcesar>
    {
        protected ICadenaResponsabilidad<TEntidadPorProcesar> siguienteResponsabilidad;
        
        public CadenaResponsabilidadBase()
        {
            siguienteResponsabilidad = null;
        }

        public ICadenaResponsabilidad<TEntidadPorProcesar> RegistrarSiguiente(ICadenaResponsabilidad<TEntidadPorProcesar> _siguienteResponsabilidad)
        {
            siguienteResponsabilidad = _siguienteResponsabilidad;
            return siguienteResponsabilidad;
        }

        public void ProcesarYAvanzar(TEntidadPorProcesar _InformacionFuente)
        {
            Procesar(_InformacionFuente);
            if (siguienteResponsabilidad!=null)
            {
                siguienteResponsabilidad.ProcesarYAvanzar(_InformacionFuente);
            }
        }

        protected abstract void Procesar(TEntidadPorProcesar _InformacionFuente);

        protected virtual void NotificarErrorEncontrado(string _cMensajeError)
        {
            if (!string.IsNullOrEmpty(_cMensajeError))
            {
                throw new Exception(_cMensajeError);
            }
        }
    }
}
