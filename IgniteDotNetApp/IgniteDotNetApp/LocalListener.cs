using Apache.Ignite.Core.Events;
using System;
using System.Threading;

namespace IgniteDotNetApp
{
    class LocalListener: IEventListener<IEvent>
    {
        private int _eventsReceived;

        public int EventsReceived
        {
            get { return _eventsReceived; }
        }

        public bool Invoke(IEvent evt)
        {
            Interlocked.Increment(ref _eventsReceived);

            Console.WriteLine("Local listener received an event [evt={0}]", evt.Name);

            return true;
        }
    }
}
