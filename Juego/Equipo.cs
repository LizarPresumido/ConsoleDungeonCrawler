using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Equipo
    {
        private readonly string[] nombres = new string[2] { "Espada", "Escudo" };
        private int coste;
        private string nombre;
        private int tipo;
        private int lvl;
        Random rng;

        public Equipo(int lvl) //Crea el equipamiento que puede ser una espada o un escudo
        {
            rng = new Random();
            tipo = rng.Next(0, 2);
            nombre = nombres[tipo];
            this.lvl = lvl;
            coste = 5;
        }

        public int getTipo()
        {
            return tipo;
        }

        public string pintar() //Pinta el item con un nivel variable que depende del nivel del jugador 
        {
            return nombre + " Lvl " + lvl + "(+"+lvl+" "+((tipo==0)? "Atk" : "Def")+") --> " + coste + " Oro";
        }

        public int getCoste()
        {
            return coste;
        }

        public int getLvl()
        {
            return lvl;
        }
    }
}
