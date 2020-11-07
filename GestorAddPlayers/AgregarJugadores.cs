using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excepciones.CustomExceptions;
using Newtonsoft.Json;
using linq.Torneo;

namespace linq.GestorAddPlayers{
    
    public class AgregarJugadores{

        #region Methods
        
        public void AgregarJugador(string fileName, List<Seleccion> Teams, string nombreEquipo){
            try{
                List<Jugador> JugadoresDeserializada = JsonConvert.DeserializeObject<List<Jugador>>(File.ReadAllText(fileName));

                Seleccion x = Teams.First(x=>x.Nombre == nombreEquipo);

                List<Jugador> c = x.Jugadores;

                c.AddRange(JugadoresDeserializada);

                x.Jugadores = c;
            }
            catch(System.IO.FileNotFoundException){
                Console.WriteLine("Digitar unicamente los nombres que aparecen disponibles");
            }
            catch(NullReferenceException){
                Console.WriteLine("Objeto no existente");
            }
            catch(InvalidOperationException){
                Console.WriteLine("Digitar unicamente los nombres que aparecen disponibles");
            }
            

        }


        #endregion 
    }

    
}