using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Rx.NetProject
{
    class ReducingSequence
    {
        //we will use the Where to filter out all even values produced from a Range sequence.
        public void WhereMethod()
        {
            var oddNumbers = Observable.Range(0, 10)
                .Where(i => i % 2 == 0)
                .Subscribe(
                    Console.WriteLine,
                    () => Console.WriteLine("Completed"));
        }

        //Distinct will only pass on values from the source that it has not seen before.
        public void DistinctMethod()
        {
            var subject = new Subject<int>();
            var distinct = subject.Distinct();
            subject.Subscribe(
                i => Console.WriteLine("{0}", i),
                () => Console.WriteLine("subject.OnCompleted()"));
            distinct.Subscribe(
                i => Console.WriteLine("distinct.OnNext({0})", i),
                () => Console.WriteLine("distinct.OnCompleted()"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnNext(1);
            subject.OnNext(1);
            subject.OnNext(4);
            subject.OnCompleted();
        }

        //DistinctUntilChanged. This method will surface values only if they are different from the previous value.
        public void DistinctUntilChangedMethod()
        {
            var subject = new Subject<int>();
            var distinct = subject.DistinctUntilChanged();
            subject.Subscribe(
                i => Console.WriteLine("{0}", i),
                () => Console.WriteLine("subject.OnCompleted()"));
            distinct.Subscribe(
                i => Console.WriteLine("distinct.OnNext({0})", i),
                () => Console.WriteLine("distinct.OnCompleted()"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnNext(1);
            subject.OnNext(1);
            subject.OnNext(4);
            subject.OnCompleted();
        }

        //The IgnoreElements extension method  allows us to receive the OnCompleted or OnError notifications
        public void IgnoreElementsMethod()
        {
            var subject = new Subject<int>();
            //subject.Where(_=>false);   //It will also produce the same result.
            var noElements = subject.IgnoreElements();
            subject.Subscribe(
                i => Console.WriteLine("subject.OnNext({0})", i),
                () => Console.WriteLine("subject.OnCompleted()"));
            noElements.Subscribe(
                i => Console.WriteLine("noElements.OnNext({0})", i),
                () => Console.WriteLine("noElements.OnCompleted()"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnCompleted();
        }


        //Note the first three values (0, 1 & 2) were all ignored from the output.
        public void SkipMethod()
        {
            Observable.Range(0, 10)
                .Skip(3)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }


        //we would only get the first 3 values and then the Take operator would complete the sequence.
        public void TakeMethod()
        {
            Observable.Range(0, 10)
                .Take(3)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }


        //The implementation of the SkipLast could cache all values, wait for the source sequence to complete, and then replay all the values except for the last number of elements. 
        public void SkipLastMethod()
        {
            var subject = new Subject<int>();
            subject
                .SkipLast(2)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            Console.WriteLine("Pushing 1");
            subject.OnNext(1);
            Console.WriteLine("Pushing 2");
            subject.OnNext(2);
            Console.WriteLine("Pushing 3");
            subject.OnNext(3);
            Console.WriteLine("Pushing 4");
            subject.OnNext(4);
            subject.OnCompleted();
        }


        //TakeLast does have to wait for the source sequence to complete to be able to push its results.
        public void TakeLastMethod()
        {
            var subject = new Subject<int>();
            subject
                .SkipLast(2)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            Console.WriteLine("Pushing 1");
            subject.OnNext(1);
            Console.WriteLine("Pushing 2");
            subject.OnNext(2);
            Console.WriteLine("Pushing 3");
            subject.OnNext(3);
            Console.WriteLine("Pushing 4");
            subject.OnNext(4);
            Console.WriteLine("Completing");
            subject.OnCompleted();
        }

        //SkipUntil will skip all values until any value is produced by a secondary observable sequence.
        public void SkipUntilMethod()
        {
            var subject = new Subject<int>();
            var otherSubject = new Subject<Unit>();
            subject
                .SkipUntil(otherSubject)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            otherSubject.OnNext(Unit.Default);
            subject.OnNext(4);
            subject.OnNext(5);
            subject.OnNext(6);
            subject.OnNext(7);
            subject.OnNext(8);
            subject.OnCompleted();
        }

        public void TakeUntilMethod()
        {
            var subject = new Subject<int>();
            var otherSubject = new Subject<Unit>();
            subject
                .TakeUntil(otherSubject)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnNext(4);
            subject.OnNext(5);
            subject.OnNext(6);
            subject.OnNext(7);
            otherSubject.OnNext(Unit.Default);
            subject.OnNext(8);
            subject.OnNext(9);
            subject.OnNext(10);
            subject.OnCompleted();
        }

    }
}
