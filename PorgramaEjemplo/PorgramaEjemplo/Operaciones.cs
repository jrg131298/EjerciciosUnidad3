using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PorgramaEjemplo
{
    public class Operaciones
    {
        LinkedList<string> Lista = new LinkedList<string>(); //Creacion de la lista ligada
        
        public void Metodo1()
        {
            Lista.AddLast("Caguamon");//Agregamos la cadena de texto al final de la lista ligada
            Lista.AddLast("Levanton");
            Lista.AddLast("Fierro");
            Lista.AddLast("Menores de edad");
            Lista.AddFirst("Legales");//Se agrega una cadena de texto al inicio de la lista ligada
            LinkedListNode<string> Nodo = Lista.Find("Menores de edad");//buscamos un nodo en la lista llamado Menores de edad y creamos un nodo nuevo
            Lista.AddBefore(Nodo, "CON");//agreamos CON antes de Menores de edad
            LinkedListNode<string> despues = Lista.Find("Caguamon"); //Encontramos el nodo Caguamos
            Lista.AddAfter(despues,"Drogas"); //Y agregamos el nuevo elemento despues del nodo
            foreach(string item in Lista)//Imprimimos cada elemento guardado en la lista ligada
            {
                Console.WriteLine(item);
            }
        }

        public void metodo2()//Metodo para calcular el tiempo entre listas y listas ligadas
        {
            const int max = 100000;
            List<string> lista = new List<string>();//Instanciamos una lista
            LinkedList<string> listaligada = new LinkedList<string>();// y una lista ligada

            for (int i = 0; i < 1000; i++)//Las dos listas las llenamos con un elemento 1,000 veces
            {
                lista.Add("Okey");
                listaligada.AddLast("Okey");

                

                

            }
            var m1 = Stopwatch.StartNew();//Instanciamos una variable para medir el tiempo

            for (int i = 0; i < max; i++)//Hacemos el recorrido de la lista
            {
                foreach (string item in lista)//Por cada elemento de la lista decimos que si el elemento de la lista es diferente a 4
                {
                    if (item.Length != 4)
                    {
                        throw new Exception();//arroja un error
                    }
                }
            }

            m1.Stop();//Paramos el tiempo

            var m2 = Stopwatch.StartNew();//LA misma medicion

            for (int i = 0; i < max; i++)// pero con la lista ligada
            {
                foreach (string item in listaligada)
                {
                    if (item.Length != 4)
                    {

                    
                    throw new Exception();
                    }

                    
                }
            }

            m2.Stop();

            Console.WriteLine("Lista: " + ((double)(m1.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));//Imprimimos los tiempos
            Console.WriteLine("Lista ligada: " + ((double)(m2.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));//y comparamos 
            //Made in ED-305 desde la maquina del buchon <3
        }
    }
}
