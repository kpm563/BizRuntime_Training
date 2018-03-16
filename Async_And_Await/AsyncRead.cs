using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
	/// <summary>
	/// This class is provinding implementation for the Async and Await during file read operation.
	/// </summary>
	class AsyncRead
	{
		/// <summary>
		/// This is Main method of the program which is being used as the entry point for this program.
		/// </summary>
		static void Main() {
			Task task = new Task(CallMethod);
			task.Start();
			task.Wait();
			Console.ReadKey();
		}

		/// <summary>
		/// This CallMethod is b=providing definition for the reading a file and declaring a Task type variable which is later used for the count the number of characters read by StreamReader.
		/// </summary>
		static async void CallMethod() {
			string textFilePath = @"E:\FileIO\Users\AsyncAwait\Read.txt";
			Task<int> task = ReadFile(textFilePath);

			Console.WriteLine("Other Work 1");
			Console.WriteLine("Other Work 2");
			Console.WriteLine("Other Work 3");
			Console.WriteLine("Other Work 4");
			Console.WriteLine("Other Work 5");
			Console.WriteLine("Other Work 6");
			Console.WriteLine("Other Work 7");
			Console.WriteLine("Other Work 8");
			Console.WriteLine("Other Work 9");
			Console.WriteLine("Other Work 10");

			int length = await task;
			Console.WriteLine("Total length: " + length);

			Console.WriteLine("After work 1");
			Console.WriteLine("After work 2");
			Console.WriteLine("After work 3");
			Console.WriteLine("After work 4");
			Console.WriteLine("After work 5");
		}

		/// <summary>
		/// This method is being used for reading string from a file and counting the length of the strings.
		/// </summary>
		/// <param name="file">This is defining the parameter which is a string type and the complete address of the file which is presented in the disk.</param>
		/// <returns>After reading the file and performing other operations this is going to return Task type.</returns>
		static async Task<int> ReadFile(string file) {
			int length = 0;

			Console.WriteLine("File reading is starting ....");
			using (StreamReader sr = new StreamReader(file))
			{
				string s = await sr.ReadToEndAsync();
				Console.WriteLine(s);
				length = s.Length;
			}
			Console.WriteLine("File Reading completed.");
			return length;
		}
	}
}
