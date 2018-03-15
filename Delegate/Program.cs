using System;

namespace DelegateProject
{
	/// <summary>
	/// This is delegates declaration, We can also declare this inside the class, But its preferable to declare here outside the class.
	/// </summary>	
	public delegate int AddDelegate(int x, int y);
	public delegate string SayDelegate(string str);
	
	public class Program
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
		/// <summary>
		/// This method will going to add numbers whatever are passed as arguments and show as output.
		/// </summary>
		/// <param name="a">This is first parameter which must be an int type.</param>
		/// <param name="b">This is Second parameter which must be an int type.</param>
		public int Add(int a, int b) {
			return (a + b); 
		}

		/// <summary>
		/// This method will concatenate Hello with the arguement which will have to be provided and it will show as result.
		/// </summary>
		/// <param name="Name">This is only parameter which must be an string type.</param>
		/// <returns>This method is returning Hello with entered parameter.</returns>
		public static string SayHello(string Name) {
			return "Hello " + Name;
		}

		/// <summary>
		/// This is Main method of the class which takes only one arguement as string
		/// </summary>
		/// <param name="args">This is only parameter which must be an string type.</param>
		static void Main(string[] args)
		{			
			log4net.Config.BasicConfigurator.Configure();

			Program program = new Program();

			log.Info("Normal method call ");
			log.Info("Sum of the entered numbers :: " + program.Add(30, 20));
			log.Info(SayHello("Sachin"));
			Console.WriteLine();
			
			log.Info("Usage of delegates...");
			//Creating delegate instance
			AddDelegate addDelegate = new AddDelegate(program.Add);
			SayDelegate sayDelegate = new SayDelegate(SayHello);

			log.Info("Method call using delegates.");
			log.Info("Addition :: " + addDelegate(50, 40));
			log.Info(sayDelegate("Samir"));
			Console.WriteLine();

			log.Info("Add :: " + addDelegate.Invoke(89, 68));
			log.Info(sayDelegate.Invoke("Rahul"));			

			Console.Read();
		}
	}
}
