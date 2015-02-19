using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization_101
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\Data";
            string file = "\\myFile.bin";

            MyClass obj = new MyClass();
            obj.Id = 100;
            obj.Content = "Hello";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            SerializeObject<MyClass>((path + file), obj);

            MyClass receiveObj = DeSerializeObject<MyClass>(path+file);

            Console.WriteLine();
        }

        public static void SerializeObject<T>(string filename, T obj)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, obj);
            stream.Close();
        }

        public static T DeSerializeObject<T>(string filename)
        {
            T objectToBeDeSerialized;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objectToBeDeSerialized = (T)binaryFormatter.Deserialize(stream);
            stream.Close();
            return objectToBeDeSerialized;
        }

    }

    [Serializable]
    class MyClass
    {
        int id;
        string content;

        public MyClass()
        {

        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
    }
}
