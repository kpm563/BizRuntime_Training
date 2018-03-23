using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace JSONProject
{
	[DataContract]
    class BlogSite
    {
		[DataMember]
		public string Name { get; private set; }
		[DataMember]
		public string Description { get; private set; }


		static void JSONSerialize() {
			BlogSite blogSite = new BlogSite()
			{
				Name = "Rajesh Khanna",
				Description = "He was the first bollywood superstar."
			};

			//Serialization using DataContractJsonSerializer
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BlogSite));
			MemoryStream stream = new MemoryStream();
			serializer.WriteObject(stream, blogSite);
			stream.Position = 0;
			StreamReader reader = new StreamReader(stream);
			string json = reader.ReadToEnd();
			Console.WriteLine("Conveted into JSON string using DataContractJsonSerializer...");
			Console.WriteLine(json);

			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONData.json";
			FileStream file = new FileStream(textFilePath, FileMode.Create);			
			StreamWriter writer = new StreamWriter(file);
			writer.WriteLine(json);
			
			writer.Close();
			file.Close();
			reader.Close();
			stream.Close();
		}


		// Desrialization using DataContractJsonSerializer.
		static void JSONDeserialize() {
			//string json = "{\"Name\":\"Rajesh Khanna\",\"Description\":\"He was the first bollywood superstar.\"}";
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONData.json";
			FileStream file = new FileStream(textFilePath, FileMode.Open);
			StreamReader reader = new StreamReader(file);
			string json = reader.ReadToEnd();

			using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(BlogSite));
				BlogSite blogSite = (BlogSite)deserializer.ReadObject(stream);
				Console.WriteLine("\nConverting JSON string into C# Object using DataContractJsonSerializer...");
				Console.WriteLine("Actor Name :: " + blogSite.Name);
				Console.WriteLine("Description :: " + blogSite.Description);
			}
			reader.Close();
			file.Close();
		}

		//Serialization using JSONDotNetSerializer
		static void JSONDotNetSerializer()
		{
			BlogSite blogSite = new BlogSite()
			{
				Name = "Akshay Kumar",
				Description = "He is the bollywood superstar."
			};

			string json = JsonConvert.SerializeObject(blogSite);
			Console.WriteLine("\nConveted into JSON string using JSONDotNetSerializer...");
			Console.WriteLine(json);

			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONDotNet.json";
			FileStream file = new FileStream(textFilePath, FileMode.Create);
			StreamWriter writer = new StreamWriter(file);
			writer.WriteLine(json);

			writer.Close();
			file.Close();
		}

		//Deserialization using JSONDotNetSerializer
		static void JSONDotNetDeserializer()
		{
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONDotNet.json";
			FileStream file = new FileStream(textFilePath, FileMode.Open);
			StreamReader reader = new StreamReader(file);
			string json = reader.ReadToEnd();

			BlogSite blogSite = JsonConvert.DeserializeObject<BlogSite>(json);

			Console.WriteLine("\nConverting JSON string into C# Object using JSONDotNetSerializer...");
			Console.WriteLine("Actor name :: " + blogSite.Name);
			Console.WriteLine("Description :: " + blogSite.Description);
		}

		//Serialization using JavaScriptSerializer
		static void JSSerializer() {
			BlogSite blogSite = new BlogSite()
			{
				Name = "Amitabh Bachchan",
				Description = "He is the bollywood legendary superstar."
			};

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			string json = serializer.Serialize(blogSite);
			Console.WriteLine("\nConveted into JSON string using JavaScriptSerializer...");
			Console.WriteLine(json);

			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONUsingJSData.json";
			FileStream file = new FileStream(textFilePath, FileMode.Create);
			StreamWriter writer = new StreamWriter(file);
			writer.WriteLine(json);

			writer.Close();
			file.Close();
		}

		//Deserialization using JavaScriptSerializer
		static void JSDeserializer() {
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\JSONUsingJSData.json";			
			FileStream file = new FileStream(textFilePath, FileMode.Open);
			StreamReader reader = new StreamReader(file);
			string json = reader.ReadToEnd();

			JavaScriptSerializer deserializer = new JavaScriptSerializer();
			BlogSite blogSite = deserializer.Deserialize<BlogSite>(json);
			string name = blogSite.Name;
			string description = blogSite.Description;

			Console.WriteLine("\nConverting JSON string into C# Object using JavaScriptSerializer...");
			Console.WriteLine("Actor name :: " + name);
			Console.WriteLine("Description :: " + description);

			reader.Close();
			file.Close();
		}		

		static void Main() {

			JSONSerialize();
			JSONDeserialize();
			//JSSerializer();
			//JSDeserializer();
			JSONDotNetSerializer();
			JSONDotNetDeserializer();

			Console.WriteLine("\nPress any key to exit.");
			Console.ReadKey();
		}
    }
}
