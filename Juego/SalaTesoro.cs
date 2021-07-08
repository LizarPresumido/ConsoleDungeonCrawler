using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class SalaTesoro : Sala
    {
        private Objeto item;
		public SalaTesoro(Random rng) {
            item = new Objeto(rng);
        }

		public override void pintar()
		{
			Console.WriteLine("     +--------------------------------------------------+");
			Console.WriteLine("     |                     Tesoro                       |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
            pintarObjeto(item.getTipo());
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     |                                                  |");
			Console.WriteLine("     +--------------------------------------------------+");
		}
        //dependiendo del objeto que salga, se pinta un mensaje u otro
        public void pintarObjeto(int tipo)
        {
            switch (tipo)
            {
                case 0:
                    Console.WriteLine("     |      Has recibido "+item.getNombre()+"                         |");
                    break;
                case 1:
                    Console.WriteLine("     |      Has recibido "+item.getNombre()+"                         |");
                    break;
                case 2:
                    Console.WriteLine("     |      Has recibido "+item.getNombre()+"                          |");
                    break;
                case 3:
                    Console.WriteLine("     |      Has recibido "+item.getNombre()+"             |");
                    break;
                case 4:
                    Console.WriteLine("     |      Has recibido "+item.getNombre()+"                  |");
                    break;
            }
        }

        public override int getItemType()
        {
            return item.getTipo();
        }
    } 
}
