using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
	class AsyncAwait
	{
		private static async void Mehtod1() {
			int value = await Method2();
			Console.WriteLine("Output of method1 is :: " + value);
		}

		private static Task<int> Method2() {
			return Task.Run(() =>
			{
				Thread.Sleep(5000);
				return 1;
			});
		}

		static void Main() {
			Console.WriteLine("Program execution begins....");
			Mehtod1();

			for (int i =1 ; i < 6; i++) {
				Console.WriteLine("For loop" + i);				
			}

			Console.WriteLine("End of program.");
			Console.ReadKey();
		}
	}
}
