using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization_102
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "C:\\Users\\Daniel\\GitHub\\CSharp-101\\Serialization-101\\Serialization-101\\bin\\Debug\\Data\\myFile.bin";
            MyClass obj_receive;

            if(File.Exists(filepath))
                obj_receive = DeSerializeObject<MyClass>(filepath);
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
            try
            {
                T objectToBeDeSerialized;
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                objectToBeDeSerialized = (T)binaryFormatter.Deserialize(stream);
                stream.Close();
                return objectToBeDeSerialized;
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e);   
                throw e;
            }
            
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
