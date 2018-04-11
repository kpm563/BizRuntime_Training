using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;

namespace Rx.NetProject
{
    class Sequence
    {
        //This method takes a value of T and returns an IObservable<T> with the single value and then completes
        public void ReturnMethod()
        {
            var singleValue = Observable.Return<string>("Value"); //This also can be implemented using ReplaySubject.
            //singleValue = Observable.Return("Value"); //This is the same as above, no need to declare type <string>.

            
            var subject = new ReplaySubject<string>();
            subject.OnNext("Value");
            subject.OnCompleted();

            singleValue.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }


        //This returns an empty IObservable<T> i.e. it just publishes an OnCompleted notification.
        public void  EmptyMethod()
        {
            var empty = Observable.Empty<string>();

            //This is also like the above one.
            var subject = new ReplaySubject<string>();
            subject.OnCompleted();


            empty.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }

        //The Observable.Never<T>() method will return infinite sequence without any notifications.
        public void NeverMethod()
        {
            var never = Observable.Never<string>(); //This returns infinite sequence without any notification.

            //this is also similar as above one.
            var subject = new Subject<string>();


            never.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }

        //This method creates a sequence with just a single OnError notification containing the exception passed to the factory.
        public void ThrowMethod()
        {
            var throws = Observable.Throw<string>(new Exception());

            //This is the same as above.
            var subject = new ReplaySubject<string>();
            subject.OnError(new Exception());

            throws.Subscribe();
        }



        //Examples of Empty, Return, Never are recreated with Observable.Create:
        public IObservable<T> EmptyExample<T>()
        {
            return Observable.Create<T>(o =>
            {
                o.OnCompleted();
                return Disposable.Empty;
            });
        }

        public IObservable<T> ReturnExample<T>(T value)
        {
            return Observable.Create<T>(o =>
            {
                o.OnNext(value);
                o.OnCompleted();
                return Disposable.Empty;
            });
        }

        public IObservable<T> NeverExample<T>()
        {
            return Observable.Create<T>(o =>
            {
                return Disposable.Empty;
            });
        }



        public void NonBlocking_event_driven()
        {
            var obj = Observable.Create<string>(observer =>
            {
                var timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Elapsed += (s, e) => observer.OnNext("tick");
                timer.Elapsed += OnTimerElapsed;
                timer.Start();
                return () => {
                    timer.Elapsed -= OnTimerElapsed;
                    timer.Dispose();
                };

                //return Disposable.Empty;
            });
            var subscription = obj.Subscribe(Console.WriteLine);
            Console.ReadLine();
            subscription.Dispose();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime);
        }

        //Interval method will publish incremental values starting from zero, based on a frequency of your choosing.
        public void IntervalMethod()
        {
            var interval = Observable.Interval(TimeSpan.FromMilliseconds(500));

            var subscribe = interval.Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));

            subscribe.Dispose();
        }


        //Observable.Range(int, int) simply returns a range of integers.
        public static void RangeMethod()
        {
            var observable = Observable.Range(5, 8);

            var subscription = observable.Subscribe(new Observer());

            subscription.Dispose();
        }


        //Timer takes just a TimeSpan as Observable.
        public void TimerMethod()
        {
            var timer = Observable.Timer(TimeSpan.FromSeconds(1));
            timer.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));
        }


        //The Observable.Start method allows you to turn a long running Func<T> or Action into a single value observable sequence.
        public static void StartAction()
        {
            var start = Observable.Start(() =>
            {
                Console.Write("Working away");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }
            });
            start.Subscribe(
                unit => Console.WriteLine("Unit published"),
                () => Console.WriteLine("Action completed"));
        }


        public static void StartFunc()
        {
            var start = Observable.Start(() =>
            {
                Console.Write("Working away");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }
                return "Published value";
            });
            start.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("Action completed"));
        }



    }

    class Observer : IObserver<int>
    {
        public void OnNext(int value)
        {
            Console.WriteLine("Received value {0}", value);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }
    }
}
