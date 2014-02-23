using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuffinFramework.Tests.Platforms;

namespace MuffinFramework.Tests.Services
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void LoadPlatformTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(PlatformTester)));

            // act
            client.Start();

            // assert
            Assert.IsTrue(client.PlatformLoader.OfType<PlatformTester>().Any());
        }

        [TestMethod]
        public void PlatformArgsTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(PlatformTester)));
            client.Start();

            // act
            var platform = client.PlatformLoader.Get<PlatformTester>();

            // assert
            Assert.IsNotNull(platform.TestPlatformLoader);
        }   
    }
}
