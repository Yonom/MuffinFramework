using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
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

        [TestMethod]
        public void Constructor1Test()
        {
            // arrange

            // act
            var client = new MuffinClient();

            // assert
            Assert.IsNotNull(client.MuffinLoader);
            Assert.IsNotNull(client.ServiceLoader);
            Assert.IsNotNull(client.PlatformLoader);

            Assert.IsNotNull(client.AggregateCatalog);
            Assert.AreEqual(1, client.AggregateCatalog.Catalogs.Count);
        }


        [TestMethod]
        public void Constructor2Test()
        {
            // arrange
            var catalog = new AggregateCatalog();

            // act
            var client = new MuffinClient(catalog);

            // assert
            Assert.IsNotNull(client.MuffinLoader);
            Assert.IsNotNull(client.ServiceLoader);
            Assert.IsNotNull(client.PlatformLoader);
            Assert.AreSame(catalog, client.AggregateCatalog);
        }


        [TestMethod]
        public void Constructor3Test()
        {
            // arrange
            var catalog1 = new TypeCatalog();
            var catalog2 = new TypeCatalog();

            // act
            var client = new MuffinClient(catalog1, catalog2);

            // assert
            Assert.IsNotNull(client.MuffinLoader);
            Assert.IsNotNull(client.ServiceLoader);
            Assert.IsNotNull(client.PlatformLoader);

            Assert.IsNotNull(client.AggregateCatalog);
            Assert.AreEqual(2, client.AggregateCatalog.Catalogs.Count);
        }

        [TestMethod]
        public void Constructor4Test()
        {
            // arrange

            // act
            var client = new MuffinClient(new ComposablePartCatalog[] {});

            // assert
            Assert.IsNotNull(client.MuffinLoader);
            Assert.IsNotNull(client.ServiceLoader);
            Assert.IsNotNull(client.PlatformLoader);

            Assert.IsNotNull(client.AggregateCatalog);
            Assert.AreEqual(0, client.AggregateCatalog.Catalogs.Count);
        }
    }
}
