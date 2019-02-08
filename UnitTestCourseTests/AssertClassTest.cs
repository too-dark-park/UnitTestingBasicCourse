using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTestCourse.PersonClasses;

namespace UnitTestCourseTests
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests

        [TestMethod]
        [Owner("Sarah")]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
            //Assert.AreEqual(str1, str2, false); // Case insensitive
        }

        [TestMethod]
        [Owner("Sarah")]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Johm";

            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region AreSame/NotSame Tests

        [TestMethod]
        [Owner("Sarah")]
        public void AreSameTest()
        {
            var x = new FileProcessTest();
            var y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("Sarah")]
        public void AreNotSameTest()
        {
            var x = new FileProcessTest();
            var y = new FileProcessTest();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region IsInstanceOfType Test

        [TestMethod]
        [Owner("Sarah")]
        public void IsInstanceOfTypeTest()
        {
            var manager = new PersonManager();
            Person person = manager.CreatePerson("Jane", "Doe", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Sarah")]
        public void IsNullTest()
        {
            var manager = new PersonManager();
            Person person = manager.CreatePerson("", "Doe", true);

            Assert.IsNull(person);
        }

        #endregion

        #region StringAssert

        [TestMethod]
        [Owner("Sarah")]
        public void ContainsTest()
        {
            string str1 = "The fox jumped";
            string str2 = "fox";

            StringAssert.Contains(str1, str2);
            //StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Sarah")]
        public void IsNotAllLowerCase()
        {
            Regex regex = new Regex(@"^([A-Z])+$");
            string str1 = "The fox jumped";

            StringAssert.DoesNotMatch(str1, regex);
        }

        #endregion
    }
}