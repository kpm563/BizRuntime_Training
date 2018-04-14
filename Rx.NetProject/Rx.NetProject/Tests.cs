using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class Tests
    {
        public void Testing()
        {
            var query = from method in typeof(Observable).GetMethods()
                from parameter in method.GetParameters()
                where typeof(IScheduler).IsAssignableFrom(parameter.ParameterType)
                group method by method.Name into m
                orderby m.Key
                select m.Key;
            foreach (var methodName in query)
            {
                Console.WriteLine(methodName);
            }
        }

        

    }
}
