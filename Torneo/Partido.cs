using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
using Parcial2.Observer;

namespace linq.Torneo
{
    public class Partido
    {
        #region Properties  
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }

        #endregion Properties

        #region Initialize
        public Partido(Seleccion EquipoLocal, Seleccion EquipoVisitante) 
        {
            this.EquipoLocal = new Equipo(EquipoLocal);
            this.EquipoVisitante = new Equipo(EquipoVisitante);
        }
        #endregion Initialize
        #region Methods
        private void CalcularExpulsiones()
        {
            GestorEjecciones myGestor = new GestorEjecciones();
            Random random = new Random();
            int randyOrton = random.Next(10);
            if(randyOrton<3){
                int juanCena = random.Next(5);
                for(int c=0; c<juanCena; c++){
                    int lastRandy = random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                    string kicked = EquipoLocal.Seleccion.Jugadores[lastRandy].Nombre;
                    EquipoLocal.ExpulsarJugador(kicked);
                    Console.WriteLine("Expulsado inmediatamente: "+kicked);
                    myGestor.Notificar(kicked);
                }

            }else if(randyOrton>3 && randyOrton<5){
                int lastRandy = random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                string kicked = EquipoLocal.Seleccion.Jugadores[lastRandy].Nombre;
                EquipoLocal.ExpulsarJugador(kicked);
                Console.WriteLine("Jugador herido se retira: "+kicked);
                myGestor.Notificar(kicked);
            }


        }

        private void CalcularResultado()
        {
            Random random = new Random();
            EquipoLocal.Goles = random.Next(0,6);
            EquipoVisitante.Goles = random.Next(0,6);
        }

        private void AmarillaEnPartido(RepositorioDatos Data, List<Seleccion> Selecciones){
            try{
                GestorEjecciones myGestor = new GestorEjecciones();
                Random random = new Random();

                int cantAmarillas = random.Next(6);
                for(int c=0; c<=cantAmarillas; c++){
                    int numPlayer = random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                    EquipoLocal.DarAmarilla(EquipoLocal.Seleccion.Nombre, EquipoLocal.Seleccion.Jugadores[numPlayer].Nombre, Data, Selecciones);
                }
                int cantAmarillas2 = random.Next(6);
                for(int c=0; c<=cantAmarillas2; c++){
                    int numPlayer2 = random.Next(EquipoVisitante.Seleccion.Jugadores.Count);
                    EquipoVisitante.DarAmarilla(EquipoVisitante.Seleccion.Nombre, EquipoVisitante.Seleccion.Jugadores[numPlayer2].Nombre, Data, Selecciones);
                }
            }
            catch(InvalidOperationException){
                Console.WriteLine("El jugador no existe en el equipo");
            }
            

            
        }

        public string Resultado(RepositorioDatos Data, List<Seleccion> Selecciones)
        {
            string resultado = "0 - 0";
            try
            {
                CalcularExpulsiones();
                CalcularResultado();
                resultado = EquipoLocal.Goles.ToString() + " - " + EquipoVisitante.Goles.ToString();

                AmarillaEnPartido(Data, Selecciones);
            }
            catch(LoseForWException ex)
            {
                Console.WriteLine(ex.Message);
                EquipoLocal.Goles -= EquipoLocal.Goles;
                EquipoVisitante.Goles -= EquipoVisitante.Goles;
                if (ex.NombreEquipo == EquipoLocal.Seleccion.Nombre)
                {
                    EquipoVisitante.Goles += 3;
                    resultado = "0 - 3";
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado = "3 - 0";
                }
            }
            
            return resultado;
        }
        #endregion Methods

    }
}