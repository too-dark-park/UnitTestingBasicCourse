using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCourseTests
{
    /// <summary>
    /// Assembly Initialise and Cleanup Methods
    /// </summary>
    [TestClass]
    public class UnitTestCourseInitialisation
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            testContext.WriteLine("In the Assembly Initialise method.");
            // TODO: Create resources needed for tests
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // TODO: Cleanup resources
        }
    }
}