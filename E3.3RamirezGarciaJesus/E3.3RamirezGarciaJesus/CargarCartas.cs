using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3._3RamirezGarciaJesus
{
    class CargaCartas
    {
        Random _random = new Random(); //Permite generar un numero ramdom
        Stack<Carta> Baraja; //Creacion del stack
        string TipoCarta; //Tipo de la carta
        int NumeroCarta, Opcion, ValorAz, Suma = 0;
        //NumeroCarta = Numero de la carta
        //Opcion = Valor que permite saber que cantidad asignarle el Az
        //ValorAz = toma el valor desea que se requiera del Az
        //Suma = la suma total de las cartas en la mano
        string Mano = ""; //Cartas tomadas en el usuario
        bool SalirProceso = false; //Permite terminar la pregunta que asigna el valor al Az
        public void Carga() //Permite generar una Baraja
        {
            Baraja = new Stack<Carta>(); //Se crea un objeto del stack
            Carta C; //Objeto de la clase Carta
            int[] Valor = new int[52]; //Se almacenan los valores de las cartas
            string[] Tipos = new string[52]; //Se almacenan los tipos de las cartas

            for (int Contador1 = 1, Contador2 = 0; Contador1 <= 4; Contador1++) //Permite guardar los valores de las cartas
            {
                for (int Contador3 = 1; Contador3 <= 13; Contador3++)
                {
                    if (Contador3 >= 10)
                    {
                        Valor[Contador2] = 10;
                    }
                    else
                    {
                        Valor[Contador2] = Contador3;
                    }
                    Contador2++;
                }
            }

            for (int Contador = 0; Contador < 52; Contador++) //Permite guardar los tipos de las cartas
            {
                if (Contador <= 12)
                {
                    Tipos[Contador] = "♠"; //(char)3
                }
                else if (Contador <= 25)
                {
                    Tipos[Contador] = "♥"; //(char)4
                }
                else if (Contador <= 38)
                {
                   Tipos[Contador] = "♦"; //(char)5
                }
                else
                {
                    Tipos[Contador] = "♣"; //(char)6
                }
            }

            Shuffle(Tipos); //Barajeo
            Shuffle(Valor); //Barajeo

            for (int Contador = 0; Contador < 52; Contador++) //Se almacenan los valoes barajeados en el stack
            {
                C = new Carta();
                C.Numero = Valor[Contador];
                C.Tipo = Tipos[Contador];
                Baraja.Push(C);
            }
        }

        public void Shuffle<T>(T[] Array) //Permite barajear
        {
            int N = Array.Length;
            for (int I = 0; I < N; I++)
            {
                int R = I + _random.Next(N - I);
                T Tt = Array[R];
                Array[R] = Array[I];
                Array[I] = Tt;
            }
        }

        public void SacarCarta(int CantidadCartas) //Metodo que permite sacar una carta de la Baraja
        {
            var Carta = Baraja.Pop(); //Objeto Carta
            if (CantidadCartas == 2) //Si se cumple la condicion, significa que se sacaran las 2 primeras cartas de tu mano
            {
                NumeroCarta = Carta.Numero;
                TipoCarta = Carta.Tipo;
                Carta = Baraja.Pop();

                if (NumeroCarta == 1) //Si se cumple la condicion, significa que se a encontrado un Az
                {
                    Suma = Carta.Numero; 
                    Mano = Carta.Tipo + " " + Carta.Numero + "\t"; 
                    NumeroCarta = CartaAz(Suma);
                    Suma = Suma + NumeroCarta;
                    Mano = Mano + TipoCarta + " " + NumeroCarta + "\t";
                }
                else if (Carta.Numero == 1) //Si se cumple la condicion, significa que se a encontrado un Az
                {
                    Suma = NumeroCarta;
                    Mano = TipoCarta + " " + NumeroCarta + "\t";
                    Carta.Numero = CartaAz(Suma);
                    Suma = Suma + Carta.Numero;
                    Mano = Mano + Carta.Tipo + " " + Carta.Numero + "\t";
                }
                else //Si se cumple la condicion, significa que no se a encontrado un Az
                {
                    Suma = NumeroCarta + Carta.Numero;
                    Mano = TipoCarta + " " + NumeroCarta + "\t" + Carta.Tipo + " " + Carta.Numero + "\t";
                }
            }
            else //Si se cumple la condicion, significa que se sacara 1 carta
            {
                Carta = Baraja.Pop();
                if (Carta.Numero == 1) //Si se cumple la condicion, significa que se a encontrado un Az
                {
                    Carta.Numero = CartaAz(Suma);
                    Suma = Suma + Carta.Numero;
                    Mano = Mano + Carta.Tipo + " " + Carta.Numero + "\t";
                }
                else
                {
                    Suma = Suma + Carta.Numero;
                    Mano = Mano + Carta.Tipo + " " + Carta.Numero + "\t";
                }
            }
        }

        public int CartaAz(int Suma) //Metodo que permite saber que valor asignarle al Az
        {
            if (Suma <= 10) //Si se cumple, significa que la suma de los valores de tu mano son <= 10
            {
                do
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("\nHaz obtenido un az, ingresa el numero de la opcion que desee: (Suma total: {0})", Suma);
                        Console.WriteLine("1.- Utilizarlo como 1");
                        Console.WriteLine("2.- Utilizarlo como 11");
                        Console.Write("R: ");
                        Opcion = Convert.ToInt32(Console.ReadLine()); //Opcion que permite decidir que valor asignarle al Az
                        if (Opcion == 1) //Si se cumple la condicion, significa que se asignara el valor de 1
                        {
                            ValorAz = 1;
                            SalirProceso = true;
                        }
                        else if (Opcion == 2) //Si se cumple la condicion, significa que se asignara el valor de 11
                        {
                            ValorAz = 11;
                            SalirProceso = true;
                        }
                        else //Si se cumple, significa que se introdujo un valor no aceptable
                        {
                            Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            SalirProceso = false;
                        }
                    }
                    catch //Captura de un error
                    {
                        Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        SalirProceso = false;
                    }
                } while (SalirProceso == false); //Mientras se cumpla la condicion se realizara la pregunta para saber que valor toma el Az
            }
            else //Significa que la suma de tu mano es > 10, por lo cual se le asigna 1 al Az
            {
                ValorAz = 1;
            }
            return ValorAz; //Se retorna el valor tomado por el Az
        }

        public void MostrarMano() //Te permite desplegar la mano y su suma
        {
            Console.WriteLine("Suma: {0}", Suma);
            Console.WriteLine(Mano);
        }

        public bool VerificarSuma(bool TipoVerificacion) //Te permite saber si la suma de tu mano es <21 o =21 o >21
        {
            if (TipoVerificacion == false)
            {
                if (Suma < 21)
                {
                    return false;
                }
                else if (Suma == 21)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (Suma == 21)
                {
                    Console.WriteLine("You Win!\nPresione una tecla para continuar."); //Impresion en caso de haber ganado la partida
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("You Lose.\nPresione una tecla para continuar."); //Impresion en caso de haber perdido la partida
                    Console.ReadKey();
                    return false;
                }
            }
        }
    }
}
