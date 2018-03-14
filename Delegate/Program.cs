using System;

namespace DelegateProject
{
	/// <summary>
	/// This is delegates declaration, We can also declare this inside the class, But its preferable to declare here outside the class.
	/// </summary>	
	public delegate void AddDelegate(int x, int y);
	public delegate string SayDelegate(string str);

	public class Program
	{
		/// <summary>
		/// This method will going to add numbers whatever are passed as arguments and show as output.
		/// </summary>
		/// <param name="a">This is first parameter which must be an int type.</param>
		/// <param name="b">This is Second parameter which must be an int type.</param>
		public void Add(int a, int b) {
			Console.WriteLine(a + b);
		}

		/// <summary>
		/// This method will concatenate Hello with the arguement which will have to be provided and it will show as result.
		/// </summary>
		/// <param name="Name">This is only parameter which must be an string type.</param>
		/// <returns></returns>
		public static string SayHello(string Name) {
			return "Hello " + Name;
		}


		/// <summary>
		/// This is Main method of the class which takes only one arguement as string
		/// </summary>
		/// <param name="args">This is only parameter which must be an string type.</param>
		static void Main(string[] args)
		{
			//Logs
			log4net.Config.BasicConfigurator.Configure();
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));



			Program program = new Program();
			log.Info("Normal method call ");
			program.Add(30, 20);
			//string str = SayHello("Sachin");
			//Console.WriteLine(str);

			log.Info("Usage of delegates...");
			log.Info("Method call using delegates.");
			AddDelegate addDelegate = new AddDelegate(program.Add);
			SayDelegate sayDelegate = new SayDelegate(SayHello);

			addDelegate(50, 40);
			string str =  sayDelegate("Samir");
			Console.WriteLine(str);

			addDelegate.Invoke(89, 68);
			str = sayDelegate.Invoke("Rahul");
			Console.WriteLine(str);

			Console.Read();
		}
	}
}
