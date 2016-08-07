using Microsoft.VisualStudio.TestTools.UnitTesting;
using GpaCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpaCalculator.Core.Tests
{
    [TestClass()]
    public class CourseTests
    {
        [TestMethod()]
        public void CourseTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void getWeightTest()
        {
            // Setup
            Course testCourse = new Course("CSC108H", 90);

            // Assert
            Assert.AreEqual(0.5, testCourse.Weight);
        }
    }
}