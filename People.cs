using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _11._5练习
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public static bool operator >(Person one,Person another)
        {
            return (one.Age > another.Age);
        }

        public static bool operator<=(Person one ,Person another)
        {
            return !(one > another);
        }

        public static bool operator <(Person one,Person another)
        {
            return (one.Age < another.Age);
        }

        public static bool operator>=(Person one,Person another)
        {
            return !(one < another);
        }
    }

    class People:DictionaryBase
    {
        public void Add(Person one)
        {
            Dictionary.Add(one.Name,one);
        }

        public void Remove(string name )
        {
            Dictionary.Remove(name);
        }

        public Person this[string name]
        {
            get
            {
                return (Person)Dictionary[name];
            }
            set
            {
                Dictionary[name] = value;
            }
        }

        public new IEnumerator GetEnumerator()
        {
            foreach (object person in Dictionary.Values)
                yield return (Person)person;
        }

        public People /*Person[]*/GetOldest()
        {
            Person oldestPerson = null;
            People oldestPeople = new People();
            Person currentPerson;
            foreach(DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                if (oldestPerson == null)
                {
                    oldestPerson = currentPerson;
                    oldestPeople.Add(oldestPerson);
                }
                else
                {
                    if (currentPerson > oldestPerson)
                    {
                        oldestPeople.Clear();
                        oldestPeople.Add(currentPerson);
                        oldestPerson = currentPerson;
                    }
                    else
                    {
                        if (currentPerson >= oldestPerson)  
                        { 
                            oldestPeople.Add(currentPerson);
                        }
                    }
                }
            }
            //Person[] oldestPeopleArray = new Person[oldestPeople.Count];
            //int copyIndex = 0;
            //foreach (DictionaryEntry p in oldestPeople)
            //{
            //    oldestPeopleArray[copyIndex] = p.Value as Person;
            //    copyIndex++;
            //}
            //return oldestPeopleArray;
            return oldestPeople;
        }

    }
}
