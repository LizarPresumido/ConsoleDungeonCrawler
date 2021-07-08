using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class SalaEnemigo : Sala
    {
        private int tipoEnemigo;

        public SalaEnemigo(int tipo) {
            tipoEnemigo = tipo;
        }
        //Se pintan los distintos enemigos dependiendo de lo que haya salido en el generador en Controlador
        public override void pintar()
        {
            
            switch (tipoEnemigo)
            {
                case 1:
                    Console.WriteLine("     +--------------------------------------------------+");
                    Console.WriteLine("     |                    .-\"\"\"\".                       |");
                    Console.WriteLine("     |                   /       \\                      |");
                    Console.WriteLine("     |                 __/   .-.  .\\                    |");
                    Console.WriteLine("     |               /  `\\  /   \\/  \\                   |");
                    Console.WriteLine("     |               |  _ \\/   .==.==.                  |");
                    Console.WriteLine("     |               | (   \\  /____\\__\\                 |");
                    Console.WriteLine("     |               \\ \\      (_()(_()                  |");
                    Console.WriteLine("     |                 \\ \\            \'---.             |");
                    Console.WriteLine("     |                  \\                   \\           |");
                    Console.WriteLine("     |               /\\ |`       (__)________/          |");
                    Console.WriteLine("     |              /  \\|     /\\___/                    |");
                    Console.WriteLine("     |             |    \\     \\||VV                     |");
                    Console.WriteLine("     |             |     \\     \\|\"\"\"\"                   |");
                    Console.WriteLine("     |             |      \\     ______)                 |");
                    Console.WriteLine("     |              \\       \\  /`                       |");
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
                    break;
                case 2:
                    Console.WriteLine("     +--------------------------------------------------+");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |             \\                  /                 |");
                    Console.WriteLine("     |     _________))                ((__________      |");
                    Console.WriteLine("     |    /.-------./\\\\    \\    /    //\\.--------.\\     |");
                    Console.WriteLine("     |   //#######//##\\\\   ))  ((   //##\\\\########\\\\    |");
                    Console.WriteLine("     |  //#######//###((  ((    ))  ))###\\\\########\\\\   |");
                    Console.WriteLine("     | ((#######((#####\\\\  \\\\  //  //#####))########))  |");
                    Console.WriteLine("     |  \\##' `###\\######\\\\  \\)(/  //######/####' `##/   |");
                    Console.WriteLine("     |   )'    ``#)'  `##\\`->oo<-'/##'  `(#''     `(    |");
                    Console.WriteLine("     |           (       ``\\`..'/''       )             |");
                    Console.WriteLine("     |                      \\\"\"(                        | ");
                    Console.WriteLine("     |                       `- )                       |");
                    Console.WriteLine("     |                       / /                        |");
                    Console.WriteLine("     |                      ( /\\                        |");
                    Console.WriteLine("     |                      /\\| \\                       |");
                    Console.WriteLine("     |                     (  \\                         |");
                    Console.WriteLine("     |                          )                       |");
                    Console.WriteLine("     |                         /                        |");
                    Console.WriteLine("     |                        (                         |");
                    Console.WriteLine("     |                        `                         |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     +--------------------------------------------------+");
                    break;
                case 3:
                    Console.WriteLine("     +--------------------------------------------------+");
                    Console.WriteLine("     |                                                  |");
                    Console.WriteLine("     |                     _____                        |");
                    Console.WriteLine("     |                 .-,;='';_),-.                    |");
                    Console.WriteLine("     |                  \\_\\(),()/_/                     |");
                    Console.WriteLine("     |                    (,___,)                       |");
                    Console.WriteLine("     |                   ,-/`~`\\-,___                   |");
                    Console.WriteLine("     |                  / /).:.('--._)                  |");
                    Console.WriteLine("     |                 {_[ (_,_)                        |");
                    Console.WriteLine("     |                     | Y |                        |");
                    Console.WriteLine("     |                    /  |  \\                       |");
                    Console.WriteLine("     |                    \"\"\" \"\"\"                       |");
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
                    break;
                

            }

        }
    }

}
