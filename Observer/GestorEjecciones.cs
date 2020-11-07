using System;
using System.Collections.Generic;

namespace Parcial2.Observer
{
    public class GestorEjecciones
    {
        #region Properties
        private List<IObserverEjecciones> subs;
        public List<IObserverEjecciones> Subs
        {
            get { return subs; }
            set { subs = value; }
        }

        #endregion Properties

        

        

        public GestorEjecciones(){
            Subs = new List<IObserverEjecciones>();
        }

        #region Methods

        public void Suscribir(IObserverEjecciones sub){
            Subs.Add(sub);

        }

        public void desSuscribir(IObserverEjecciones sub){
            Subs.Remove(sub);
        }

        public void Notificar(string jugadorEnCuestion){
            Subs.ForEach(x => {
                x.update(jugadorEnCuestion);
            });
        }

        #endregion Methods


    
    }
}
