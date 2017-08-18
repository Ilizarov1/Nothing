using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5练习
{
    class Program
    {
        static void Main(string[] args)
        {
            Person first = new Person("A", 19);
            Person second = new Person("B", 20);
            Person third = new Person("C", 20);
            People ManyPeople = new People();
            ManyPeople.Add(first);
            ManyPeople.Add(second);
            ManyPeople.Add(third);
            People theOld = ManyPeople.GetOldest();
            //Person[] many = ManyPeople.GetOldest();
            //foreach(Person one in many)
            //{
            //    Console.WriteLine(one.Name + "  " + one.Age);
            //}
            foreach(Person one in theOld)
            {
                Console.WriteLine(one.Name + "  " + one.Age);
            }
            
            Console.ReadKey();

        }
    }
}
