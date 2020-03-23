using Genericos.Interfaces;
using System;

namespace Genericos.Clases
{
    public abstract class CadenaResponsabilidadConParametroBase<TEntidadPorProcesar, TParametro> : ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro>
    {
        protected ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro> siguienteResponsabilidad;

        public CadenaResponsabilidadConParametroBase()
        {
            siguienteResponsabilidad = null;
        }

        public ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro> RegistrarSiguiente(ICadenaResponsabilidadConParametro<TEntidadPorProcesar, TParametro> _siguienteResponsabilidad)
        {
            siguienteResponsabilidad = _siguienteResponsabilidad;
            return siguienteResponsabilidad;
        }

        public void ProcesarYAvanzar(TEntidadPorProcesar _InformacionFuente, TParametro _Parametro)
        {
            Procesar(_InformacionFuente,_Parametro);
            if (siguienteResponsabilidad != null)
            {
                siguienteResponsabilidad.ProcesarYAvanzar(_InformacionFuente, _Parametro);
            }
        }

        protected abstract void Procesar(TEntidadPorProcesar _InformacionFuente, TParametro _Parametro);

        protected virtual void NotificarErrorEncontrado(string _cMensajeError)
        {
            if (!string.IsNullOrEmpty(_cMensajeError))
            {
                throw new Exception(_cMensajeError);
            }
        }
    }
}
