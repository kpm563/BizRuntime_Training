using System;

namespace Rx.NetProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new MySequenceOfNumbers();
            //var observer = new MyConsoleObserver<int>();
            //numbers.Subscribe(observer);


            SubjectClass subjectClassObject = new SubjectClass();
            //subjectClassObject.SubjectMethod();
            //subjectClassObject.SubjectMethod2();
            //subjectClassObject.ReplaySubjectMethod();
            //subjectClassObject.ReplaySubjectBufferExample();
            //subjectClassObject.BehaviorSubjectMethod();
            //subjectClassObject.BehaviorSubjectMethod2();
            //subjectClassObject.BehaviorSubjectCompletedMethod();
            //subjectClassObject.AsyncSubjectMethod();
            //subjectClassObject.AsyncSubjectMethod2();


            Sequence sequenceObject = new Sequence();
            //sequenceObject.ReturnMethod();
            //sequenceObject.EmptyMethod();
            //sequenceObject.NeverMethod();
            //sequenceObject.ThrowMethod();
            //sequenceObject.EmptyExample<T>();
            //sequenceObject.NonBlocking_event_driven();
            //sequenceObject.IntervalMethod();
            //sequenceObject.TimerMethod();


            //Sequence.RangeMethod();
            //Sequence.StartAction();
            //Sequence.StartFunc();



            ReducingSequence reducingObject = new ReducingSequence();
            //reducingObject.WhereMethod();
            //reducingObject.DistinctMethod();
            //reducingObject.DistinctUntilChangedMethod();
            //reducingObject.IgnoreElementsMethod();
            //reducingObject.SkipMethod();
            //reducingObject.TakeMethod();
            //reducingObject.SkipLastMethod();
            //reducingObject.TakeLastMethod();
            //reducingObject.SkipUntilMethod();
            //reducingObject.TakeUntilMethod();


            Inspection inspectionObject = new Inspection();
            //inspectionObject.AnyMethod();
            //inspectionObject.AnyErrorMethod();
            //inspectionObject.AllMethod();
            //inspectionObject.ContainsMethod();
            //inspectionObject.DefaultIfEmpty();
            //inspectionObject.ElementAtMethod();
            //inspectionObject.SequenceEqual();



            //Aggregation.CountMethod();
            //Aggregation.AggregateMethod();
            //Aggregation.FirstMethod();
            //Aggregation.ScanMethod();


            Console.WriteLine("Press enter to exit!");
            Console.Read();
        }



       

    }
}
