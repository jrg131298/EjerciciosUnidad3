using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3._3RamirezGarciaJesus
{
    class Program
    {
        static void Main(string[] args)
        {
            int CantidadJuegos = 0, Ganados = 0, Perdidos = 0, CantidadCartas, Opcion;
            //CantidadJuegos = Cantidad de partidas jugadas
            //Ganados = Partidas ganadas
            //Perdidas = Partidas perdidas
            //CantidadCartas = Cantidad de cartas en mano
            //Opcion = Donde se almacena la desicion tomada en si tomar o no una carta
            Console.OutputEncoding = Encoding.Unicode; //Nos permite imprimir caracteres especial 
            bool Salir = false, ConclusionJuego, SalirPartida;
            //Salir = Salir del programa
            //ConclusionJuego = Toma el valor en si gano o perdio
            //SalirPartida = terminar la partida actual
            do
            {
                CantidadJuegos++;
                CantidadCartas = 2;
                SalirPartida = false;
                CargaCartas CC = new CargaCartas(); //Se crea un objeto de la clase CargaCartas
                CC.Carga(); //Metodo el cual barajea
                CC.SacarCarta(CantidadCartas); //Saca las primeras 2 cartas
                do
                {
                    if (CantidadCartas < 5) //Si cumple la condicion, significa que aun no se tiene la cantidad maxima de cartas
                    {
                        Console.Clear();
                        Console.WriteLine("-----Partida No.{0}-----", CantidadJuegos);
                        Console.WriteLine("Ganados:{0}\tPerdidos:{1}", Ganados, Perdidos);
                        CC.MostrarMano(); //Muestra la mano del usuario
                        Console.WriteLine("\nDeseas otra carta?");
                        Console.WriteLine("1.- Si");
                        Console.WriteLine("2.- No");
                        Console.Write("R: ");
                        try
                        {
                            Opcion = Convert.ToInt32(Console.ReadLine());
                            if (Opcion == 1) //Si se cumple, significa que se desea otra carta
                            {
                                CantidadCartas++;
                                CC.SacarCarta(CantidadCartas); //Se saca otra carta
                                SalirPartida = CC.VerificarSuma(false); //Se verifica si la suma de sus cartas son <= 21
                                                                        //true = cuando suma <= a 21
                                                                        //false = cuando suma < 21
                            }
                            else if (Opcion == 2) //Si se cumple, significa que no se desea otra carta
                            {
                                SalirPartida = true; //Valor que permitira termianar la partida
                            }
                            else //Si se cumple, significa que se introdujo un valor no aceptable
                            {
                                Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                                Console.ReadKey();
                                SalirPartida = false;
                            }
                        }
                        catch //Captura de un error
                        {
                            Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                        }
                    }
                    else //Si se cumple, significa que ya se tiene la cantidad maxima de cartas
                    {
                        Console.Clear();
                        Console.WriteLine("-----Partida No.{0}-----", CantidadJuegos);
                        Console.WriteLine("Ganados:{0}\tPerdidos:{1}\n", Ganados, Perdidos);
                        CC.MostrarMano(); //Muestra la mano del usuario
                        CC.VerificarSuma(false); //Se verifica si la suma de sus cartas son <= 21
                                                 //true = cuando suma <= a 21
                                                 //false = cuando suma < 21
                        SalirPartida = true; //Valor que permita terminar la partida
                    }
                } while (SalirPartida == false); //Mientras se cumpla la condicion, la partida actual seguira en proceso
                Console.Clear();
                Console.WriteLine("-----Partida No.{0}-----", CantidadJuegos);
                Console.WriteLine("Ganados:{0}\tPerdidos:{1}", Ganados, Perdidos);
                CC.MostrarMano(); //Muestra la mano del usuario
                ConclusionJuego = CC.VerificarSuma(true); //Se verifica si la suma de sus cartas son <= 21
                                                          //true = cuando suma <= a 21
                                                          //false = cuando suma < 21
                if (ConclusionJuego == true)
                {
                    Ganados++; //Ganados = Partidas ganadas      
                }
                else
                {
                    Perdidos++; //Perdidas = Partidas perdidas
                }

                do
                {
                    Console.Clear();
                    Console.WriteLine("Deseas jugar de nuevo?");
                    Console.WriteLine("1.- Si");
                    Console.WriteLine("2.- No");
                    Console.Write("R: ");
                    try
                    {
                        Opcion = Convert.ToInt32(Console.ReadLine()); //Toma el valor que permite saber si se jugara de nuevo o se sale del programa
                        if (Opcion == 1) //Si se cumple, significa que se desea jugar de nuevo
                        { SalirPartida = true; }
                        else if (Opcion == 2) //Si se cumple, significa que no se desea jugar de nuevo
                        {
                            Salir = true;
                            SalirPartida = true;
                        }
                        else //Si se cumple, significa que se introdujo un valor no aceptable
                        {
                            SalirPartida = false;
                            Console.WriteLine("Ocurrio un error.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                        }
                    }
                    catch //Captura de un error
                    {
                        SalirPartida = false;
                        Console.WriteLine("Ocurrio un error.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (SalirPartida == false); //Mientras se cumpla la condicion, se realizara la pregunta que si se desea otra partida
            } while (Salir == false); //Mientras se cumpla la condicion, se realizara otra partida
        }
    }
}
