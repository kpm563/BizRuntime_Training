using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class provides the implementation of threading concept, how to create a thread an how to start a thread.
	/// Thread is a lightweight process or unit. 
	/// </summary>
	class ThreadTest
	{
		static void Test1() {
			for (int i = 1; i <= 50; i++) {
				Console.WriteLine("Test 1 : " + i);
			}
			Console.WriteLine("Thread 1 exiting...");
		}

		static void Test2()
		{
			for (int i = 1; i <= 50; i++)
			{
				Console.WriteLine("Test 2 : " + i);
				if (i == 25) {
					Console.WriteLine("Thread 2 is going to sleep.");
					Thread.Sleep(10000);
					Console.WriteLine("Thread 2 woke up.");
				}				
			}
			Console.WriteLine("Thread 2 exiting...");
		}

		static void Test3()
		{
			for (int i = 1; i <= 50; i++)
			{
				Console.WriteLine("Test 3 : " + i);
			}
			Console.WriteLine("Thread 3 exiting...");
		}

		static void Main() {
			Thread thread1 = new Thread(Test1);
			Thread thread2 = new Thread(Test2);
			Thread thread3 = new Thread(Test3);

			thread1.Start(); // After invoking start method the thread will be ready to execute.
			thread2.Start();
			thread3.Start();

			Console.WriteLine("Thread Main exiting...");
			//Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
