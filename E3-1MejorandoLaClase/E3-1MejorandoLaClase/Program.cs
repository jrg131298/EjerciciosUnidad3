using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1RamirezGarciaJesus
{
    class Menu
    {
        static void Main(string[] args)
        {
            Int16 Opcion = 0; //Valor de la accion que se desea realizar en el menu principal
            bool Salir = false, SalirProceso = false; //Permiten saber si se realizo con exito un proceso o permite la salida del programa
            int Contador = 1;
            Proceso P = new Proceso(); //Objeto de la clase
            do
            {
                do
                {
                    try
                    {
                        //Menu principal el cual se repite hasta que ingresen una opcion certera
                        Console.Clear();
                        Console.WriteLine("Ingresa la opcion que desee:");
                        Console.WriteLine("1.- Realizar una consulta.");
                        Console.WriteLine("2.- Dar de alta a un alumno.");
                        Console.WriteLine("3.- Salir del programa.");
                        Console.Write("R: ");
                        Opcion = Convert.ToInt16(Console.ReadLine());
                        SalirProceso = true;
                    }
                    catch
                    {
                        Console.WriteLine("\nIngresaste algo erroneo, intentelo de nuevo.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (SalirProceso == false);


                switch (Opcion) //Se compara la opcion escogida
                {
                    case 1: //Significa que el usuario desea realizar una consulta
                        if (Contador == 1) //Se hace una comparacion para saber si ya hay un alumno dado de alta
                        {
                            Console.WriteLine("Debe por lo menos dar de alta un alumno para hacer una consulta.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            P.Consulta(); //Se ejecuta el metodo tipo procedimiento el cual te muestra otro menu para preguntar el tipo de consulta.
                        }
                        break;
                    case 2: //Significa que el usuario desea agregar un alumno a la lista
                        P.Alta(Contador); // Se ejecuta el metodo tipo procedimento al cual se el envia el parametro "Contador" el cual es la posicion del alumno en la lista
                        Contador++;
                        break;
                    case 3: //Cuando se desea salir del programa
                        Salir = true;
                        Console.WriteLine("\nGracias por utilizar el programa.\nPresione una tecla para salir del programa.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nIngresaste algo erroneo, intentelo de nuevo.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (Salir == false); //Cuando se cierra el ciclo Do-While se termina el programa.
        }
    }

    class Proceso
    {
        public ArrayList NoControl = new ArrayList(); //Se guardan los numeros de control de cada alumno
        public ArrayList Nombre = new ArrayList(); //Se guardan los nombres de cada alumno
        public ArrayList Calificacion = new ArrayList(); //Se guardan las calificaciones de cada alumno
        public ArrayList Materia = new ArrayList(); //Se guardan las materias
        int Aux1, Aux2; //Variables que permiten validar si efectivamente se ingresa un numero de control y calificacion de puros numeros enteros 
        string Aux3; //Se le asigna informacion de forma temporal
        string[] VectorAux = new string[4]; //Vector que guarda temporalmente los valores de un alumno (NoControl, Nombre, Materia, Calificacion) para despues ingresarlos a una lista
        bool SalirProceso = false, SalidaProceso2 = false, NoControlR = false, MateriaR = false; //Variables que permiten hacer comparaciones
        public void Consulta()
        {
            do
            {
                try
                {   //Menu que se muestra al entrar en las consultas
                    Console.Clear();
                    Console.WriteLine("Consultas");
                    Console.WriteLine("Ingresa la opcion que desee: ");
                    Console.WriteLine("1.- Consultar por numero de control.");
                    Console.WriteLine("2.- Consultar por materia.");
                    Console.WriteLine("3.- Salir de las consultas.");
                    Aux1 = Convert.ToInt32(Console.ReadLine()); //Valor de la opcion deseada

                    switch (Aux1) //Se analiza la opcion ingresada
                    {
                        case 1: //Significa que se realizara una consulta por numero de control
                            Console.Write("\n1.- Consultar por numero de control.\nIngresaste el numero de control del alumno: ");
                            Aux2 = Convert.ToInt32(Console.ReadLine());
                            Aux3 = Convert.ToString(Aux2);
                            Buscar(Aux1, Aux3); //Se ejecuta el metodo encargado de realizar la consulta, este recibe como parametros Aux1(tipo de consulta) y Aux3(NoControl a consultar)
                            SalidaProceso2 = true;
                            break;
                        case 2: //Significa que se realizara una consulta por el nombre de la materia
                            Console.Write("\n2.- Consultar por materia.\nIngresaste el nombre de la materia: ");
                            Aux3 = Console.ReadLine();
                            Buscar(Aux1, Aux3); //Se ejecuta el metodo encargado de realizar la consulta, este recibe como parametros Aux1(tipo de consulta) y Aux3(Materia a consultar)
                            SalidaProceso2 = true;
                            break;
                        case 3: //Significa que no se desea realizar una consulta, lo cual te retorna al menu principal
                            SalidaProceso2 = true;
                            break;
                        default: //Significa que escogiste un valor que soporta el tipo el cual no se encuentra en el menu
                            Console.WriteLine("\nIngresaste algo erroneo, intentelo de nuevo.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\nIngresaste algo erroneo, intentelo de nuevo.\nPresione una tecla para continuar.");
                    Console.ReadKey();
                }
            } while (SalidaProceso2 == false); //Este termina las consultas y te retorna al menu principal
        }
        public void Buscar(int Cual, string Dato)
        {
            Console.Clear();
            Console.WriteLine("-------Resultado de la consulta-------");
            if (Cual == 1) //"Cual" contiene el tipo de consulta (1 si es por NoControl) (2 si es por Materia)
            {
                for (int Contador = 0; Contador < NoControl.Count; Contador++) //1er for el cual permite saber si existe el valor en la lista
                {
                    if (Dato == Convert.ToString(NoControl[Contador]))
                    {
                        Console.WriteLine("Calificaciones de {0} {1}:", NoControl[Contador], Nombre[Contador]);
                        for (int Contador2 = 0; Contador2 < NoControl.Count; Contador2++) //For el cual se ejecuta tras saber que existe el valor a consultar y despliega los datos de alumno
                        {
                            if (Dato == Convert.ToString(NoControl[Contador2]))
                            {
                                Console.WriteLine("{0}: {1}", Materia[Contador2], Calificacion[Contador2]);
                            }
                            else { }
                        }
                        break;
                    }
                    else { }
                }
            }
            else
            {
                for (int Contador = 0; Contador < Materia.Count; Contador++) //1er for el cual permite saber si existe el valor en la lista
                {
                    if (Dato == Convert.ToString(Materia[Contador]))
                    {
                        Console.WriteLine("{0}", Materia[Contador]);
                        for (int Contador2 = 0, Contador3 = 0; Contador2 < Materia.Count; Contador2++) //For el cual se ejecuta tras saber que existe el valor a consultar y despliega los datos de los alumnos en la clase
                        {
                            if (Dato == Convert.ToString(Materia[Contador2]))
                            {
                                Console.WriteLine("{0} {1}: {2}", NoControl[Contador2], Nombre[Contador2], Calificacion[Contador2]);
                                Contador3 = Contador3 + 1;
                            }
                            else { }
                            Console.WriteLine("Cantidad de alumno en la clase: {0}", Contador3);
                        }
                        break;
                    }
                    else { }
                }
            }
            Console.WriteLine("\nPresione una tecla para continuar.");
            Console.ReadKey();
        }

        public void Alta(int Posicion) //Posicion contiene la posicion del alumno en la lista
        {
            do
            {
                try
                {
                    do
                    {   //Se capturan datos de un alumno (NoControl, Nombre, Materia, Clificacion)
                        Console.Clear();
                        Console.WriteLine("Alta de un alumno {0}", Posicion);
                        Console.Write("Ingresa el numero de control del alumno (este debe ser numerico y tener un largo de 4 digitos): ");
                        Aux1 = Convert.ToInt32(Console.ReadLine());
                        VectorAux[0] = Convert.ToString(Aux1);
                        if (VectorAux[0].Length == 4) //Verifica que efectivamente el largo del numero de control sea de 4
                        {
                            if (Posicion > 1) //Si se cumple esta condicion, significa que ya existe por lo menos 1 alumno en la lista
                            {
                                NoControlR = NoControlRepetido(VectorAux[0]); //Se ejecuta metodo tipo funcion el cual valida si ya existe el NoControl en la lista y el cual regresa un valor tipo bool
                                if (NoControlR == true) //Significa que si se encontro el NoControl del alumno y por lo cual ya no se pide el nombre del mismo
                                {
                                    Console.Write("Nombre: {0}\n", Aux3);
                                    VectorAux[1] = Aux3;

                                }
                                else //Significa que no se encontro el NoControl de alumno por lo cual es necesario pedir su nombre
                                {
                                    Console.Write("Ingresa el nombre del alumno: ");
                                    VectorAux[1] = Console.ReadLine();
                                }
                            }
                            else //En caso de ser el 1er alumno, se piden todos los datos
                            {
                                Console.Write("Ingresa el nombre del alumno: ");
                                VectorAux[1] = Console.ReadLine();
                            }

                            Console.Write("Ingresa el nombre de la materia: ");
                            VectorAux[2] = Console.ReadLine();
                            if (NoControlR == true) //Si esta desicion se cumple, significa que ya existe el numero de control
                            {
                                MateriaR = MateriaRepetido(VectorAux[0], VectorAux[2]); //Se ejecuta el metodo tipo funcion el cual realiza una consulta para saber si para el NoControl 
                            }                                                           //ya existe una calificacion de esa materia, y este regresa un valor tipo bool
                            else { }

                            if (MateriaR == false) //Si esta condicion se cumple, significa que el alumno no tiene asignada una calificacion en la materia ingresada
                            {
                                Console.Write("Ingresa la calificacion 0 - 100 (no debe contener decimales): ");
                                Aux2 = Convert.ToInt32(Console.ReadLine());
                                VectorAux[3] = Convert.ToString(Aux2);
                                if (Aux2 >= 0 && Aux2 < 101) //Se valida si efectivamente la calificacion se encuentra en el rango establecido
                                {
                                    //Se almacenan los datos en la lista correspondiente (los datos se encuentran en el vector con valores temporales)
                                    NoControl.Add(VectorAux[0]);
                                    Nombre.Add(VectorAux[1]);
                                    Materia.Add(VectorAux[2]);
                                    Calificacion.Add(VectorAux[3]);
                                    Console.WriteLine("\n{0} {1}, tiene calificacion de {2} en la materia {3}.", NoControl[Posicion - 1], Nombre[Posicion - 1], Calificacion[Posicion - 1], Materia[Posicion - 1]);
                                    SalirProceso = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nIngresaste un valor fuera del rango.\nPresione una tecla para continuar.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nYa existe una calificacion para el alumno en esta materia.\nPresione una tecla para continuar.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Write("\nIngresaste un valor fuera del rango.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                        }
                    } while (SalirProceso == false);
                }
                catch
                {
                    Console.WriteLine("\nIngresaste algo erroneo, intentelo de nuevo.\nPresione una tecla para continuar.");
                    Console.ReadKey();
                }
            } while (SalirProceso == false); //Cuando se cierra el ciclo, este da por terminada el alta del alumno y te regresa al menu principal
            Console.WriteLine("Alumno dado de alta correctamente.\nPresione una tecla para continuar.");
            Console.ReadKey();
            SalirProceso = false;
        }

        public bool NoControlRepetido(string Dato) //Metodo el cual permite saber si existe el NoControl en la lista
        {
            for (int Contador = 0; Contador < NoControl.Count; Contador++)
            {
                if (Dato == Convert.ToString(NoControl[Contador]))
                {
                    Aux3 = Convert.ToString(Nombre[Contador]);
                    return true;
                }
                else { }
            }
            return false;
        }

        public bool MateriaRepetido(string Dato1, string Dato2) //Metodo el cual permite saber si existe una calificacion en la materia del alumno
        {
            for (int Contador = 0; Contador < Materia.Count; Contador++)
            {
                if ((Dato1 == Convert.ToString(NoControl[Contador])) && (Dato2 == Convert.ToString(Materia[Contador])))
                {
                    return true;
                }
                else { }
            }
            return false;
        }
    }
}