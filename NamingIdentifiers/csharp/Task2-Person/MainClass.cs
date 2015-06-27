using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Person
{
    public class MainClass
    {
        public enum Gender { male, female };

        public class Person
        {
            public Gender Gender { get; set; }
            public string PersonName { get; set; }
            public int Age { get; set; }
        }

        public void CreatePerson(int personsAge)
        {
            Person person = new Person();
            person.Age = personsAge;
            if (personsAge % 2 == 0)
            {
                person.PersonName = "Batkata";
                person.Gender = Gender.male;
            }
            else
            {
                person.PersonName = "Picheto";
                person.Gender = Gender.female;
            }
        }
    }
}
