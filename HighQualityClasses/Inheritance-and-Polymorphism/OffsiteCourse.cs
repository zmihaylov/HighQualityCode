using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {

        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {

        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {

        }

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }


        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town cannot be null!");

                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                string result = base.ToString() + string.Format("; Town = {0}", this.Town) + " }";
                return result;
            }
            else
            {
                return base.ToString() + " }";
            }
        }
    }
}
