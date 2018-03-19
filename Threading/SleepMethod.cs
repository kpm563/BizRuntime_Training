using System;
using System.Security;
using System.Threading;

namespace ThreadingProject
{
	class SleepMethod
	{
		/// <summary>
		/// This method is providing definition for Sleep method, Which suspends execution for specific time.
		/// </summary>
		static void SleepMethod1() {
			Console.WriteLine("Thread1 started ....");
			for (int i = 0; i < 5; i++) {
				Console.WriteLine("Sleep() method ...");
				Thread.Sleep(2000);
			}
			Console.WriteLine("Thread1 quites....");
		}

		/// <summary>
		/// This is the overloaded Sleep method, which takes timespan instead of milliseconds as an argument.
		/// </summary>
		static void SleepMethod2() {
			Console.WriteLine("Thread2 started ....");
			for (int i = 0; i < 5; i++)
			{
				int hour = 0;
				int minutes = 0;
				int seconds = 2;
				Console.WriteLine("Sleep(new TimeSpan(hour,minutes,seconds) method ...");
				Thread.Sleep(new TimeSpan(hour,minutes,seconds));
			}
			Console.WriteLine("Thread2 quites....");
		}

		/// <summary>
		/// This method is providing definition for exceptions thrown by sleep method. 1. ArgumentException, 2. ThreadInterruptedException, 3. SecurityException.
		/// </summary>
		static void SleepMethod3() {
			Console.WriteLine("Thread3 started ....");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Sleep() method With try- catch ...");
				try
				{
					Thread.Sleep(2000);
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.ToString());
				}
				catch (ThreadInterruptedException tie) {
					Console.WriteLine(tie.ToString());
				}
				catch (SecurityException se) {
					Console.WriteLine(se.ToString());
				}
				
			}
			Console.WriteLine("Thread3 quites....");
		}



		static void Main() {
			Thread thread1 = new Thread(SleepMethod1);
			thread1.Start();

			Thread thread2 = new Thread(SleepMethod2);
			thread2.Start();

			Thread thread3 = new Thread(SleepMethod3);
			thread3.Start();

			Console.ReadKey();
		}
	}
}
