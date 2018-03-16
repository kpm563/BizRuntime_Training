using System;

namespace EventExample
{	
	class Program
	{
		static void Main(string[] args)
		{
			EventMS eventMS = new EventMS();
			eventMS.MyEvent += new EventMS.MyDelegate(myEvent);

			Console.WriteLine("Please Enter message :: \n");
			string msg = Console.ReadLine();

			eventMS.OnEventRaise(msg);
			Console.ReadKey();
		}
		static void myEvent(object sender, EventMS.MyEventArgs e) {
			if (sender is EventMS) {
				EventMS eventMS = (EventMS)sender;
				Console.WriteLine("Entered message is :: " + e.message);
			}
		}
	}
}
