using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuffinFramework.Muffins;

namespace MuffinFramework.Tests
{
    [TestClass]
    public class MuffinClientTests
    {
        [TestMethod]
        public void LoadMuffinTest()
        {
            var client = new MuffinClient();
            client.Start();
            client.Dispose();
        }
    }
}
