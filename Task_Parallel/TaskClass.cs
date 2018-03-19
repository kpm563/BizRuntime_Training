using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProject
{
	class TaskClass
	{		
		/// <summary>
		/// This method shows the varios ways to create and start a task.
		/// </summary>
		static void CreateTasks()
		{
			Console.WriteLine();
			Action<object> action = (object obj) =>
			{
				Console.WriteLine("Task = {0}, obj = {1}, Thread = {2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
			};

			//Creating a Task.
			Task task1 = new Task(action, "alpha");

			//Construct a started task.
			Task task2 = Task.Factory.StartNew(action, "beta");
			task2.Wait();

			//Launch Task1
			task1.Start();
			Console.WriteLine("Task1 has been launched. (Main Thread = {0})", Thread.CurrentThread.ManagedThreadId);

			// Wait for the task to finish.
			task1.Wait();

			// Construct a started task using Task.Run.
			string taskData = "delta";
			Task task3 = Task.Run(() =>
			{
				Console.WriteLine("Task = {0}, obj = {1}, Thread = {2}", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
			});

			// Wait for the task to finish.
			task3.Wait();

			// Construct an unstarted task
			Task task4 = new Task(action, "gamma");

			// Run it synchronously
			task4.RunSynchronously();

			// to wait for it in the event exceptions were thrown by the task.
			task4.Wait();

		}

		/// <summary>
		/// This method shows the use of wait().A call to the wait() blocks the calling thread waits until the single class instance has completed execution.
		/// </summary>
		static void WaitMethod() {
			Task taskWait = Task.Run(() => Thread.Sleep(2000));
			Console.WriteLine("taskWait status :: {0} ", taskWait.Status);
			try
			{
				taskWait.Wait();
				Console.WriteLine("taskWait status :: {0} ", taskWait.Status);
			}
			catch (AggregateException ae) {
				Console.WriteLine(ae.ToString());
			}
		}

		/// <summary>
		/// wait for all of a series of tasks to complete by calling the WaitAll method,Note that when you wait for one or more tasks to complete, any exceptions thrown in the running tasks are propagated on the thread that calls the Wait method
		/// </summary>
		static void WaitAllMethod() {
			Task[] tasks = new Task[10];
			for (int i = 0; i < 10; i++) {
				tasks[i] = Task.Run(() => Thread.Sleep(1000));
			}

			try
			{
				Task.WaitAll(tasks);
			}
			catch (AggregateException ae) {
				Console.WriteLine("One or more exception occured ::");
				foreach (var ex in ae.Flatten().InnerExceptions)
					Console.WriteLine("   {0}", ex.Message);
			}

			Console.WriteLine("Status of completed tasks :: ");
			foreach(var task in tasks)
			{
				Console.WriteLine("     Task #{0} :: {1}", task.Id, task.Status);
			}
		}

		static void Main(string[] args)
		{
			CreateTasks();
			WaitMethod();
			WaitAllMethod();

			Console.ReadKey();
		}
	}
}
