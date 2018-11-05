using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3PracticasEvaluativas
{
    class Ejercicio3Clase1
    {
        List<Ejercicio3Vacas> ListaInicio = new List<Ejercicio3Vacas>(); //Lista que guarda a las vacas al incio del puente
        List<Ejercicio3Vacas> ListaFinal = new List<Ejercicio3Vacas>(); //Lista que guarda a las vacas al final del puente
        int Suma = 0; //Suma del tiempo tanscurrido
        public void Inicio()
        {
            Ejercicio3Vacas Vaca = new Ejercicio3Vacas(); //Objeto Vaca1
            Vaca.Nombre = "Mazie";
            Vaca.Tiempo = 2;
            ListaInicio.Add(Vaca); //Introducir valores a la lista del inicio del recorrido
            Ejercicio3Vacas Vaca2 = new Ejercicio3Vacas(); //Objeto Vaca2
            Vaca2.Nombre = "Daisy";
            Vaca2.Tiempo = 4;
            ListaInicio.Add(Vaca2); //Introducir valores a la lista del inicio del recorrido
            Ejercicio3Vacas Vaca3 = new Ejercicio3Vacas(); //Objeto Vaca3
            Vaca3.Nombre = "Crazy";
            Vaca3.Tiempo = 10;
            ListaInicio.Add(Vaca3); //Introducir valores a la lista del inicio del recorrido
            Ejercicio3Vacas Vaca4 = new Ejercicio3Vacas(); //Objeto Vaca4
            Vaca4.Nombre = "Lazy";
            Vaca4.Tiempo = 20;
            ListaInicio.Add(Vaca4); //Introducir valores a la lista del inicio del recorrido

            Console.Clear();
            Console.WriteLine("======= Acertijo del puente ======="); //Primera impresion de las vacas al inicio del puente
            Console.WriteLine();
            foreach (var Item in ListaInicio) //Ciclo que nos permite imprimir el nombre de las vacas
            {
                Console.Write(Item.Nombre + " ");
            }
            Console.Write("______________________ FINAL");
            Console.WriteLine("\nEl tiempo transcurrido es: {0}", Suma); //Imprime el tiempo transcurrido
            Console.Write("Precione un boton para empezar."); Console.ReadKey();

            for (int Contador = 1; Contador <= 5; Contador++) //For que nos permite realizar paso a paso el recorrido de las vaca, dando un tiempo de 34 min.
            {
                Console.Clear();
                Console.WriteLine("======= Acertijo del puente ======="); //Impresion de los nombres de las vacas que van cruzando el puente
                Suma = Suma + Pasos(Contador); //Suma que por medio de un metodo tipo funcion, realiza la suma de los minutos transcurridos
                Console.WriteLine();
                foreach(var Item in ListaInicio) //Impresion del nombre de las vacas que se encuentran al inicio del puente
                {
                    Console.Write(Item.Nombre + " ");
                }
                Console.Write("______________________ ");
                foreach (var Item in ListaFinal) //Impresion del nombre de las vacas que se encuentran al final del puente
                {
                    Console.Write(Item.Nombre + " ");
                }
                Console.WriteLine("\nEl tiempo transcurrido es: {0}", Suma); //Impresion de los minutos transcurridos
                Console.Write("Precione un boton para continuar."); Console.ReadKey();
            }
        }

        public int Pasos(int Cont) //Metodo que nos permite realizar el movimiento de las vacas de extremo a extremo del puente
        {
            int Cuantos = 1;
            if (Cont == 1) //Significa que se realizara el primer paso
            {
                foreach (var Item in ListaInicio) //Nos permite pasar las 2 vacas de "ListaInicio" deseadas, que pasen al otro lado del puente y pasen a "ListaFinal"
                {
                    if(Cuantos <= 2)
                    {
                        ListaFinal.Add(Item);
                    }
                    else
                    {
                        ListaInicio.RemoveAt(0);
                        ListaInicio.RemoveAt(0);
                        break;
                    }
                    Cuantos++;
                }
                return 4;
            }
            else if(Cont == 2) //Nos permite regresar a una vaca de "ListaFinal" al inicio del puente "ListaInicio"
            {
                foreach (var Item in ListaFinal)
                {
                    ListaInicio.Add(Item);
                    ListaFinal.RemoveAt(0);
                    break;
                }
                return 2;
            }
            else if (Cont == 3) //Nos permite pasar las 2 vacas de "ListaInicio" deseadas, que pasen al otro lado del puente y pasen a "ListaFinal"
            {
                foreach (var Item in ListaInicio)
                {
                    if (Cuantos <= 2)
                    {
                        ListaFinal.Add(Item);
                    }
                    else
                    {
                        ListaInicio.RemoveAt(0);
                        ListaInicio.RemoveAt(0);
                        break;
                    }
                    Cuantos++;
                }
                return 20;
            }
            else if (Cont == 4) //Nos permite regresar a una vaca de "ListaFinal" al inicio del puente "ListaInicio"
            {
                foreach (var Item in ListaFinal)
                {
                    ListaInicio.Add(Item);
                    ListaFinal.RemoveAt(0);
                    break;
                }
                return 4;
            }
            else if (Cont == 5) //Nos permite pasar las 2 vacas de "ListaInicio" deseadas, que pasen al otro lado del puente y pasen a "ListaFinal"
            {
                foreach (var Item in ListaInicio)
                {
                    if (Cuantos == 2)
                    {
                        ListaFinal.Add(Item);
                        ListaInicio.RemoveAt(0);
                        ListaInicio.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        ListaFinal.Add(Item);
                    }
                    Cuantos++;
                }
                return 4;
            }
            return 0;
        }
    }
}
