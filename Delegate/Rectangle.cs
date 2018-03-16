using System;
using System.Collections.Generic;

namespace DelegateProject
{
	/// <summary>
	/// This is delegates declaration, We can also declare this inside the class, But its preferable to declare here outside the class. This class is also implementing a feature of delegate called multicast.
	/// </summary>
	public delegate double RectDelegate(double Width, double Height);
	public delegate string Greetings(string Name);

	/// <summary>
	/// This is Rectangle class which is being used for performing operation on rectagle.
	/// </summary>
	public class Rectangle
	{
		/// <summary>
		/// This is going to create an object of log4net and the instance of the object is "log".
		/// </summary>
		public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Rectangle));
		/// <summary>
		/// This is a method which will take 2 double arguements and returns Area of the rectangle as output.
		/// </summary>		
		public double GetArea(double Width, double Height) {
			return Width * Height;			
		}

		/// <summary>
		/// This is a method which will take 2 double arguments as parameter and returns the perimeter of the rectangle.
		/// </summary>
		/// <param name="Width">This is width argument.</param>
		/// <param name="Height">this is height argument.</param>
		public double GetPerimeter(double Width, double Height) {
			return (2 * (Width + Height));			
		}

		/// <summary>
		/// This method is implementing lambda expression.
		/// </summary>		
		public List<int> LambdaMethod()
		{
			List<int> list = new List<int>() { 11, 22, 33, 44, 55, 66, 77, 88, 99 };
			List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);			
			return evenNumbers;
		}
		
		static void Main(string[] args) {			
			log4net.Config.BasicConfigurator.Configure();
			
			Rectangle rectangle = new Rectangle();
			log.Info("Area of Rectangle :: " + rectangle.GetArea(12.34, 56.78));
			log.Info("Perimeter of the Rectangle :: " + rectangle.GetPerimeter(12.34, 56.78));

			log.Info("Getting area and perimeter using delegates");
			RectDelegate rectDelegate = rectangle.GetArea;
			rectDelegate += rectangle.GetPerimeter;
			
			//This will be calling both the methods and execute both the methods, but the proble is..it will be showing last methods result because 1st method's result is being overwritten by last method.
			log.Info("Area and Perimeter using Delegate :: " + rectDelegate.Invoke(12.34, 56.78));

			//This is anonymous method delclaration using delegate.
			Greetings greetings = delegate (string Name)
			{
				return "Hello " + Name;
			};
			log.Info(greetings.Invoke("Ramesh"));

			//Lambda Expression using delegate
			greetings = (Name) =>
			{
				return "Hello " + Name + ",  have a nice day !!!";
			};
			log.Info(greetings.Invoke("Ramesh Khanna"));

			//Lambda method call
			List<int> list = rectangle.LambdaMethod();
			foreach (int number in list) {
				log.Info(number);
			}

			Console.Read();
		}
	}
}
