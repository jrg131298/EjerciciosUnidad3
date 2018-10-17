using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_2InvestigacionRamirezGarciaJesus
{
    class Menu
    {
        static void Main(string[] args)
        {
            double Numero;
            bool FinProceso = false;
            Queue Cola1 = new Queue();
            Queue Cola2 = new Queue();
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-------Ingresar datos del Queue-------");
                    for (int Contador = 0; Contador < 5; Contador++) //Captura e ingresa datos en el Queue
                    {
                        Console.Write("Ingresa un numero: ");
                        Numero = Convert.ToDouble(Console.ReadLine());
                        Cola1.Enqueue(Numero);   //Cola1.Enqueue(Numero); Metodo que agrega datos a un Queue
                        Cola2.Enqueue(Numero);   //Pila.Push(Numero);     Metodo que agrega datos a un Stack
                    }
                    FinProceso = true;
                }
                catch
                {
                    Console.WriteLine("\nA ocurrido un error, intentelo de nuevo.\nPresiona una tecla para continuar.");
                }
            } while (FinProceso == false);
            Cola1.TrimToSize(); //Se utiliza para limitar la cantidad de elementos dentro del Queue
            Cola2.TrimToSize(); //Se utiliza para limitar la cantidad de elementos dentro del Queue

            FinProceso = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-------Consulta de un dato en el Queue-------");
                    Console.Write("Ingresa el dato a consultar: ");
                    Numero = Convert.ToDouble(Console.ReadLine());
                    FinProceso = Cola1.Contains(Numero); //Se utiliza el metodo Contains para buscar el dato en el Stack
                               //Pila.Contains(Numero);  //Se utiliza el metodo Contains para buscar el dato en el Queue
                    if (FinProceso == true)
                    {
                        Console.WriteLine("Valor {0} encontrado.", Numero);//Impresion en caso de encontrar el numero
                    }
                    else
                    {
                        Console.WriteLine("Valor {0} no encontrado.", Numero);//Impresion en caso de no encontrar el numero
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
            Console.WriteLine("-------Datos del Queue-------");
            for (int Contador = 0; Contador < 5; Contador++) //Impresion de los datos y el tipo del Queue
            {
                Console.WriteLine("{0} tipo: {1}", Cola1.Peek(), Cola1.Dequeue().GetType()); //Cola1.Peek() = Pila.Peek()       nos muestra el dato sin eliminarlo
            }                                                                                //Cola1.Dequeue() = Pila.Pop()     elimina el dato
                                                                                             //Cola1.GetType() = Pila.GetType() nos muestra el tipo del elemento

            object[] MiColitaArray = Cola2.ToArray();  //Transforma el Queue en arreglo
          //object[] MiPilitaArray = Pila.ToArray();   //Transforma el Stack en arreglo
            Console.WriteLine("\n\n-------Datos del Queue invertidos-------");
            for (int Contador = 4; Contador >= 0; Contador--)
            {
                Console.WriteLine("{0}", MiColitaArray[Contador]); //Impresion de los datos del Arreglo creado del Queue
            }

            Console.WriteLine("\n\n-------Datos del Queue convertidos a string-------");
            foreach (var valor in Cola2)
            {
                Console.WriteLine("{0} que es una variable tipo {1}", valor, valor.ToString().GetType()); //valor.ToString() transforma el valor en una cadena (se encuentra en Queue y en Stack)
            }                                                                                             //GetType() nos permite saber el tipo del dato del Queue y este nos permite saber si verdaderamente se transformo a String

            Console.WriteLine("\n\n-------Cambio de posicion en un dato en el Queue-------");
            IEnumerator MoverPosicion = Cola2.GetEnumerator(); //Cola2.GetEnumerator() permite mover los elementos de posicion en el Queue
                                                               //pila.GetEnumerator()  permite mover los elementos de posicion en el Stack
            MoverPosicion.MoveNext(); //Se mueve de posicion el dato
            Console.WriteLine(MoverPosicion.Current); //Devuelve el valor en el que se quedo el enumerador
            Console.WriteLine("\n\n-------Metodos diferentes entre Stack y Queue-------" +
                              "\n1.- Cola.Enqueue(Dato) (Se utiliza para ingresar valores al Queue)" +
                              "\n2.- Cola.Dequeue()     (Se utiliza para eliminar valores al Queue)" +
                              "\n3.- Cola.TrimToSize()  (Se utiliza para limitar en numero de valores en el Queue)");
            Console.WriteLine("\nIngresa una tecla para salir del programa.");
            Console.ReadKey();
        }
    }
}
