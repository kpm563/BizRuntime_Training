using Apache.Ignite.Core;
using Apache.Ignite.Core.Events;
using System;
using System.Linq;

namespace IgniteDotNetApp
{
    class EventsExample
    {
        private static void ExecuteTask(IIgnite ignite)
        {
            var employees = Enumerable.Range(1, 10).SelectMany(x => new[]
            {
                new Employee("Allison Mathis",
                    25300,
                    new Address("2702 Freedom Lane, San Francisco, CA", 94109),
                    new[] {"Development"}),

                new Employee("Breana Robbin",
                    6500,
                    new Address("3960 Sundown Lane, Austin, TX", 78130),
                    new[] {"Sales"})
            }).ToArray();

            ignite.GetCompute().Execute(new AverageSalaryTask(), employees);
        }


        public static void EventCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine(">>> Events example started.");
                Console.WriteLine();

                // Local listen example
                Console.WriteLine(">>> Listening for a local event...");

                ignite.GetEvents().EnableLocal(EventType.TaskExecutionAll);

                var listener = new LocalListener();
                ignite.GetEvents().LocalListen(listener, EventType.TaskExecutionAll);

                ExecuteTask(ignite);

                ignite.GetEvents().StopLocalListen(listener);

                Console.WriteLine(">>> Received events count: " + listener.EventsReceived);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
        }
    }
}
