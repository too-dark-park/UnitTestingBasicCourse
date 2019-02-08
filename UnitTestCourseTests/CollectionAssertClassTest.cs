using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestCourse.PersonClasses;

namespace UnitTestCourseTests
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionsEqualWithCompareTest()
        {
            var manager = new PersonManager();
            var peopleExpected = new List<Person>();
            var peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Jane", LastName = "Doe" });
            peopleExpected.Add(new Person() { FirstName = "John", LastName = "Doe" });
            peopleExpected.Add(new Person() { FirstName = "Tom", LastName = "Jerry" });

            peopleActual = manager.GetPeople();

            Mock 

            // Fails because they are different objects
            //CollectionAssert.AreEqual(peopleExpected, peopleActual);

            // Passes regardless of order
            //CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

            //CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));

            CollectionAssert.AreEqual(peopleExpected, peopleActual, Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }
    }
}