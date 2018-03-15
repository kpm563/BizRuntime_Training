using System;
using System.Threading;

namespace EventAndDelegate
{
	class Program
	{
		/// <summary>
		/// This is the entry point of the project, Main() method.
		/// </summary>
		static void Main(string[] args)
		{
			log4net.Config.BasicConfigurator.Configure();
			var video = new Video() { Title = "Video 1" };
			var videoEncoder = new VideoEncoder(); //Publisher
			var mailService = new MailService(); //Subscriber
			var messageService = new MessageService(); //Subscriber

			videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
			videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

			videoEncoder.Encode(video);
			Console.WriteLine("Enter any key to exit.");
			Console.ReadKey();
		}
	}

	/// <summary>
	/// This class is implementing details about video.
	/// </summary>
	class Video
	{
		public string Title { get; internal set; }
	}
	
	/// <summary>
	/// This class is proving implementation methods for encoding the video.
	/// </summary>
	class VideoEncoder
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VideoEncoder));
		public delegate void VideoEncoderEventHandler(Object source, EventArgs args);
		public event VideoEncoderEventHandler VideoEncoded;

		/// <summary>
		/// This method is going to encode the video.
		/// </summary>
		/// <param name="video">Taking the parameter as a video.</param>
		public void Encode(Video video)
		{
			log.Info("Encoding video ...");
			Thread.Sleep(4000);

			OnVideoEncoded();
		}

		protected virtual void OnVideoEncoded()
		{
			if (VideoEncoded != null)
				VideoEncoded(this, EventArgs.Empty);
		}
	}

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
			log.Info("MailService :: Sending an email...");
		}
	}

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
			log.Info("MessageService :: Sending a text message...");
		}
	}
}
