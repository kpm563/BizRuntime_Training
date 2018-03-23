using System;
using System.Net;
using Newtonsoft.Json;

namespace JSONProject
{
    class Program
    {
		static void JsonMethod() {
			var client = new WebClient();
			var text = client.DownloadString("http://jsonplaceholder.typicode.com/posts/1");

			Posts post = JsonConvert.DeserializeObject<Posts>(text);

			Console.WriteLine("User ID :: " + post.userId);
			Console.WriteLine("ID :: " + post.id);
			Console.WriteLine("Title :: " + post.title);
			Console.WriteLine("Body :: " + post.body);

		}

		static void Main(string[] args)
        {
			JsonMethod();
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
        }
    }
	
	public class Posts
	{
		public int userId { get; set; }
		public int id { get; set; }
		public string title { get; set; }
		public string body { get; set; }
	}
}
