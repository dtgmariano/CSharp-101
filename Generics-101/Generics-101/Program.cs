using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Generics_101
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employer> list = new List<Employer>();
            list.Add(new Employer(1, "John", 10, 1));
            list.Add(new Employer(2, "Joey", 5, 2));
            list.Add(new Employer(3, "Christina", 5, 1));
            list.Add(new Employer(3, "Vicent", 10, 1));

            var a = Handler.Filter<Employer>(list, "jobStatus", 10);
            var b = Handler.Filter2<Employer>(list, new List<string>() { "jobStatus", "yearAtTheCompany" }, new List<object>() { 10, 1 });
            Console.WriteLine();
        }
    }


    public class Employer
    {
        public int id { get; set; }
        public string name { get; set; }
        public int jobStatus { get; set; }

        public int yearAtTheCompany { get; set; }

        public Employer()
        {

        }
        
        public Employer(int _id, string _name, int _jobStatus, int _yearAtTheCompany)
        {
            id = _id;
            name = _name;
            jobStatus = _jobStatus;
            yearAtTheCompany = _yearAtTheCompany;
        }
    }

    public static class Handler
    {
        public static List<T> Filter<T>(List<T> collection, string property, object filterValue)
        {
            var filteredCollection = new List<T>();
            foreach (var item in collection)
            {
                // To check multiple properties use,
                // item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)

                var propertyInfo =
                    item.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                    throw new NotSupportedException("property given does not exists");

                var propertyValue = propertyInfo.GetValue(item, null);
                if (propertyValue.Equals(filterValue))
                    filteredCollection.Add(item);
            }

            return filteredCollection;
        }

        public static List<T> Filter2<T>(List<T> collection, List<string> properties, List<object> filterValues)
        {
            var filteredCollection = new List<T>();
            foreach (var item in collection)
            {
                //// To check multiple properties use,
                //// item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                //// To check single property use,
                //// item.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
                properties.ForEach(x => propertyInfos.Add(item.GetType().GetProperty(x, BindingFlags.Public | BindingFlags.Instance)));

                //var propertyInfo = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

                List<object> propertyValues = new List<object>();

                //var a = propertyInfos[0].GetValue(item, null);
                propertyInfos.ForEach(x => propertyValues.Add(x.GetValue(item, null)));

                if (propertyInfos.Where(x => x == null).Count() >0)
                    throw new NotSupportedException("property given does not exists");


                if (Enumerable.SequenceEqual(propertyValues, filterValues))
                    filteredCollection.Add(item);
            }

            return filteredCollection;
        }
    }
}
