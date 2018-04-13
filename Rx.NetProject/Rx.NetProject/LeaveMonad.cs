using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class LeaveMonad
    {

        //We can use for each instead for subscribe.
        //The key difference between ForEach and Subscribe is that ForEach will block the current thread until the sequence completes.
        public void ForEach()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(5);
            source.ForEach(i => Console.WriteLine("received {0} @ {1}", i, DateTime.Now));
            Console.WriteLine("completed @ {0}", DateTime.Now);
        }

        //If we substitute the call to ForEach with a call to Subscribe, we will see the completed line happen first.
        public void WithSubscribe()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(5);
            source.Subscribe(i => Console.WriteLine("received {0} @ {1}", i, DateTime.Now));
            Console.WriteLine("completed @ {0}", DateTime.Now);
        }



        public void ToEnumerableMethod()
        {
            var period = TimeSpan.FromMilliseconds(200);
            var source = Observable.Timer(TimeSpan.Zero, period)
                .Take(5);
            var result = source.ToEnumerable();
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("done");
        }


        //Once the observable sequence completes, the array or list will be pushed as the single value of the result sequence.
        public void ToArrayMethod()
        {
            var period = TimeSpan.FromMilliseconds(200);
            var source = Observable.Timer(TimeSpan.Zero, period).Take(5);
            var result = source.ToArray();
            result.Subscribe(
                arr => {
                    Console.WriteLine("Received array");
                    foreach (var value in arr)
                    {
                        Console.WriteLine(value);
                    }
                },
                () => Console.WriteLine("Completed")
            );
            Console.WriteLine("Subscribed");
        }



    }
}
