using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var startTime = TimeSpan.Parse("20:00:00");
            var now = TimeSpan.Parse("18:00:00");
            Assert.AreEqual(2, GetNextInterval(startTime, now));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var startTime = TimeSpan.Parse("20:00:00");
            var now = TimeSpan.Parse("23:00:00");
            Assert.AreEqual(21, GetNextInterval(startTime, now));
        }

        protected double GetNextInterval(TimeSpan startTime, TimeSpan timeOfDay)
        {
            TimeSpan res;
            if (startTime < timeOfDay)
            {
                res = startTime.Add(new TimeSpan(24, 0, 0)).Subtract(timeOfDay);
            }
            else
            {
                res = startTime.Subtract(timeOfDay);
            }
            return res.TotalMilliseconds;
        }
    }
}
