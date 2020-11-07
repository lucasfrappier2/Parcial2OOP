using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excepciones.CustomExceptions;
using Newtonsoft.Json;
using linq.Torneo;
using linq.GestorAddPlayers;

namespace linq.GestorCrearEquipos{

    public class CrearEquipos{
        AgregarJugadores objectAdder = new AgregarJugadores();

        #region Methods

        public void CrearEquipo(string team, List<Seleccion> Selecciones){
            try{
                if((team.ToLower() == "italia")){

                Selecciones.Add(new Seleccion()
                    {
                    Nombre = team,
                    Jugadores = new List<Jugador>()
                    {}

                });
                objectAdder.AgregarJugador("./jugadores"+team+".json", Selecciones, team);
                

                }else{
                objectAdder.AgregarJugador("./jugadores"+team+".json", Selecciones, team);
                }
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