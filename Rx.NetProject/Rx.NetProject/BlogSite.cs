using System;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Rx.NetProject
{
    [DataContract]
    class BlogSite 
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Age { get; private set; }

        [DataMember]
        public string City { get; private set; }

        [DataMember]
        public string Country { get; private set; }


        public static void JsonSerialize()
        {
            BlogSite blogSite = new BlogSite()
            {
                Name = "Rajesh Khanna",
                Age = 23,
                City = "Mumbai",
                Country = "India"
            };

            //Serialization using DataContractJsonSerializer
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BlogSite));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, blogSite);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            Console.WriteLine("Converted into JSON string using DataContractJsonSerializer...");
            Console.WriteLine(json);

            string textFilePath = @"D:\FileIO\JSONData.json";
            FileStream file = new FileStream(textFilePath, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(json);

            writer.Close();
            file.Close();
            reader.Close();
            stream.Close();
        }

        static void WriteSequenceToConsole(IObservable<BlogSite> sequence)
        {
            sequence.Subscribe(value =>
                Console.WriteLine("Name ::" + value.Name + "\nAge :: " + value.Age + "\nCity :: " + value.City +
                                  "\nCountry :: " + value.Country));
        }

        // Desrialization using DataContractJsonSerializer.
        public static void JsonDeserialize()
        {
            string textFilePath = @"D:\FileIO\JSONData.json";
            FileStream file = new FileStream(textFilePath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string json = reader.ReadToEnd();
            
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(BlogSite));
                BlogSite blogSite = (BlogSite)deserializer.ReadObject(stream);
                Console.WriteLine("\nConverting JSON string into C# Object using Observable...");

                //Getting output on console using Observable.
                var subject = new Subject<BlogSite>();
                WriteSequenceToConsole(subject);
                subject.OnNext(blogSite);
                //subject.OnNext(blogSite);

                
                //Console.WriteLine("Actor Name :: " + blogSite.Name);
                //Console.WriteLine("Age :: " + blogSite.Age);
            }
            reader.Close();
            file.Close();
        }
    }
}
