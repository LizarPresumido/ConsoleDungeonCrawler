using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Jugador : Inventario
    {
        private readonly int[] cantItemsInicio = new int[5] { 2, 1, 0, 0, 1 };
        private int xpTotal = 0;
        private int xpNeed = 3;
        private int xp;
        private int maxVida = 20;
        private int vida;
        private int level;
        private int daño;
        private int defensa;
        private int dinero;
        private bool defensaUp = false;
        private bool huir = false;
        private int buffAtk = 0;
        private int buffDef = 0;
        private Random rng;

        private string mensaje = "";
        //Estructura del objeto
        public struct objCant
        {
            public Objeto objeto;
            public int cantidad;
        }
        private objCant[] inventario = new objCant[5];
        private Equipo[] equipo = new Equipo[2];

        public Jugador()
        {
            rng = new Random();
            vida = maxVida;
            level = 1;
            daño = 3;
            defensa = 3;
            dinero = 0;
            xp = 0;
            for(int i = 0; i < cantItemsInicio.Length; ++i)
            {
                inventario[i].objeto = new Objeto(i);
                inventario[i].cantidad = cantItemsInicio[i];
            }
        }

        public bool vivo()
        {
            return vida > 0;
        }

        public int getLevel()
        {
            return level;
        }

        public int[] getStats()
        {
            return new int[] {level,daño,defensa,xpTotal,dinero};
        }
        //Método para subir de nivel 
        private void lvlUp()
        {
            ++level;
            xpNeed *= 2;
            ++daño;
            ++defensa;
            vida += 10;
            maxVida += 10;
        }

        public void addExp(int exp)
        {
            if (xp + exp > xpNeed)
            {
                xp = exp - (xpNeed - xp);
                lvlUp();
            }
            else if(xp + exp == xpNeed)
            {
                xp = 0;
                lvlUp();
            }else
                xp += exp;
            xpTotal += exp;
        }
        //Método donde se realiza el combate
		public void hit(int dmgEnemigo)
		{
            if (defensaUp == true) //Comprueba si estas defendiendo ,en cuyo caso recibes menos daño
            {
                int escudo = 0;
                if (equipo[1] != null)
                    escudo = equipo[1].getLvl();
                vida -= dmgEnemigo - defensa - escudo - buffDef;
                mensaje = "     Has recibido " + (dmgEnemigo-defensa-escudo-buffDef) + " daño";
                defensaUp = false;
            }
            else //Si no estas defendiendo recibes una cantidad de daño igual al daño del enemigo
            {
                vida -= dmgEnemigo;            
                mensaje = "     Has recibido " + dmgEnemigo + " daño";
            }
            buffDef = 0;
		}
		
		public void hitTrue() 
		{
            --vida;
		}
        public void defender() //Activa la defensa
        {
            defensaUp = true;
        }

		public int getDaño() //Recibe el daño teniendo en cuenta los modificadores
		{
            int espada = 0;
            if (equipo[0] != null)
                espada = equipo[0].getLvl();
			return daño + espada + buffAtk;
		}

        public void pintar() //Método que pinta las estadisticas del jugador en pantalla
        {
            string espada = "",escudo = "";
            if (equipo[0] != null)
                espada = "(+"+(equipo[0].getLvl()+buffAtk)+")";
            else if(buffAtk != 0)
                espada = "(+" + buffAtk + ")";
            if (equipo[1] != null)
                escudo = "(+" + (equipo[1].getLvl()+buffDef) + ")";
            else if (buffDef != 0)
                espada = "(+" + buffDef + ")";
            Console.WriteLine();
            Console.WriteLine("     Vida: "+vida+"/"+maxVida+"     DAÑO: "+daño+espada+"      Defensa: "+defensa+escudo+"    Dinero: " +dinero);
            Console.WriteLine("     Nivel: " + level + "        Xp necesaria: " + (xpNeed - xp));
        }

		public string getMensaje()
		{
            return mensaje;
		}

		public void addDinero(int din)
		{
            dinero += din;
		}

        public void curar(double perc)
        {
            if (vida <= maxVida - (maxVida * perc))
                vida += (int)(maxVida * perc);
        }

        public void curar(int cura)
        {
            if (vida + cura > maxVida)
                vida = maxVida;
            else
                vida += cura;
        }

        public void añadirObjeto(int tipo)
        {
            ++inventario[tipo].cantidad;
        }

        public void añadirArma(Equipo item)
        {
            if (item.getTipo() == 0)
                equipo[0] = item;
            else
                equipo[1] = item;
        }

        public void pintarInventario() //Se pintan los objetos que tienes 
        {
           Console.WriteLine();
           for(int i = 0;i < inventario.Length; ++i)
            {
                Console.WriteLine("     "+i+". Usar "+inventario[i].objeto.getNombre()+" ("+inventario[i].objeto.getEfecto()+") tienes "+inventario[i].cantidad);
            }
            Console.WriteLine("     5.Salir");
        }

        public bool usarItem(int item)
        {
            bool resp = false;
            if (inventario[item].cantidad >= 1)
            {
                resp = true;
                --inventario[item].cantidad;
            }
            return resp;
        }

        public Objeto getItem(int item)
        {
            return inventario[item].objeto;
        }

        public bool comprar(int coste) //Se resta el dinero segun el coste del objeto a comprar
        {
            bool respuesta = true;
            if (coste > dinero)
                respuesta = false;
            else
            {
                dinero -= coste;
            }
            return respuesta;
        }

        public void huirAccion()
        {
            huir = true;
        }

        public bool intentaHuir()
        {
            bool resp = false;
            if (rng.Next(0, 5) == 0)
                resp = true;
            return resp;
        }
        //Métodos que te aumentan el ataque o la defensa al usar un item
        public void addBuffAtk(int cant)
        {
            buffAtk = cant;
        }

        public void addBuffDef(int cant)
        {
            buffDef = cant;
        }
    }
}
