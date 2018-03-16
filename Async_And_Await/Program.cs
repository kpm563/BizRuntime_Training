using System;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
	/// <summary>
	/// This clas is defining all the methods and providing implementations about Async and Await.
	/// </summary>
	class Program
	{
		/// <summary>
		/// This is main method used as a entry point of the program.
		/// </summary>
		/// <param name="args"> The Main() method is taking string array as argument.</param>
		static void Main(string[] args)
		{
			MethodOne();
			MethodTwo();
			Console.ReadKey();
		}

		/// <summary>
		/// This method MethodOne is providing implementation for async method.
		/// </summary>		
		public static async Task MethodOne() {
			await Task.Run(() => {
				for (int i = 1; i <= 100; i++) {
					Console.WriteLine("Method1 " + i);
				}
			});
		}

		/// <summary>
		/// This is an independent method which has nothing to do with MethodOne() in any manner.It will be going to execute independently.
		/// </summary>
		public static void MethodTwo() {
			for (int i = 1; i <= 10; i++) {
				Console.WriteLine("Method2 " + i);
			}
		}
	}
}
