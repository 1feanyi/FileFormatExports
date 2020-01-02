using FileFormatExports;
using System;
using System.Collections.Generic;

namespace ConsoleSandbox
{
    public class Program
    {
        public class Person
        {
            public int Id { get; set; }
            public string SSN { get; set; }
            public string Name { get; set; }
            public DateTime DoB { get; set; }
        }

        public static void Main(string[] args)
        {
            var _data = new List<Person>();
            _data.Add(new Person() { Id = 1, SSN = "136-568-5787", Name = "John Smith", DoB = DateTime.Today });
            _data.Add(new Person() { Id = 2, SSN = "111-525-6545", Name = "Mary Jones", DoB = DateTime.Today.AddMonths(-36) });
            _data.Add(new Person() { Id = 3, SSN = "151-125-2525", Name = "Dick Wolf", DoB = DateTime.Today.AddMonths(-24) });

            FileExport.CSV(_data);
            FileExport.JSON(_data);
            FileExport.XML(_data);
        }
    }
}