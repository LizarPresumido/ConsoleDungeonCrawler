using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Juego
{
    class Mensajes
    {
        Queue mensajes = new Queue();

        public void guardarMensaje(string mensaje)
        {
            mensajes.Enqueue(mensaje);
        }

        public void escribirMensajes()
        {
            if (!isEmpty())
            {
                for (int i = 0; i < 2; ++i)
                {
                    Console.WriteLine(mensajes.Dequeue());
                }
            }
        }

        public bool isEmpty()
        {
            try
            {
                mensajes.Peek();
                return false;
            }
            catch(InvalidOperationException)
            {
                return true;
            }
        }

        public void limpiarCola()
        {
            for(int i = 0; i < 2; ++i)
            {
                mensajes.Dequeue();
            }
        }
    }
}
