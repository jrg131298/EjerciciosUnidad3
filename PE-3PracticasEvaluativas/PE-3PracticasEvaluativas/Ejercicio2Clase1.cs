using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3PracticasEvaluativas
{
    class Ejercicio2Clase1
    {
        int Opcion; //Captura una opcion
        bool SalirProceso = false; //Nos pemrite permanecer en el ejercicio
        //Diferentes listas en donde se pueden encontrar las tareas creadas por el profesor y que el alumno pueda mover
        List<Ejercicio2Tarea> ListaGlobal = new List<Ejercicio2Tarea>();
        List<Ejercicio2Tarea> ListaPendientes = new List<Ejercicio2Tarea>();
        List<Ejercicio2Tarea> ListaProceso = new List<Ejercicio2Tarea>();
        List<Ejercicio2Tarea> ListaTerminados = new List<Ejercicio2Tarea>();
        public void Inicio()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("======= To Do List =======");  //Menu donde nos permite saber si se desea ingresar a la "base de datos" como profesor o ingresar como alumno
                Console.WriteLine("Ingresa la opcion que desees: ");
                Console.WriteLine("1.- Ingresar como profesor");
                Console.WriteLine("2.- Ingresar como alumno");
                Console.WriteLine("3.- Regresar");
                Console.Write("R: ");
                try
                {
                    Opcion = Convert.ToInt32(Console.ReadLine()); //Captura de la opcion
                    switch (Opcion)
                    {
                        case 1:
                            SalirProceso = ComoProfesor(); //Nos permite ingresar como profesor
                            break;
                        case 2:
                            SalirProceso = ComoAlumno(); //Nos permite ingresar como alumno
                            break;
                        case 3:
                            SalirProceso = true; //Nos permite regresar al menu de los dif programas
                            break;
                        default:
                            Console.WriteLine("Ingresaste algo erroneo."); //Opcion en caso de ingresar un valor aceptable al tipo de dato, pero que no sea uno que muestra el menu
                            Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                            break;
                    }
                }
                catch //Captura de excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
            } while (SalirProceso == false); //Do-While que nos permite permanecer en el ejercicio
        }

        public bool ComoProfesor() //Metodo que nos permite consultar las tareas en general y crear tareas
        {
            do
            {
                Console.Clear();
                Console.WriteLine("======= To Do List ======="); //Menu que nos permite realizar una accion como profesor
                Console.WriteLine("Ingresa la opcion que desees prof.: ");
                Console.WriteLine("1.- Crear tarea");
                Console.WriteLine("2.- Consultar tareas");
                Console.WriteLine("3.- Regresar");
                Console.Write("R: ");
                try
                {
                    Opcion = Convert.ToInt32(Console.ReadLine()); //Captura de opcion
                    switch (Opcion)
                    {
                        case 1:
                            SalirProceso = CrearTarea(); //Metodo que nos permite crear una tarea
                            break;
                        case 2:
                            SalirProceso = MostrarTareas(); //Metodo que nos muestra una lista general de todas las tareas
                            break;
                        case 3:
                            SalirProceso = true; //Nos permite regresar al primer menu de este ejercicio
                            break;
                        default:
                            Console.WriteLine("Ingresaste algo erroneo."); //Opcion en caso de ingresar un valor aceptable al tipo de dato, pero que no sea uno que muestra el menu
                            break;
                    }
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
                catch //Captura de excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
            } while (SalirProceso == false); //Nos permite permanecer en este menu
            return false;
        }

        public bool ComoAlumno() //Metodo que nos permite consultar las tareas y cambiar su estatus
        {
            do
            {
                Console.Clear();
                Console.WriteLine("======= To Do List ======="); //Menu que nos permite realizar una accion
                Console.WriteLine("Ingresa la opcion que desees: ");
                Console.WriteLine("1.- Lista Global");
                Console.WriteLine("2.- Lista de Pendientes");
                Console.WriteLine("3.- Lista de Tareas en Proceso");
                Console.WriteLine("4.- Lista de Terminados");
                Console.WriteLine("5.- Regresar");
                Console.Write("R: ");
                try
                {
                    Opcion = Convert.ToInt32(Console.ReadLine()); //Captura de opcion
                    switch (Opcion)
                    {
                        case 1:
                            SalirProceso = MostrarTareas(1); //Metodo que permite consultar una lista, dependiendo el parametro que reciba
                            break;
                        case 2:
                            SalirProceso = MostrarTareas(2); //Metodo que permite consultar una lista, dependiendo el parametro que reciba
                            break;
                        case 3:
                            SalirProceso = MostrarTareas(3); //Metodo que permite consultar una lista, dependiendo el parametro que reciba
                            break;
                        case 4:
                            SalirProceso = MostrarTareas(4); //Metodo que permite consultar una lista, dependiendo el parametro que reciba
                            break;
                        case 5:
                            SalirProceso = true; //Nos permite regresar al menu anterior
                            break;
                        default:
                            Console.WriteLine("Ingresaste algo erroneo."); //Opcion en caso de ingresar un valor aceptable al tipo de dato, pero que no sea uno que muestra el menu
                            break;
                    }
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
                catch //Captura de Excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
            } while (SalirProceso == false); //Do-While que nos permite permanecer en este menu
            return false;
        }

        public bool CrearTarea() //Metodo por el cual se crean tareas
        {
            do
            {
                try
                {
                    Console.Clear();
                    Ejercicio2Tarea TareaGlobal = new Ejercicio2Tarea();
                    Console.WriteLine("======= To Do List ======="); //Captura de datos del objeto "TareaGlobal" el cual es una tarea nueva
                    Console.WriteLine("Ingresa el nombre de la tarea: ");
                    TareaGlobal.Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa el nombre la fecha de inicio: ");
                    TareaGlobal.FechaInicio = Console.ReadLine();

                    ListaGlobal.Add(TareaGlobal); //Se introduce el objeto que contiene a la tarea nueva, en la lista global
                    SalirProceso = true;
                }
                catch //Captura de excepciones
                {
                    Console.WriteLine("Ingresaste algo erroneo.");
                    Console.WriteLine("\nPresiona un boton para continuar."); Console.ReadKey();
                }
            } while (SalirProceso == false); //Nos permite permanecer en la captura de una nueva tarea
            return false;
        }

        public bool MostrarTareas() //Metodo el cual nos permite mostrar todas las tareas en general
        {
            Console.Clear();
            Console.WriteLine("======= To Do List =======\n"); //Impresion de todas las listas existentes
            int Contador = 1;
            foreach (var Item in ListaGlobal)
            {
                Console.WriteLine("{0}.-{1}  Fecha I: {2}", Contador, Item.Nombre, Item.FechaInicio);
                Contador++;
            }
            foreach (var Item in ListaPendientes)
            {
                Console.WriteLine("{0}.-{1}  Fecha I: {2}", Contador, Item.Nombre, Item.FechaInicio);
                Contador++;
            }
            foreach (var Item in ListaProceso)
            {
                Console.WriteLine("{0}.-{1}  Fecha I: {2}", Contador, Item.Nombre, Item.FechaInicio);
                Contador++;
            }
            foreach (var Item in ListaTerminados)
            {
                Console.WriteLine("{0}.-{1}  Fecha I: {2}", Contador, Item.Nombre, Item.FechaInicio);
                Contador++;
            }
            return false;
        }

        public bool MostrarTareas(int Cual) //Sobrecargo de metodo el cual nos permite consultar una lista en especifico, dependiendo del parametro que reciba
        {
            do
            {
                Console.Clear();
                Console.WriteLine("======= To Do List =======\n");
                int Contador = 1, Cantidad = 0;
                if (Cual == 1) //Si se cumple la condicion, se imprimira la lista global
                {
                    foreach (var Item in ListaGlobal)
                    {
                        Console.WriteLine("{0}.-{1}  Fecha I: {2}", Contador, Item.Nombre, Item.FechaInicio);
                        Contador++;
                    }
                    Cantidad = ListaGlobal.Count();
                }
                else if(Cual == 2) //Si se cumple la condicion, se imprimira la lista de pendientes
                {
                    foreach (var Item in ListaPendientes)
                    {
                        Console.WriteLine("{0}.-{1}  Fecha I: {2}  Status:{3}", Contador, Item.Nombre, Item.FechaInicio, Item.Status);
                        Contador++;
                    }
                    Cantidad = ListaPendientes.Count();
                }
                else if (Cual == 3) //Si se cumple la condicion, se imprimira la lista de tareas en proceso
                {
                    foreach (var Item in ListaProceso)
                    {
                        Console.WriteLine("{0}.-{1}  Fecha I: {2}  Status:{3}", Contador, Item.Nombre, Item.FechaInicio, Item.Status);
                        Contador++;
                    }
                    Cantidad = ListaProceso.Count();
                }
                else if (Cual == 4) //Si se cumple la condicion, se imprimira la lista de tareas terminadas
                {
                    foreach (var Item in ListaTerminados)
                    {
                        Console.WriteLine("{0}.-{1}  Fecha I: {2}  Fecha F: {4}  Status:{3}  Descripcion: {5}", Contador, Item.Nombre, Item.FechaInicio, Item.Status, Item.FechaFinal, Item.Descripcion);
                        Contador++;
                    }
                    Cantidad = ListaTerminados.Count();
                }
                if (Cantidad != 0) //Nos permite saber si existe alguna tarea en la lista escogida, si se cumple la condicion es porque si se pueden realizar cambios de estatos a una tarea en la tabla escogida
                {
                    try
                    {
                        Console.WriteLine("\nDeseas realizar un cambio?");
                        Console.WriteLine("1.- Si");
                        Console.WriteLine("2.- No");
                        int Cambio = Convert.ToInt32(Console.ReadLine()); //Captura de opcion
                        
                        if(Cambio == 1) //Si se cumple. significa que se desea realizar un cambio de estatus
                        {
                            Console.WriteLine("Ingresa la posicion de la tarea que desees cambiar: ");
                            Console.Write("R: ");
                            int IndiceTarea = Convert.ToInt32(Console.ReadLine());
                            if(IndiceTarea >= 0 && IndiceTarea <= Cantidad) //Nos permite saber si la tarea existe en la tabla
                            {
                                Ejercicio2Tarea Tarea = new Ejercicio2Tarea();
                                Tarea = Busqueda(Cual, IndiceTarea); //Nos permite extraer la tarea que se desea modificar
                                Intercambio(Tarea, Cual); //Nos permite realizar un intercambio de status a la tarea extraida
                            }
                            else //Significa que la tarea escogida no existe
                            {
                                Console.WriteLine("Cambio no puede ser realizado");
                                Console.WriteLine("Presiona un boton para continuar."); Console.ReadKey();
                            }
                        }
                        else //En caso de no haber tareas en la tabla escogida, este te devuelve al menu anterior
                        {
                            SalirProceso = true;
                        }

                    }
                    catch //Captura de excepciones
                    {
                        Console.WriteLine("Ingresaste algo erroneo.");
                        Console.WriteLine("Presiona un boton para continuar."); Console.ReadKey();
                    }
                }
                else
                {
                    SalirProceso = true;
                }
            } while (SalirProceso == false); //Nos permite permanecer en este menu
            return false;
        }

        public Ejercicio2Tarea Busqueda(int Cual, int Cual2) //Metodo el cual busca la tarea a la que se desea realizar cambios
        {
            Ejercicio2Tarea Tomado = new Ejercicio2Tarea();
            int Cont = 1;
            if(Cual == 1) //Si se cumple, significa que se necesita una tarea de la tabla global
            {
                foreach (var Item in ListaGlobal) //Nos permite rastrear la tarea
                {
                    if (Cont == Cual2)
                    {
                        Tomado = Item;
                    }
                    else { }
                    Cont++;
                }
                ListaGlobal.RemoveAt(Cual2 - 1);
            }
            else if (Cual == 2) //Si se cumple, significa que se necesita una tarea de la tabla de pendientes
            {
                foreach (var Item in ListaPendientes) //Nos permite rastrear la tarea
                {
                    if (Cont == Cual2)
                    {
                        Tomado = Item;
                    }
                    else { }
                    Cont++;
                }
                ListaPendientes.RemoveAt(Cual2 - 1);
            }
            else if (Cual == 3) //Si se cumple, significa que se necesita una tarea de la tabla de tareas en proceso
            {
                foreach (var Item in ListaProceso) //Nos permite rastrear la tarea
                {
                    if (Cont == Cual2)
                    {
                        Tomado = Item;
                    }
                    else { }
                    Cont++;
                }
                ListaProceso.RemoveAt(Cual2 - 1);
            }
            else //Si se cumple, significa que se necesita una tarea de la tabla de tareas terminadas
            {
                foreach (var Item in ListaTerminados) //Nos permite rastrear la tarea
                {
                    if (Cont == Cual2)
                    {
                        Tomado = Item;
                    }
                    else { }
                    Cont++;
                }
                ListaTerminados.RemoveAt(Cual2 - 1);
            }
            return Tomado;
        }

        public void Intercambio(Ejercicio2Tarea Ese, int Cual) //Nos permite realizar cambios en la tarea seleccionada
        {
            try
            {
                if (Cual == 1) //Cambios permitidos en una tarea de la lista global
                {
                    Console.WriteLine("Indique el cambio de status deseado: ");
                    Console.WriteLine("1.- Pendiente");
                    Console.WriteLine("2.- Proceso");
                    Console.WriteLine("3.- Terminado");
                    Console.Write("R: ");
                    int Opc = Convert.ToInt32(Console.ReadLine());
                    if(Opc == 1)
                    {
                        Ese.Status = "Pendiente";
                        ListaPendientes.Add(Ese);
                    }
                    else if (Opc == 2)
                    {
                        Ese.Status = "Proceso";
                        ListaProceso.Add(Ese);
                    }
                    else if (Opc == 3)
                    {
                        Ese.Status = "Terminado";
                        Console.Write("Ingresa una descripcion: ");
                        Ese.Descripcion = Console.ReadLine();
                        Console.Write("Ingresa la fecha de entrega: ");
                        Ese.FechaFinal = Console.ReadLine();
                        ListaTerminados.Add(Ese);
                    }
                    else
                    {
                        Console.WriteLine("A ocurrido un error");
                    }
                }
                else if (Cual == 2) //Cambios permitidos en una tarea de la lista de pendientes
                {
                    Console.WriteLine("Indique el cambio de status deseado: ");
                    Console.WriteLine("1.- Proceso");
                    Console.WriteLine("2.- Terminado");
                    Console.Write("R: ");
                    int Opc = Convert.ToInt32(Console.ReadLine());
                    if (Opc == 1)
                    {
                        Ese.Status = "Proceso";
                        ListaProceso.Add(Ese);
                    }
                    else if (Opc == 2)
                    {
                        Ese.Status = "Terminado";
                        Console.Write("Ingresa una descripcion: ");
                        Ese.Descripcion = Console.ReadLine();
                        Console.Write("Ingresa la fecha de entrega: ");
                        Ese.FechaFinal = Console.ReadLine();
                        ListaTerminados.Add(Ese);
                    }
                    else
                    {
                        Console.WriteLine("A ocurrido un error");
                    }
                }
                else if (Cual == 3) //Cambios permitidos en una tarea de la lista de tareas en proceso
                {
                    Ese.Status = "Terminado";
                    Console.Write("Ingresa una descripcion: ");
                    Ese.Descripcion = Console.ReadLine();
                    Console.Write("Ingresa la fecha de entrega: ");
                    Ese.FechaFinal = Console.ReadLine();
                    ListaTerminados.Add(Ese);
                }
                else if (Cual == 4) //Cambios permitidos en una tarea de la lista de tareas termnadas
                {
                    Console.WriteLine("Indique el cambio de status deseado: ");
                    Console.WriteLine("1.- Pendiente");
                    Console.WriteLine("2.- Proceso");
                    Console.Write("R: ");
                    int Opc = Convert.ToInt32(Console.ReadLine());
                    if (Opc == 1)
                    {
                        Ese.Status = "Pendiente";
                        ListaPendientes.Add(Ese);
                    }
                    else if (Opc == 2)
                    {
                        Ese.Status = "Proceso";
                        ListaProceso.Add(Ese);
                    }
                }
            }
            catch
            {
                Console.WriteLine("A ocurrido un error.");
            }
        }
    }
}
