using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProject
{
	class Cancellation
	{
		static void CancelToken()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = cancellationTokenSource.Token;

			Task task = new Task(() =>
			{
				for (int i = 1; i <= 1000000; i++)
				{
					if (token.IsCancellationRequested)
					{
						Console.WriteLine("Cancle() called.");
						return;
					}
					Console.WriteLine("Loop value {0}", i);
				}
			}, token);

			Console.WriteLine("Press any key to start task...");			
			Console.ReadKey();

			//Starting the task.
			task.Start();

			Console.WriteLine("Press any key to cancel the running task..");
			Console.ReadKey();

			Console.WriteLine("Cancelling the task....");
			cancellationTokenSource.Cancel(); // Cancel method won't cancel the task immediately.

			Console.WriteLine("Main method complete. Press any key to exit.");
			Console.ReadKey();
		}

		static void Main() {
			CancelToken();
		}
	}
}
