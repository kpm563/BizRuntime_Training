using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class is implemanting the join method, which is available inside the Thread class.
	/// </summary>
	class JoinMethod
	{
		private static void Method1() {
			for (int i = 0; i < 25; i++) {
				Console.WriteLine("Method 1 " + i);
			}
			Console.WriteLine("Thread 1 exiting.");
		}

		private static void Method2() {
			for (int i = 0; i < 25; i++) {
				Console.WriteLine("Method 2 " + i);
			}
			Thread.Sleep(5000);
			Console.WriteLine("Thread 2 exiting.");
		}

		private static void Method3()
		{
			for (int i = 0; i < 25; i++)
			{
				Console.WriteLine("Method 3 " + i);
			}
			Console.WriteLine("Thread 3 exiting.");
		}

		static void Main()
		{
			Console.WriteLine("Main thread Started ...");
			Thread thread1 = new Thread(Method1);
			Thread thread2 = new Thread(Method2);
			Thread thread3 = new Thread(Method3);
			thread1.Start();
			thread2.Start();
			thread3.Start();

			thread1.Join(); //Parent thread will be allowed to exit only after child thread has been completed.
			thread2.Join(2000);
			thread3.Join();

			Console.WriteLine("Main thread exiting.");

			Console.ReadKey();
		}
	}
}
