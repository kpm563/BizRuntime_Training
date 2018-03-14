using System;

namespace DelegateProject
{
	/// <summary>
	/// This is delegates declaration, We can also declare this inside the class, But its preferable to declare here outside the class.
	/// </summary>
	public delegate void RectDelegate(double Width, double Height);

	/// <summary>
	/// This is Rectangle class which is being used for performing operation on rectagle.
	/// </summary>
	public class Rectangle
	{
		/// <summary>
		/// This is a method which will take 2 double arguements and prints Area of the rectangle as output.
		/// </summary>		
		public void GetArea(double Width, double Height) {
			Console.WriteLine("Area of Rectangle :: " + Width * Height);
		}

		
		public void GetPerimeter(double Width, double Height) {
			Console.WriteLine("Perimeter of Rectangle :: " + 2 * (Width + Height));
		}

		static void Main(string[] args) {
			// Logs
			log4net.Config.BasicConfigurator.Configure();
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Rectangle));


			Rectangle rectangle = new Rectangle();
			log.Info("Getting area....");
			rectangle.GetArea(12.34, 56.78);
			log.Info("Getting perimeter....");
			rectangle.GetPerimeter(12.34, 56.78);

			log.Info("Getting area and perimeter using delegates");
			RectDelegate rectDelegate = rectangle.GetArea;
			rectDelegate += rectangle.GetPerimeter;

			Console.WriteLine();
			rectDelegate.Invoke(12.34, 56.78);

			Console.Read();
		}
	}
}
