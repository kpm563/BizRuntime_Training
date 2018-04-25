using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produce
{
    class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            producer.ProducerMethod();

            //Broadcast broadcast = new Broadcast();
            //broadcast.Producer();


            //Ordered ordered = new Ordered();
            //ordered.Producer();

            Console.ReadKey();
        }
    }
}
