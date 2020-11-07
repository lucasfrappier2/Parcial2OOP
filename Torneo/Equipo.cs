using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
using Parcial2.Observer;

namespace linq.Torneo
{
    public class Equipo
    {
        #region Properties  
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int Faltas { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
        public Seleccion Seleccion { get; set; }
        public bool EsLocal { get; set; }

        #endregion Properties

        #region Initialize
        public Equipo(Seleccion seleccion)
        {
            this.Seleccion = seleccion;
        }
        #endregion Initialize

        #region Methods

        public void DarAmarilla(string equipo, string name, RepositorioDatos Data, List<Seleccion> selecciones){
            try{
                GestorEjecciones myGestor = new GestorEjecciones();
                Seleccion x = selecciones.First(x=>x.Nombre == equipo);
                Jugador giocatore = x.Jugadores.First(p=>p.Nombre == name); ///////////////////////////

                if(giocatore.Amonestaciones == 0){
                    Console.WriteLine("Amonestado: " + giocatore.Nombre);
                    giocatore.Amonestaciones++;
                }else{
                    Console.WriteLine("Segunda Amonestación: " + giocatore.Nombre + ". Jugador expulsado");
                    ExpulsarJugador(giocatore.Nombre);
                    myGestor.Notificar(giocatore.Nombre);
                }
            }catch(InvalidOperationException){
                Console.WriteLine("El jugador no pertenece a la seleccion");
            }

        }

        public void ExpulsarJugador(string name)
        {
            try
            {
                GestorEjecciones myGestor = new GestorEjecciones();
                Jugador jugadorExpulsado = Seleccion.Jugadores.First(j => j.Nombre == name);
                TarjetasRojas++;
                if (Seleccion.Jugadores.Count < 6)
                {
                    LoseForWException ex = new LoseForWException(Seleccion.Nombre);
                    ex.NombreEquipo = Seleccion.Nombre;
                    throw ex;
                }
                Seleccion.Jugadores.Remove(jugadorExpulsado);
                myGestor.Notificar(jugadorExpulsado.Nombre);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No existe ese jugador para expulsarlo del equipo " + Seleccion.Nombre);
            }
            
        }
        #endregion Methods
    }
}