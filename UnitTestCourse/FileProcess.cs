﻿using System;
using System.IO;

namespace UnitTestCourse
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("FileName");
            }

            return File.Exists(fileName);
        }
    }
}
