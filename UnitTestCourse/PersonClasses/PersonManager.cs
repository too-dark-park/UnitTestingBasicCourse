using System.Collections.Generic;

namespace UnitTestCourse.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    person = new Supervisor();
                }
                else
                {
                    person = new Employee();
                }

                person.FirstName = first;
                person.LastName = last;
            }

            return person;
        }

        public List<Person> GetPeople()
        {
            var people = new List<Person>();

            people.Add(new Person() { FirstName = "Jane", LastName = "Doe" });
            people.Add(new Person() { FirstName = "John", LastName = "Doe" });
            people.Add(new Person() { FirstName = "Tom", LastName = "Jerry" });

            return people;
        }
    }
}