using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3PracticasEvaluativas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Salir = false; //Variable que nos permite permanecer o salir dl programa
            int Opcion; //Captura el numero del ejercicio a utilizar
            do
            {
                Console.Clear();
                Console.WriteLine("||||| Practicas Evaluativas |||||"); //Menu donde nos permite escoger el ejercicio a realizar
                Console.WriteLine("Ingresa el numero de la opcion que desee: ");
                Console.WriteLine("1.- Ejercicio 1 'torres de hanoi'");
                Console.WriteLine("2.- Ejercicio 2 'to do list'");
                Console.WriteLine("3.- Ejercicio 3 'vacas'");
                Console.WriteLine("4.- Salir");
                Console.Write("R: ");
                try
                {
                    Opcion = Convert.ToInt32(Console.ReadLine());
                    switch (Opcion) //Comparacion de la opcion para iniciar un ejercicio
                    {
                        case 1:
                            Ejercicio1Clase1 EC1 = new Ejercicio1Clase1();
                            EC1.Inicio(); //Se ejecuta la clase que permite utilizar el programa torres de hanoi
                            break;
                        case 2:
                            Ejercicio2Clase1 EC2 = new Ejercicio2Clase1();
                            EC2.Inicio(); //Se ejecuta la clase que permite utilizar el programa to do list
                            break;
                        case 3:
                            Ejercicio3Clase1 EC3 = new Ejercicio3Clase1();
                            EC3.Inicio(); //Se ejecuta la clase que permite utilizar el programa de las vacas
                            break;
                        case 4:
                            Salir = true;
                            break;
                        default:
                            Console.WriteLine("Ingresaste algo erroneo."); //Opcion en caso de ingresar un valor aceptable al tipo de dato, pero que no sea uno que muestra el menu
                            break;
                    }
                }
                catch //Captura de excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                }
            } while (Salir == false); //Do-While que permite permanecer en el programa
            Console.WriteLine("\nPresiona un boton para salir."); Console.ReadKey();
        }
    }
}
