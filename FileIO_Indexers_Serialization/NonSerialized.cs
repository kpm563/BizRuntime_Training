using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ComapnyHierarchy
{
	[Serializable()]	
	public class NonSerialized
	{
		public int num;
		public string name;
		public string address;

		[XmlIgnore]
		public double height;

		[NonSerialized]		
		public double weight;




		public NonSerialized() {
			this.num = 101;
			this.name = "Ankit";
			this.address = "Blore";
			this.height = 167;
			this.weight = 85;
		}

		public void printData() {
			Console.WriteLine("Num :: " + num);
			Console.WriteLine("Name :: " + name);
			Console.WriteLine("Address :: " + address);
			Console.WriteLine("Height :: " + height);
			Console.WriteLine("weight :: " + weight);
		}
	}

	public class Program1 {
		static void Main(string[] args)
		{
			NonSerialized nonSerialized = new NonSerialized();
			Console.WriteLine("Before Serilization :: ");
			nonSerialized.printData();
			Console.WriteLine();

			//Binary Formatter - serializer
			Stream stream = File.Open(@"E:\FileIO\Users\CSharp_Data\Non.txt", FileMode.Create);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, nonSerialized);
			stream.Close();
			nonSerialized = null;

			//Binary Formatter - Deserializer
			stream = new FileStream(@"E:\FileIO\Users\CSharp_Data\Non.txt", FileMode.Open);
			binaryFormatter = new BinaryFormatter();
			nonSerialized = (NonSerialized)binaryFormatter.Deserialize(stream);
			stream.Close();

			Console.WriteLine("After Binary Serialization :: ");
			nonSerialized.printData();
			Console.WriteLine();

			// XmlSerialiser
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(NonSerialized));
			TextWriter textWriter = new StreamWriter(@"E:\FileIO\Users\CSharp_Data\NonXml.xml");
			xmlSerializer.Serialize(textWriter, nonSerialized);
			textWriter.Close();
			nonSerialized = null;

			// Deserializer
			TextReader textReader = new StreamReader(@"E:\FileIO\Users\CSharp_Data\NonXml.xml");
			xmlSerializer = new XmlSerializer(typeof(NonSerialized));
			Object obj = xmlSerializer.Deserialize(textReader);
			nonSerialized = (NonSerialized)obj;
			Console.WriteLine("After Xml Serialization :: ");
			nonSerialized.printData();
			textReader.Close();

			Console.Read();
		}
	}
}
