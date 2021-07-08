using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class SalaTienda : Sala
    {
        //Se crean las variables que afectan a la tienda en especifico y se generan 3 objetos y un equipamiento de forma aleatoria
        private Random rng;
        private Objeto[] objetos = new Objeto[3];
        private Equipo equipo;
		public SalaTienda(ref Jugador j1) {
            rng = new Random();
            crearObjetos();
            equipo = new Equipo(j1.getLevel());
        }

		public override void pintar()
		{
			Console.WriteLine("     +--------------------------------------------------+");
			Console.WriteLine("     |                     Tienda                       |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
            pintarObjeto(0);
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
            pintarObjeto(1);
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
            pintarObjeto(2);
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
            pintarEquipo();
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |      4.Salir                                     |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     +--------------------------------------------------+");
		}
        public void crearObjetos()
        {
            for(int i = 0; i < 3; ++i)
            {
                objetos[i] = new Objeto(rng);
            }
        }
        //Se pintan los objetos generados aleatoriamente
        public void pintarObjeto(int num)
        {
            if (objetos[num] != null)
            {
                switch (objetos[num].getTipo())
                {
                    case 0:
                        Console.WriteLine("     |      " + num + "." + objetos[num].pintar() + "                          |");
                        break;
                    case 1:
                        Console.WriteLine("     |      " + num + "." + objetos[num].pintar() + "                          |");
                        break;
                    case 2:
                        Console.WriteLine("     |      " + num + "." + objetos[num].pintar() + "                           |");
                        break;
                    case 3:
                        Console.WriteLine("     |      " + num + "." + objetos[num].pintar() + "              |");
                        break;
                    case 4:
                        Console.WriteLine("     |      " + num + "." + objetos[num].pintar() + "                  |");
                        break;
                }
            }
            else
                Console.WriteLine("     |      Comprado                                    |");
        }
        //Se pinta el equipo generado
        public void pintarEquipo()
        {
            if (equipo != null)
            {
                switch (equipo.getTipo())
                {
                    case 0:
                        Console.WriteLine("     |      3." + equipo.pintar() + "            |");
                        break;
                    case 1:
                        Console.WriteLine("     |      3." + equipo.pintar() + "            |");
                        break;
                }
            }
            else
                Console.WriteLine("     |      Comprado                                    |");
        }
        //Devuelve el precio del objeto
        public override int comprar(int item)
        {
            int coste;
            if (item <= 2)
                coste = objetos[item].getCoste();
            else
                coste = equipo.getCoste();
            return coste;
        }
        //Se guardan los objetos en el jugador y se actualiza la tienda
        public override void actualizar (int item, ref Jugador j1)
        {
            if (item != 3)
            {
                j1.añadirObjeto(objetos[item].getTipo());
                objetos[item] = null;
            }
            else
            {
                j1.añadirArma(equipo);
                equipo = null;
            }
        }

        public override bool getItemValue(int item)
        {
            
            return (item!=3)? objetos[item] != null : equipo != null;
        }
	}

}
