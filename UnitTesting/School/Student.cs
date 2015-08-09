namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private static List<int> studentsUniqueNumbers = new List<int>();
        private int uniqueNumber;
        private string name;

        public Student(string name, int uniqueNumber)
        {
            this.UniqueNumber = uniqueNumber;
            this.Name = name;
            studentsUniqueNumbers.Add(uniqueNumber);
            School.students.Add(this);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                if (value < 10000 || 99999 < value)
                {
                    throw new IndexOutOfRangeException("Unique number is not in range!");
                }

                if (studentsUniqueNumbers.Contains(value))
                {
                    throw new ArgumentException("This unique number exists allready!");
                }

                this.uniqueNumber = value;
            }
        }
    }
}
