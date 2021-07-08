using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Enemigo
    {
        private readonly string[] nombres = new string[4] { "Bruja", "Vampiro", "Demonio", "Goblin" };
        private readonly int[] vidas = new int[4] { 20, 10, 6, 3 };
        private readonly int[] danos = new int[4] { 5, 4, 3, 2 };
        private readonly int[] exps = new int[4] { 5, 2, 1, 1 };
        private int exp;
        private int nivel;
        private string mensaje = "";
        private readonly int[] dineros = new int[4] { 20, 10, 5, 2 };
        private Random rng;

        private string nombre;
        private int vida;
        private int dano;
        private int dinero;
        private int max_vida;
        private int tipo;


        public Enemigo(int lvlJug)
        {
            setLevel(lvlJug);
            crearEnemigo();
        }

        public Enemigo(int lvlJug, int tipoEnem)
        {
            setLevel(lvlJug);
            tipo = tipoEnem;
            crearEnemigo(tipoEnem);
        }
        //Métodos de creacion de enemigos, dependiendo de si es aleatorio o no
        public void crearEnemigo()
        {
            
            rng = new Random();
            tipo = rng.Next(1, 4);
            nombre = nombres[tipo];
            exp = exps[tipo];
            vida = vidas[tipo] + (nivel - 1) * 2;
            dano = danos[tipo] + nivel - 1;
            dinero = dineros[tipo];
            max_vida = vida;
        }
        public void crearEnemigo(int tipo)
        {
            
            nombre = nombres[tipo];
            exp = exps[tipo];
            vida = vidas[tipo] + (nivel - 1) * 2;
            dano = danos[tipo] + nivel - 1;
            dinero = dineros[tipo];
            max_vida = vida;
        }
        //El nivel del monstruo sera 1 mas o 1 menos que el del jugador y se establece cuando se genera la sala
        private void setLevel(int lvlJug)
        {
            rng = new Random();
            if (lvlJug > 1)
                nivel = rng.Next(lvlJug - 1, lvlJug + 2);
            else
                nivel = 1;
        }

        public int getDaño()
        {
            return dano;
        }

        public int getDinero()
        {
            return dinero;
        }

        public int getExp()
        {
            return exp;
        }
        
        public int getTipo()
        {
            return tipo;
        }

        public bool hit(int dmgPlayer) //Resa vida según el daño del jugador
        {
            vida -= dmgPlayer;
            mensaje = "     El enemigo ha recibido " + dmgPlayer + " daño";
            return vivo();

        }
        public bool vivo()
        {
            if (vida > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void pintarEnemigo() //Pinta las estadisticas conocidas del enemigo
        {
            Console.WriteLine("     " + nombre + ": " + vida + "/" + max_vida + "PV");
        }

        public string getMensaje()
        {
            return mensaje;
        }



	}
}
