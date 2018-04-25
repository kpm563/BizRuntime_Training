using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consume
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            consumer.ConsumerMethod();

            //Broadcast broadcast = new Broadcast();
            //broadcast.Consumer();

            //Ordered ordered = new Ordered();
            //ordered.Consumer();

            Console.ReadKey();
        }
    }
}
