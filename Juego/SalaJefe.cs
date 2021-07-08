using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Juego
{
    class SalaJefe : Sala
    {
        StreamReader fichero;
        string nomFichero = "jefe.txt";
        public SalaJefe() { }
        //Se pinta el boss
		public override void pintar()
		{
            fichero = File.OpenText(nomFichero);
            if (File.Exists(nomFichero))
            {
                string linea;
                fichero = File.OpenText(nomFichero);
                linea = fichero.ReadLine();
                while (linea != null)
                {
                    Console.WriteLine(linea);
                    linea = fichero.ReadLine();
                };
                fichero.Close();
            }
        }
	}
}
