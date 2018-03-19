using System;
using System.Net;

namespace NetworkProject
{
	class ShowIP
	{		
		static void Main(string[] args)
		{
			string name = (args.Length < 1) ? Dns.GetHostName() : args[0];
			try
			{
				IPAddress[] iPAddresses = Dns.Resolve(name).AddressList;
				foreach (IPAddress address in iPAddresses)
					Console.WriteLine("{0}/{1}", name, address);
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}

			Console.ReadKey();
		}
	}
}
