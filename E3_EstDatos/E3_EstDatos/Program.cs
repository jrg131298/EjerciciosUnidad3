using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_EstDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Operacion o = new Operacion();
            o.Ejercicio1();
            Console.WriteLine("\nPreciona un boton para continuar");
            Console.ReadKey();
            o.Ejercicio3();
            Console.WriteLine("Preciona un boton para continuar");
            Console.ReadKey();
            o.Ejercicio4();
            Console.WriteLine("Preciona un boton para salir");
            Console.ReadKey();
        }
    }
    public class Operacion
    {
        public void Ejercicio1()
        {
            Stack Lista = new Stack();
            Queue Cola = new Queue();

            Console.WriteLine("Valores que devuelve una pila inicialmente vacia");
            Lista.Push(5);
            Lista.Push(3);
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(2);
            Lista.Push(8);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(9);
            Lista.Push(1);
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(7);
            Lista.Push(6);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            Lista.Push(4);
            Console.Write(Lista.Pop() + "\t");
            Console.Write(Lista.Pop() + "\t");
            //¿Qué valores se devuelven durante la siguiente serie de operaciones de pila,
            //si se ejecutan en una pila inicialmente vacía ?
            //push(5), push(3), pop(), push(2), push(8),
            //pop(), pop(), push(9), push(1), pop(), push(7), push(6), pop(), pop(), push(4),
            //pop(), pop()
        }
        public void Ejercicio2()
        {

            //Escriba en este metodo un modulo que pueda leer  y almacenar palabras reservadas en una lista enlazada 
            //e identificadores y literales en Otra lista enlazada.
            //Cuando el programa haya terminado de leer la entrada, mostrar
            //Los contenidos de cada lista enlazada.
            //Revise que es un Identificador y que es un literal
        }
        public void Ejercicio3()
        {
            //mida el tiempo entre Un lista ligada y una lista normal en el tiempo de ejecucion de 9876 elementos agregados.
            Console.Clear();
            const int max = 100000;
            LinkedList<int> Ligada1 = new LinkedList<int>();
            List<int> Listita = new List<int>();

            var m1 = Stopwatch.StartNew();
            for (int i = 1; i <= 9876; i++)
            {
                Listita.Add(i);
            }
            m1.Stop();

            var m2 = Stopwatch.StartNew();
            for (int i = 1; i <= 9876; i++)
            {
                Ligada1.AddLast(i);
            }
            m2.Stop();
            Console.WriteLine("Lista: " + ((double)(m1.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));//Imprimimos los tiempos
            Console.WriteLine("Lista ligada: " + ((double)(m2.Elapsed.TotalMilliseconds * 1000000) / max).ToString("0.00 ns"));//y comparamos 
        }
        public void Ejercicio4()
        {
            bool salir = false;
            int Mayor = 0, Menor = 0, Suma = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Ejercicio 4");
                Console.Write("Ingresa tu nombre Prof.: ");
                string Profe = Console.ReadLine();
                Console.Write("Ingresa el nombre de la clase: ");
                string NomClase = Console.ReadLine();
                Console.Write("Ingresa la cantidad de alumnos: ");
                int CantAlumnos = Convert.ToInt32(Console.ReadLine());
                List<Clase> clase = new List<Clase>();

                if (CantAlumnos >= 1 || CantAlumnos <= 58)
                {
                    Console.WriteLine();
                    for (int Cont = 0; Cont < CantAlumnos; Cont++)
                    {
                        Clase Salon = new Clase();
                        Salon.Maestro = Profe;
                        Salon.NombreClase = NomClase;
                        Console.Write("Ingresa el nombre del alumno: ");
                        Salon.Alumno = Console.ReadLine();
                        Console.Write("Ingresa la calificacion del alumno: ");
                        Salon.Calificacion = Convert.ToInt32(Console.ReadLine());
                        Suma = Suma + Salon.Calificacion;
                        if (Cont == 0)
                        {
                            Mayor = Salon.Calificacion;
                            Menor = Salon.Calificacion;
                        }
                        else
                        {
                            if(Salon.Calificacion > Mayor)
                            {
                                Mayor = Salon.Calificacion;
                            }
                            else { }

                            if (Salon.Calificacion < Menor)
                            {
                                Menor = Salon.Calificacion;
                            }
                            else { }
                        }
                        clase.Add(Salon);
                    }

                    List<string> NombresMayor = new List<string>();
                    List<string> NombresMenor = new List<string>();
                    foreach (var item in clase)
                    {
                        if(item.Calificacion == Mayor)
                        {
                            NombresMayor.Add(item.Alumno);
                        }
                        else if(item.Calificacion == Menor)
                        {
                            NombresMenor.Add(item.Alumno);
                        }
                    }

                    Console.WriteLine("Alumnos con la calificacion mayor ({0})", Mayor);
                    foreach(var item in NombresMayor)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("Alumnos con la calificacion menor ({0})", Menor);
                    foreach (var item in NombresMenor)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Calificacion media: {0}", (Suma / CantAlumnos));
                    salir = true;
                }
                else
                {
                    Console.WriteLine("Cantidad de alumnos no valida.");
                    salir = false;
                }
            } while (salir == false);
            // Diseñar e implementar una clase que le permita a un maestro hacer un seguimiento de las calificaciones
            // en un solo curso.Incluir métodos que calculen la nota media, la
            //calificacion más alto, y el calificacion más bajo. Escribe un programa para poner a prueba tu clase.
            //implementación. Minimo 30 Calificaciones, de 30 alumnos.
        }
    }

    public class Clase
    {
        public string Maestro { get; set; }
        public string Alumno { get; set; }
        public string NombreClase { get; set; }
        public int Calificacion { get; set; }

        public Clase()
        {

        }

    }
}
