using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core;

namespace IgniteDotNetApp
{
    class ServicesClass
    {
        public static void ServiceMethod()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine(">>> ServicesClass execution started.......");
                Console.WriteLine();

                var svc = new MapService<int, string>();
                Console.WriteLine(">>> Deploying service to all nodes ....");

                var prx = ignite.GetServices().GetServiceProxy<IMapService<int, string>>("service", true);

                for (int i = 0; i < 10; i++)
                {
                    prx.Put(i, i.ToString());
                }

                var mapSize = prx.Size;

                Console.WriteLine(">>> Map service size :: " + mapSize);

                ignite.GetServices().CancelAll();
            }
            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
        }
    }
}
