using System;
using System.Linq;
using System.Reactive.Linq;

namespace Rx.NetProject
{
    class Taming
    {
        public void SideEffects()
        {
            var letters = Observable.Range(0, 3)
                .Select(i => (char)(i + 65));
            var index = -1;
            var result = letters.Select(
                c =>
                {
                    index++;
                    return c;
                });

            result.Subscribe(
                c => Console.WriteLine("Received {0} at index {1}", c, index),
                () => Console.WriteLine("completed"));

            result.Subscribe(
                c => Console.WriteLine("Also received {0} at index {1}", c, index),
                () => Console.WriteLine("2nd completed"));
        }



        public void WithPipeLine()
        {
            var source = Observable.Range(0, 3);

            var result = source.Select(
                (idx, value) => new
                {
                    Index = idx,
                    Letter = (char)(value + 65)
                });

            result.Subscribe(
                x => Console.WriteLine("Received {0} at index {1}", x.Letter, x.Index),
                () => Console.WriteLine("completed"));

            result.Subscribe(
                x => Console.WriteLine("Also received {0} at index {1}", x.Letter, x.Index),
                () => Console.WriteLine("2nd completed"));
        }





		private static void Log(object onNextValue)
		{
			Console.WriteLine("Logging OnNext({0}) @ {1}", onNextValue, DateTime.Now);
		}
		private static void Log(Exception onErrorValue)
		{
			Console.WriteLine("Logging OnError({0}) @ {1}", onErrorValue, DateTime.Now);
		}
		private static void Log()
		{
			Console.WriteLine("Logging OnCompleted()@ {0}", DateTime.Now);
		}

		public void DoWithSideEffects(){
			var source = Observable
				.Interval(TimeSpan.FromSeconds(1))
				.Take(3);
			var result = source.Do(
				i => Log(i),
				ex => Log(ex),
				() => Log());
			result.Subscribe(
				Console.WriteLine,
				() => Console.WriteLine("completed"));
		}





		private static IObservable<long> GetNumbers()
		{
			return Observable.Interval(TimeSpan.FromMilliseconds(250))
				.Do(i => Console.WriteLine("pushing {0} from GetNumbers", i));
		}

		public void DowithoutSideEffets(){
			var source = GetNumbers();
			var result = source.Where(i => i%3 == 0)
				.Take(3)
				.Select(i => (char) (i + 65));
			result.Subscribe(
				Console.WriteLine,
				() => Console.WriteLine("completed"));
		}
	}
}
