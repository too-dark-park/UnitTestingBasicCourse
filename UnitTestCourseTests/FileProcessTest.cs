using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestCourse;

namespace UnitTestCourseTests
{
    [TestClass]
    public class FileProcessTest
    {
        private readonly string _badFileName = @"C:\BadFileName.bad";
        private string _goodFileName;

        #region Class Initialisation and Cleanup

        [ClassInitialize]
        public static void ClassInitialise(TestContext testContext)
        {
            testContext.WriteLine("In the Class Initialise");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        #endregion

        #region Test Initialise and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                TestContext.WriteLine("Creating the file: " + _goodFileName + "");
                File.AppendAllText(_goodFileName, "Some text");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                TestContext.WriteLine("Delete the file: " + _goodFileName + "");
                File.Delete(_goodFileName);
            }
        }

        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if filename does exist.")]
        // Descriptions not always needed if method name is descriptive enough
        [Owner("Sarah")]
        // Right click Test Explorer window and group by traits - allows you to group by owner, description etc
        [Priority(0)]
        // Can filter in command line
        [TestCategory("NoException")]
        // Useful in grouping
        [Ignore]
        // Useful to avoid commenting out
        public void FileNameDoesExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall = fileProcess.FileExists(_goodFileName);

            Assert.IsTrue(fromCall);
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fileProcess = new FileProcess();
            string fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking file: " + fileName + "");
            bool fromCall = fileProcess.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall = fileProcess.FileExists(_goodFileName);

            Assert.IsTrue(fromCall, "File DOES exist.");
        }

        [Timeout(3000)]
        // Stipulate the maximum time a the method should take to run/respond
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [TestMethod]
        [Owner("Sarah")]
        [Priority(1)]
        public void FileNameDoesNotExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(_badFileName);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fileProcess = new FileProcess();
            fileProcess.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UseTryCatch()
        {
            FileProcess fileProcess = new FileProcess();

            try
            {
                fileProcess.FileExists("");
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Call to FileExists did not throw an argument NULL exception");
        }

        public void SetGoodFileName()
        {
            _goodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_goodFileName.Contains("[AppPath]"))
            {
                _goodFileName = _goodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
