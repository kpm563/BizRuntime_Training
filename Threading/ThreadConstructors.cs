using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class provides the basic implementation of the thread constructors.
	/// </summary>
	class ThreadConstructors
	{
		static void Test() {
			for (int i = 0; i < 50; i++) {
				Console.WriteLine("Test :: " + i);
			}
		}

		static void Test(object max)
		{
			int num = Convert.ToInt32(max);
			for (int i = 0; i < num; i++)
			{
				Console.WriteLine("Test :: " + i);
			}
		}

		static void Main() {
			//ThreadStart threadStart = new ThreadStart(Test);
			//ThreadStart threadStart1 = Test;
			//ThreadStart threadStart2 = delegate () { Test(); }; // Inittialization of delegate using Anonymous method
			ThreadStart threadStart3 = () => Test(); // Inittialization of delegate using Lambda Expression

			ParameterizedThreadStart start1 = new ParameterizedThreadStart(Test);

			Thread thread = new Thread(threadStart3);
			Thread thread1 = new Thread(start1);

			thread.Start();
			thread1.Start(50);
			
			//Test();

			Console.ReadKey();
		}
	}
}
