using System;

namespace Event_Delegate
{

	/// <summary>
	/// This class is proving the implementation for the event methods which are goint to execute when event raised .
	/// </summary>
	class MessageService
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MessageService));
		/// <summary>
		/// This method is providing definition for sending an email after video encoding.
		/// </summary>	
		public void OnVideoEncoded(Object source, EventArgs args)
		{
			Console.WriteLine("Type message to send...");
			string message = Console.ReadLine();
			log.Info("MessageService :: Sending a text message...  \n" + message);
		}
	}
}
