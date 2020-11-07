using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Torneo;
using Newtonsoft.Json;
using linq.GestorAddPlayers;
using linq.GestorCrearEquipos;
using Parcial2.Observer;

namespace linq.FachadaPartido{
    
    public class FachadaMain{
        
                

        #region Methods
        public void EjecutarPrograma(RepositorioDatos Data, List<Seleccion> Selecciones){
            try{

                #region Observer
                GestorEjecciones myGestor = new GestorEjecciones();
                DobleAmarilla alert1 = new DobleAmarilla();
                Inmediata alert2 = new Inmediata();
                Lesion alert3 = new Lesion();

                myGestor.Suscribir(alert1);
                myGestor.Suscribir(alert2);
                myGestor.Suscribir(alert3);



        

        
        #endregion Observer



                AgregarJugadores objAddPlayer = new AgregarJugadores();
                CrearEquipos objCreateTeams = new CrearEquipos();
                AgregarJugadores objectAdder = new AgregarJugadores();



                string team1, team2;
                Console.WriteLine("Digite el nombre del primer equipo:\n-Francia\nColombia\nArgentina\nEspaña\nItalia (seleccion externa)");
                team1 = Console.ReadLine();
                Console.WriteLine("Digite el nombre del segundo equipo:\n-Francia\nColombia\nArgentina\nEspaña\nItalia (seleccion externa)");
                team2 = Console.ReadLine();

                objCreateTeams.CrearEquipo(team1, Selecciones);
                objCreateTeams.CrearEquipo(team2, Selecciones);

                Seleccion Equipo1 = Selecciones.First(s => s.Nombre == team1) as Seleccion;
                Seleccion Equipo2 = Selecciones.FirstOrDefault(s => s.Nombre == team2) as Seleccion;

                Partido partido1 = new Partido(Equipo1, Equipo2);
                Console.WriteLine(partido1.Resultado(Data, Selecciones));
            }
            catch(InvalidOperationException){

            }
            


        }
        #endregion







    }
}

    
