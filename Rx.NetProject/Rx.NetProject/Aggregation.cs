using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Rx.NetProject
{
    public static class Aggregation
    {
        public static void Dump<T>(this IObservable<T> source, string name)
        {
            source.Subscribe(
                i => Console.WriteLine("{0}-->{1}", name, i),
                ex => Console.WriteLine("{0} failed-->{1}", name, ex.Message),
                () => Console.WriteLine("{0} completed", name));
        }


        //The return sequence will have a single value being the count of the values in the source sequence. 
        public static void CountMethod()
        {
            var numbers = Observable.Range(0, 3);
            numbers.Dump("numbers");
            numbers.Count().Dump("count");
        }



        public static void AggregateMethod()
        {
            var numbers = new Subject<int>();
            numbers.Dump("numbers");
            numbers.Min().Dump("Min");
            numbers.Average().Dump("Average");
            numbers.OnNext(10);
            numbers.OnNext(20);
            numbers.OnNext(30);
            numbers.OnCompleted();
        }


        //The First() extension method simply returns the first value from a sequence.
        public static void FirstMethod()
        {
            var interval = Observable.Interval(TimeSpan.FromSeconds(3));
            //Will block for 3s before returning
            try
            {
                Console.WriteLine(interval.First());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void ScanMethod()
        {
            var numbers = new Subject<int>();
            var scan = numbers.Scan(0, (acc, current) => acc + current);
            numbers.Dump("numbers");
            scan.Dump("scan");
            numbers.OnNext(1);
            numbers.OnNext(2);
            numbers.OnNext(3);
            numbers.OnCompleted();
        }


    }
}
