using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class CombineSequences
    {
        public void ConcatMethod()
        {
            //Generate values 0,1,2 
            var s1 = Observable.Range(0, 3);
            //Generate values 5,6,7,8,9 
            var s2 = Observable.Range(5, 5);
            s1.Concat(s2)
                .Subscribe(Console.WriteLine);
        }


        public IEnumerable<IObservable<long>> GetSequences()
        {
            Console.WriteLine("GetSequences() called");
            Console.WriteLine("Yield 1st sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("1st subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(500))
                    .Select(i => 1L)
                    .Subscribe(o);
            });
            Console.WriteLine("Yield 2nd sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("2nd subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(300))
                    .Select(i => 2L)
                    .Subscribe(o);
            });
            Thread.Sleep(1000);     //Force a delay
            Console.WriteLine("Yield 3rd sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("3rd subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(100))
                    .Select(i => 3L)
                    .Subscribe(o);
            });
            Console.WriteLine("GetSequences() complete");
        }


        public void RepeatMethod()
        {
            var source = Observable.Range(0, 3);
            var result = source.Repeat(3);
            result.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Completed"));
        }


        public void StartWithMethod()
        {
            //Generate values 0,1,2 
            var source = Observable.Range(0, 3);
            var result = source.StartWith(-3, -2, -1);
            result.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Completed"));
        }


        public void AmbiguousMethod()
        {
            var s1 = new Subject<int>();
            var s2 = new Subject<int>();
            var s3 = new Subject<int>();
            var result = Observable.Amb(s1, s2, s3);
            result.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Completed"));
            s1.OnNext(1);
            s2.OnNext(2);
            s3.OnNext(3);
            s1.OnNext(1);
            s2.OnNext(2);
            s3.OnNext(3);
            s1.OnCompleted();
            s2.OnCompleted();
            s3.OnCompleted();
        }


        //The result of a Merge will complete only once all input sequences complete
        public void MergeMethod()
        {
            //Generate values 0,1,2 
            var s1 = Observable.Interval(TimeSpan.FromMilliseconds(250))
                .Take(3);
            //Generate values 100,101,102,103,104 
            var s2 = Observable.Interval(TimeSpan.FromMilliseconds(150))
                .Take(5)
                .Select(i => i + 100);
            s1.Merge(s2)
                .Subscribe(
                    Console.WriteLine,
                    () => Console.WriteLine("Completed"));
        }


    }
}
