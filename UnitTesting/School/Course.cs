namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private string courseName;
        private IList<Student> studentsInCourse;
        public Course(string name)
        {
            this.CourseName = name;
            this.studentsInCourse = new List<Student>();
            School.courses.Add(this);
        }

        public IList<Student> StudentsInCourse
        {
            get
            {
                return new List<Student>(this.studentsInCourse);
            }
        }
        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Please enter course name!");
                }

                this.courseName = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.studentsInCourse.Contains(student))
            {
                throw new ArgumentException("Students is allready enrolled in this course!");
            }

            if (this.studentsInCourse.Count >= 30)
            {
                throw new ArgumentOutOfRangeException("Course is full!");
            }

            this.studentsInCourse.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (this.studentsInCourse.Contains(student))
            {
                this.studentsInCourse.Remove(student);   
            }
        }
    }
}
