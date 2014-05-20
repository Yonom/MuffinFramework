using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuffinFramework.Tests.Services;

namespace MuffinFramework.Tests.Platforms
{
    [TestClass]
    public class PlatformTests
    {
        [TestMethod]
        public void LoadServiceTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(ServiceTester)));

            // act
            client.Start();

            // assert
            Assert.IsTrue(client.ServiceLoader.OfType<ServiceTester>().Any());
        }

        [TestMethod]
        public void ServiceArgsTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(ServiceTester)));
            client.Start();

            // act
            var service = client.ServiceLoader.Get<ServiceTester>();

            // assert
            Assert.IsNotNull(service.TestServiceLoader);
            Assert.IsNotNull(service.TestPlatformLoader);
        }
    }
}
