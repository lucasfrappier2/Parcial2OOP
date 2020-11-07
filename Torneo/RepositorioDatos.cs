using System.Collections.Generic;
using System.Linq;

namespace linq.Torneo
{
    public class RepositorioDatos
    {
        #region Properties  
        public List<Seleccion> Selecciones { get; set; }
        
        #endregion Properties

        #region Initialize
        public RepositorioDatos()
        {
            Selecciones = CrearSelecciones();
        }
        #endregion Initialize


        #region Methods
        private List<Seleccion> CrearSelecciones()
        {
            List<Seleccion> selecciones = new List<Seleccion>();
            selecciones.Add(new Seleccion()
            {
                Nombre = "Francia",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Griezmann", 28, 11, 90, 55, 10, 2, 0),    //nombre, edad, posicion, ataque, defensa, goles, assists, amonestaciones
                    new Jugador("Benzema", 32, 9, 92, 40, 20, 1, 0),
                    new Jugador("Mbappe", 21, 7, 95, 50, 15, 14, 0),
                    new Jugador("Dembelé", 23, 11, 92, 45, 12, 17, 0),
                    /*new Jugador("Pogba", 30, 4, 98, 30, 20, 2, 0),
                    new Jugador("Cammavinga", 21, 6, 82, 54, 8, 19, 0),
                    new Jugador("Pavard", 24, 11, 91, 42, 18, 9, 0),
                    new Jugador("Umtiti", 27, 2, 79, 75, 2, 26, 0),
                    new Jugador("Upamecano", 23, 10, 90, 50, 10, 15, 0),
                    new Jugador("Fekir", 19, 8, 86, 48, 9, 12, 0),
                    new Jugador("Grenouille", 86, 0, 99, 10, 8, 65, 0),*/
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "España",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Ramos", 33, 6, 60, 85, 8, 0, 0),
                    new Jugador("Fati", 17, 9, 95, 40, 10, 12, 0),
                    new Jugador("Aspas", 32, 11, 85, 55, 5, 5, 0),
                    new Jugador("Busquets", 33, 5, 79, 85, 2, 3, 0),

                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Colombia",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Falcao", 33, 9, 89, 50, 9, 2, 0),
                    new Jugador("James", 29, 10, 97, 45, 7, 17, 0),
                    new Jugador("Ospina", 31, 1, 40, 95, 0, 0, 0),
                    new Jugador("Mina", 24, 2, 55, 89, 4, 0, 0),

                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Argentina",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Messi", 33, 10, 99, 50, 40, 20, 0),
                    new Jugador("Aguero", 32, 9, 90, 50, 10, 5, 0),
                    new Jugador("Acuña", 24, 4, 75, 85, 3, 10, 0),
                    new Jugador("Dybala", 25, 7, 90, 45, 8, 6, 0),
  
                }
            });
            

            return selecciones;
        }

        #endregion Methods



    }
}