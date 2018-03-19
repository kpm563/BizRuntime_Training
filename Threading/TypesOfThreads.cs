using System;
using System.Threading;

namespace ThreadingProject
{
	/// <summary>
	/// This class is providing implementation of types of thread. 1. Foreground Thread 2. Background Thread.
	/// </summary>
	class TypesOfThreads
	{
		/// <summary>
		/// This method is providing definition for Foreground thread.Which keeps running even after main thread quites.
		/// </summary>
		static void ForegroundThread()
		{
			for (int i = 0; i < 25; i++) {
				Console.WriteLine("Foreground Thread in progress....." + i);				
			}
			Thread.Sleep(3000);
			Console.WriteLine("Foreground Thread quites...");
		}

		/// <summary>
		/// This method is providing definition for background thread, which quites once the main thread quites.
		/// </summary>
		static void BackgroundThread() {
			for (int i = 0; i < 25; i++)
			{
				Console.WriteLine("Background Thread in progress....." + i);	//doubt			
			}
			Thread.Sleep(3000);
			Console.WriteLine("Background Thread quites...");
		}

		static void Main() {
			//Thread foregroundThread = new Thread(ForegroundThread);
			//foregroundThread.Start();

			Thread backgroundThread = new Thread(BackgroundThread);			
			backgroundThread.Start();
			backgroundThread.IsBackground = true;

			Console.WriteLine("Main thread quites....");

			Console.ReadKey();
		}
	}
}
