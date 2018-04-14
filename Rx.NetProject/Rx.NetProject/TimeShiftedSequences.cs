using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx.NetProject
{
    class TimeShiftedSequences
    {

        /// <summary>
        /// The Buffer operator allows you to store away a range of values and then re-publish them as a list once the buffer is full. You can temporarily withhold a specified number of elements, stash away all the values for a given time span, or use a combination of both count and time.
        /// </summary>
        public void BufferMethod()
        {
            var idealBatchSize = 15;
            var maxTimeDelay = TimeSpan.FromSeconds(3);
            var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
                .Concat(Observable.Interval(TimeSpan.FromSeconds(0.01)).Take(100));
            source.Buffer(maxTimeDelay, idealBatchSize)
                .Subscribe(
                    buffer => Console.WriteLine("Buffer of {1} @ {0}", DateTime.Now, buffer.Count),
                    () => Console.WriteLine("Completed"));
        }


        //Overlapping buffers by count
        public void OverlappingBehavior()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);
            source.Buffer(3, 1)
                .Subscribe(
                    buffer =>
                    {
                        Console.WriteLine("--Overlap Buffered values");
                        foreach (var value in buffer)
                        {
                            Console.WriteLine(value);
                        }
                    }, () => Console.WriteLine("Overlap Completed"));
        }


        public void StandardBehavior()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);
            source.Buffer(3, 3)
                .Subscribe(
                    buffer =>
                    {
                        Console.WriteLine("--Standard Buffered values");
                        foreach (var value in buffer)
                        {
                            Console.WriteLine(value);
                        }
                    }, () => Console.WriteLine("Standard Completed"));
        }

        public void SkipBehavior()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);
            source.Buffer(3, 5)
                .Subscribe(
                    buffer =>
                    {
                        Console.WriteLine("--Skip Buffered values");
                        foreach (var value in buffer)
                        {
                            Console.WriteLine(value);
                        }
                    }, () => Console.WriteLine("Skip Completed"));
        }





        //Overlapping buffers by time

        public void OverlappingByTime()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);

            var overlapped = source.Buffer(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(1));
            overlapped.Subscribe(buffer =>
            {
                Console.WriteLine("--Overlap Buffered values");
                foreach (var value in buffer)
                {
                    Console.WriteLine(value);
                }
            }, () => Console.WriteLine("Overlap Completed"));


            var standard = source.Buffer(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(3));

            standard.Subscribe(buffer =>
            {
                Console.WriteLine("--standard Buffered values");
                foreach (var value in buffer)
                {
                    Console.WriteLine(value);
                }
            }, () => Console.WriteLine("standard Completed"));



            var skipped = source.Buffer(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(5));
            skipped.Subscribe(buffer =>
                {
                    Console.WriteLine("--skipped Buffered values");
                    foreach (var value in buffer)
                    {
                        Console.WriteLine(value);
                    }
                }, () => Console.WriteLine("skipped Completed"));
        }



        /// <summary>
        /// The Delay extension method is a purely a way to time-shift an entire sequence. You can provide either a relative time the sequence should be delayed by using a TimeSpan, or an absolute point in time that the sequence should wait for using a DateTimeOffset. 
        /// </summary>
        public void DelayMethod()
        {
            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(5)
                .Timestamp();
            var delay = source.Delay(TimeSpan.FromSeconds(2));
            source.Subscribe(
                value => Console.WriteLine("source : {0}", value),
                () => Console.WriteLine("source Completed"));
            delay.Subscribe(
                value => Console.WriteLine("delay : {0}", value),
                () => Console.WriteLine("delay Completed"));
        }


        //The Sample method simply takes the last value for every specified TimeSpan
        public void SampleMethod()
        {
            var interval = Observable.Interval(TimeSpan.FromMilliseconds(150));
            interval.Sample(TimeSpan.FromSeconds(1))
                .Subscribe(Console.WriteLine);
        }


        public void TimeOutMethod()
        {
            var source = Observable.Interval(TimeSpan.FromMilliseconds(100)).Take(10)
                .Concat(Observable.Interval(TimeSpan.FromSeconds(2)));
            var timeout = source.Timeout(TimeSpan.FromSeconds(1));
            timeout.Subscribe(
                Console.WriteLine,
                Console.WriteLine,
                () => Console.WriteLine("Completed"));
        }



    }
}
