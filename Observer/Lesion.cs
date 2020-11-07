using System;

namespace Parcial2.Observer
{
    public class Lesion : IObserverEjecciones
    {
      public void update(string jugadorEnCuestion){
          Console.WriteLine("Se ha lesionado y se retira: " + jugadorEnCuestion);
      }
    }
}