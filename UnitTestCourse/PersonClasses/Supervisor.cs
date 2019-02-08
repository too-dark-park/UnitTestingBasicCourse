using System.Collections.Generic;

namespace UnitTestCourse.PersonClasses
{
    public class Supervisor : Person
    {
        public List<Employee> Employees { get; set; }
    }
}