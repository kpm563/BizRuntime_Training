using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileIO_Indexers
{
	class FileInputOutput {
		public void DirectoryOperation() {
			DirectoryInfo currentDirectiory = new DirectoryInfo("."); // Get access to current directory
			DirectoryInfo myDirectory = new DirectoryInfo(@"E:\FileIO\Users");
			
			// DirectoryInfo class properties
			Console.WriteLine(myDirectory.FullName);
			Console.WriteLine(myDirectory.Name);
			Console.WriteLine(myDirectory.Parent);
			Console.WriteLine(myDirectory.Attributes);
			Console.WriteLine(myDirectory.CreationTime);

			// Creating CSharp_Data Directory
			try
			{
				if (Directory.Exists(@"E:\FileIO\Users\CSharp_Data"))
				{
					Console.WriteLine("\nCSharp_Data Directory already exists.");
					return;
				}
				DirectoryInfo directoryInfo = Directory.CreateDirectory(@"E:\FileIO\Users\CSharp_Data");
				Console.WriteLine("\nDirectory Created :: {0}", Directory.GetCreationTime(@"E:\FileIO\Users\CSharp_Data"));
			}
			catch (Exception e) {
				Console.WriteLine("\nThe process Failed : " + e.ToString());
			}

			DirectoryInfo dataDirectory = new DirectoryInfo(@"E:\FileIO\Users\CSharp_Data");

			// Creating CSharp_Data1 Directory
			try
			{
				if (Directory.Exists(@"E:\FileIO\Users\CSharp_Data1"))
				{
					Console.WriteLine("\nThe directory already exists.");
					return;
				}

				DirectoryInfo dataDirectory1 = Directory.CreateDirectory(@"E:\FileIO\Users\CSharp_Data1");
				Console.WriteLine("\nDirectory created :: {0}", Directory.GetCreationTime(@"E:\FileIO\Users\CSharp_Data1"));
			}
			catch (Exception e) {
				Console.WriteLine("\nThe process is failed :: " + e.ToString());
			}

			//Directory.Delete(@"E:\FileIO\Users\CSharp_Data");

		}

		//Copying files from CSharp_Data to CSharp_Data1
		public void CopyFiles(DirectoryInfo source , DirectoryInfo target) {
			if (source.FullName.ToLower() == target.FullName.ToLower()) {
				return;
			}

			// Create directory
			if(Directory.Exists(target.FullName) == false){
				Directory.CreateDirectory(target.FullName);
			}
			// Copying files
			foreach (FileInfo fi in source.GetFiles())
			{
				Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
			}
			// Copying Subdirectories
			foreach (DirectoryInfo diSourceDir in source.GetDirectories()) {
				DirectoryInfo nextTargetDir = target.CreateSubdirectory(diSourceDir.Name);
				CopyFiles(diSourceDir, nextTargetDir);
			}

		}

		public void FileOperations() {
			string[] customers = { "Rajesh khanna", "Mukesh Khanna", "Ramesh Khanna" };
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\testFile1.txt";

			// Writting String data into file
			File.WriteAllLines(textFilePath, customers);

			// Reading String data from file
			Console.WriteLine("\nReading data from file ::");
			foreach (string cust in File.ReadAllLines(textFilePath)) {
				Console.WriteLine($"Customer : {cust}");
			}

			// Listing all the .txt files of CSharp_Data Directory
			DirectoryInfo myDataDirectory = new DirectoryInfo(@"E:\FileIO\Users\CSharp_Data");
			FileInfo[] textFiles = myDataDirectory.GetFiles("*.*", SearchOption.AllDirectories);
			Console.WriteLine("List of files is :: "+textFiles.Length);
			foreach (FileInfo file in textFiles) {
				Console.WriteLine(file.Name + " " + file.Length);				
			}
		}

		public void FileStreams() {
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\testFile2.txt";
			
			// Creating a File using FileStream class
			FileStream fs = File.Open(textFilePath,FileMode.Create);
			string randomString = "This is a random array.This is from File stream.";
			byte[] rsByteArray = Encoding.Default.GetBytes(randomString);

			// Writting Bytes into file
			fs.Write(rsByteArray, 0, rsByteArray.Length);
			fs.Position = 0;

			// Reading Bytes from file
			byte[] fileByteArray = new byte[rsByteArray.Length];
			for (int i = 0; i < rsByteArray.Length; i++) {
				fileByteArray[i] = (byte)fs.ReadByte();
			}
			Console.WriteLine("\nFrom FileStreams() :: ");
			Console.WriteLine(Encoding.Default.GetString(fileByteArray));
			fs.Close();
		}

		public void StreamReaderWritter() {
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\testFile3.txt";
			// Writting Strings into file using streamWritter
			StreamWriter sw = File.CreateText(textFilePath);
			sw.Write("This is random...");
			sw.WriteLine("Sentence.");
			sw.WriteLine("This is another Sentence.");
			sw.Close();

			// Reading Strings from file using streamReader
			if (File.Exists(textFilePath)) {
				StreamReader sr = File.OpenText(textFilePath);
				Console.WriteLine("\nFrom StreamReaderWritter() :: ");
				Console.WriteLine("Peak ::  {0}", Convert.ToChar(sr.Peek()));
				Console.WriteLine("1st String :: {0}", sr.ReadLine());
				Console.WriteLine("Everything :: {0}", sr.ReadToEnd());
				sr.Close();
			}
		}

		public void BinaryReaderWritter() {
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\testFile4.dat";
			FileInfo datFile = new FileInfo(textFilePath);

			// Writting String into file using BinaryWritter 
			BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());
			string randomText = "This is random text.";
			int myAge = 44;
			double height = 6.44;

			bw.Write(randomText);
			bw.Write(myAge);
			bw.Write(height);
			bw.Close();

			// Reading String from file using BinaryReader 
			if (File.Exists(textFilePath)) {
				BinaryReader br = new BinaryReader(datFile.OpenRead());
				Console.WriteLine();
				Console.WriteLine("From BinaryReaderWritter() ::");
				Console.WriteLine(br.ReadString());
				Console.WriteLine(br.ReadInt32());
				Console.WriteLine(br.ReadDouble());
				br.Close();
			}
		}

		public void BinaryReaderNew() {
			const string textFilePath = @"E:\FileIO\Users\CSharp_Data\testFile4.dat";
			// Writting strings into binary file using BinaryWriter
			using (BinaryWriter writer = new BinaryWriter(File.Open(textFilePath, FileMode.Create))) {
				writer.Write("This is new BinaryWritter and BinaryReader.");
				writer.Write(4440);
				writer.Write(555.666);
				writer.Write(true);
			}

			// Reading strings From binary file using BinaryReader
			if (File.Exists(textFilePath)) {
				using (BinaryReader reader = new BinaryReader(File.Open(textFilePath, FileMode.Open)))
				{
					Console.WriteLine("\nReading data from textFile4.dat....");
					Console.WriteLine(reader.ReadString());
					Console.WriteLine(reader.ReadInt32());
					Console.WriteLine(reader.ReadDouble());
					Console.WriteLine(reader.ReadBoolean());
				}
			}
		}		
	}

	// Indexers

	class IndexerExamples {
		int EmpId;
		string EmpName, Job, DesgName, Location;
		double Salary;

		public IndexerExamples(int EmpId, string EmpName, string Job, string Location, double Salary, string DesgName) {
			this.EmpId = EmpId;
			this.EmpName = EmpName;
			this.Job = Job;
			this.Location = Location;
			this.Salary = Salary;
			this.DesgName = DesgName;
		}

		public object this[int index] {
			get {
				if (index == 1)
					return EmpId;
				else if (index == 2)
					return EmpName;
				else if (index == 3)
					return Job;
				else if (index == 4)
					return Location;
				else if (index == 5)
					return Salary;
				else if (index == 6)
					return DesgName;
				else
					return null;
			}
			set {
				if (index == 1)
					EmpId = (int)value;
				else if (index == 2)
					EmpName = (string)value;
				else if (index == 3)
					Job = (string)value;
				else if (index == 4)
					Location = (string)value;
				else if (index == 5)
					Salary = (double)value;
				else if (index == 6)
					DesgName = (string)value;
			}			 
		}

		public object this[string name]
		{
			get
			{
				if (name.ToLower() == "EmpId".ToLower())
					return EmpId;
				else if (name.ToLower() == "EmpName".ToLower())
					return EmpName;
				else if (name.ToLower() == "Job".ToLower())
					return Job;
				else if (name.ToLower() == "Location".ToLower())
					return Location;
				else if (name.ToLower() == "Salary".ToLower())
					return Salary;
				else if (name.ToLower() == "DesgName".ToLower())
					return DesgName;
				else
					return null;
			}
			set
			{
				if (name.ToLower() == "EmpId".ToLower())
					EmpId = (int)value;
				else if (name.ToLower() == "EmpName".ToLower())
					EmpName = (string)value;
				else if (name.ToLower() == "Job".ToLower())
					Job = (string)value;
				else if (name.ToLower() == "Location".ToLower())
					Location = (string)value;
				else if (name.ToLower() == "Salary".ToLower())
					Salary = (double)value;
				else if (name.ToLower() == "DesgName".ToLower())
					DesgName = (string)value;
			}

		}
	}

	// Indexer in Interface 

	public interface ISomeInterface {
		//indexer declaration
		int this[int index] {
			get;
			set;
		}
	}

	class IndexerClass : ISomeInterface
	{
		private int[] arr = new int[100];
		public int this[int index] {
			get {
				return arr[index];
			}
			set {
				arr[index] = value;
			}
		}
	}

	// Serialization
	[Serializable]
	class SerializableExample {
		public int SRollNo;
		public string SName;
		public string SAddress;
		public int SMarks;

		public SerializableExample(int SRollNo, string SName, string SAddress, int SMarks) {
			this.SRollNo = SRollNo;
			this.SName = SName;
			this.SAddress = SAddress;
			this.SMarks = SMarks;
		}		
	}

	[Serializable()]
	public class Animal : ISerializable {
		public string Name { get; set; }
		public double Weight { get; set; }
		public double Height { get; set; }

		public Animal() { }
		public Animal(string Name = "No Name", double Weight = 0.0, double Height = 0.0 ) {
			this.Name = Name;
			this.Weight = Weight;
			this.Height = Height;
		}

		// Serialization function
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("Weight", Weight);
			info.AddValue("Height", Height);
		}
		public void ShowData() {
			Console.WriteLine("Entered details are :: {0}, {1}, {2}.",Name, Weight, Height);
		}

		// Deserialize function
		public Animal(SerializationInfo info, StreamingContext context) {
			Name = (string)info.GetValue("Name", typeof(string));
			Weight = (double)info.GetValue("Weight", typeof(double));
			Height = (double)info.GetValue("Height", typeof(double));
		}
	}



	class Program
	{
		static void Main(string[] args)
		{
			FileInputOutput FileIOObject = new FileInputOutput();
			string diSource = @"E:\FileIO\Users\CSharp_Data";
			string diTarget = @"E:\FileIO\Users\CSharp_Data1";

			DirectoryInfo diSourceDir = new DirectoryInfo(diSource);
			DirectoryInfo diTargetDir = new DirectoryInfo(diTarget);

			FileIOObject.DirectoryOperation();
			FileIOObject.CopyFiles(diSourceDir, diTargetDir);
			FileIOObject.FileOperations();
			FileIOObject.FileStreams();
			FileIOObject.StreamReaderWritter();
			FileIOObject.BinaryReaderWritter();
			FileIOObject.BinaryReaderNew();

			IndexerExamples indexerExamples = new IndexerExamples(101, "Suresh Khana", "IT", "Mumbai", 20000.00, "Manager");
			Console.WriteLine("\nEmployee ID          :: " + indexerExamples[1]);
			Console.WriteLine("Employee Name        :: " + indexerExamples[2]);
			Console.WriteLine("Employee Job         :: " + indexerExamples[3]);
			Console.WriteLine("Employee Location    :: " + indexerExamples[4]);
			Console.WriteLine("Employee Salary      :: " + indexerExamples[5]);
			Console.WriteLine("Employee Designation :: " + indexerExamples[6]);

			indexerExamples[5] = 50000.99;
			indexerExamples[6] = "Sr. Manager";
			Console.WriteLine("\nEmployee Salary      :: " + indexerExamples[5]);
			Console.WriteLine("Employee Designation :: " + indexerExamples[6]);

			Console.WriteLine("\nEmployee ID          :: " + indexerExamples["Empid"]);
			Console.WriteLine("Employee Name        :: " + indexerExamples["EMpname"]);
			Console.WriteLine("Employee Job         :: " + indexerExamples["Job"]);
			Console.WriteLine("Employee Location    :: " + indexerExamples["Location"]);
			Console.WriteLine("Employee Salary      :: " + indexerExamples["Salary"]);
			Console.WriteLine("Employee Designation :: " + indexerExamples["Desgname"]);

			IndexerClass indexerClass = new IndexerClass();
			Random random = new Random();
			for (int i = 0; i < 10; i++)
			{
				indexerClass[i] = random.Next();
			}
			Console.WriteLine();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Element #{0} = {1}", i, indexerClass[1]);
			}

			// Serialization
			FileStream stream = new FileStream(@"E:\FileIO\Users\CSharp_Data\testFile6.txt", FileMode.OpenOrCreate);
			BinaryFormatter formatter = new BinaryFormatter();
			SerializableExample example = new SerializableExample(101, "Sachin", "Blore", 460);
			try
			{
				formatter.Serialize(stream, example);
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			finally {
				stream.Close();
				Console.WriteLine("Serialization done.");
			}

			//Deserialization
			FileStream stream1 = new FileStream(@"E:\FileIO\Users\CSharp_Data\testFile6.txt", FileMode.Open);
			BinaryFormatter formatter1 = new BinaryFormatter();
			try
			{
				SerializableExample example1 = (SerializableExample)formatter1.Deserialize(stream1);
				Console.WriteLine("Students setails :: \n");
				Console.WriteLine("Roll No :: {0}\nName :: {1}\nAddress :: {2}\nMarks :: {3}", example1.SRollNo, example1.SName, example1.SAddress, example1.SMarks);
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			finally {
				stream1.Close();
			}

			//Serialization using interface
			Animal animal = new Animal("Bowser", 45.88, 25);
			Stream st = File.Open("AnimalData.dat", FileMode.Create);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			try
			{	
				binaryFormatter.Serialize(st, animal);
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			finally {
				st.Close();
				//animal = null;
			}

			//Deserialization
			st = File.Open("AnimalData.dat", FileMode.Open);
			binaryFormatter = new BinaryFormatter();
			try
			{
				animal = (Animal)binaryFormatter.Deserialize(st);
				animal.ShowData();
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			finally {				
				st.Close();
			}
			

			// XMLSerializer
			animal.Weight = 50;
			XmlSerializer xmlSerializer = new XmlSerializer((typeof(Animal)));
			try {
				using (TextWriter tw = new StreamWriter(@"E:\FileIO\Users\CSharp_Data\testFile7.xml"))
				{
					xmlSerializer.Serialize(tw, animal);
				}
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			//animal = null;

			//Deserializer
			TextReader textReader = new StreamReader(@"E:\FileIO\Users\CSharp_Data\testFile7.xml");
			try
			{
				XmlSerializer xmlDeserializer = new XmlSerializer(typeof(Animal));
				Object obj = xmlSerializer.Deserialize(textReader);
				animal = (Animal)obj;
				animal.ShowData();
			}
			catch (SerializationException se)
			{
				Console.WriteLine("Exception in serialization :: " + se.Message);
			}
			finally {
				textReader.Close();
			}
			
			Console.WriteLine("Press any key to exit.");			
			Console.ReadKey();
		}
	}
}
