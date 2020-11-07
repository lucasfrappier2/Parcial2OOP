using System;

namespace Parcial2.Observer
{
    public class DobleAmarilla : IObserverEjecciones
    {
          public void update(string jugadorEnCuestion){
          Console.WriteLine("Por doble amarilla se expulsa a: " + jugadorEnCuestion);
      }
    }
}