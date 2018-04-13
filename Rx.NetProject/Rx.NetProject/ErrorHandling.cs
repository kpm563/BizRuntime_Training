using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class ErrorHandling
    {
        public void Catch()
        {
            var source = new Subject<int>();
            var result = source.Catch(Observable.Empty<int>());
            result.Dump("Catch");
            source.OnNext(1);
            source.OnNext(2);
            //source.OnNext();
            source.OnError(new Exception("Fail!"));
        }
    }
}
