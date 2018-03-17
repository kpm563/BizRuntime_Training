using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class is having implentation of thread and lock keyword.This keyword provide the functionality to lock the block of codes that multiple thread can not be able to execute the same.
	/// </summary>
	class ThreadLocking
	{
		/// <summary>
		/// This method is providing the implementation for the lock keyword.
		/// </summary>
		public void Method() {
			lock (this) // the lock keyword will be going to lock the block of code.
			{
				Console.Write("[CSharp is an ");
				Thread.Sleep(3000);
				Console.WriteLine("Object oriented language.]");
			}
		}

		static void Main() {
			ThreadLocking threadObject = new ThreadLocking();

			Thread thread1 = new Thread(threadObject.Method);
			Thread thread2 = new Thread(threadObject.Method);
			Thread thread3 = new Thread(threadObject.Method);

			thread1.Start();
			thread2.Start();
			thread3.Start();

			Console.ReadKey();
		}
	}
}
