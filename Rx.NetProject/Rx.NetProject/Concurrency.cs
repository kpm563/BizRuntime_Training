using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class Concurrency
    {
        public void SingleThread()
        {
            Console.WriteLine("Starting on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
            var subject = new Subject<object>();
            subject.Subscribe(
                o => Console.WriteLine("Received {1} on threadId:{0}",
                    Thread.CurrentThread.ManagedThreadId,
                    o));
            ParameterizedThreadStart notify = obj =>
            {
                Console.WriteLine("OnNext({1}) on threadId:{0}",
                    Thread.CurrentThread.ManagedThreadId,
                    obj);
                subject.OnNext(obj);
            };
            notify(1);
            new Thread(notify).Start(2);
            new Thread(notify).Start(3);
        }

        public void MultiThreadExample()
        {
            Console.WriteLine("Starting on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
            var source = Observable.Create<int>(
                o =>
                {
                    Console.WriteLine("Invoked on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
                    o.OnNext(1);
                    o.OnNext(2);
                    o.OnNext(3);
                    o.OnCompleted();
                    Console.WriteLine("Finished on threadId:{0}",
                        Thread.CurrentThread.ManagedThreadId);
                    return Disposable.Empty;
                });
            source
                .SubscribeOn(Scheduler.ThreadPool)
                .Subscribe(
                    o => Console.WriteLine("Received {1} on threadId:{0}",
                        Thread.CurrentThread.ManagedThreadId,
                        o),
                    () => Console.WriteLine("OnCompleted on threadId:{0}",
                        Thread.CurrentThread.ManagedThreadId));
            Console.WriteLine("Subscribed on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
        }


        public void LockUps()
        {
            var sequence = new Subject<int>();
            Console.WriteLine("Next line should lock the system.");
            var value = sequence.First();
            sequence.OnNext(1);
            Console.WriteLine("I can never execute....");
        }


        
    }
}
