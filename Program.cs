using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Torneo;
using Newtonsoft.Json;
using linq.GestorAddPlayers;
using linq.GestorCrearEquipos;
using linq.FachadaPartido;
using Parcial2.Observer;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioDatos Data = new RepositorioDatos();
            List<Seleccion> Selecciones = Data.Selecciones;

            FachadaMain objFachada = new FachadaMain();
            
            objFachada.EjecutarPrograma(Data, Selecciones);

            GestorEjecciones GestorA = new GestorEjecciones();

        }
    }
}
