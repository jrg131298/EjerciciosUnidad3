using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC3_1RamirezGarciaJesus
{
    class Menu
    {
        static void Main(string[] args)
        {
            Stack Pila = new Stack();
            Stack Pila2 = new Stack();
            Stack Pila3 = new Stack();
            Stack Pila4 = new Stack();
            double Numero;
            string NumeroConcatenado = "";
            bool FinProceso = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-------Ingresar datos a la pila-------");
                    for (int Contador = 0; Contador < 5; Contador++) //Captura e ingresa datos a la pila
                    {
                        Console.Write("Ingresa un numero: ");
                        Numero = Convert.ToDouble(Console.ReadLine());
                        Pila.Push(Numero);
                        Pila2.Push(Numero);
                        Pila3.Push(Numero);
                        Pila4.Push(Numero);
                    }
                    FinProceso = true;
                }
                catch
                {
                    Console.WriteLine("\nA ocurrido un error, intentelo de nuevo.\nPresiona una tecla para continuar.");
                }
            } while (FinProceso == false);

            FinProceso = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-------Consulta-------");
                    Console.Write("Ingresa el dato a consultar: ");
                    Numero = Convert.ToDouble(Console.ReadLine());
                    FinProceso = Pila.Contains(Numero);

                    if(FinProceso == true)
                    {
                        Console.WriteLine("Valor {0} encontrado.", Numero);
                    }
                    else
                    {
                        Console.WriteLine("Valor {0} no encontrado.", Numero);
                    }
                    Console.WriteLine("Ingresa una tecla para continuar.");
                    Console.ReadKey();
                    FinProceso = true;
                }
                catch
                {
                    Console.WriteLine("\nA ocurrido un error, intentelo de nuevo.\nPresiona una tecla para continuar.");
                }
            } while (FinProceso == false);

            Console.Clear();
            Console.WriteLine("-------Datos a la pila-------");
            for (int Contador = 0; Contador < 5; Contador++)
            {
                Console.WriteLine("{0} tipo: {1}", Pila.Peek(), Pila.Pop().GetType());
            }

            object[] MiPilaArray = Pila2.ToArray();
            Console.WriteLine("\n-------Datos a la pila inversos-------");
            for (int Contador = 4; Contador >= 0; Contador--)
            {
                Console.WriteLine("{0}", MiPilaArray[Contador]);
            }

            Console.WriteLine("\n-------Datos a la pila convertidos a string-------");
            foreach (var valor in Pila3)
            {
                Console.WriteLine("{0} que es una variable tipo {1}", valor, valor.ToString().GetType());
            }


            Console.WriteLine("\n-------Datos a la pila convertidos a string-------");
            IEnumerator mover = Pila4.GetEnumerator(); //Utilizamos GetEnumerator para mover los elementos
            mover.MoveNext(); //movemos el enumerador 
            Console.WriteLine(mover.Current); //Devuelve el valor en el que se quedo el enumerador


            Console.WriteLine("Ingresa una tecla para salir del programa.");
            Console.ReadKey();
        }
    }
}
