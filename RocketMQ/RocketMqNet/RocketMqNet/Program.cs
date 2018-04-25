using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketMqNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Producer producer = new Producer();
            //producer.ProducerMethod();


            Consumer consumer = new Consumer();
            consumer.ConsumerMethod();

            Console.ReadKey();
        }
    }
}
