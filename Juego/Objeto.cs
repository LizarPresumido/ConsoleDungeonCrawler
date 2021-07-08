using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Objeto
    {
        private readonly string[] nombres = new string[5] {"Pocion", "Cuerda", "Vodka","Hierbas Aromaticas", "Piedra de oro" };
        private readonly string[] efectos = new string[5] {"+10 HP", "Huir 100%", "+3 Atk", "+5 Def", "1 - 50 Daño" };
        private readonly int[] costes = new int[5] { 2, 5, 5, 5, 50 };
        private string efecto;
        private string nombre;
        private int daño;
        private int tipo;
        private int coste;
        private Random rng;
        //Se genera un objeto cogiendo valores de los arrays de arriba
        public Objeto(Random r)
        {
            rng = r;
            tipo = rng.Next(0, 5);
            if (tipo == 4)
                daño = rng.Next(1, 51);
            coste = costes[tipo];
            nombre = nombres[tipo];
            efecto = efectos[tipo];
        }
        //Se genera un objeto especifico segun el valor
        public Objeto(int item)
        {
            tipo = item;
            if (tipo == 4)
            {
                rng = new Random();
                daño = rng.Next(1, 51);
            }
            coste = costes[item];
            nombre = nombres[item];
            efecto = efectos[item];
        }

        public int getTipo()
        {
            return tipo;
        }

        public string pintar()
        {
            return nombre + " --> " + coste + " Oro";
        }

        public int getCoste()
        {
            return coste;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getEfecto()
        {
            return efecto;
        }
        //Los distintos usos que tiene cada objeto
        public void usar(ref Jugador j1)
        {
            switch (tipo)
            {
                case 0: //Pocion
                    j1.curar(10);
                    break;
                case 1: //Cuerda
                    j1.huirAccion();
                    break;
                case 2: //Vodka
                    j1.addBuffAtk(3);
                    break;
                case 3: //Hierbas aromaticas
                    j1.addBuffDef(5);
                    break;
                case 4: //Piedra
                    //como no activa ninguna funcion externa esto es un easter egg :)
                    break;
            }
        }

        public int getDaño()
        {
            return daño;
        }
    }
}
