using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_2InvestigacionRamirezGarciaJesus
{
    class Colas
    {
        private ArrayList MiColita;
        public Colas()
        {
            MiColita = new ArrayList();
        }

        public void EnQueue(object item) //Introduce un tipo
        {
            MiColita.Add(item);
        }

        public void DeQueue() //Elimina el valor en la posicion 0
        {
            MiColita.RemoveAt(0);
        }

        public object Peek() //Muestra la posicion 0
        {
            return MiColita[0];
        }

        public void Clear()
        {
            MiColita.Clear();
        }

        public int Count()
        {
            return Cola.Count;
        }
    }
}
