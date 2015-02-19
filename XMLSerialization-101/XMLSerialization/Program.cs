using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\Data\\";
            string file = "myFile.xml";

            Stopwatch sw = new Stopwatch();

            sw.Start();
            MySerializableClass myObject = new MySerializableClass();
            myObject.Content = "Hello World!";
            myObject.Id = 87321;

            MySecondaryClass my2a = new MySecondaryClass(10, 4.5);
            //my2a.X = 10;
            //my2a.Y = 4.5;

            MySecondaryClass my2b = new MySecondaryClass(9, 2.5);
            //my2b.X = 9;
            //my2b.Y = 2.5;

            MySecondaryClass my2c = new MySecondaryClass(-3, 5.3);

            List<MySecondaryClass> my2 = new List<MySecondaryClass>();
            my2.Add(my2a);
            my2.Add(my2b);
            my2.Add(my2c);

            myObject.MySecondaryClass = my2;

            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(MySerializableClass));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(path+file);
            
            mySerializer.Serialize(myWriter, myObject);
            myWriter.Close();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            sw.Start();
            MySerializableClass myObject2;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer2 = new XmlSerializer(typeof(MySerializableClass));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream((path+file), FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            myObject2 = (MySerializableClass)mySerializer.Deserialize(myFileStream);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

        }
    }

    public class MySerializableClass
    {
        int id;
        string content;
        List<MySecondaryClass> mysecondaryclass;

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

        public List<MySecondaryClass> MySecondaryClass
        {
            get
            {
                return this.mysecondaryclass;
            }
            set
            {
                this.mysecondaryclass = value;
            }
        }
    }

    public class MySecondaryClass
    {
        int x;
        double y;

        public MySecondaryClass(int _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public MySecondaryClass()
        {

        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
    

