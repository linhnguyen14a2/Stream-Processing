using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAPIapp.Service;

namespace WebAPI.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestService1()
        {
            TestService ts = new TestService();
            Assert.AreEqual(ts.StreamProcessingScore("{}"), 1);
            Assert.AreEqual(ts.StreamProcessingScore("{{{}}}"), 6);
            Assert.AreEqual(ts.StreamProcessingScore("{{<ab>},{<ab>},{<ab>},{<ab>}}"), 9);
        }
    }
}
