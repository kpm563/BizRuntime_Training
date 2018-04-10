using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new MySequenceOfNumbers();
            var observer = new MyConsoleObserver<int>();
            numbers.Subscribe(observer);


            SubjectClass subjectClassObject = new SubjectClass();
            subjectClassObject.SubjectMethod();
            subjectClassObject.SubjectMethod2();
            subjectClassObject.ReplaySubjectMethod();
            subjectClassObject.ReplaySubjectBufferExample();
            subjectClassObject.BehaviorSubjectMethod();
            subjectClassObject.BehaviorSubjectMethod2();
            subjectClassObject.BehaviorSubjectCompletedMethod();
            subjectClassObject.AsyncSubjectMethod();
            subjectClassObject.AsyncSubjectMethod2();

            Console.Read();
        }



       

    }
}
