using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class Transformation
    {
        //The signature for Select is nice and simple and suggests that its most common usage is to transform from one type to another type, i.e. IObservable<TSource> to IObservable<TResult>.
        public void SelectMethod()
        {
            var source = Observable.Range(0, 5);
            source.Select(i => i + 3)
                .Dump("+3");
        }

        //In this example we transform integer values to characters.
        public void SelectExample()
        {
            Observable.Range(1, 5)
                .Select(i => (char)(i + 64))
                .Dump("char");
        }

        //transform our sequence of integers to a sequence of anonymous types.
        public void SelectAnonymous()
        {
            Observable.Range(1, 10)
                .Select(i=> new {Number =i, Character = (char)(i+64)})
                .Dump("Anonymous");
        }


        public void CastMethod()
        {
            var objects = new Subject<object>();
            objects.Cast<int>().Dump("cast");
            objects.OnNext(1);
            objects.OnNext(2);
            objects.OnNext(3);
            objects.OnNext(4);
            //objects.OnNext("5"); //Here it will fail to cast the value, it will generate an error.
        }

        public void OftypeMethod()
        {
            var objects = new Subject<object>();
            objects.OfType<int>().Dump("OfType");
            objects.OnNext(1);
            objects.OnNext(2);
            objects.OnNext("3");//This will be ignored ,  it will not generate any error.
            objects.OnNext(4);
            objects.OnCompleted();
        }


        public void TimeStampMethod()
        {
            Observable.Interval(TimeSpan.FromSeconds(2))
                .Take(5)
                .Timestamp()
                .Dump("TimeStamp");
        }

        public void TimeIntervalMethod()
        {
            Observable.Interval(TimeSpan.FromSeconds(2))
                .Take(5)
                .TimeInterval()
                .Dump("TimeInterval");
        }

        public void MaterializeMethod()
        {
            Observable.Range(1, 3)
                .Materialize()
                .Dump("Materialize");
        }



    }
}
