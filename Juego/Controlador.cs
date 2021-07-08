using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Juego
{
    class Controlador
    {

        private const int minSalas = 10;
        private Mensajes m = new Mensajes();
        private Jugador j1;
        private Sala s1;
        private Enemigo e1;
        private bool final = false;
        private bool enemigo = false;
        private bool nuevaSala = false;
        private bool boss = false;
        private string mensajeFinal = "";
        private bool tienda = false;
        private bool inventario = false;
        private StreamWriter ficheroStats;
        private string nomFicheroStats = "Resultado.txt";
        Random rnd;

        public Controlador() { }

        //creacion de variables de juego
        public void start()
        {
            Console.SetWindowSize(160,45);
            rnd = new Random();
            j1 = new Jugador();
            game();
        }

        //'turno/sala' del juego
        private void game()
        {
            do
            {
                Console.Clear();
                pintarSala();
            } while (!final);
            Console.WriteLine(mensajeFinal);
            printFinal();
            Console.ReadLine();
        }

        //bucle de combate
        private int combate(int a)
        {
            int finalCombate = 0;
			switch (a)
			{
                //ataque
				case 1:
                    if(e1.hit(j1.getDaño()))
						j1.hit(e1.getDaño());
                    m.guardarMensaje(e1.getMensaje());
                    m.guardarMensaje(j1.getMensaje());
                    break;
                //defensa
                case 2:
                    j1.defender();
					j1.hit(e1.getDaño());
                    m.guardarMensaje(j1.getMensaje());
					break;
                //usar item
				case 3:
                    int respuesta = 5;
                    bool itemUsado = false;
                    do
                    {
                        Console.Clear();
                        s1.pintarNumSala();
                        pintarStatsEnemigo();
                        m.escribirMensajes();
                        s1.pintar();
                        pintarStats();
                        j1.pintarInventario();
                        try
                        {
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta <= 4)
                            {
                                if (j1.usarItem(respuesta))
                                {
                                    j1.getItem(respuesta).usar(ref j1);
                                    itemUsado = true;
                                }
                            }
                            inventario = true;
                        }
                        catch (Exception)
                        {

                        }
                    } while (!inventario);
                    //usar cuerda o no usar nada
                    if (respuesta != 5 && respuesta != 1)
                        if (respuesta == 4)
                            if (e1.hit(j1.getItem(respuesta).getDaño()))
                            {
                                j1.hit(e1.getDaño());
                            }
                        else if (respuesta == 1 && itemUsado)
                            finalCombate = 3;
                        else if (respuesta == 1 && !itemUsado)
                            j1.hit(e1.getDaño());
                    
                    break;
                //huir
				case 4:
                    if(j1.intentaHuir())
                        finalCombate = 3;
                    else
                        j1.hit(e1.getDaño());
                    break;
				default:
                    //en el caso de que pongas mal el valor recibes un punto de daño
                    j1.hitTrue();
                    break;
			}
            if (!e1.vivo())//comprueba si el enemigo ha muerto, y despues si eres tu el que ha muerto para terminar el juego o continuarlo
                finalCombate = 1;
            else if (!j1.vivo())
                finalCombate = 2;


            return finalCombate;
			
        }

        //visualizacion del menu de accion
        private void menuAcciones()
        {
            int accion;
            Console.WriteLine();
            Console.WriteLine("	Introduzca el numero de accion: ");
            Console.WriteLine();
            Console.WriteLine("	1. Atacar			3. Inventario");
			Console.WriteLine("	2. Defender			4. Huir");
			try
			{
				accion = int.Parse(Console.ReadLine());
            }catch(Exception)
			{
                accion = 0;
			}
			//Resultado del combate
			switch (combate(accion))
			{
				//gana el player
				case 1:
                    m.limpiarCola();
                    nuevaSala = true;
                    if (boss)
                    {
                        final = true;
                        mensajeFinal = "Has ganado, gran aventura en la mazmorra!!";
                    }
                    j1.addDinero(e1.getDinero());
                    j1.addExp(e1.getExp());

                    break;
				//gana el enemigo
				case 2:
                    m.limpiarCola();
                    nuevaSala = true;
                    final = true;
                    mensajeFinal = "El enemigo te ha derrotado!!";
                    break;
                //huir
                case 3:
                    nuevaSala = true;
                    if (boss)
                        boss = false;

                    break;
            }
		}
  
        //visualizacion de sala
        private void pintarSala()
        {
            crearSala();
            do
            {
                Console.Clear();
                s1.pintarNumSala();
				if (enemigo) //Si la sala es de enemigo te imprime dicha sala con un enemigo aleatorio
				{

                    pintarStatsEnemigo();
                    m.escribirMensajes();
                    s1.pintar();
                    pintarStats();
					menuAcciones();
				}
				else if (tienda) { //Si es una tienda te imprime la tienda con 3 objetos y un equipamiento para comprar 
                    int respuesta = 5;
                    do{
                        s1.pintar();
                        pintarStats();
                        try
                        {
                            respuesta = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            respuesta = 5;
                        }
                        if (respuesta <= 3)
                        {
                            if (s1.getItemValue(respuesta))
                            {
                                if (j1.comprar(s1.comprar(respuesta)))
                                {
                                    s1.actualizar(respuesta,ref j1);
                                }
                            }
                        }
                        Console.Clear();
                        s1.pintarNumSala();
                    } while (respuesta != 4);
                    tienda = false;
                    nuevaSala = true;
                }
                else
				{
					s1.pintar();
                    pintarStats();
                    Console.ReadLine();
                    nuevaSala = true;
                }
            } while (!nuevaSala);
			enemigo = false;
            nuevaSala = false;
		} 

        //visualizacion de stats del jugador
        private void pintarStats()
        {
            j1.pintar();
        }
        private void pintarStatsEnemigo()
        {
            e1.pintarEnemigo();
			Console.WriteLine();
		}
        
        //creacion de sala
        private void crearSala()
        {
            int numSala = 4;
            int tipoSala;
			//activacion de sala de boss
            if(Sala.cantSalas <= minSalas)
                tipoSala = rnd.Next(0,numSala);
            else
                tipoSala = rnd.Next(0, numSala+1);
			++Sala.cantSalas;
			switch (tipoSala)
            {
                //sala descanso
                case 0:
                    s1 = new SalaDescanso();
                    j1.curar(0.1);
                    break;
                //sala enemigo
                case 1:
                    e1 = new Enemigo(j1.getLevel());
                    s1 = new SalaEnemigo(e1.getTipo());

                    enemigo = true;
                    break;
                //sala tesoro
                case 2:
                    s1 = new SalaTesoro(new Random());
                    j1.añadirObjeto(s1.getItemType());
                    break;
                //sala tienda
                case 3:
                    s1 = new SalaTienda(ref j1);
                    tienda = true;
                    break;
                //sala Boss
                case 4:
                    s1 = new SalaJefe();
                    boss = true;
                    e1 = new Enemigo(j1.getLevel(), 0);
                    enemigo = true;
                    break;
            }
        }

        public void printFinal()
        {
            int[] stats;
            using (ficheroStats = new StreamWriter(nomFicheroStats, false))
            {
                ficheroStats.WriteLine("Resultado: ");
                if (j1.vivo())
                    ficheroStats.WriteLine("Victoria Heroica!");
                else
                    ficheroStats.WriteLine("Derrota Aplastante!");
                ficheroStats.WriteLine();
                ficheroStats.WriteLine("Estadisticas:");
                stats = j1.getStats();
                ficheroStats.WriteLine("Nivel: " + stats[0]);
                ficheroStats.WriteLine("Daño: " + stats[1]);
                ficheroStats.WriteLine("Defensa: " + stats[2]);
                ficheroStats.WriteLine("Experiencia: " + stats[3]);
                ficheroStats.WriteLine("Dinero: " + stats[4]);
                ficheroStats.Close();
            }
            
        }
    }
}
