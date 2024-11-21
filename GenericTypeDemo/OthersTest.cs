using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeDemo
{
    public class StaticDemo<T>
    {
        public static int x;
    }

    public class Base<T>
    {

    }

    public class Derived<T> : Base<T>
    {

    }

    public class Derived1: Base<string>
    {

    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int CompareTo(Person? other)
        {
            return Name.CompareTo(other?.Name);
        }
    }

    public class Person1 : IComparable
    {
        public string Name { get; set; }
        public int CompareTo(object? obj)
        {
            string name = ((Person1)obj).Name;
            return Name.CompareTo(name);
        }
    }

    //public class Shape
    //{
    //    public string Name { get; set; }
    //}

    //public class Rectangle : Shape
    //{

    //}



}
