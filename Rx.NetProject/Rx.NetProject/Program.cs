using System;
using System.Collections.Generic;

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


            Transformation transObject = new Transformation();
            //transObject.SelectMethod();
            //transObject.SelectExample();
            //transObject.SelectAnonymous();




            //BlogSite.JsonSerialize();
            //BlogSite.JsonDeserialize();

            //Taming tamingObject = new Taming();
            //tamingObject.SideEffects();
            //tamingObject.WithPipeLine();
            //tamingObject.DoWithSideEffects();
            //tamingObject.DowithoutSideEffets();


            //LeaveMonad leaveMonadObject=new LeaveMonad();
            //leaveMonadObject.ForEach();
            //leaveMonadObject.WithSubscribe();
            //leaveMonadObject.ToEnumerableMethod();
            //leaveMonadObject.ToArrayMethod();

            //ErrorHandling errorObject =new ErrorHandling();
            //errorObject.Catch();


            TimeShiftedSequences timeShiftedObject = new TimeShiftedSequences();
            //timeShiftedObject.BufferMethod();
            //timeShiftedObject.OverlappingBehavior();
            //timeShiftedObject.StandardBehavior();
            //timeShiftedObject.SkipBehavior();
            //timeShiftedObject.OverlappingByTime();
            //timeShiftedObject.DelayMethod();
            //timeShiftedObject.SampleMethod();
            //timeShiftedObject.TimeOutMethod();



            HotColdObservables hotColdObject = new HotColdObservables();
            //hotColdObject.ReadFirstValue(EagerEvaluation());
            //hotColdObject.DisposalMethod();
            //hotColdObject.DisposalExample();
            //hotColdObject.AutoDisposal();



            Concurrency concurrencyObject = new Concurrency();
            //concurrencyObject.SingleThread();
            //concurrencyObject.MultiThreadExample();
            //concurrencyObject.LockUps();



            Tests tests = new Tests();
            tests.Testing();

            Console.WriteLine("Press enter to exit!");
            Console.Read();
        }

        public static IEnumerable<int> EagerEvaluation()
        {
            var result = new List<int>();
            Console.WriteLine("About to return 1");
            result.Add(1);
            //code below is executed but not used.
            Console.WriteLine("About to return 2");
            result.Add(2);
            return result;
        }
    }
}
