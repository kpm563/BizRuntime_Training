using System;

namespace DelegateProject
{
	//public delegate double Delegate1(int x, float y, double z);
	//public delegate void Delegate2(int x, float y, double z);
	//public delegate bool Delegate3(string str);


	class DelegateTypes
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateTypes));

		//public static double AddNums1(int x, float y, double z)
		//{
		//	return x + y + z;
		//}

		//public static void AddNums2(int x, float y, double z) {
		//	log.Info(x + y + z);
		//}

		//public static bool CheckLength(string str) {
		//	if (str.Length > 3)
		//		return true;
		//	return false;
		//}



		static void Main(string[] args) {
			log4net.Config.BasicConfigurator.Configure();

			/* Delegate1 */
			Func<int, float, double, double> delegate1 = /*AddNums1*/ (x, y, z) =>
			{
				return x + y + z;
			};

			double result1 = delegate1.Invoke(100, 34.5f, 333.5);
			log.Info(result1);

			/* Delegate2 */
			Action<int, float, double> delegate2 = /*AddNums2*/ (x, y, z) =>
			{
				log.Info(x + y + z);
			};

			delegate2.Invoke(100, 34.7f, 444.5);

			/* Delegate3 */
			Predicate<string> delegate3 = /*CheckLength*/ (str) =>
			{
				if (str.Length > 3)
					return true;
				return false;
			};
			bool status = delegate3("Hello");
			log.Info(status);

			Console.ReadKey();
		}
	}
}
