using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorgramaEjemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Operaciones o = new Operaciones();
            Console.WriteLine("To Do List");
            o.Metodo1();
            o.metodo2();
            Console.ReadKey();
        }
    }
}
