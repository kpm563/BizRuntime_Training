using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
	public class EventMS
	{
		public delegate void MyDelegate(object sender, MyEventArgs e);
		public event MyDelegate MyEvent;

		public class MyEventArgs : EventArgs
		{
			public readonly string message;
			public MyEventArgs(string message)
			{
				this.message = message;
			}
		}

		public void OnEventRaise(string msg)
		{
			if (MyEvent != null)
			{
				MyEvent(this, new EventMS.MyEventArgs(msg));
			}
		}
	}
}
