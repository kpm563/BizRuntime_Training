using System;

namespace Event_Delegate
{
	/// <summary>
	/// This class is proving the implementation for the event methods which are goint to execute when event raised .
	/// </summary>
	public class MailService
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MailService));
		/// <summary>
		/// This method is providing definition for sending an email after video encoding.
		/// </summary>
		public void OnVideoEncoded(Object source, EventArgs args)
		{
			Console.WriteLine("Type email to send...");
			string message = Console.ReadLine();
			log.Info("MailService :: Sending an email...  \n" + message);
		}
	}
}
