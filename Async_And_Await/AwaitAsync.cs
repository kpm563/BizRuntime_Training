using System;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
	/// <summary>
	/// This class is proving method which are going to provide definition for Async and Await.
	/// </summary>
	class AwaitAsync
	{
		/// <summary>
		/// This is the entry point for this program and being used for making calls to the methods.
		/// </summary>
		/// <param name="args">The main method takes an string array as argument, we can later use that string array</param>
		static void Main(string[] args) {
			CallMethod();
			Console.ReadKey();
		}

		/// <summary>
		/// This is Async method which is being used for create a task and making call to Method3(), Which is completely depends on the execution of the method 1.
		/// </summary>
		public static async void CallMethod() {
			Task<int> task = MethodOne();
			MethodTwo();
			int count = await task;
			MethodThree(count);
		}
		
		/// <summary>
		/// This method is Async method which is being used here for performing await task.
		/// </summary>
		/// <returns>This method will be returning Task type.</returns>
		public static async Task<int> MethodOne()
		{
			int count = 0;
			await Task.Run(() => {
				for (int i = 1; i <= 100; i++) {
					Console.WriteLine("Method1");
					count += 1;
				}
			});
			return count;
		}
		
		/// <summary>
		/// This is completely independent method which has nothing to do with any of the methods in the class.
		/// </summary>
		public static void MethodTwo()
		{
			for (int i = 1; i <= 100; i++)
			{
				Console.WriteLine("Method2");
			}
		}

		/// <summary>
		/// This method is being used for count the characters read by first method and will only be  running when the Method1 got executed.
		/// </summary>
		/// <param name="count">This will be taking an int type argument which is the number of iterations performed by the method1.</param>
		public static void MethodThree(int count)
		{
			Console.WriteLine("Total count :: " + count);
		}
	}
}
