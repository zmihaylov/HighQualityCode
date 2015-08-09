namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTests
    {
        private static Random generator = new Random();
        [TestInitialize]

        [TestMethod]
        public void TestCourseConstructor()
        {
            Course programming = new Course("Programming");
            Assert.IsInstanceOfType(programming, typeof(Course));
        }

        [TestMethod]
        public void TestCoursePropertyName()
        {
            Course course = new Course("english");
            Assert.AreEqual(course.CourseName, "english");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseNameNullExeption()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void TestStudentConstructor()
        {
            Student student = new Student("Pesho", 10001);
            Assert.IsInstanceOfType(student, typeof(Student));
        }

        [TestMethod]
        public void TestStudentNameProperty()
        {
            Student pesho = new Student("Pesho", 10008);
            Assert.AreEqual(pesho.Name, "Pesho");
        }

        [TestMethod]
        public void TestStudentNumberProperty()
        {
            Student student = new Student("Pesho", 10011);
            int testNumber = 10011;
            Assert.AreEqual(student.UniqueNumber, testNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentNameNullException()
        {
            Student student = new Student("", 10100);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestStudentNumberOutOfBottomRangeException()
        {
            Student student = new Student("Pesho", 101);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestStudentNumberOutOfUpperRangeException()
        {
            Student student = new Student("Pesho", 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentNumberContainsException()
        {
            Student one = new Student("Pesho", 10001);
            Student two = new Student("Pesho", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCourseCannotHaveMoreThan30Students()
        {
            Course course = new Course("HQC");

            for (int i = 0; i < 32; i++)
            {
                course.AddStudent(new Student("Some student", 11000 + i));
            }
        }

        [TestMethod]
        public void TestAddingStudentsInCourse()
        {
            Course course = new Course("HQC");
            Student student = new Student("Pesho", 11111);
            course.AddStudent(student);
            Assert.IsTrue(course.StudentsInCourse.Contains(student));
        }

        [TestMethod]
        public void TestRemovingStudentsFromCourse()
        {
            Course course = new Course("HQC");
            Student student = new Student("Pesho", 10021);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.IsFalse(course.StudentsInCourse.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseCannotAddSameStudentTwice()
        {
            var course = new Course("HQC");
            var student = new Student("Pesho", 10001);
            course.AddStudent(student);
            course.AddStudent(student);
        }
    }
}
