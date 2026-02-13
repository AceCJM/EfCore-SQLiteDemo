using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo
{
    public class Department
    {
        public int Id { get; set; } // map as PKEY, auto generated

        // Department Attributes
        public string Code { get; set; }
        public string DepartmentName { get; set; }

        // Navigational Property, Effectively a list of foreign keys with a natrual OOP way to interact with data relationships.
        public List<Person> People { get; set; } = new();
    }
}