using Event_Delegate;
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
			Video video = new Video() { Title = "Video 1" };
			VideoEncoder videoEncoder = new VideoEncoder(); //Publisher
			MailService mailService = new MailService(); //Subscriber
			MessageService messageService = new MessageService(); //Subscriber

			videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
			videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

			videoEncoder.Encode(video);
			Console.WriteLine("Enter any key to exit.");
			Console.ReadKey();
		}
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
		/// <summary>
		/// This method is checking the event agaist a null value to ensure that the caller has registered with the event.
		/// </summary>
		protected virtual void OnVideoEncoded()
		{
			if (VideoEncoded != null)
				VideoEncoded(this, EventArgs.Empty);
		}
	}
}
