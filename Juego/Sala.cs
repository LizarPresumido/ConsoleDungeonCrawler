using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    abstract class Sala
    {
        public static int cantSalas = 0;
        //El método abstracto del cual salen el resto de salas
        public abstract void pintar();

        public void pintarNumSala()
        {
            Console.WriteLine("     Sala "+cantSalas);
            Console.WriteLine();
		}
        //Los métodos de la tienda
        public virtual int comprar(int num) { return 0; }
        public virtual void actualizar(int num, ref Jugador j1) {}
        public virtual bool getItemValue(int num) { return true; }

        public virtual int getItemType() { return 0; }
    }
}
