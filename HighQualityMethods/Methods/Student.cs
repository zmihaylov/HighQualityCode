namespace Methods
{
    using System;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.GetBirthDate(this);
            DateTime secondDate = this.GetBirthDate(other);
            return firstDate > secondDate;
        }

        private DateTime GetBirthDate(Student student)
        {
            if (student.OtherInfo == null)
            {
                string studentName = student.FirstName + " " + student.LastName;
                throw new ArgumentNullException(string.Format("There is no additional information for {0}!", studentName));
            }

            string studentInfo = student.OtherInfo;
            string date = studentInfo.Substring(studentInfo.Length - 10);
            DateTime studentBirthDay = DateTime.Parse(date);

            return studentBirthDay;
        }
    }
}
