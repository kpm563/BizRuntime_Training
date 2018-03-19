using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class is prividing implementation of priorities of thread class. There are 5 priorities are defined already.. 1. Highest 2. AboveNormal 3. Normal 4. BelowNormal 5. Lowest.
	/// </summary>
	class ThreadPriorities
	{
		static long count1, count2, count3, count4, count5;
		public static void IncrementCount1() {
			while (true) {
				count1 += 1;				
			}				
		}

		public static void IncrementCount2()
		{
			while (true)
				count2 += 1;
		}

		public static void IncrementCount3()
		{
			while (true)
				count3 += 1;
		}

		public static void IncrementCount4()
		{
			while (true)
				count4 += 1;
		}

		public static void IncrementCount5()
		{
			while (true)
				count5 += 1;
		}

		static void Main() {
			Thread thread1 = new Thread(IncrementCount1);
			Thread thread2 = new Thread(IncrementCount2);
			Thread thread3 = new Thread(IncrementCount3);
			Thread thread4 = new Thread(IncrementCount4);
			Thread thread5 = new Thread(IncrementCount5);

			thread1.Priority = ThreadPriority.Highest;
			thread2.Priority = ThreadPriority.AboveNormal;
			thread3.Priority = ThreadPriority.Normal;
			thread4.Priority = ThreadPriority.BelowNormal;
			thread5.Priority = ThreadPriority.Lowest;

			thread1.Start();
			thread2.Start();
			thread3.Start();
			thread4.Start();
			thread5.Start();

			Console.WriteLine("Main thread is going to sleep.");
			Thread.Sleep(5000);
			Console.WriteLine("Main thread woke up");

			thread1.Abort();
			thread2.Abort();
			thread3.Abort();
			thread4.Abort();
			thread5.Abort();

			thread1.Join();
			thread2.Join();
			thread3.Join();
			thread4.Join();
			thread5.Join();

			Console.WriteLine("Count1 :: " + count1);
			Console.WriteLine("Count2 :: " + count2);
			Console.WriteLine("Count3 :: " + count3);
			Console.WriteLine("Count4 :: " + count4);
			Console.WriteLine("Count5 :: " + count5);

			Console.ReadKey();
		}
	}
}
