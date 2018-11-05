using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3PracticasEvaluativas
{
    class Ejercicio1Clase1
    {
        //Pilas las cuales simulan ser las torres que contengan los aros
        Stack Torre1 = new Stack();
        Stack Torre2 = new Stack();
        Stack Torre3 = new Stack();
        public void Inicio()
        {
            bool SalirProceso = false; //Variable que nos permite permanecer en el ejercicio
            int Discos = 0;
            do
            {
                try
                {
                    SalirProceso = false;
                    Console.Clear();
                    Console.WriteLine("======= Torres de Hanoi =======");
                    Console.WriteLine("Ingresa la cantidad de discos: ");
                    Discos = Convert.ToInt32(Console.ReadLine()); //Captura de la cantidad de aros a ordenar

                    if(Discos >= 1 && Discos < 100) //La cantidad de discos debe ser mayor o igual a 1 y menor a 100
                    {
                        for (int Cont = Discos; Cont > 0; Cont--) //Se llena de aros la primer torre
                        {
                            Torre1.Push(Cont);
                        }
                        Console.WriteLine("Presiona una tecla para empezar el juego."); Console.ReadKey();
                        Juego(Discos, Torre1, Torre2, Torre3); //Ejecuta el juego
                        SalirProceso = true; //Nos permite regresar al menu de los ejercicios
                    }
                    else
                    {
                        Console.WriteLine("Ingresaste algo erroneo."); //Opcion en caso de ingresar un valor aceptable al tipo de dato, pero que no sea uno que muestra el menu
                        Console.WriteLine("Presiona un boton para continuar."); Console.ReadKey();
                    }
                }
                catch //Captura de excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                    Console.WriteLine("Presiona un boton para continuar."); Console.ReadKey();
                }
            } while (SalirProceso == false); //Do-While que permite permanecer en el ejercicio

        }

        public void Juego(int Disco, Stack Torre1, Stack Torre2, Stack Torre3) //Metodo recursivo el cual acomoda los aros
        {
            if (Disco == 1) //Este caso, significa que ya nomas queda 1 unico movimiento por realizar
            {
                Torre3.Push(Torre1.Pop()); //Mueve un aro a otra torre
                Console.Clear();
                Console.WriteLine("======= Torres de Hanoi ======="); //Impresion de las torres
                Console.WriteLine("\nTorre 1");
                foreach (var Item in Torre1)
                {
                    Console.Write(Item + " ");
                }

                Console.WriteLine("\nTorre 2");
                foreach (var Item in Torre2)
                {
                    Console.Write(Item + " ");
                }

                Console.WriteLine("\nTorre 3");
                foreach (var Item in Torre3)
                {
                    Console.Write(Item + " ");
                }
                Console.WriteLine("\nPresiona una tecla para continuar."); Console.ReadKey();
            }
            else //Movimiento de aro sin ser el ultimo movimiento
            {
                Juego(Disco - 1, Torre1, Torre3, Torre2); //Recursividad
                Torre3.Push(Torre1.Pop()); //Mueve un aro a otra torre
                Console.Clear();
                Console.WriteLine("======= Torres de Hanoi ======="); //Impresion de las torres
                Console.WriteLine("\nTorre 1");
                foreach (var Item in Torre1)
                {
                    Console.Write(Item + " ");
                }

                Console.WriteLine("\nTorre 2");
                foreach (var Item in Torre2)
                {
                    Console.Write(Item + " ");
                }

                Console.WriteLine("\nTorre 3");
                foreach (var Item in Torre3)
                {
                    Console.Write(Item + " ");
                }
                Console.WriteLine("\nPresiona una tecla para continuar."); Console.ReadKey();
                Juego(Disco - 1, Torre2, Torre1, Torre3); //Recursividad
            }
        }
    }
}
