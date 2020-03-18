using System;
using Entidades;
using Interfaces;

namespace Business.ObtenedoresInformacion
{
    public class ObtenedorEstacionesAnio : IObtenedorEstacionAnio
    {
        public  EnumEstacionesAnio ObtenerEstacion(DateTime date)
        {
            decimal value = date.Month + date.Day / 100M;  

            EnumEstacionesAnio estacionesAnio = EnumEstacionesAnio.Invierno;

            if (value < 3.21M && value >= 12.21M){
                estacionesAnio = EnumEstacionesAnio.Invierno;   // Invierno
            }

            if (value >= 3.21M && value < 6.21M){
                estacionesAnio = EnumEstacionesAnio.Primavera; // Primavera
            }

            if (value < 9.21M && value >=6.21M){
                estacionesAnio = EnumEstacionesAnio.Verano; // Verano
            }

            if (value < 12.21M && value >= 9.21M)
            {
                estacionesAnio = EnumEstacionesAnio.Otonio; // Otoño
            }

            return estacionesAnio;
        }

    }
}