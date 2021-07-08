using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    interface Inventario
    {
        void añadirObjeto(int tipo);

        void añadirArma(Equipo equipo);

        void pintarInventario();

        bool usarItem(int item);

        Objeto getItem(int item);
    }
}
