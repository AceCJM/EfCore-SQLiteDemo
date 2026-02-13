using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo
{
    public class Person
    {
        public int Id { get; set; } // map as PKEY, auto generated

        // Person Attributes
        public string Name { get; set; }
        public int Age { get; set; }
        public int Mark { get; set; }

        // Navigational Property, Effectively a list of foreign keys with a natrual OOP way to interact with data relationships.
        public List<Department> Department { get; set; } = new();
    }
}