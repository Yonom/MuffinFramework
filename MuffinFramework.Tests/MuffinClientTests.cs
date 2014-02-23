using System;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuffinFramework.Tests
{
    [TestClass]
    public class MuffinClientTests
    {
        [TestMethod]
        public void DoubleStartTest()
        {
            // arrange
            InvalidOperationException expectedException = null;
            var client = new MuffinClient(new AggregateCatalog());
            client.Start();

            // act
            try
            {
                // try to start the client a second time...
                client.Start();
            }
            catch (InvalidOperationException ex)
            {
                expectedException = ex;
            }


            // assert
            Assert.IsNotNull(expectedException);
        }
    }
}
