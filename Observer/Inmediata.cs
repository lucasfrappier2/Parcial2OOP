using System;

namespace Parcial2.Observer
{
    public class Inmediata : IObserverEjecciones
    {
      public void update(string jugadorEnCuestion){
          Console.WriteLine("Expulsion inmediata para: " + jugadorEnCuestion);
      }
    }
}