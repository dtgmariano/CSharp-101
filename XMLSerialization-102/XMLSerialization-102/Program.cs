using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace XMLSerialization_102
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "C:\\Users\\Daniel\\GitHub\\CSharp-101\\XMLSerialization-101\\XMLSerialization\\bin\\Debug\\myFile.xml";

            MySerializableClass myObject;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(MySerializableClass));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream(filepath, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            myObject = (MySerializableClass)mySerializer.Deserialize(myFileStream);

            Console.WriteLine();
        }
    }

    public class MySerializableClass
    {
        int id;
        string content;

        public MySerializableClass()
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
