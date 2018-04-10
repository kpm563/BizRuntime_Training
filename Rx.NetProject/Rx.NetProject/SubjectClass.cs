using System;
using System.Reactive.Subjects;

namespace Rx.NetProject
{
    class SubjectClass
    {
        public void SubjectMethod()
        {
            var subject = new Subject<string>();
            WriteSequenceToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
        }

        public void SubjectMethod2()
        {
            var subject = new Subject<string>();
            subject.OnNext("a");
            WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
        }

        //ReplaySubject<T> provides the feature of caching values and then replaying them for any late subscriptions.
        public void ReplaySubjectMethod()
        {
            var subject = new ReplaySubject<string>();
            subject.OnNext("a");
            WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
        }
        
        public void ReplaySubjectBufferExample()
        {
            var bufferSize = 2;
            var subject = new ReplaySubject<string>(bufferSize);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("d");
        }

        //BehaviorSubject<T> is similar to ReplaySubject<T> except it only remembers the last publication. 
        public void BehaviorSubjectMethod()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.Subscribe(Console.WriteLine);
        }

        public void BehaviorSubjectMethod2()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("c");
            subject.OnNext("d");
        }

        // No values will be published as the sequence has completed. Nothing is written to the console.
        public void BehaviorSubjectCompletedMethod()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnCompleted();
            subject.Subscribe(Console.WriteLine);
        }


        //AsyncSubject<T> is similar to the Replay and Behavior subjects in the way that it caches values, however it will only store the last value, and only publish it when the sequence is completed. 

        public void AsyncSubjectMethod()
        {
            var asyncsubject = new AsyncSubject<string>();
            asyncsubject.OnNext("a");
            WriteSequenceToConsole(asyncsubject);
            asyncsubject.OnNext("b");
            asyncsubject.OnNext("c"); //No values will be written to the console.
        }

        public void AsyncSubjectMethod2()
        {
            var subject = new AsyncSubject<string>();
            subject.OnNext("a");
            WriteSequenceToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnCompleted();
        }

        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            sequence.Subscribe(value => Console.WriteLine(value));
        }
    }


}
