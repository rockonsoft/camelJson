using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace core
{
    class Program
    {

        public List<Person> LoadJson(string fullFilePath)
        {
            using (StreamReader r = File.OpenText(fullFilePath))
            {
                string json = r.ReadToEnd();
                List<Person> items = JsonConvert.DeserializeObject<List<Person>>(json);
                
                return items;
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            var list  = program.LoadJson(args[0]);
            foreach(var p in list)
            {
                System.Console.WriteLine($"Title: {p.title}");
                System.Console.WriteLine($"FirstName: {p.firstName}");
                System.Console.WriteLine($"LastName: {p.lastName}");
            }




        }
    }

    public class Person{
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string title {get;set;}
    }
}
