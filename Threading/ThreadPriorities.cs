using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class is prividing implementation of priorities of thread class.
	/// </summary>
	class ThreadPriorities
	{
		static long count1, count2, count3;
		public static void IncrementCount1() {
			while(true)
				count1 += 1;
		}

		public static void IncrementCount2() {
			while(true)
				count2 += 1;
		}

		public static void IncrementCount3()
		{
			while (true)
				count3 += 1;
		}

		static void Main() {
			Thread thread1 = new Thread(IncrementCount1);
			Thread thread2 = new Thread(IncrementCount2);
			Thread thread3 = new Thread(IncrementCount3);

			thread1.Priority = ThreadPriority.Highest;
			thread2.Priority = ThreadPriority.Lowest;
			thread3.Priority = ThreadPriority.AboveNormal;

			thread1.Start();
			thread2.Start();
			thread3.Start();

			Console.WriteLine("Main thread is going to sleep.");
			Thread.Sleep(5000);
			Console.WriteLine("Main thread woke up");

			thread1.Abort();
			thread2.Abort();
			thread3.Abort();

			thread1.Join();
			thread2.Join();
			thread3.Join();

			Console.WriteLine("Count1 :: " + count1);
			Console.WriteLine("Count2 :: " + count2);
			Console.WriteLine("Count3 :: " + count3);

			Console.ReadKey();
		}
	}
}
