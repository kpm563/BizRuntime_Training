using System;

namespace ComapnyHierarchy
{
	class Customer {
		int _CustId;
		bool _Status;
		string _CName;
		double _Balance;

		public int CustId {
			get { return _CustId; }
		}
		public double Balance {
			get { return _Balance; }
			set { if (value > 4000) { _Balance = value; } }
		}
		public bool Status {
			get { return _Status; }
			set { _Status = value; }
		}
		public string Name {
			get { return _CName; }
			set { _CName = value; }
		}

		public Customer(int CustId, bool Status, string CName, double Balance) {
			_CustId = CustId;
			_Status = Status;
			_CName = CName;
			_Balance = Balance;
		}
	}
	
	class PropertiesExample
	{
		static void Main(string[] args) {
			Customer customer = new Customer(101, true, "Ramesh", 4000);
			Console.WriteLine("Custome id :: " + customer.CustId);
			Console.WriteLine("Customer balance :: " + customer.Balance);
			if (customer.Status)
			{
				Console.WriteLine("Customer current status : Active.");
			}
			else {
				Console.WriteLine("Customer current status : Inactive.");
			}
			Console.WriteLine("Enter new balance ::");
			customer.Balance = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Upadted balance :: " + customer.Balance);

			Console.Read();
		}
	}
}
